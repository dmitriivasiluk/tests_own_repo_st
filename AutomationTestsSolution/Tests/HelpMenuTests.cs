using NUnit.Framework;
using ScreenObjectsHelpers.Windows;
using ScreenObjectsHelpers.Windows.MenuFolder;
using ScreenObjectsHelpers.Windows.Options;
using ScreenObjectsHelpers.Windows.ToolbarTabs;

namespace AutomationTestsSolution.Tests
{
    class HelpMenuTests : BasicTest
    {

        [Test]
        public void AboutWindowPresenceTest()
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            AboutWindow aboutWindow = mainWindow.OpenMenu<HelpMenu>().OpenAbout();

            string aboutWindowHeader = aboutWindow.GetHeader();
            string copyrightCaption = aboutWindow.GetCopyrightCaption();
            string appVersion = aboutWindow.GetAppVersion();
            Assert.AreEqual(aboutWindowHeader, "About SourceTree");
            Assert.AreEqual(copyrightCaption, "Copyright Atlassian 2012-2017. All Rights Reserved.");
            Assert.AreEqual(appVersion, "Version 2.0.15.1");
        }
    }
}