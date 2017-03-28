using NUnit.Framework;
using ScreenObjectsHelpers.Windows;
using ScreenObjectsHelpers.Windows.MenuFolder;
using ScreenObjectsHelpers.Windows.Options;
namespace AutomationTestsSolution.Tests
{
    class HelpMenuTests : BasicTest
    {

        [Test]
        public void AboutWindowPresenceTest()
        {
            NewTabWindow mainWindow = new NewTabWindow(MainWindow);
            AboutWindow aboutWindow = mainWindow.OpenMenu<HelpMenu>().OpenAbout();

            string aboutWindowHeader = aboutWindow.GetHeader();
            string copyrightCaption = aboutWindow.GetCopyrightCaption();
            string appVersion = aboutWindow.GetAppVersion();
            Assert.AreEqual(aboutWindowHeader, "About SourceTree");
            Assert.AreEqual(copyrightCaption, "Copyright Atlassian 2012-2017. All Rights Reserved.");
            Assert.AreEqual(appVersion, "2.0.14.1");
        }
    }
}


