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
            Model CurrentModel = new Model();

            if (CurrentModel.GetConnectionStatus() != true || CurrentModel == null)
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




