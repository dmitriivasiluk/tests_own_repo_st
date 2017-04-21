using System;
using NUnit.Framework;
using ScreenObjectsHelpers.Helpers;
using ScreenObjectsHelpers.Windows.ToolbarTabs;
using System.IO;
using LibGit2Sharp;

namespace AutomationTestsSolution.Tests
{
    class ToolbarAddTabTests : BasicTest
    {
        #region Test Variables
        private string pathToTestFolder = Environment.ExpandEnvironmentVariables(ConstantsList.gitInitFolderForAddTest);
        private string pathToEmptyFolder = Environment.ExpandEnvironmentVariables(ConstantsList.emptyFolderForAddTest);
        #endregion


        [SetUp]
        public override void SetUp()
        {
            RemoveTestFolders();

            Directory.CreateDirectory(pathToTestFolder);
            Directory.CreateDirectory(pathToEmptyFolder);
            
            Repository.Init(pathToTestFolder);

            base.SetUp();           
        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();            

            RemoveTestFolders();
        }

        private void RemoveTestFolders()
        {
            Utils.RemoveDirectory(pathToTestFolder);
            Utils.RemoveDirectory(pathToEmptyFolder);
        }

        [Test]
        public void AddGitFolderValidationMessageTest()
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            AddTab addTab = mainWindow.OpenTab<AddTab>();
            var a = pathToTestFolder;
            addTab.WorkingCopyPathTextBox.Enter(a);

            Assert.AreEqual(addTab.GetGitValidationMessage(), ConstantsList.gitRepoType);
        }

        [Test]
        public void AddNotRepoFolderValidationMessageTest()
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            AddTab addTab = mainWindow.OpenTab<AddTab>();

            addTab.WorkingCopyPathTextBox.Enter(pathToEmptyFolder);

            bool isAddButtonEnabled = addTab.AddButton.Enabled;
            Assert.AreEqual(addTab.GetInvalidRepoMessage(), ConstantsList.invalidFolder);
            Assert.IsFalse(isAddButtonEnabled);
        }

        [Test]
        public void AddEmptyPathValidationMessageTest()
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            AddTab addTab = mainWindow.OpenTab<AddTab>();

            addTab.ValidateFolder();

            bool isAddButtonEnabled = addTab.AddButton.Enabled;
            Assert.AreEqual(addTab.GetEmptyPathMessage(), ConstantsList.emptyPath);
            Assert.IsFalse(isAddButtonEnabled);
        }

        [Test]
        public void CheckAddButtonEnablesWithValidGitFolderTest()
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            AddTab addTab = mainWindow.OpenTab<AddTab>();

            addTab.WorkingCopyPathTextBox.Enter(pathToTestFolder);
            addTab.ValidateFolder();

            bool isAddButtonEnabled = addTab.AddButton.Enabled;
            Assert.IsTrue(isAddButtonEnabled);
        }               
    }
}