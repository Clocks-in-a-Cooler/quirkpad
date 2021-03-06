﻿/*
 * Created by SharpDevelop.
 * User: cacan_000
 * Date: 2018/10/4
 * Time: PM 10:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace quirkpad {
    /// <summary>
    /// static class with program entry point.
    /// handles the program
    /// has static variables that are crucial to the entire program
    /// </summary>
    public class Quirkpad {
        public static MainForm form;
        
        /// <summary>
        /// Program entry point.
        /// </summary>
        [STAThread]
        public static void Main(string[] args) {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            form = new MainForm();
            
            if (args.Length > 0) {
                if (System.IO.File.Exists(args[0])) {
                    form.OpenFile_(args[0]);
                }
            }
            
            Application.Run(form);
        }        
    }
}
