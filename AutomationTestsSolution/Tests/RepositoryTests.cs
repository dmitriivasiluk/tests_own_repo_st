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

namespace AutomationTestsSolution.Tests
{
    class RepositoryTests : BasicTest
    {
     
       [Test]
        public void CheckForUpdatesTest()
        {
            NewTabWindow mainWindow = new NewTabWindow(MainWindow);
            OptionsWindow optionsWindows = mainWindow.SwitchToOptionsWindow();
            UpdatesTab updatesTab = optionsWindows.SwitchUpdatesTab();
            updatesTab.CheckForUpdate();
        }

    }

    }
    

