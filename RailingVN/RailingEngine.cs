using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures;
using Tekla.Structures.Model;
using Tekla.Structures.Geometry3d;
using T3D = Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;


namespace RailingVN
{
    public class RailingEngine
    {
       
        public static void BlackLine(T3D.Point startPoint, T3D.Point endPoint)
        {
            LineSegment s = new LineSegment(startPoint, endPoint);
            ControlLine l = new ControlLine(s, false);
            l.Extension = 100;
            l.Color = ControlLine.ControlLineColorEnum.BLACK;
            l.Insert();
        }
        public static void RedLine(T3D.Point startPoint, T3D.Point endPoint)
        {
            LineSegment s = new LineSegment(startPoint, endPoint);
            ControlLine l = new ControlLine(s, false);
            l.Extension = 100;
            l.Color = ControlLine.ControlLineColorEnum.RED;
            l.Insert();
        }

        public List<T3D.Point> PickedPoints { get; set; } = new List<Point>()
        {
            new T3D.Point(0,0),
            new T3D.Point(0,2000),
            new T3D.Point(4000,2000),
            new T3D.Point(4000,0)
        };
        public double StartOffset { get; set; } = -100d;
        public double EndOffset { get; set; } = -100d;
        public double ManualStep { get; set; } = 1000d;
        public double MaxStep { get; set; } = 1200d;

        public enum Dividing
        {
            Auto,
            Manual,
        }
        public enum StepRounding
        {
            NoRounding,
            ClosestInteger,
            ToBaseOfFive,
            ToBaseOfTen
        }
        public enum Leftover
        {
            StartOffset,
            EndOffset,
            BothOffsets,
            FirstStep,
            LastStep,
            BothSteps
        }
        public Dividing DividingOptions { get; set; } = Dividing.Auto;
        public StepRounding StepRoundingOptions { get; set; } = StepRounding.NoRounding;
        public Leftover LeftoverOptions { get; set; } = Leftover.BothOffsets;

        public static void InsertPost(Point startPoint, Point endPoint, PostModel pM)
        {
            endPoint.Z = pM.Height;
            Beam postBeam = new Beam(startPoint, endPoint);

            postBeam.PartNumber.Prefix = pM.PartPrefix;
            postBeam.AssemblyNumber.Prefix = pM.AssemblyPrefix;
            postBeam.Name = pM.Name;
            postBeam.Profile.ProfileString = pM.Profile;
            postBeam.Material.MaterialString = pM.Material;
            postBeam.Finish = pM.Finish;
            postBeam.Class = pM.Class;
            postBeam.Position.Depth = pM.Depth;
            postBeam.Position.Rotation = pM.Rotation;           
            postBeam.Position.Plane = pM.Plane;
            postBeam.Position.DepthOffset = pM.DepthOffset;
            postBeam.Position.RotationOffset = pM.RotationOffset;
            postBeam.Position.PlaneOffset = pM.PlaneOffset;

            bool result = false;
            result = postBeam.Insert();
        }
        public static void InsertPostCC(Point startPoint, Point endPoint, PostModel pM)
        {
            CustomPart customPart = new CustomPart(startPoint, new Point(startPoint.X, 100d, 0) );
            customPart.Name = pM.CustomComponentName;
            customPart.Number = BaseComponent.CUSTOM_OBJECT_NUMBER;
            customPart.Position.Depth = pM.Depth;
            customPart.Position.Rotation = pM.Rotation;
            customPart.Position.Plane = pM.Plane;
            customPart.Position.DepthOffset = pM.DepthOffset;
            customPart.Position.RotationOffset = pM.RotationOffset;
            customPart.Position.PlaneOffset = pM.PlaneOffset;

            bool result = false;
            result = customPart.Insert();
        }
        public static void InsertInfill(Point startPoint, Point endPoint, InfillModel iM)
        {
            startPoint.Z = iM.Height; //setting railing height test it in usage
            endPoint.Z = iM.Height;
            Beam infillBeam = new Beam(startPoint, endPoint);

            infillBeam.PartNumber.Prefix = iM.PartPrefix;
            infillBeam.AssemblyNumber.Prefix = iM.AssemblyPrefix;
            infillBeam.Name = iM.Name;
            infillBeam.Profile.ProfileString = iM.Profile;
            infillBeam.Material.MaterialString = iM.Material;
            infillBeam.Finish = iM.Finish;
            infillBeam.Class = iM.Class;
            infillBeam.Position.Depth = iM.Depth;
            infillBeam.Position.Rotation = iM.Rotation;
            infillBeam.Position.Plane = iM.Plane;            
            infillBeam.Position.DepthOffset = iM.DepthOffset;
            infillBeam.Position.RotationOffset = iM.RotationOffset;
            infillBeam.Position.PlaneOffset = iM.PlaneOffset;

            infillBeam.StartPointOffset.Dx = iM.StartPointOffsetDx;
            infillBeam.EndPointOffset.Dx = iM.EndPointOffsetDx;

            bool result = false;
            result = infillBeam.Insert();
        }

        public static void InsertInfillCC(Point startPoint, Point endPoint, InfillModel iM)
        {
            startPoint.Z = iM.Height;
            endPoint.Z = iM.Height;
            CustomPart customPartInfill = new CustomPart(startPoint, endPoint);
            customPartInfill.Name = iM.CustomComponentName;
            customPartInfill.Number = BaseComponent.CUSTOM_OBJECT_NUMBER;
            //customPartInfill.SetAttribute("H2",1435.0);
            //customPartInfill.SetAttribute("St", 110.0);
            //customPartInfill.SetAttribute("h1", 0.0);


            customPartInfill.Position.Depth = iM.Depth;
            customPartInfill.Position.Rotation = iM.Rotation;
            customPartInfill.Position.Plane = iM.Plane;
            customPartInfill.Position.DepthOffset = iM.DepthOffset;
            customPartInfill.Position.RotationOffset = iM.RotationOffset;
            customPartInfill.Position.PlaneOffset = iM.PlaneOffset;

            bool result = false;
            result = customPartInfill.Insert();            
        }
        public static void InsertHandrail(List<T3D.Point> pickedPoints, HandrailModel hM)
        {           
            PolyBeam pB = new PolyBeam();           
            foreach (var point in pickedPoints)
            {
                var tempPoint = new T3D.Point(point.X, point.Y, point.Z + hM.Height);                
                var contourPoint = new ContourPoint();
                contourPoint.SetPoint(tempPoint);
                pB.Contour.AddContourPoint(contourPoint);
            }
            
            pB.PartNumber.Prefix = hM.PartPrefix;
            pB.AssemblyNumber.Prefix = hM.AssemblyPrefix;
            pB.Name = hM.Name;
            pB.Profile.ProfileString = hM.Profile;
            pB.Material.MaterialString = hM.Material;
            pB.Finish = hM.Finish;
            pB.Class = hM.Class;
            pB.Position.Depth = hM.Depth;
            pB.Position.Rotation = hM.Rotation;
            pB.Position.Plane = hM.Plane;
            pB.Position.DepthOffset = hM.DepthOffset;
            pB.Position.RotationOffset = hM.RotationOffset;
            pB.Position.PlaneOffset = hM.PlaneOffset;

            bool result = false;
            result = pB.Insert();
        }


        public static double GetStep(double clearLength, int stepCount, StepRounding stepRounding, Dividing dividingOptions, double manualStep)
        {
            double step = clearLength / stepCount;
            switch (stepRounding)
            {
                case StepRounding.NoRounding:
                    break;
                case StepRounding.ClosestInteger:
                    step = Math.Round(step);
                    break;
                case StepRounding.ToBaseOfFive:
                    step = Math.Round(step / 5) * 5;
                    break;
                case StepRounding.ToBaseOfTen:
                    step = Math.Round(step / 10) * 10;
                    break;
            }
            if (dividingOptions == Dividing.Manual)
            {
                step = manualStep;
            }
            return step;
        }
        public static int GetStepNumber(double clearLength, double maxStep)
        {
            int stepNumber = (int)Math.Ceiling(clearLength / maxStep);
            return stepNumber;
        }
        public static double GetFirstPoint(double leftover, double startOffset, Leftover leftoverOptions)
        {
            double x = 0 - startOffset;
            if (leftoverOptions == Leftover.StartOffset)
                x += leftover;
            if (leftoverOptions == Leftover.BothOffsets)
                x += leftover / 2;

            return x;
        }
        public static double GetSecondPoint(double leftover, double firstPoint, double step, Leftover leftoverOptions)
        {
            double x = firstPoint + step;
            if (leftoverOptions == Leftover.FirstStep)
                x += leftover;
            if (leftoverOptions == Leftover.BothSteps)
                x += leftover / 2;

            return x;
        }
        public static double GetLastPoint(double leftover, double endOffset, double length, Leftover leftoverOptions)
        {
            double x = length + endOffset;
            if (leftoverOptions == Leftover.EndOffset)
                x -= leftover;
           if (leftoverOptions == Leftover.BothOffsets)
               x -= leftover/2;
            return x;
        }
    }

    public class RailingSegment
    {
        double Length;
        double ClearLength;
        double Step;
        int StepCount;
        double Leftover;
        public List<T3D.Point> InsertionPoints;

        public RailingSegment(T3D.Point start, T3D.Point end, RailingEngine re)
        {            
            Length = Distance.PointToPoint(start, end);
            ClearLength = Length + re.StartOffset + re.EndOffset;
            StepCount = RailingEngine.GetStepNumber(ClearLength, re.MaxStep);
            Step = RailingEngine.GetStep(ClearLength, StepCount, re.StepRoundingOptions, re.DividingOptions, re.ManualStep);

            Leftover = ClearLength - Step * StepCount;
            InsertionPoints = new List<T3D.Point>();
            var FirstPoint = new T3D.Point();
            var SecondPoint = new T3D.Point();
            var LastPoint = new T3D.Point();
            FirstPoint.X = RailingEngine.GetFirstPoint(Leftover, re.StartOffset, re.LeftoverOptions);
            SecondPoint.X = RailingEngine.GetSecondPoint(Leftover, FirstPoint.X, Step, re.LeftoverOptions);
            InsertionPoints.Add(FirstPoint);
            InsertionPoints.Add(SecondPoint);
            for (int i = 2; i < StepCount; i++)
            {
                InsertionPoints.Add(new Point());
                InsertionPoints[i].X = InsertionPoints[i - 1].X + Step;
            }
            LastPoint.X = RailingEngine.GetLastPoint(Leftover, re.EndOffset, Length, re.LeftoverOptions);
            InsertionPoints.Add(LastPoint);
          
        }
    }

    public class PostModel
    {
        public double Height { get; set; } = 1000d;
        public string PartPrefix { get; set; } = "w";
        public string AssemblyPrefix { get; set; } = "P";
        public string Name { get; set; } = "POST";
        public string Profile { get; set; } = "SHS45*4";
        public string Material { get; set; } = "S355J0";
        public string Finish { get; set; } = "PAINT";
        public string Class { get; set; } = "2";
        public string CustomComponentName { get; set; } = "CLMN45x55";


        public Position.DepthEnum Depth { get; set; } = Position.DepthEnum.MIDDLE;
        public Position.RotationEnum Rotation { get; set; } = Position.RotationEnum.BELOW;
        public Position.PlaneEnum Plane { get; set; } = Position.PlaneEnum.LEFT;
        public double DepthOffset { get; set; } = 0d;
        public double RotationOffset { get; set; } = 0d;
        public double PlaneOffset { get; set; } = 0d;

    }

    public class InfillModel
    {       
        public double Height { get; set; } = 1000d;
        public string PartPrefix { get; set; } = "g";
        public string AssemblyPrefix { get; set; } = "G";
        public string Name { get; set; } = "Glass";
        public string Profile { get; set; } = "8*1040";
        public string Material { get; set; } = "Glass";
        public string Finish { get; set; } = "clear";
        public string Class { get; set; } = "5";
        public string CustomComponentName { get; set; } = "spileSection";

        public Position.DepthEnum Depth { get; set; } = Position.DepthEnum.BEHIND;
        public Position.RotationEnum Rotation { get; set; } = Position.RotationEnum.BACK;
        public Position.PlaneEnum Plane { get; set; } = Position.PlaneEnum.MIDDLE;
        public double DepthOffset { get; set; } = 0d;
        public double RotationOffset { get; set; } = 0d;
        public double PlaneOffset { get; set; } = 20d;
        public double StartPointOffsetDx { get; set; } = 10d;
        public double EndPointOffsetDx { get; set; } = -10d;

    }

    public class HandrailModel
    {
        public double Height { get; set; } = 1000d;
        public string PartPrefix { get; set; } = "hr";
        public string AssemblyPrefix { get; set; } = "HR";
        public string Name { get; set; } = "HANDRAIL";
        public string Profile { get; set; } = "CHS42.4*2";
        public string Material { get; set; } = "AISI304";
        public string Finish { get; set; } = "BRUSHED";
        public string Class { get; set; } = "7";
        public Position.DepthEnum Depth { get; set; } = Position.DepthEnum.MIDDLE;
        public Position.RotationEnum Rotation { get; set; } = Position.RotationEnum.TOP;
        public Position.PlaneEnum Plane { get; set; } = Position.PlaneEnum.MIDDLE;
        public double DepthOffset { get; set; } = 0d;
        public double RotationOffset { get; set; } = 0d;
        public double PlaneOffset { get; set; } = 0d;
    }
}
