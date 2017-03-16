using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using NUnit.Framework;
using ScreenObjectsHelpers.Windows;
using System.Windows.Automation;



namespace AutomationTestsSolution.Tests
{
    class WelcomeWizardTests : BasicTestInstallation
    {
        [Test]
        public void ContinueButtonIsNotActiveTest()
        {
            InstallationWindow installWindow = new InstallationWindow(MainWindow);
            installWindow.UncheckLicenceAgreementCheckbox();

            bool isContinueButtonActive = installWindow.IsContinueButtonActive();
            Assert.IsFalse(isContinueButtonActive);
        }

    }
}


