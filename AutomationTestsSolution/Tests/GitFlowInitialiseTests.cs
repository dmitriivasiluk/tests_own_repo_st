using NUnit.Framework;
using ScreenObjectsHelpers.Helpers;
using ScreenObjectsHelpers.Windows.Options;
using ScreenObjectsHelpers.Windows.MenuFolder;
using ScreenObjectsHelpers.Windows.ToolbarTabs;
using System.IO;
using System;
using ScreenObjectsHelpers.Windows.Repository;

namespace AutomationTestsSolution.Tests
{
    class GitFlowInitialiseTests : BasicTest
    {
        #region Test Variables
        private string pathToClonedGitRepo = Environment.ExpandEnvironmentVariables(ConstantsList.pathToClonedGitRepo);
        private string currentUserProfile = Environment.ExpandEnvironmentVariables(ConstantsList.currentUserProfile);
        private string openTabsPath = Environment.ExpandEnvironmentVariables(@"%localappdata%\Atlassian\SourceTree\opentabs.xml");
        private string resourceName = Resources.opentabs_for_clear_repo;
        private string userprofileToBeReplaced = ConstantsList.currentUserProfile;
        private string testData = "test@atlassian.com";
        private string testString = "123";
        private GitFlowInitialiseWindow gitFlowInitWindow;
        #endregion

        [SetUp]
        public override void SetUp()
        {
            base.BackupConfigs();
            base.UseTestConfigs(sourceTreeDataPath);
            
            GitWrapper git = new GitWrapper(pathToClonedGitRepo, testData, testData);
            resourceName = resourceName.Replace(userprofileToBeReplaced, currentUserProfile);
            File.WriteAllText(openTabsPath, resourceName);
            base.RunAndAttachToSourceTree();
        }

        [TearDown]
        public override void TearDown()
        {
            gitFlowInitWindow.ClickCancelButton();
            base.TearDown();
        }

        [Test]
        public void UseDefaultsButtonTest()
        {
            RepositoryTab mainWindow = new RepositoryTab(MainWindow);
            gitFlowInitWindow = mainWindow.ClickGitFlowButton();

            gitFlowInitWindow.SetTextboxContent(gitFlowInitWindow.ProductionBranch, testString);
            gitFlowInitWindow.SetTextboxContent(gitFlowInitWindow.DevelopmentBranch, testString);
            gitFlowInitWindow.SetTextboxContent(gitFlowInitWindow.FeatureBranch, testString);
            gitFlowInitWindow.SetTextboxContent(gitFlowInitWindow.ReleaseBranch, testString);
            gitFlowInitWindow.SetTextboxContent(gitFlowInitWindow.HotfixBranch, testString);
            gitFlowInitWindow.SetTextboxContent(gitFlowInitWindow.VersionTag, testString);

            gitFlowInitWindow.ClickUseDefaultsButton();

            Assert.IsTrue(gitFlowInitWindow.IsDefaultBranchNameCorrect(gitFlowInitWindow.ProductionBranch, ConstantsList.defaultProductionBranch));
            Assert.IsTrue(gitFlowInitWindow.IsDefaultBranchNameCorrect(gitFlowInitWindow.DevelopmentBranch, ConstantsList.defaultDevelopmentBranch));

        }
    }
}