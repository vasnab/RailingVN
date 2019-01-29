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
    static public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ModelKeeper.CurrentModel = new Model();
            if (!ModelKeeper.CurrentModel.GetConnectionStatus() || ModelKeeper.CurrentModel == null)
            {
                MessageBox.Show("Tekla Structures Model is not opened," +
                              " or crashed, restart Tekla and Railing app and try again");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RailingUI());

        }
    }

}

public static class ModelKeeper
{
    public static Model CurrentModel { get; set; }
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
