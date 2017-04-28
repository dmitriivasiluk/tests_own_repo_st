﻿using NUnit.Framework;
using ScreenObjectsHelpers.Helpers;
using ScreenObjectsHelpers.Windows.Options;
using ScreenObjectsHelpers.Windows.MenuFolder;
using ScreenObjectsHelpers.Windows.ToolbarTabs;
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
            base.BackupConfigs();
            base.UseTestConfigs(sourceTreeDataPath);

            //GitWrapper git = new GitWrapper(pathToClonedGitRepo, testData, testData);
            CreateTestFolders();
            Repository.Init(pathToClonedGitRepo);
            resourceName = resourceName.Replace(userprofileToBeReplaced, currentUserProfile);
            File.WriteAllText(openTabsPath, resourceName);
            base.RunAndAttachToSourceTree();
        }

        [TearDown]
        public override void TearDown()
        {
            gitFlowInitWindow.ClickCancelButton();
            base.TearDown();

            Utils.RemoveDirectory(pathToClonedGitRepo);
        }
        private void CreateTestFolders()
        {
            Directory.CreateDirectory(pathToClonedGitRepo);
        }

        [Test]
        public void CheckUseDefaultsButtonResetTextboxesTest()
        {
            RepositoryTab mainWindow = new RepositoryTab(MainWindow);
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