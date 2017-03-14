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

namespace AutomationTestsSolution.Tests
{
    class BasicTestInstallation : BasicTest 
    {
        [SetUp]
        public override void SetUp()
        {
            Uninstall uninstallSourceTree = new Uninstall();
            if (uninstallSourceTree.isExist())
            {
                uninstallSourceTree.CompletelyUninstallSourceTree(); 
            }
            DownloadActualBuildOfSourceTree();
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

        private void DownloadActualBuildOfSourceTree() {
            using (WebClient wc = new WebClient())
            {
                string rootPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, "..\\..\\"));
                string installFileInResources = Path.Combine(rootPath, @"Resources\SourceTree_Setup\install.exe");
                wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.33 Safari/537.36");
                wc.DownloadFile(@"https://downloads.atlassian.com/software/sourcetree/windows/beta/SourceTreeSetup-2.0.12-beta-001.exe", installFileInResources);
            }
        }

        private string FindSourceTreeInstall()
        {
            string rootPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, "..\\..\\"));
            string pathToInstallSourceTree = Path.Combine(rootPath, @"Resources\SourceTree_Setup\install.exe");
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


