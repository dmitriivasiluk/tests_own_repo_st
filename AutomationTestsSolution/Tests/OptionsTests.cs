﻿using NUnit.Framework;
using ScreenObjectsHelpers.Windows;
using ScreenObjectsHelpers.Windows.Options;
using ScreenObjectsHelpers.Windows.MenuFolder;

namespace AutomationTestsSolution.Tests
{
    class OptionsTests : BasicTest
    {
     
       [Test]
        public void CheckForUpdatesTest()
        {
            NewTabWindow mainWindow = new NewTabWindow(MainWindow);         
            OptionsWindow optionsWindows = mainWindow.OpenMenu<ToolsMenu>().OpenOptions();
            UpdatesTab updatesTab = optionsWindows.OpenTab<UpdatesTab>();
            updatesTab.CheckForUpdate();
            updatesTab.ClickOkButton();
        }

        [Test]
        public void UseEmbededGit()
        {
            NewTabWindow mainWindow = new NewTabWindow(MainWindow);
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
            NewTabWindow mainWindow = new NewTabWindow(MainWindow);
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
            NewTabWindow mainWindow = new NewTabWindow(MainWindow);
            OptionsWindow optionsWindows = mainWindow.OpenMenu<ToolsMenu>().OpenOptions();
            GitTab gitTab = optionsWindows.OpenTab<GitTab>();
            gitTab.UpdateEmbededGitVersion();
            gitTab.ClickOkButton();
        }

    }

    }
    

