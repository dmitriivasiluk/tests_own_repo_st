using System;
using System.Linq;
using TestStack.White;
using NUnit.Framework;
using System.Threading;
using AutomationTestsSolution.Helpers;
using System.Net;
using System.Windows.Automation;
using ScreenObjectsHelpers.Helpers;
using TestStack.White.UIItems.WindowItems;
using Debug = System.Diagnostics.Debug;

namespace AutomationTestsSolution.Tests
{
    class BasicTestInstallation : BasicTest 
    {
        /// <summary>
        /// This setup only for installation/configuration tests. Pre-condition removes user config files to return 
        /// to configuration state of SourceTree (Welcome Wizard).
        /// </summary>
        [SetUp]
        public override void SetUp()
        {
            Uninstall uninstallSourceTree = new Uninstall();
            if (uninstallSourceTree.IsExist())
            {
                uninstallSourceTree.ResetToCleanInstallState();
            }
            var exeAndVersion = FindSourceTree();
            sourceTreeExePath = exeAndVersion.Item1;
            RunSourceTree(sourceTreeExePath);
            AttachToSourceTreeInstallation();
        }

        private void AttachToSourceTreeInstallation()
        {
            MainWindow = null;
            int testCount = 0;
            MainWindow = Utills.FindNewWindow("Welcome");
        }

        [TearDown]
        public override void TearDown()
        {
            if (MainWindow != null)
            {
                var allChildWindow = MainWindow.ModalWindows(); 
                foreach (var window in allChildWindow)
                {
                    window.Close();
                }
                MainWindow.Close();
            }

            if (sourceTreeProcess.HasExited) return;
            sourceTreeProcess.CloseMainWindow();
            sourceTreeProcess.Close();
        }

    }

   

}


