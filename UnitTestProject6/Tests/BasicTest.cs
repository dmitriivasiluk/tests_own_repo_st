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
        private Process sourceTreeProcess;

        [SetUp]
        public void SetUp()
        {
            var sourceTreeType = string.Empty; // "Beta", "Alpha" ....
            var sourceTreeInstallParentDir = Environment.ExpandEnvironmentVariables(@"%localappdata%\SourceTree" + sourceTreeType);

            // TODO find SourceTree
            // assumption that it is a squirrel install.
            string[] sourceTreeAppDirs = Directory.GetDirectories(sourceTreeInstallParentDir, "app-*", SearchOption.TopDirectoryOnly);
            Array.Sort(sourceTreeAppDirs);
            string sourceTreeAppDir = sourceTreeAppDirs.Last();

            var sourceTreeInstallationFolder =
                Environment.ExpandEnvironmentVariables(@"%localappdata%\SourceTree\app-1.10.20.1");
            // TODO reset config to known state
            // TODO run SourceTree
            var sourceTreeExe = Path.Combine(sourceTreeAppDir, "SourceTree.exe");

            ProcessStartInfo psi = new ProcessStartInfo(sourceTreeExe);
            psi.WorkingDirectory = sourceTreeInstallationFolder;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.UseShellExecute = false;
            sourceTreeProcess = new Process();
            sourceTreeProcess.StartInfo = psi;

            sourceTreeProcess.Start();
            MainWindow = null;
            int testCount = 0;
            while (!sourceTreeProcess.HasExited && MainWindow == null && testCount < 30)
            {
                MainWindow = Desktop.Instance.Windows().FirstOrDefault(x => x.Name == "SourceTree");
                Thread.Sleep(1000);
                testCount++;
            }
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
