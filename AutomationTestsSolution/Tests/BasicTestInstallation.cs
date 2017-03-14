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
            var sourceTreeExePath = FindLastVersionOfSourceTreeInstall();
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

        private void DownloadActualBuildOfSourceTree(string actual_version="2.0.12-beta-001") {
            string rootPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, "..\\..\\"));
            string pathToInstallSourceTree = Path.Combine(rootPath, @"Resources\SourceTree_Setup");
            string[] filePaths = Directory.GetFiles(pathToInstallSourceTree, "*.exe", SearchOption.TopDirectoryOnly);
            foreach (string fileName in filePaths)
            {
                if (fileName.Contains(actual_version))
                {
                    return; // We have already downloaded this build of SourceTree
                }
            }
            using (WebClient webClient = new WebClient())
            {
                string fileName = $"SourceTreeSetup-{actual_version}.exe";
                string installFileInResources = Path.Combine(rootPath, @"Resources\SourceTree_Setup\" + fileName);
                webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.33 Safari/537.36");
                string linkToInstallationFile = $"https://downloads.atlassian.com/software/sourcetree/windows/beta/{fileName}";
                webClient.DownloadFile(linkToInstallationFile, installFileInResources);
            }
        }

        private string FindLastVersionOfSourceTreeInstall()
        {
            string rootPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, "..\\..\\"));
            string pathToInstallSourceTree = Path.Combine(rootPath, @"Resources\SourceTree_Setup");
            string[] filePaths = Directory.GetFiles(pathToInstallSourceTree, "*.exe", SearchOption.TopDirectoryOnly);
            string lastBuild = filePaths[filePaths.Length - 1]; // need implement catch exception in this case
            return lastBuild;
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


