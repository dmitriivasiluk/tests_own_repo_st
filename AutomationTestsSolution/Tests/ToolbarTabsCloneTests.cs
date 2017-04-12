using NUnit.Framework;
using ScreenObjectsHelpers.Helpers;
using ScreenObjectsHelpers.Windows.ToolbarTabs;
using System;

namespace AutomationTestsSolution.Tests
{
    class ToolbarTabsCloneTests : BasicTest
    {
        string repoDir = Environment.ExpandEnvironmentVariables(ConstantsList.pathToTestRepoDirectory);
        string bookmarks = Environment.ExpandEnvironmentVariables(ConstantsList.pathToBookmarks);

        /// <summary>        
        /// Pre-conditions: Test Repository folder is not stored in Documents and is not listed in bookmarks.
        /// Removes test repo folder and a bookmarks.xml
        /// TearDown: Removes test repo folder and a bookmarks.xml
        /// </summary>
        [SetUp]
        public override void SetUp()
        {
            Utils.RemoveDirectory(repoDir);
            Utils.RemoveFile(bookmarks);

            base.SetUp();
        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();

            Utils.ThreadWait(1000);

            Utils.RemoveDirectory(repoDir);
            Utils.RemoveFile(bookmarks);
        }

        [Test]
        public void ValidateGitRepoLinkTest()
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            CloneTab cloneTab = mainWindow.OpenTab<CloneTab>();            

            cloneTab.SourcePathTextBox.Enter(ConstantsList.GitRepoLink);            

            Assert.AreEqual(cloneTab.ValidateGitLink(), "Git");
        }

        [Test]
        public void ValidateMercurialRepoLinkTest() // Mercyrial should be installed
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            CloneTab cloneTab = mainWindow.OpenTab<CloneTab>();

            cloneTab.SourcePathTextBox.Enter(ConstantsList.MercurialRepoLink);

            Assert.AreEqual(cloneTab.ValidateMercurialLink(), "Mercurial");
        }

        [Test]
        public void CheckCloneButtonTest()
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            CloneTab cloneTab = mainWindow.OpenTab<CloneTab>();

            cloneTab.SourcePathTextBox.Enter(ConstantsList.GitRepoLink);
            cloneTab.ValidateRepoLinkEnableCloneButton();

            Assert.IsTrue(cloneTab.IsCloneButtonEnabled());            
        }
    }
}