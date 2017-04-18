using System;
using NUnit.Framework;
using ScreenObjectsHelpers.Helpers;
using ScreenObjectsHelpers.Windows.ToolbarTabs;

namespace AutomationTestsSolution.Tests
{
    class ToolbarTabsCloneTests : BasicTest
    {
        #region Test Variables
        string gitRepoToClone = ConstantsList.gitRepoToClone;
        string pathToClonedGitRepo = Environment.ExpandEnvironmentVariables(ConstantsList.pathToClonedGitRepo);
        string mercurialRepoToClone = ConstantsList.mercurialRepoToClone;
        string pathToClonedMercurialRepo = Environment.ExpandEnvironmentVariables(ConstantsList.pathToClonedMercurialRepo);
        #endregion

        /// <summary>        
        /// Pre-conditions: 
        /// Test repo folders are removed
        /// Mercurial is installed
        /// 2.0 Welcome - Disabled
        /// </summary>
        [SetUp]
        public override void SetUp()
        {
            Utils.RemoveDirectory(pathToClonedGitRepo);
            Utils.RemoveDirectory(pathToClonedMercurialRepo);

            base.SetUp();

            base.RunAndAttachToSourceTree();
        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();

            Utils.ThreadWait(2000);

            Utils.RemoveDirectory(pathToClonedGitRepo);
            Utils.RemoveDirectory(pathToClonedMercurialRepo);
        }

        [Test]
        public void ValidateGitRepoLinkTest()
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            CloneTab cloneTab = mainWindow.OpenTab<CloneTab>();

            cloneTab.SourcePathTextBox.Enter(ConstantsList.gitRepoLink);

            Assert.AreEqual(cloneTab.ValidateGitLink(), ConstantsList.gitRepoType);
        }

        [Test]
        public void ValidateMercurialRepoLinkTest() // Mercurial should be installed
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            CloneTab cloneTab = mainWindow.OpenTab<CloneTab>();

            cloneTab.SourcePathTextBox.Enter(ConstantsList.mercurialRepoLink);

            Assert.AreEqual(cloneTab.ValidateMercurialLink(), ConstantsList.mercurialRepoType);
        }

        [Test]
        public void ValidateInvalidRepoLinkTest()
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            CloneTab cloneTab = mainWindow.OpenTab<CloneTab>();

            cloneTab.SourcePathTextBox.Enter(ConstantsList.notValidRepoLink);

            Assert.AreEqual(cloneTab.ValidateInvalidLink(), ConstantsList.notValidRepoLink);
        }

        [Test]
        public void CheckCloneButtonEnabledTest()
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            CloneTab cloneTab = mainWindow.OpenTab<CloneTab>();

            cloneTab.SourcePathTextBox.Enter(ConstantsList.gitRepoLink);
            cloneTab.ValidateRepoLinkEnableCloneButton();

            Assert.IsTrue(cloneTab.IsCloneButtonEnabled());
        }

        [Test]
        public void CheckCloneGitRepoTest()
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            CloneTab cloneTab = mainWindow.OpenTab<CloneTab>();

            cloneTab.SourcePathTextBox.Enter(gitRepoToClone);
            cloneTab.ValidateRepoLinkEnableCloneButton();
            cloneTab.ClickCloneButton();

            bool isDotGitExistByPath = Utils.IsFolderGit(pathToClonedGitRepo);

            Assert.IsTrue(isDotGitExistByPath);
        }

        [Test]
        public void CheckCloneMercurialRepoTest()  // Mercurial should be installed
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            CloneTab cloneTab = mainWindow.OpenTab<CloneTab>();

            cloneTab.SourcePathTextBox.Enter(mercurialRepoToClone);
            cloneTab.ValidateRepoLinkEnableCloneButton();
            cloneTab.ClickCloneButton();

            bool isDotHgExistByPath = Utils.IsFolderMercurial(pathToClonedMercurialRepo);

            Assert.IsTrue(isDotHgExistByPath);
        }

        [Test]
        public void CheckBookmarkAppearedAfterGitRepoClonedTest()
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            CloneTab cloneTab = mainWindow.OpenTab<CloneTab>();

            cloneTab.SourcePathTextBox.Enter(gitRepoToClone);
            cloneTab.ValidateRepoLinkEnableCloneButton();
            cloneTab.ClickCloneButton();
            var localtab = mainWindow.OpenTab<LocalTab>();
            var bookmarkAdded = localtab.isTestGitRepoBookmarkAdded();
            Assert.IsTrue(bookmarkAdded);
        }

        [Test]
        public void CheckBookmarkAppearedAfterHgRepoClonedTest()  // Mercurial should be installed
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            CloneTab cloneTab = mainWindow.OpenTab<CloneTab>();

            cloneTab.SourcePathTextBox.Enter(mercurialRepoToClone);
            cloneTab.ValidateRepoLinkEnableCloneButton();
            cloneTab.ClickCloneButton();
            var localtab = mainWindow.OpenTab<LocalTab>();
            var bookmarkAdded = localtab.isTestHgRepoBookmarkAdded();
            Assert.IsTrue(bookmarkAdded);
        }
    }
}