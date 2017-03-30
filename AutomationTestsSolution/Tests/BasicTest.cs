using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using TestStack.White;
using NUnit.Framework;
using TestStack.White.UIItems.WindowItems;

namespace AutomationTestsSolution.Tests
{
    class BasicTest
    {
        private string BackupSuffix = "st_ui_test_bak";
        protected Window MainWindow;
        protected string sourceTreeExePath;
        protected string sourceTreeVersion;
        protected string sourceTreeUserConfigPath;
        protected string sourceTreeDataPath;
        protected Process sourceTreeProcess;
        private string testDataFolder;

        private readonly string sourceTreeTypeEnvVar = Environment.GetEnvironmentVariable("ST_UI_TEST_TYPE"); // "Beta", "Alpha" ....

        [SetUp]
        public virtual void SetUp()
        {
            testDataFolder = Path.Combine(TestContext.CurrentContext.TestDirectory, @"../../TestData");
            var exeAndVersion = FindSourceTree();
            sourceTreeExePath = exeAndVersion.Item1;
            sourceTreeVersion = exeAndVersion.Item2;
            sourceTreeUserConfigPath = FindSourceTreeUserConfig(sourceTreeVersion);
            
            sourceTreeDataPath = FindSourceTreeData();

            SetUserConfig(sourceTreeUserConfigPath);
            SetData(sourceTreeDataPath);

            RunSourceTree(sourceTreeExePath);

            AttachToSourceTree();
        }
       
        private void SetData(string dataFolder)
        {
            BackupFile(Path.Combine(dataFolder, "bookmarks.xml"));
            BackupFile(Path.Combine(dataFolder, "opentabs.xml"));
            BackupFile(Path.Combine(dataFolder, "accounts.json"));
            var testAccountsJson = Path.Combine(testDataFolder, "accounts.json");
            SetFile(testAccountsJson, Path.Combine(dataFolder, "accounts.json"));
        }
        
        private void SetFile(string sourceFile, string targetFile)
        {
            File.Copy(sourceFile, targetFile);
        }
        
        private void RestoreData(string dataFolder)
        {
            RestoreFile(Path.Combine(dataFolder, "bookmarks.xml"));
            RestoreFile(Path.Combine(dataFolder, "opentabs.xml"));
        }

        private void BackupFile(string fileName)
        {
            if (File.Exists(fileName + BackupSuffix))
            {
                File.Delete(fileName + BackupSuffix);
            }

            if (File.Exists(fileName))
            {
                File.Move(fileName, fileName + BackupSuffix);
            }
        }

        private void RestoreFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            if (File.Exists(fileName + BackupSuffix))
            {
                File.Move(fileName + BackupSuffix, fileName);
            }
        }

        private void SetUserConfig(string userConfig)
        {
            BackupFile(userConfig);
        }

        private void RestoreUserConfig(string userConfig)
        {
            RestoreFile(userConfig);
        }

        private string FindSourceTreeData()
        {
            return Environment.ExpandEnvironmentVariables(@"%localappdata%\Atlassian\SourceTreeBeta");
        }
      
        private string FindSourceTreeUserConfig(string version)
        {
            var sourceTreeInstallParentDir =
                Environment.ExpandEnvironmentVariables(@"%localappdata%\Atlassian");
            var userConfigDirectories = Directory.GetDirectories(sourceTreeInstallParentDir, version,
                    SearchOption.AllDirectories);
            if (userConfigDirectories.Count(d => !d.Contains("vshost")) != 1)
            {
                throw new Exception("Unexpected number of user.config folders");
            }

            Array.Sort(userConfigDirectories);
            var folder = userConfigDirectories.Last(d => !d.Contains("vshost"));
            return Path.Combine(folder, "user.config");
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

        protected void RunSourceTree(string sourceTreeExe)
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

        protected Tuple<string, string> FindSourceTree()
        {
            // Allowing Environment Variables to override defaults  lets us test against GA, Beta, Alpha with runtime changes etc.
            var sourceTreeType =  string.IsNullOrWhiteSpace(sourceTreeTypeEnvVar) ? string.Empty : sourceTreeTypeEnvVar;

            var sourceTreeInstallParentDir =
                Environment.ExpandEnvironmentVariables(@"%localappdata%\SourceTreeBeta" + sourceTreeType);

            // TODO find SourceTree
            // assumption that it is a squirrel install.
            string[] sourceTreeAppDirs = Directory.GetDirectories(sourceTreeInstallParentDir, "app-*",
                SearchOption.TopDirectoryOnly);
            Array.Sort(sourceTreeAppDirs);
            string sourceTreeAppDir = sourceTreeAppDirs.Last();
            string version = new DirectoryInfo(sourceTreeAppDir).Name.Substring("app-".Length);

            // TODO reset config to known state
            // TODO run SourceTree
            return new Tuple<string, string>(Path.Combine(sourceTreeAppDir, "SourceTree.exe"), version);
        }

        [TearDown]
        public virtual void TearDown()
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

            if (!sourceTreeProcess.HasExited)
            {
                sourceTreeProcess.CloseMainWindow();
                sourceTreeProcess.Close();
            }

            RestoreUserConfig(sourceTreeUserConfigPath);
            RestoreData(sourceTreeDataPath);
        }

    }
}
