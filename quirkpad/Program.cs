/*
 * Created by SharpDevelop.
 * User: cacan_000
 * Date: 2018/10/4
 * Time: PM 10:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace quirkpad
{
    /// <summary>
    /// Class with program entry point.
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        /// Program entry point.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            MainForm form = new MainForm();
            
            if (args.Length > 0) {
                if (System.IO.File.Exists(args[0])) {
                    form.OpenFile_(args[0]);
                }
            }
            
            Application.Run(form);
        }
        
    }
}
