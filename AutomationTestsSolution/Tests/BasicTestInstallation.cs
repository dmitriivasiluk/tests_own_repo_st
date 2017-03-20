using System;
using System.Diagnostics;
using System.Linq;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.WindowsAPI;
using TestStack.White;
using NUnit.Framework;
using TestStack.White.UIItems.WindowItems;
using ScreenObjectsHelpers.Helpers;
using ScreenObjectsHelpers.Windows;
using ScreenObjectsHelpers.Windows.Options;
using ScreenObjectsHelpers.Windows.MenuFolder;
using ScreenObjectsHelpers.Windows.MenuFolder.ActionMenu;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Collections;
using Microsoft.Win32;
using AutomationTestsSolution.Helpers;
using System.Net;
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
            while (MainWindow == null && testCount < 30)
            {
                try
                {
                    MainWindow = Desktop.Instance.Windows().FirstOrDefault(x => x.Name == "Welcome");
                }
                catch (ElementNotAvailableException e)
                {
                    Debug.WriteLine(e);
                    MainWindow = null;
                }
                catch (NullReferenceException e)
                {
                    Debug.WriteLine(e);
                    MainWindow = null;
                }
                Thread.Sleep(1000);
                testCount++;
            }
        }

        [TearDown]
        public override void TearDown()
        {
            if (MainWindow != null)
            {
                var allChildWindow = MainWindow.ModalWindows(); 
                foreach (Window window in allChildWindow)
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


