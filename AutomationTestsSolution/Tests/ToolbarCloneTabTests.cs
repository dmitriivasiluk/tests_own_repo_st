//using System;
//using NUnit.Framework;
//using ScreenObjectsHelpers.Helpers;
//using ScreenObjectsHelpers.Windows.ToolbarTabs;

//namespace AutomationTestsSolution.Tests
//{
//    class ToolbarCloneTabTests : BasicTest
//    {
//        #region Test Variables
//        string gitRepoToClone = ConstantsList.gitRepoToClone;
//        string pathToClonedGitRepo = Environment.ExpandEnvironmentVariables(ConstantsList.pathToClonedGitRepo);
//        string mercurialRepoToClone = ConstantsList.mercurialRepoToClone;
//        string pathToClonedMercurialRepo = Environment.ExpandEnvironmentVariables(ConstantsList.pathToClonedMercurialRepo);
//        #endregion

//        /// <summary>        
//        /// Pre-conditions: 
//        /// Test repo folders are removed
//        /// Mercurial is installed
//        /// 2.0 Welcome - Disabled
//        /// </summary>
//        [SetUp]
//        public override void SetUp()
//        {
//            RemoveTestFolders();

//            base.SetUp();           
//        }

//        [TearDown]
//        public override void TearDown()
//        {
//            base.TearDown();

//            Utils.ThreadWait(2000);

//            RemoveTestFolders();
//        }

//        private void RemoveTestFolders()
//        {
//            Utils.RemoveDirectory(pathToClonedGitRepo);
//            Utils.RemoveDirectory(pathToClonedMercurialRepo);
//        }

//        [Test]
//        public void ValidateGitRepoLinkTest()
//        {
//            LocalTab mainWindow = new LocalTab(MainWindow);
//            CloneTab cloneTab = mainWindow.OpenTab<CloneTab>();
            
//            cloneTab.SourcePathTextBox.SetValue(ConstantsList.gitRepoLink);

//            Assert.AreEqual(cloneTab.GetGitValidationMessage(), ConstantsList.gitRepoType);
//        }

//        [Test]
//        public void ValidateMercurialRepoLinkTest() // Mercurial should be installed
//        {
//            LocalTab mainWindow = new LocalTab(MainWindow);
//            CloneTab cloneTab = mainWindow.OpenTab<CloneTab>();

//            cloneTab.SourcePathTextBox.SetValue(ConstantsList.mercurialRepoLink);

//            Assert.AreEqual(cloneTab.GetMercurialValidationMessage(), ConstantsList.mercurialRepoType);
//        }

//        [Test]
//        public void ValidateInvalidRepoLinkTest()
//        {
//            LocalTab mainWindow = new LocalTab(MainWindow);
//            CloneTab cloneTab = mainWindow.OpenTab<CloneTab>();

//            cloneTab.SourcePathTextBox.SetValue(ConstantsList.notValidRepoLink);

//            Assert.AreEqual(cloneTab.GetInvalidRepoMessage(), ConstantsList.invalidFolder);
//        }

//        [Test]
//        public void CheckCloneButtonEnabledTest()
//        {
//            LocalTab mainWindow = new LocalTab(MainWindow);
//            CloneTab cloneTab = mainWindow.OpenTab<CloneTab>();

//            cloneTab.SourcePathTextBox.SetValue(ConstantsList.gitRepoLink);
//            cloneTab.ValidateRepoLinkEnableCloneButton();

//            Assert.IsTrue(cloneTab.IsCloneButtonEnabled());
//        }

//        [Test]
//        public void CheckCloneGitRepoTest()
//        {
//            LocalTab mainWindow = new LocalTab(MainWindow);
//            CloneTab cloneTab = mainWindow.OpenTab<CloneTab>();

//            cloneTab.SourcePathTextBox.SetValue(gitRepoToClone);
//            cloneTab.ValidateRepoLinkEnableCloneButton();
//            cloneTab.ClickCloneButton();

//            var isFolderInitialized = GitWrapper.GetRepositoryByPath(pathToClonedGitRepo);            

//            Assert.IsNotNull(isFolderInitialized);
//        }

//        [Test]
//        public void CheckCloneMercurialRepoTest()  // Mercurial should be installed
//        {
//            LocalTab mainWindow = new LocalTab(MainWindow);
//            CloneTab cloneTab = mainWindow.OpenTab<CloneTab>();

//            cloneTab.SourcePathTextBox.SetValue(mercurialRepoToClone);

//            cloneTab.ValidateRepoLinkEnableCloneButton();
//            cloneTab.ClickCloneButton();

//            bool isDotHgExistByPath = Utils.IsFolderMercurial(pathToClonedMercurialRepo);

//            Assert.IsTrue(isDotHgExistByPath);
//        }

//        [Test]
//        public void CheckBookmarkAppearedAfterGitRepoClonedTest()
//        {
//            LocalTab mainWindow = new LocalTab(MainWindow);
//            CloneTab cloneTab = mainWindow.OpenTab<CloneTab>();

//            cloneTab.SourcePathTextBox.SetValue(gitRepoToClone);
//            cloneTab.ValidateRepoLinkEnableCloneButton();
//            cloneTab.ClickCloneButton();
//            var localtab = mainWindow.OpenTab<LocalTab>();
//            var bookmarkAdded = localtab.IsTestGitRepoBookmarkAdded();
//            Assert.IsTrue(bookmarkAdded);
//        }

//        [Test]
//        public void CheckBookmarkAppearedAfterHgRepoClonedTest()  // Mercurial should be installed
//        {
//            LocalTab mainWindow = new LocalTab(MainWindow);
//            CloneTab cloneTab = mainWindow.OpenTab<CloneTab>();

//            cloneTab.SourcePathTextBox.SetValue(mercurialRepoToClone);
//            cloneTab.ValidateRepoLinkEnableCloneButton();
//            cloneTab.ClickCloneButton();
//            var localtab = mainWindow.OpenTab<LocalTab>();
//            var bookmarkAdded = localtab.IsTestHgRepoBookmarkAdded();
//            Assert.IsTrue(bookmarkAdded);
//        }
//    }
//}