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
using Tekla.Structures.Dialog.UIControls;
using Tekla.Structures.Dialog;

namespace RailingVN
{
    public partial class RailingUI : ApplicationFormBase
    {
        public RailingUI()
        {
            InitializeComponent();
            base.InitializeForm();
            RealTimeLogLabel.Text = RE.MaxStep.ToString();

        }
        RailingEngine RE = new RailingEngine();
        PostModel PM = new PostModel();
        InfillModel IM = new InfillModel();
        HandrailModel HM = new HandrailModel();

        private void PickButton_Click(object sender, EventArgs e) // obsolete
        {
            try
            {
                //Save user work plane
                Model CurrentModel = new Model();
                TransformationPlane userWorkPlane =
                    CurrentModel.GetWorkPlaneHandler().GetCurrentTransformationPlane();

                //Pick points
                var Picker = new Picker();
                var PickedPoints = Picker.PickPoints(Picker.PickPointEnum.PICK_POLYGON,
                    "Pick points in the model space");

                if (PickedPoints != null)
                {
                    for (int i = 0; i < PickedPoints.Count - 1; i++)
                    {
                        var StartPoint = PickedPoints[i] as T3D.Point;
                        var EndPoint = PickedPoints[i + 1] as T3D.Point;

                        var Length = Distance.PointToPoint(StartPoint, EndPoint)
                            + (double)StartOffsetNumericUpDown.Value + (double)EndOffsetNumericUpDown.Value;

                        int StepNumber;
                        StepNumber = (int)Math.Ceiling(Length / (double)MaxStepNumericUpDown.Value);
                        var Step = Length / StepNumber;

                        if (ClosestIntegerRadioButton.Checked)
                            Step = Math.Round(Step);
                        if (ToBaseOfFiveRadioButton.Checked)
                            Step = Math.Round(Step / 5) * 5;
                        if (ToBaseOfTenRadioButton.Checked)
                            Step = Math.Round(Step / 10) * 10;

                        if (ManualStepRadioButton.Checked)
                        {
                            StepNumber = (int)Math.Ceiling(Length / (double)ManualStepNumericUpDown.Value);
                            Step = (double)ManualStepNumericUpDown.Value;
                        }

                        var Leftover = Length - (Step * StepNumber);

                        #region WorkPlane

                        T3D.Vector xVector = new T3D.Vector(EndPoint.X - StartPoint.X, EndPoint.Y - StartPoint.Y,
                            EndPoint.Z - StartPoint.Z);
                        T3D.Vector yVector = xVector.Cross(new T3D.Vector(0, 0, -1));

                        CurrentModel.GetWorkPlaneHandler().
                            SetCurrentTransformationPlane(new TransformationPlane(StartPoint, xVector, yVector));

                        CurrentModel.CommitChanges(); //debug
                        #endregion

                        int insertCount = 0;
                        double insertPointOnXAxis = 0;

                        if (BothOffsetsRadioButton.Checked)
                            insertPointOnXAxis = 0 - (double)StartOffsetNumericUpDown.Value - Leftover / 2;
                        if (StartOffsetRadioButton.Checked)
                            insertPointOnXAxis = 0 - (double)StartOffsetNumericUpDown.Value - Leftover;
                        if (BothOffsetsRadioButton.Checked)
                            insertPointOnXAxis = 0 - (double)StartOffsetNumericUpDown.Value;

                        while (insertCount < StepNumber + 1) //object insertion
                        {
                            // x first step last step leftover

                            T3D.Point PointX = new T3D.Point(insertPointOnXAxis, 0);
                            T3D.Point PointY = new T3D.Point(insertPointOnXAxis, 500);
                            T3D.Point PointZ = new T3D.Point(insertPointOnXAxis, 0, 1000);

                            RailingEngine.BlackLine(PointX, PointY);
                            RailingEngine.RedLine(PointX, PointZ);

                            CurrentModel.CommitChanges();                               //debug

                            insertPointOnXAxis += Step;

                            if (BothStepsRadioButton.Checked && insertCount == 0 && ManualStepRadioButton.Checked)
                                insertPointOnXAxis -= Leftover / 2;
                            if (FirstStepRadioButton.Checked && insertCount == 0 && ManualStepRadioButton.Checked)
                                insertPointOnXAxis -= Leftover;

                            insertCount++;
                        }

                        CurrentModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(userWorkPlane);
                    }

                    //Load user work plane
                    CurrentModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(userWorkPlane);
                    CurrentModel.CommitChanges();
                }
                else
                {
                    MessageBox.Show("Operation interrupted or something went wrong, try again");
                }
            }
            catch { } //catching user interrupt exp
        }

        private void PickAndTestButton_Click(object sender, EventArgs e) // pick points button
        {
            RE.PickedPoints.Clear();
            var Picker = new Picker();
            try
            {
                var PickedPoints = Picker.PickPoints(Picker.PickPointEnum.PICK_POLYGON, "Pick points in the model space");
                for (int i = 0; i < PickedPoints.Count; i++)
                {
                    RE.PickedPoints.Add((T3D.Point)PickedPoints[i]);
                }
            }
            catch { }
        }

        private void MaxStepNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            RE.MaxStep = (double)MaxStepNumericUpDown.Value;
            RealTimeLogLabel.Text = RE.MaxStep.ToString();
        }

        private void ForceUpdateButton_Click(object sender, EventArgs e) //left side log updater
        {
            string pickedPoints = "";

            for (int i = 0; i < RE.PickedPoints.Count; i++)
            {
                pickedPoints += $"P{i}:\n X:{RE.PickedPoints[i].X} \n" +
                    $" Y:{RE.PickedPoints[i].Y} \n" +
                    $" Z:{RE.PickedPoints[i].Z}\n";
            }

            RealTimeLogLabel.Text = $"Max Step: \n {RE.MaxStep.ToString()}" +
                $"Picked points:\n {pickedPoints}";
        }

        private void EndOffsetNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            RE.EndOffset = (double)EndOffsetNumericUpDown.Value;
        }

        private void StartOffsetNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            RE.StartOffset = (double)StartOffsetNumericUpDown.Value;
        }

        private void OverrideStepNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            RE.ManualStep = (double)ManualStepNumericUpDown.Value;
        }

        private void AutoStepRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoStepRadioButton.Checked)
                RE.DividingOptions = RailingEngine.Dividing.Auto;
        }

        private void ManualStepRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ManualStepRadioButton.Checked)
                RE.DividingOptions = RailingEngine.Dividing.Manual;
        }

        private void NoRoundingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (NoRoundingRadioButton.Checked)
                RE.StepRoundingOptions = RailingEngine.StepRounding.NoRounding;
        }

        private void ClosestIntegerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ClosestIntegerRadioButton.Checked)
                RE.StepRoundingOptions = RailingEngine.StepRounding.ClosestInteger;
        }

        private void ToBaseOfFiveRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ToBaseOfFiveRadioButton.Checked)
                RE.StepRoundingOptions = RailingEngine.StepRounding.ToBaseOfFive;
        }

        private void ToBaseOfTenRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ToBaseOfTenRadioButton.Checked)
                RE.StepRoundingOptions = RailingEngine.StepRounding.ToBaseOfTen;
        }

        private void StartOffsetRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (StartOffsetRadioButton.Checked)
                RE.LeftoverOptions = RailingEngine.Leftover.StartOffset;
        }

        private void EndOffsetRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (EndOffsetRadioButton.Checked)
                RE.LeftoverOptions = RailingEngine.Leftover.EndOffset;
        }

        private void BothOffsetsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (BothOffsetsRadioButton.Checked)
                RE.LeftoverOptions = RailingEngine.Leftover.BothOffsets;
        }

        private void FirstStepRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (FirstStepRadioButton.Checked)
                RE.LeftoverOptions = RailingEngine.Leftover.FirstStep;
        }

        private void LastStepRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (LastStepRadioButton.Checked)
                RE.LeftoverOptions = RailingEngine.Leftover.LastStep;
        }

        private void BothStepsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (BothStepsRadioButton.Checked)
                RE.LeftoverOptions = RailingEngine.Leftover.BothSteps;
        }

        private void InsertRSButton_Click(object sender, EventArgs e) //insert railing button
        {
            Model CurrentModel = new Model();
            TransformationPlane userWorkPlane =
                    CurrentModel.GetWorkPlaneHandler().GetCurrentTransformationPlane();
            if (RE.PickedPoints.Count > 1)
            {
                for (int i = 0; i < RE.PickedPoints.Count - 1; i++)
                {
                    RailingSegment rs = new RailingSegment(RE.PickedPoints[i], RE.PickedPoints[i + 1], RE);
                    var StartPoint = RE.PickedPoints[i];
                    var EndPoint = RE.PickedPoints[i + 1];

                    Vector xVector = new T3D.Vector(EndPoint.X - StartPoint.X, EndPoint.Y - StartPoint.Y, EndPoint.Z - StartPoint.Z);
                    Vector yVector = xVector.Cross(new T3D.Vector(0, 0, -1));

                    CurrentModel.GetWorkPlaneHandler().
                        SetCurrentTransformationPlane(new TransformationPlane(StartPoint, xVector, yVector));
                    for (int j = 0; j < rs.InsertionPoints.Count; j++)
                    {
                        T3D.Point PointX = new T3D.Point(rs.InsertionPoints[j].X, 0);                      
                        T3D.Point PointY = new T3D.Point(rs.InsertionPoints[j].X, 500);
                        T3D.Point PointZ = new T3D.Point(rs.InsertionPoints[j].X, 0, 1000);
                        RailingEngine.BlackLine(PointX, PointY);
                        RailingEngine.RedLine(PointX, PointZ);

                        RailingEngine.InsertPost(PointX, PointZ, PM);                        
                    }
                    for (int j = 0; j < rs.InsertionPoints.Count-1; j++)
                    {
                        T3D.Point PointX = new T3D.Point(rs.InsertionPoints[j].X, 0);
                        T3D.Point NextPointX = new T3D.Point(rs.InsertionPoints[j+1].X, 0);                        
                        RailingEngine.InsertInfill(PointX, NextPointX, IM);
                    }
                   
                    CurrentModel.GetWorkPlaneHandler().
                        SetCurrentTransformationPlane(userWorkPlane);
                }
               
            }
            CurrentModel.CommitChanges();
        }

        private void PostHeightUpDownNum_ValueChanged(object sender, EventArgs e)
        {
            PM.Height = (double)PostHeightUpDownNum.Value;
        }

        private void PostPartPrefixTextBox_TextChanged(object sender, EventArgs e)
        {
            PM.PartPrefix = PostPartPrefixTextBox.Text;
        }

        private void PostAsmPrefixTextBox_TextChanged(object sender, EventArgs e)
        {
            PM.AssemblyPrefix = PostAsmPrefixTextBox.Text;
        }

        private void PostNameTextBox_TextChanged(object sender, EventArgs e)
        {
            PM.Name = PostNameTextBox.Text;
        }

        private void PostProfileTextBox_TextChanged(object sender, EventArgs e)
        {
            PM.Profile = PostProfileTextBox.Text;
        }

        private void PostMaterialTextBox_TextChanged(object sender, EventArgs e)
        {
            PM.Material = PostMaterialTextBox.Text;
        }

        private void PostFinishTextBox_TextChanged(object sender, EventArgs e)
        {
            PM.Finish = PostFinishTextBox.Text;
        }

        private void PostClassTextBox_TextChanged(object sender, EventArgs e)
        {
            PM.Class = PostClassTextBox.Text;
        }

        private void InfillHeightNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            IM.Height = (double)InfillHeightNumUpDown.Value;
        }

        private void InfillPartPrefixTextBox_TextChanged(object sender, EventArgs e)
        {
            IM.PartPrefix = InfillPartPrefixTextBox.Text;
        }

        private void InfillAsmblPrefixTextBox_TextChanged(object sender, EventArgs e)
        {
            IM.AssemblyPrefix = InfillPartPrefixTextBox.Text;
        }

        private void InfillNameTextBox_TextChanged(object sender, EventArgs e)
        {
            IM.Name = InfillNameTextBox.Text;
        }

        private void InfillProfileTextBox_TextChanged(object sender, EventArgs e)
        {
            IM.Profile = InfillProfileTextBox.Text;
        }

        private void InfillMaterialTextBox_TextChanged(object sender, EventArgs e)
        {
            IM.Material = InfillMaterialTextBox.Text;
        }

        private void InfillFinishTextBox_TextChanged(object sender, EventArgs e)
        {
            IM.Finish = InfillFinishTextBox.Text;
        }

        private void InfillClassTextBox_TextChanged(object sender, EventArgs e)
        {
            IM.Class = InfillClassTextBox.Text;
        }

        private void HandrailHeightUpDownNum_ValueChanged(object sender, EventArgs e)
        {
            HM.Height = (double)HandrailHeightUpDownNum.Value;
        }

        private void HandrailPartPrefixTextBox_TextChanged(object sender, EventArgs e)
        {
            HM.PartPrefix = HandrailPartPrefixTextBox.Text;
        }

        private void HandrailAsmPrefixTextBox_TextChanged(object sender, EventArgs e)
        {
            HM.AssemblyPrefix = HandrailAsmPrefixTextBox.Text;
        }

        private void HandrailNameTextBox_TextChanged(object sender, EventArgs e)
        {
            HM.Name = HandrailNameTextBox.Text;
        }

        private void HandrailProfileTextBox_TextChanged(object sender, EventArgs e)
        {
            HM.Profile = HandrailProfileTextBox.Text;
        }

        private void HandrailMaterialTextBox_TextChanged(object sender, EventArgs e)
        {
            HM.Material = HandrailMaterialTextBox.Text;
        }

        private void HandrailFinishTextBox_TextChanged(object sender, EventArgs e)
        {
            HM.Finish = HandrailFinishTextBox.Text;
        }

        private void HandrailClassTextBox_TextChanged(object sender, EventArgs e)
        {
            HM.Class = HandrailClassTextBox.Text;
        }

        
        private void InsertHandrailButton_Click(object sender, EventArgs e) //insert handrail button
        {
            Model CurrentModel = new Model();
            RailingEngine.InsertHandrail(RE.PickedPoints, HM);
            CurrentModel.CommitChanges();
        }




        //private void shapeCatalog1_Load(object sender, EventArgs e)
        //{
        //    ShapeCatalog shapeCatalog = new ShapeCatalog(ShapeCatalogBox.Text);
        //}
    }
}
