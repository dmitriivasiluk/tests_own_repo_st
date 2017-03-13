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

namespace AutomationTestsSolution.Tests
{
    class BasicTestInstallation : BasicTest 
    {
        [SetUp]
        public override void SetUp()
        {
            UninstallSourceTree uninstallSourceTree = new UninstallSourceTree();
            if (uninstallSourceTree.isExist())
            {
                uninstallSourceTree.DeleteSourceTree();
            }
            var sourceTreeExePath = FindSourceTreeInstall();
            RunSourceTree(sourceTreeExePath);
            AttachToSourceTreeInstallation();
        }

        private void AttachToSourceTreeInstallation()
        {
            MainWindow = null;
            int testCount = 0;
            while (MainWindow == null && testCount < 30)
            {
                MainWindow = Desktop.Instance.Windows().FirstOrDefault(x => x.Name == "Welcome"); 
                Thread.Sleep(1000);
                testCount++;
            }
        }

        private string FindSourceTreeInstall()
        {
            string rootPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, "..\\..\\"));
            string pathToInstallSourceTree = Path.Combine(rootPath, @"Resources\SourceTree_Setup\SourceTreeSetup-2.0.12-beta-001.exe");
            return pathToInstallSourceTree;
        }

        [TearDown]
        public override void TearDown()
        {
            if (MainWindow != null)
            {
                MainWindow.Close();
            }

            if (!sourceTreeProcess.HasExited)
            {
                sourceTreeProcess.CloseMainWindow();
                sourceTreeProcess.Close();
            }
        }

    }

   

}


