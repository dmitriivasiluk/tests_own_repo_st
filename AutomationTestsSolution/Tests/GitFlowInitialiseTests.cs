using NUnit.Framework;
using ScreenObjectsHelpers.Helpers;
using System.IO;
using System;
using ScreenObjectsHelpers.Windows.Repository;
using LibGit2Sharp;

namespace AutomationTestsSolution.Tests
{
    class GitFlowInitialiseTests : BasicTest
    {
        #region Test Variables
        private string pathToClonedGitRepo = Environment.ExpandEnvironmentVariables(ConstantsList.pathToClonedGitRepo);
        private string currentUserProfile = Environment.ExpandEnvironmentVariables(ConstantsList.currentUserProfile);
        private string openTabsPath = Environment.ExpandEnvironmentVariables(Path.Combine(ConstantsList.pathToDataFolder, ConstantsList.opentabsXml));
        private string resourceName = Resources.opentabs_for_clear_repo;
        private string userprofileToBeReplaced = ConstantsList.currentUserProfile;
        private string testData = "test@atlassian.com";
        private string testString = "123";
        private GitFlowInitialiseWindow gitFlowInitWindow;
        #endregion

        [SetUp]
        public override void SetUp()
        {
            RemoveTestFolders();
            CreateTestFolders();
            Repository.Init(pathToClonedGitRepo);
            base.BackupConfigs();
            base.UseTestConfigs(sourceTreeDataPath);
            resourceName = resourceName.Replace(userprofileToBeReplaced, currentUserProfile);
            File.WriteAllText(openTabsPath, resourceName);
            Utils.ThreadWait(2000);
            base.RunAndAttachToSourceTree();
        }

        [TearDown]
        public override void TearDown()
        {
            gitFlowInitWindow.ClickCancelButton();
            base.TearDown();
            Utils.ThreadWait(2000);
            RemoveTestFolders();
        }
        private void CreateTestFolders()
        {
            Directory.CreateDirectory(pathToClonedGitRepo);
        }
        private void RemoveTestFolders()
        {
            Utils.RemoveDirectory(pathToClonedGitRepo);
        }
        [Test]
        public void CheckUseDefaultsButtonResetTextboxesTest()
        {
            RepositoryTab mainWindow = new RepositoryTab(MainWindow);
            Utils.ThreadWait(4000);
            gitFlowInitWindow = mainWindow.ClickGitFlowButton();

            gitFlowInitWindow.SetTextboxContent(gitFlowInitWindow.ProductionBranchTextbox, testString);
            gitFlowInitWindow.SetTextboxContent(gitFlowInitWindow.DevelopmentBranchTextbox, testString);
            gitFlowInitWindow.SetTextboxContent(gitFlowInitWindow.FeatureBranchTextbox, testString);
            gitFlowInitWindow.SetTextboxContent(gitFlowInitWindow.ReleaseBranchTextbox, testString);
            gitFlowInitWindow.SetTextboxContent(gitFlowInitWindow.HotfixBranchTextbox, testString);
            gitFlowInitWindow.SetTextboxContent(gitFlowInitWindow.VersionTagTextbox, testString);

            gitFlowInitWindow.ClickUseDefaultsButton();

            Assert.IsTrue(gitFlowInitWindow.IsDefaultBranchNameCorrect(gitFlowInitWindow.ProductionBranchTextbox, ConstantsList.defaultProductionBranch));
            Assert.IsTrue(gitFlowInitWindow.IsDefaultBranchNameCorrect(gitFlowInitWindow.DevelopmentBranchTextbox, ConstantsList.defaultDevelopmentBranch));
            Assert.IsTrue(gitFlowInitWindow.IsDefaultBranchNameCorrect(gitFlowInitWindow.FeatureBranchTextbox, ConstantsList.defaultFeatureBranch));
            Assert.IsTrue(gitFlowInitWindow.IsDefaultBranchNameCorrect(gitFlowInitWindow.ReleaseBranchTextbox, ConstantsList.defaultReleaseBranch));
            Assert.IsTrue(gitFlowInitWindow.IsDefaultBranchNameCorrect(gitFlowInitWindow.HotfixBranchTextbox, ConstantsList.defaultHotfixBranch));
            Assert.IsTrue(gitFlowInitWindow.IsVersionTagEmpty());
        }

        [Test]
        public void CheckWhetherDefaultBranchNamesCorrect()
        {
            RepositoryTab mainWindow = new RepositoryTab(MainWindow);
            Utils.ThreadWait(4000);
            gitFlowInitWindow = mainWindow.ClickGitFlowButton();

            Assert.IsTrue(gitFlowInitWindow.TextboxDefaultContent(gitFlowInitWindow.ProductionBranchTextbox, ConstantsList.defaultProductionBranch));
            Assert.IsTrue(gitFlowInitWindow.TextboxDefaultContent(gitFlowInitWindow.DevelopmentBranchTextbox, ConstantsList.defaultDevelopmentBranch));
            Assert.IsTrue(gitFlowInitWindow.TextboxDefaultContent(gitFlowInitWindow.FeatureBranchTextbox, ConstantsList.defaultFeatureBranch));
            Assert.IsTrue(gitFlowInitWindow.TextboxDefaultContent(gitFlowInitWindow.ReleaseBranchTextbox, ConstantsList.defaultReleaseBranch));
            Assert.IsTrue(gitFlowInitWindow.TextboxDefaultContent(gitFlowInitWindow.HotfixBranchTextbox, ConstantsList.defaultHotfixBranch));
            Assert.IsTrue(gitFlowInitWindow.IsVersionTagEmpty());
        }
    }
}