using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tekla.Structures;
using Tekla.Structures.Model;
using Tekla.Structures.Geometry3d;
using T3D = Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;

namespace RailingVN
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var currentModel = new Model();
            if (!currentModel.GetConnectionStatus())
            {
                MessageBox.Show("Tekla Structures Model is not opened," +
                                    " or crashed, restart Tekla and try again");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RailingUI());

        }
    }
    public class Engine
    {

        public ArrayList PickRailingPoints()
        {
            var Picker = new Picker();
            var PickedPoints = Picker.PickPoints(Picker.PickPointEnum.PICK_POLYGON,
                "Pick points in the model space");
            return PickedPoints;
        }
        public void SaveUserWorkPlane()
        {
            //TO DO implement user work plane save to TempWorkPlane
        }


        public void BuildRailingSegment( Point startPoint, Point endPoint )
        {
            //TO DO railing constructs from start to end point
        }

    }


    public static class Enums
    {
        public enum DividingOptionsEnum
        {
            AllEqual,
            AllOverride,
            OverrideButFirst,
            OverrideButLast,
            OverrideButBoth
        }

        public enum LeftoverOptionsEnum
        {
            StartOffset,
            EndOffset,
            BothOffsets,
            FirstStep,
            LastStep,
            BothSteps
        }

        public enum StepRoundingOptionsEnum
        {
            NoRounding,
            ClosestInteger,
            ToBaseOfFive,
            ToBaseOfTen
        }
    }


}
