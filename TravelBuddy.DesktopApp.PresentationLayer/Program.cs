﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelBuddy.BaseLib;
using TravelBuddy.DAL;
using TravelBuddy.DAL.Repositories;
using TravelBuddy.DesktopApp.Controllers;
using TravelBuddy.Models.Repositories;

namespace TravelBuddy.DesktopApp.PresentationLayer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IWindowFormsFactory formsFactory = new WindowFormsFactory();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainController = new MainFormController(formsFactory);

            Application.Run(new Login(mainController));
        }
    }
}
