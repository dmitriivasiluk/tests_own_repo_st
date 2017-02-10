using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
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


namespace SourceTreeAutomation.Tests
{
    class BasicTest
    {
        protected Window MainWindow;
        protected string sourceTreeExePath;
        protected Process sourceTreeProcess;

        [SetUp]
        public void SetUp()
        {
            sourceTreeExePath = FindSourceTree();

            RunSourceTree(sourceTreeExePath);

            AttachToSourceTree();
        }

        private void AttachToSourceTree()
        {
            MainWindow = null;
            int testCount = 0;
            while (!sourceTreeProcess.HasExited && MainWindow == null && testCount < 30)
            {
                MainWindow = Desktop.Instance.Windows().FirstOrDefault(x => x.Name == "SourceTree");
                Thread.Sleep(1000);
                testCount++;
            }
        }

        private void RunSourceTree(string sourceTreeExe)
        {
            // run SourceTree
            ProcessStartInfo psi = new ProcessStartInfo(sourceTreeExe);
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.UseShellExecute = false;
            sourceTreeProcess = new Process();
            sourceTreeProcess.StartInfo = psi;

            sourceTreeProcess.Start();
        }

        private static string FindSourceTree()
        {
            var sourceTreeType = string.Empty; // "Beta", "Alpha" ....
            var sourceTreeInstallParentDir =
                Environment.ExpandEnvironmentVariables(@"%localappdata%\SourceTree" + sourceTreeType);

            // TODO find SourceTree
            // assumption that it is a squirrel install.
            string[] sourceTreeAppDirs = Directory.GetDirectories(sourceTreeInstallParentDir, "app-*",
                SearchOption.TopDirectoryOnly);
            Array.Sort(sourceTreeAppDirs);
            string sourceTreeAppDir = sourceTreeAppDirs.Last();

            // TODO reset config to known state
            // TODO run SourceTree
            return Path.Combine(sourceTreeAppDir, "SourceTree.exe");
        }

        [TearDown]
        public void TearDown()
        {
            sourceTreeProcess.CloseMainWindow();
            sourceTreeProcess.Close();
        }

        public void ifSourceTreeOpened()
        {

        }
    }
}
