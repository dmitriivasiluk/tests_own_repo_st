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
        private string pathToTestGitFolder = Environment.ExpandEnvironmentVariables(ConstantsList.gitInitFolderForAddTest);
        private string pathToTestHgFolder = Environment.ExpandEnvironmentVariables(ConstantsList.hgInitFolderForAddTest);
        private string pathToEmptyFolder = Environment.ExpandEnvironmentVariables(ConstantsList.emptyFolderForAddTest);
        #endregion


        [SetUp]
        public override void SetUp()
        {
            RemoveTestFolders();

            CreateTestFolders();

            Repository.Init(pathToTestGitFolder);
            MercurialWrapper.HgRun(MercurialWrapper.HgInit, pathToTestHgFolder);

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
            Utils.RemoveDirectory(pathToTestGitFolder);
            Utils.RemoveDirectory(pathToTestHgFolder);
            Utils.RemoveDirectory(pathToEmptyFolder);
        }

        private void CreateTestFolders()
        {
            Directory.CreateDirectory(pathToTestGitFolder);
            Directory.CreateDirectory(pathToTestHgFolder);
            Directory.CreateDirectory(pathToEmptyFolder);
        }

        [Test]
        public void AddGitFolderValidationMessageTest()
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            AddTab addTab = mainWindow.OpenTab<AddTab>();
            addTab.WorkingCopyPathTextBox.SetValue(pathToTestGitFolder);

            Assert.AreEqual(addTab.GetGitValidationMessage(), ConstantsList.gitRepoType);
        }

        [Test]
        public void AddHgFolderValidationMessageTest()
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            AddTab addTab = mainWindow.OpenTab<AddTab>();
            addTab.WorkingCopyPathTextBox.SetValue(pathToTestHgFolder);

            Assert.AreEqual(addTab.GetMercurialValidationMessage(), ConstantsList.mercurialRepoType);
        }

        [Test]
        public void AddNotRepoFolderValidationMessageTest()
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            AddTab addTab = mainWindow.OpenTab<AddTab>();

            addTab.WorkingCopyPathTextBox.SetValue(pathToEmptyFolder);

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

            addTab.WorkingCopyPathTextBox.SetValue(pathToTestGitFolder);
            addTab.ValidateFolder();

            bool isAddButtonEnabled = addTab.AddButton.Enabled;
            Assert.IsTrue(isAddButtonEnabled);
        }

        [Test]
        public void CheckAddButtonEnablesWithValidHgFolderTest()
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            AddTab addTab = mainWindow.OpenTab<AddTab>();

            addTab.WorkingCopyPathTextBox.SetValue(pathToTestHgFolder);
            addTab.ValidateFolder();

            bool isAddButtonEnabled = addTab.AddButton.Enabled;
            Assert.IsTrue(isAddButtonEnabled);
        }
    }
}