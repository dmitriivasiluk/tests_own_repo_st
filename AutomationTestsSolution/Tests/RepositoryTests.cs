﻿using System;
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

namespace AutomationTestsSolution.Tests
{
    class RepositoryTests : BasicTest
    {
        private Menu Action;
        private Button OKButton;
        private Button UpdateCheckForUpdateButton;
        private UIItem UpdatesTab;
        OptionsWindow optionsWindows;
       [Test]
        public void CheckForUpdatesTest()
        {
            RepositoryWindow mainWindow = new RepositoryWindow(MainWindow);
            mainWindow.getOptionsWindow();
            mainWindow.SwithToOptionsWindow();
            OptionsWindow optionsWindows = mainWindow.SwithToOptionsWindow();
            UpdatesWindow updatesWindow = optionsWindows.GetUpdatesWindow();
            updatesWindow.ClickCheckForUpdateButton();


        }

    }

    }
    

