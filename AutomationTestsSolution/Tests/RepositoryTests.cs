using System;
using System.Diagnostics;
using System.Linq;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.WindowsAPI;
using TestStack.White;
using NUnit.Framework;
using TestStack.White.UIItems.WindowItems;
using ScreenObjectsHelpers.Helpers;
using ScreenObjectsHelpers.Windows;
using ScreenObjectsHelpers.Windows.Options;
using ScreenObjectsHelpers.Windows.MenuFolder;

namespace AutomationTestsSolution.Tests
{
    class RepositoryTests : BasicTest
    {
     
       [Test]
        public void CheckForUpdatesTest()
        {
            NewTabWindow mainWindow = new NewTabWindow(MainWindow);
            mainWindow = mainWindow.OpenMenu<FileMenu>().OpenCloneNew();

            OptionsWindow optionsWindows = mainWindow.OpenMenu<Tools>().OpenOptions();
            UpdatesTab updatesTab = optionsWindows.SwitchUpdatesTab();
            updatesTab.CheckForUpdate();
        }

    }

    }
    

