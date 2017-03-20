using System.Linq;
using TestStack.White;
using NUnit.Framework;
using System.Threading;
using AutomationTestsSolution.Helpers;

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
                MainWindow = Desktop.Instance.Windows().FirstOrDefault(x => x.Name == "Welcome"); 
                Thread.Sleep(1000);
                testCount++;
            }
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


