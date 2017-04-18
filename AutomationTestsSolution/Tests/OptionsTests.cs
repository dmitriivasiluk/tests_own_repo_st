using NUnit.Framework;
using ScreenObjectsHelpers.Windows;
using ScreenObjectsHelpers.Windows.Options;
using ScreenObjectsHelpers.Windows.MenuFolder;
using ScreenObjectsHelpers.Windows.ToolbarTabs;

namespace AutomationTestsSolution.Tests
{
    class OptionsTests : BasicTest
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            base.RunAndAttachToSourceTree();
        }

        [Test]
        public void CheckForUpdatesTest()
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            OptionsWindow optionsWindows = mainWindow.OpenMenu<ToolsMenu>().OpenOptions();
            UpdatesTab updatesTab = optionsWindows.OpenTab<UpdatesTab>();
            updatesTab.CheckForUpdate();
            updatesTab.ClickOkButton();
        }

        [Test]
        public void UseEmbededGit()
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            OptionsWindow optionsWindows = mainWindow.OpenMenu<ToolsMenu>().OpenOptions();
            GitTab gitTab = optionsWindows.OpenTab<GitTab>();
            gitTab.UseEmbeddedGit();
            Assert.IsFalse(gitTab.IsUseEmbeddedGitEnabled());
            Assert.IsTrue(gitTab.IsUseSystemGitEnabled());
            Assert.That(gitTab.VersionText(), Does.Contain("2.11.0").IgnoreCase);
            gitTab.ClickOkButton();
        }

        [Test]
        public void UseSystemGit()
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            OptionsWindow optionsWindows = mainWindow.OpenMenu<ToolsMenu>().OpenOptions();
            GitTab gitTab = optionsWindows.OpenTab<GitTab>();
            gitTab.UseSystemGitButton();
            Assert.IsTrue(gitTab.IsUseEmbeddedGitEnabled());
            Assert.IsFalse(gitTab.IsUseSystemGitEnabled());
            Assert.That(gitTab.VersionText(), Does.Contain("2.11.0").IgnoreCase);
            gitTab.ClickOkButton();
        }

        [Test]
        public void UpdateEmbededGit()
        {
            LocalTab mainWindow = new LocalTab(MainWindow);
            OptionsWindow optionsWindows = mainWindow.OpenMenu<ToolsMenu>().OpenOptions();
            GitTab gitTab = optionsWindows.OpenTab<GitTab>();
            gitTab.UpdateEmbededGitVersion();
            gitTab.ClickOkButton();
        }

    }

}


