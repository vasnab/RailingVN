using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tekla.Structures;
using Tekla.Structures.Model;
using Tekla.Structures.Geometry3d;
using T3D = Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;

namespace RailingVN
{
    public partial class RailingUI : Form
    {

        public RailingUI()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MaxStep_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void RailingUIForm_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void rbNoRounding_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void nudEndOffset_ValueChanged(object sender, EventArgs e)
        {

        }

        private void rbAllOverride_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbOverrideButFirst_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbOverrideButLast_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbAllEqual_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void nudMaxStep_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudStartOffset_ValueChanged(object sender, EventArgs e)
        {

        }

        private void rbStartOffset_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnPickRailingPoints_Click(object sender, EventArgs e)
        {
            //Save user work plane
            TransformationPlane userWorkPlane =
                ModelKeeper.CurrentModel.GetWorkPlaneHandler().GetCurrentTransformationPlane();

            //Pick points
            var Picker = new Picker();
            var PickedPoints = Picker.PickPoints(Picker.PickPointEnum.PICK_POLYGON,
                "Pick points in the model space");

            int PointsQty = PickedPoints.Count;

            for (int i = 0; i < PointsQty - 1; i++)
            {
                var StartPoint = PickedPoints[i] as T3D.Point;
                var EndPoint = PickedPoints[i + 1] as T3D.Point;

                double Length = Distance.PointToPoint(StartPoint, EndPoint)
                    + (double)nudStartOffset.Value + (double)nudEndOffset.Value;

                double EqualStep = Length / (Math.Ceiling(Length / (double)nudMaxStep.Value));

                T3D.Vector xVector = new T3D.Vector(EndPoint.X - StartPoint.X, EndPoint.Y - StartPoint.Y,
                    EndPoint.Z - StartPoint.Z);
                T3D.Vector yVector = xVector.Cross(new T3D.Vector(0, 0, -1));

                ModelKeeper.CurrentModel.GetWorkPlaneHandler().
                    SetCurrentTransformationPlane(new TransformationPlane(StartPoint, xVector, yVector));
                int j = 0;
                double x = 0;
                while (j < Math.Ceiling(Length / (double)nudMaxStep.Value) + 1) //object insertion
                {
                    T3D.Point lineXPoint = new T3D.Point(x, 0);
                    T3D.Point lineYpoint = new T3D.Point(x, 500);
                    T3D.Point lineZpoint = new T3D.Point(x, 0, 1000);
                    LineSegment yLineSegment = new LineSegment(lineXPoint, lineYpoint);
                    LineSegment zLineSegment = new LineSegment(lineXPoint, lineZpoint);
                    ControlLine yLine = new ControlLine(yLineSegment, false);
                    yLine.Extension = 100;
                    yLine.Color = ControlLine.ControlLineColorEnum.BLACK;
                    yLine.Insert();
                    ControlLine zLine = new ControlLine(zLineSegment, false);
                    zLine.Extension = 100;
                    zLine.Color = ControlLine.ControlLineColorEnum.RED;
                    zLine.Insert();
                    x += EqualStep;
                    j++;
                }
                ModelKeeper.CurrentModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(userWorkPlane);
            }

            //Load user work plane
            ModelKeeper.CurrentModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(userWorkPlane);
            ModelKeeper.CurrentModel.CommitChanges();
        }

        private void groupDividingOptions_Enter(object sender, EventArgs e)
        {

        }

    }
}
