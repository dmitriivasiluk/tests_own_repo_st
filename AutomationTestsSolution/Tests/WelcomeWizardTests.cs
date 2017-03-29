using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using NUnit.Framework;
using ScreenObjectsHelpers.Helpers;
using ScreenObjectsHelpers.Windows;


namespace AutomationTestsSolution.Tests
{
    // Verify that Mercurial and Git are installed on computer before run tests. Also check OAuth access to GitHub and BitBucket accounts.
    class WelcomeWizardTests : BasicTestInstallation
    {
       
        [TestCase]
        public void ContinueButtonIsNotActiveTest()
        {
            InstallationWindow installWindow = new InstallationWindow(MainWindow);
            installWindow.UncheckLicenceAgreementCheckbox();

            bool isContinueButtonActive = installWindow.IsContinueButtonActive();
            Assert.IsFalse(isContinueButtonActive);
        }

        [TestCase("testdesktopapplication@20minute.email", "123SourceTree")]
        public void ValidRegistrationTest(string loginEmailToAttlassian, string passwordToAttlassian)
        {
            InstallationWindow installWindow = new InstallationWindow(MainWindow);
            installWindow.CheckLicenceAgreementCheckbox();
            installWindow.ClickContinueButton();
            AuthorizationWindow authorization = installWindow.ClickUseExistingAccount();

            installWindow = authorization.SignIn(loginEmailToAttlassian, passwordToAttlassian);

            bool isContinueButtonActive = installWindow.IsContinueButtonActive();
            string ActualtextRegistrationComplete = installWindow.CompleteText();
            //string ActualLoggedAsEmail = installWindow.LoggedAsEmail();       // Need AutomationId for this element, because get element by text - text dynamically changes
            Assert.AreEqual(ActualtextRegistrationComplete, "Registration Complete!");
            //Assert.AreEqual(ActualLoggedAsEmail, loginEmail);
            Assert.IsTrue(isContinueButtonActive);
        }

        [TestCase("testdesktopapplication@20minute.email", "123SourceTree", "githubfaketesting", "123GitHubFake")]
        public void ConnectGitHubAccountTest(
            string atlassianLoginEmail, 
            string atlassianPassword, 
            string gitHubLogin, 
            string gitHubPassword)
        {
            InstallationWindow installWindow = new InstallationWindow(MainWindow);
            installWindow.CheckLicenceAgreementCheckbox();
            installWindow.ClickContinueButton();
            AuthorizationWindow authorization = installWindow.ClickUseExistingAccount();

            installWindow = authorization.SignIn(atlassianLoginEmail, atlassianPassword);
            installWindow.ClickContinueButton();
            installWindow.FillBasicAuthenticationGithub(gitHubLogin, gitHubPassword);
            installWindow.ClickContinueButton();

            string actualTitleOfNextStep = installWindow.DownloadingVersionText();
            // This is ensure that authorization was successful, because we are located on next step "Install tools"
            Assert.AreEqual(actualTitleOfNextStep, "Downloading version control systems..."); 
        }

        [TestCase("testdesktopapplication@20minute.email", "123SourceTree", "bitbucketfaketest", "123BitBucketFake")]
        public void ConnectBitbucketAccountTest (
            string atlassianLoginEmail,
            string atlassianPassword,
            string bitBucketLogin,
            string bitbucketPassword)
        {
            InstallationWindow installWindow = new InstallationWindow(MainWindow);
            installWindow.CheckLicenceAgreementCheckbox();
            installWindow.ClickContinueButton();
            AuthorizationWindow authorization = installWindow.ClickUseExistingAccount();

            installWindow = authorization.SignIn(atlassianLoginEmail, atlassianPassword);

            installWindow.ClickContinueButton();

            installWindow.FillBasicAuthenticationBitbucket(bitBucketLogin, bitbucketPassword);

            installWindow.ClickContinueButton();

            string actualTitleOfNextStep = installWindow.DownloadingVersionText();
            // This is ensure that authorization was successful, because we are located on next step "Install tools"
            Assert.AreEqual(actualTitleOfNextStep, "Downloading version control systems...");
        }

        [TestCase("testdesktopapplication@20minute.email", "123SourceTree", "http://HostURL.com", "username", "password")]
        public void ConnectBitbucketServerAccountTest(
            string atlassianLoginEmail,
            string atlassianPassword,
            string hostUrl,
            string bitBucketLogin,
            string bitbucketPassword)
        {
            InstallationWindow installWindow = new InstallationWindow(MainWindow);
            installWindow.CheckLicenceAgreementCheckbox();
            installWindow.ClickContinueButton();
            AuthorizationWindow authorization = installWindow.ClickUseExistingAccount();

            installWindow = authorization.SignIn(atlassianLoginEmail, atlassianPassword);

            installWindow.ClickContinueButton();

            // Don't have any HostURL to BitbucketServer for check this functionality.
            installWindow.FillAuthenticationBitBucketServer(hostUrl, bitBucketLogin, bitbucketPassword);

            //string actualTitleOfNextStep = installWindow.DownloadingVersionText();
            // This is ensure that authorization was successful, because we are located on next step "Install tools"
            //Assert.AreEqual(actualTitleOfNextStep, "Downloading version control systems...");
        }

        [TestCase("testdesktopapplication@20minute.email", "123SourceTree", "incorrectLogin", "incorrectPassword")]
        public void ConnectGitHubIncorrectCredentialsNegativeTest(
            string atlassianLoginEmail,
            string atlassianPassword,
            string gitHubLogin,
            string gitHubPassword)
        {
            InstallationWindow installWindow = new InstallationWindow(MainWindow);
            installWindow.CheckLicenceAgreementCheckbox();
            installWindow.ClickContinueButton();
            AuthorizationWindow authorization = installWindow.ClickUseExistingAccount();

            installWindow = authorization.SignIn(atlassianLoginEmail, atlassianPassword);

            installWindow.ClickContinueButton();

            installWindow.FillBasicAuthenticationGithub(gitHubLogin, gitHubPassword);

            installWindow.ClickContinueButton();

            bool actualIsContinueButtonActive = installWindow.IsContinueButtonActive();
            ErrorDialogWindow error = installWindow.SwitchToErrorDialogWindow();
            string actualTitleError = error.GetTitle();
            Assert.AreEqual(actualTitleError, "Login failed");
            Assert.IsFalse(actualIsContinueButtonActive);
        }

        [TestCase("testdesktopapplication@20minute.email", "123SourceTree", "incorrectLogin", "IncorrectPassword")]
        public void ConnectBitbucketIncorrectCredentialsNegativeTest(
            string atlassianLoginEmail,
            string atlassianPassword,
            string bitBucketLogin,
            string bitBucketPassword)
        {
            InstallationWindow installWindow = new InstallationWindow(MainWindow);
            installWindow.CheckLicenceAgreementCheckbox();
            installWindow.ClickContinueButton();
            AuthorizationWindow authorization = installWindow.ClickUseExistingAccount();

            installWindow = authorization.SignIn(atlassianLoginEmail, atlassianPassword);

            installWindow.ClickContinueButton();

            installWindow.FillBasicAuthenticationBitbucket(bitBucketLogin, bitBucketPassword);

            installWindow.ClickContinueButton();

            bool actualIsContinueButtonActive = installWindow.IsContinueButtonActive();
            ErrorDialogWindow error = installWindow.SwitchToErrorDialogWindow();
            string actualTitleError = error.GetTitle();
            Assert.AreEqual(actualTitleError, "Login failed");
            Assert.IsFalse(actualIsContinueButtonActive);
        }

        [TestCase("testdesktopapplication@20minute.email", "123SourceTree", "http://IncorrectHost.com", "test", "test")]
        public void ConnectBitbucketServerIncorrectCredentialsNegativeTest(
            string atlassianLoginEmail,
            string atlassianPassword,
            string hostUrl,
            string bitBucketLogin,
            string bitBucketPassword)
        {
            InstallationWindow installWindow = new InstallationWindow(MainWindow);
            installWindow.CheckLicenceAgreementCheckbox();
            installWindow.ClickContinueButton();
            AuthorizationWindow authorization = installWindow.ClickUseExistingAccount();

            installWindow = authorization.SignIn(atlassianLoginEmail, atlassianPassword);

            installWindow.ClickContinueButton();

            installWindow.FillAuthenticationBitBucketServer(hostUrl, bitBucketLogin, bitBucketPassword);

            installWindow.ClickContinueButton();

            bool actualIsContinueButtonActive = installWindow.IsContinueButtonActive();
            ErrorDialogWindow error = installWindow.SwitchToErrorDialogWindow();
            string actualTitleError = error.GetTitle();
            Assert.AreEqual(actualTitleError, "Login failed");
            Assert.IsFalse(actualIsContinueButtonActive);

        }

        /// <summary>
        /// Verify that you have permission to access SourceTreeForWindows by atlassian to GitHub account.
        /// </summary>
        [TestCase("testdesktopapplication@20minute.email", "123SourceTree")]
        public void ConnectGitHubViaOAuthTest (
            string atlassianLoginEmail,
            string atlassianPassword)
        {
            InstallationWindow installWindow = new InstallationWindow(MainWindow);
            installWindow.CheckLicenceAgreementCheckbox();
            installWindow.ClickContinueButton();
            AuthorizationWindow authorization = installWindow.ClickUseExistingAccount();

            installWindow = authorization.SignIn(atlassianLoginEmail, atlassianPassword);

            installWindow.ClickContinueButton();

            installWindow.ChooseGitHubAccount();

            installWindow.ClickContinueButton();

            Thread.Sleep(5000); // Wait connection via OAuth

            string actualTitleOfNextStep = installWindow.DownloadingVersionText();
            // This is ensure that authorization was successful, because we are located on next step "Install tools"
            Assert.AreEqual(actualTitleOfNextStep, "Downloading version control systems...");
        }

        /// <summary>
        /// Verify that you have permission to access SourceTreeForWindows by atlassian to BitBucket account.
        /// </summary>
        [TestCase("testdesktopapplication@20minute.email", "123SourceTree")]
        public void ConnectBitbucketViaOAuthTest(
            string atlassianLoginEmail,
            string atlassianPassword)
        {
            InstallationWindow installWindow = new InstallationWindow(MainWindow);
            installWindow.CheckLicenceAgreementCheckbox();
            installWindow.ClickContinueButton();
            AuthorizationWindow authorization = installWindow.ClickUseExistingAccount();

            installWindow = authorization.SignIn(atlassianLoginEmail, atlassianPassword);

            installWindow.ClickContinueButton();

            installWindow.ChooseBitBucketAccount();

            installWindow.ClickContinueButton();

            Thread.Sleep(5000); // Wait connection via OAuth

            string actualTitleOfNextStep = installWindow.DownloadingVersionText();
            // This is ensure that authorization was successful, because we are located on next step "Install tools"
            Assert.AreEqual(actualTitleOfNextStep, "Downloading version control systems...");
        }

     [TestCase("testdesktopapplication@20minute.email", "123SourceTree", "SourceTree")]
        public void SkipSetupButtonClosesConfigurationTest(
            string atlassianLoginEmail,
            string atlassianPassword,
            string expectedTitle)
        {
            InstallationWindow installWindow = new InstallationWindow(MainWindow);
            installWindow.CheckLicenceAgreementCheckbox();
            installWindow.ClickContinueButton();
            AuthorizationWindow authorization = installWindow.ClickUseExistingAccount();

            installWindow = authorization.SignIn(atlassianLoginEmail, atlassianPassword);

            installWindow.ClickContinueButton();

            NewTabWindow mainWindow = installWindow.SkipSetup();

            string actualTitle = mainWindow.GetTitle();

            Assert.AreEqual(actualTitle, expectedTitle);
        }

        [TestCase("testdesktopapplication@20minute.email", "123SourceTree", "bitbucketfaketest", "123BitBucketFake", @"%USERPROFILE%\Documents")]
        public void InstallGlobalIgnoreFileTest(
            string atlassianLoginEmail,
            string atlassianPassword,
            string bitBucketLogin,
            string bitbucketPassword,
            string defaultPath)
        {
            InstallationWindow installWindow = new InstallationWindow(MainWindow);
            installWindow.CheckLicenceAgreementCheckbox();
            installWindow.ClickContinueButton();
            AuthorizationWindow authorization = installWindow.ClickUseExistingAccount();
            
            installWindow = authorization.SignIn(atlassianLoginEmail, atlassianPassword);

            installWindow.ClickContinueButton();

            installWindow.FillBasicAuthenticationBitbucket(bitBucketLogin, bitbucketPassword);

            installWindow.ClickContinueButton(); // step remotes

            installWindow.WaitCompleteInstallToolsProgressBar();

            installWindow.ClickContinueButton(); // step install tools

            IgnoreFileDialogWindow dialogWindow = installWindow.GetInstallGlobalIgnoreFileDialogWindow();
            dialogWindow.ClickYesButton();

            bool isGitIgnoreExistOnComputer = File.Exists(defaultPath + "/.gitignore_global");

            Assert.IsTrue(isGitIgnoreExistOnComputer);

        }

        [TestCase("testdesktopapplication@20minute.email", "123SourceTree", "githubfaketesting", "123GitHubFake", "github-public", @"Documents\CloneBasicGitHub")]
        public void CloneGitHubRepositoryUsingBasicAuthorizationTest(
            string atlassianLoginEmail,
            string atlassianPassword,
            string gitHubLogin,
            string gitHubPassword,
            string nameOfRepo,
            string subFolderInUserProfile)
        {
            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathToNewFolder = Path.Combine(userProfile, subFolderInUserProfile);
            WindowsFilesHelper.RemoveFolderRecursivelyByPath(pathToNewFolder);

            InstallationWindow installWindow = new InstallationWindow(MainWindow);
            installWindow.CheckLicenceAgreementCheckbox();
            installWindow.ClickContinueButton();
            AuthorizationWindow authorization = installWindow.ClickUseExistingAccount();

            installWindow = authorization.SignIn(atlassianLoginEmail, atlassianPassword);

            installWindow.ClickContinueButton();

            installWindow.FillBasicAuthenticationGithub(gitHubLogin, gitHubPassword);

            installWindow.ClickContinueButton(); // step remotes

            installWindow.WaitCompleteInstallToolsProgressBar();

            installWindow.ClickContinueButton(); // step install tools

            installWindow.SelectRepositoryByName(nameOfRepo);
            WindowsFilesHelper.CreateFolderByPath(pathToNewFolder);
            installWindow.BrowseDestinationPath(pathToNewFolder);

            installWindow.ClickContinueButton();

            bool actialIsRepositoryCloned = WindowsFilesHelper.IsGitRepositoryByPath(pathToNewFolder);

            Assert.IsTrue(actialIsRepositoryCloned);
        }

        [TestCase("testdesktopapplication@20minute.email", "123SourceTree", "bitbucketfaketest", "123BitBucketFake", "bitbucket-public", @"Documents\CloneBasicBitBucket")]
        public void CloneBitBucketRepositoryUsingBasicAuthorizationTest(
            string atlassianLoginEmail,
            string atlassianPassword,
            string bitbucketLogin,
            string bitbucketPassword,
            string nameOfRepo,
            string subFolderInUserProfile)
        {
            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathToNewFolder = Path.Combine(userProfile, subFolderInUserProfile);
            WindowsFilesHelper.RemoveFolderRecursivelyByPath(pathToNewFolder);

            InstallationWindow installWindow = new InstallationWindow(MainWindow);
            installWindow.CheckLicenceAgreementCheckbox();
            installWindow.ClickContinueButton();
            AuthorizationWindow authorization = installWindow.ClickUseExistingAccount();

            installWindow = authorization.SignIn(atlassianLoginEmail, atlassianPassword);

            installWindow.ClickContinueButton();

            installWindow.FillBasicAuthenticationBitbucket(bitbucketLogin, bitbucketPassword);

            installWindow.ClickContinueButton(); // step remotes

            installWindow.WaitCompleteInstallToolsProgressBar();

            installWindow.ClickContinueButton(); // step install tools

            installWindow.SelectRepositoryByName(nameOfRepo);
            WindowsFilesHelper.CreateFolderByPath(pathToNewFolder);
            installWindow.BrowseDestinationPath(pathToNewFolder);

            installWindow.ClickContinueButton();

            Thread.Sleep(2000); 
            bool actialIsRepositoryCloned = WindowsFilesHelper.IsGitRepositoryByPath(pathToNewFolder);

            Assert.IsTrue(actialIsRepositoryCloned);
        }

        /// <summary>
        /// Verify that you have permission to access SourceTreeForWindows by atlassian to GitHub account.
        /// </summary>
        [TestCase("testdesktopapplication@20minute.email", "123SourceTree", "github-public", @"Documents\CloneOAuthGitHub")]
        public void CloneGitHubRepositoryUsingOAuthAuthorizationTest(
            string atlassianLoginEmail,
            string atlassianPassword,
            string nameOfRepo,
            string subFolderInUserProfile)
        {
            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathToNewFolder = Path.Combine(userProfile, subFolderInUserProfile);
            WindowsFilesHelper.RemoveFolderRecursivelyByPath(pathToNewFolder);

            InstallationWindow installWindow = new InstallationWindow(MainWindow);
            installWindow.CheckLicenceAgreementCheckbox();
            installWindow.ClickContinueButton();
            AuthorizationWindow authorization = installWindow.ClickUseExistingAccount();

            installWindow = authorization.SignIn(atlassianLoginEmail, atlassianPassword);

            installWindow.ClickContinueButton();

            installWindow.ChooseGitHubAccount();

            installWindow.ClickContinueButton(); // step remotes

            installWindow.WaitCompleteInstallToolsProgressBar();

            installWindow.ClickContinueButton(); // step install tools

            installWindow.SelectRepositoryByName(nameOfRepo);
            WindowsFilesHelper.CreateFolderByPath(pathToNewFolder);
            installWindow.BrowseDestinationPath(pathToNewFolder);

            installWindow.ClickContinueButton();

            Thread.Sleep(2000);
            bool actialIsRepositoryCloned = WindowsFilesHelper.IsGitRepositoryByPath(pathToNewFolder);

            Assert.IsTrue(actialIsRepositoryCloned);
        }

        /// <summary>
        /// Verify that you have permission to access SourceTreeForWindows by atlassian to BitBucket account.
        /// </summary>
        [TestCase("testdesktopapplication@20minute.email", "123SourceTree", "bitbucket-public", @"%USERPROFILE%\Documents\CloneOAuthBitBucket")]
        public void CloneBitBucketRepositoryUsingOAuthAuthorizationTest(
            string atlassianLoginEmail,
            string atlassianPassword,
            string nameOfRepo,
            string subFolderInUserProfile
            )
        {
            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathToNewFolder = Path.Combine(userProfile, subFolderInUserProfile);
            WindowsFilesHelper.RemoveFolderRecursivelyByPath(pathToNewFolder);

            InstallationWindow installWindow = new InstallationWindow(MainWindow);
            installWindow.CheckLicenceAgreementCheckbox();
            installWindow.ClickContinueButton();
            AuthorizationWindow authorization = installWindow.ClickUseExistingAccount();

            installWindow = authorization.SignIn(atlassianLoginEmail, atlassianPassword);

            installWindow.ClickContinueButton();

            installWindow.ChooseBitBucketAccount();

            installWindow.ClickContinueButton(); // step remotes

            installWindow.WaitCompleteInstallToolsProgressBar();

            installWindow.ClickContinueButton(); // step install tools

            installWindow.SelectRepositoryByName(nameOfRepo);
            WindowsFilesHelper.CreateFolderByPath(pathToNewFolder);
            installWindow.BrowseDestinationPath(pathToNewFolder);

            installWindow.ClickContinueButton();

            Thread.Sleep(2000);
            bool actialIsRepositoryCloned = WindowsFilesHelper.IsGitRepositoryByPath(pathToNewFolder);

            Assert.IsTrue(actialIsRepositoryCloned);
        }

        [TestCase("testdesktopapplication@20minute.email", "123SourceTree", "https://Server.com.ua", "incorrectLogin", "incorrectPassword", "bitbucket-public", @"Documents\CloneBasicBitBucketServer")]
        public void CloneBitBucketServerRepositoryUsingBasicAuthorizationTest(
            string atlassianLoginEmail,
            string atlassianPassword,
            string urlServer,
            string bitBucketLogin,
            string bitBucketPassword,
            string nameOfRepo,
            string subFolderInUserProfile)
        {
            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathToNewFolder = Path.Combine(userProfile, subFolderInUserProfile);
            WindowsFilesHelper.RemoveFolderRecursivelyByPath(pathToNewFolder);

            InstallationWindow installWindow = new InstallationWindow(MainWindow);
            installWindow.CheckLicenceAgreementCheckbox();
            installWindow.ClickContinueButton();
            AuthorizationWindow authorization = installWindow.ClickUseExistingAccount();

            installWindow = authorization.SignIn(atlassianLoginEmail, atlassianPassword);

            installWindow.ClickContinueButton();

            installWindow.FillAuthenticationBitBucketServer(urlServer, bitBucketLogin, bitBucketPassword);

            // WE need any BitBucket server to pass this test!

            //installWindow.ClickContinueButton(); // step remotes

            //installWindow.WaitCompleteInstallToolsProgressBar();

            //installWindow.ClickContinueButton(); // step install tools

            //installWindow.SelectRepositoryByName(nameOfRepo);
            //WindowsFilesHelper.CreateFolderByPath(pathToNewFolder);
            //installWindow.BrowseDestinationPath(pathToNewFolder);

            //installWindow.ClickContinueButton();

            //Thread.Sleep(2000);
            //bool actialIsRepositoryCloned = WindowsFilesHelper.IsGitRepositoryByPath(pathToNewFolder);

            //Assert.IsTrue(actialIsRepositoryCloned);
        }

        [TestCase("testdesktopapplication@20minute.email", "123SourceTree", "githubfaketesting", "123GitHubFake", "github-public")]
        public void SearchInStartingRepositoryStepTest(
            string atlassianLoginEmail,
            string atlassianPassword,
            string gitHubLogin,
            string gitHubPassword,
            string searchCondition)
        {
            InstallationWindow installWindow = new InstallationWindow(MainWindow);
            installWindow.CheckLicenceAgreementCheckbox();
            installWindow.ClickContinueButton();
            AuthorizationWindow authorization = installWindow.ClickUseExistingAccount();

            installWindow = authorization.SignIn(atlassianLoginEmail, atlassianPassword);

            installWindow.ClickContinueButton();

            installWindow.FillBasicAuthenticationGithub(gitHubLogin, gitHubPassword);

            installWindow.ClickContinueButton(); // step remotes

            installWindow.WaitCompleteInstallToolsProgressBar();

            installWindow.ClickContinueButton(); // step install tools

            installWindow.TypeSearchCondition(searchCondition);

            int actualAmountOfRepos = installWindow.CountOfRepositroyInList();
            string nameOfRepository = installWindow.GetTextOfFirstRepository();

            Assert.AreEqual(actualAmountOfRepos, 1);
            Assert.IsTrue(nameOfRepository.Contains(searchCondition));

        }

        [TestCase("testdesktopapplication@20minute.email", "123SourceTree", "githubfaketesting", "123GitHubFake", "github-public", @"Documents\OpenSourceTree")]
        public void SourceTreeOpensAfterFinishConfiguration(
            string atlassianLoginEmail,
            string atlassianPassword,
            string gitHubLogin,
            string gitHubPassword,
            string nameOfRepo,
            string subFolderInUserProfile)
        {
            // Pre-condition
            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathToNewFolder = Path.Combine(userProfile, subFolderInUserProfile);
            WindowsFilesHelper.RemoveFolderRecursivelyByPath(pathToNewFolder);

            InstallationWindow installWindow = new InstallationWindow(MainWindow);
            installWindow.CheckLicenceAgreementCheckbox();
            installWindow.ClickContinueButton();
            AuthorizationWindow authorization = installWindow.ClickUseExistingAccount();

            installWindow = authorization.SignIn(atlassianLoginEmail, atlassianPassword);

            installWindow.ClickContinueButton();

            installWindow.FillBasicAuthenticationGithub(gitHubLogin, gitHubPassword);

            installWindow.ClickContinueButton();

            installWindow.WaitCompleteInstallToolsProgressBar();

            installWindow.ClickContinueButton();

            installWindow.SelectRepositoryByName(nameOfRepo);
            WindowsFilesHelper.CreateFolderByPath(pathToNewFolder);
            installWindow.BrowseDestinationPath(pathToNewFolder);

            installWindow.ClickContinueButton();

            NewTabWindow mainWindow = installWindow.ClickContinueAtTheLatestStepButton();

            string actualTitle = mainWindow.GetTitle();

            Assert.AreEqual(actualTitle, "SourceTree");

        }

    }
}


