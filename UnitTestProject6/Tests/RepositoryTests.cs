using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
using SourceTreeAutomation.Helpers;

namespace SourceTreeAutomation.Tests
{
    class RepositoryTests : BasicTest
    {
        private Menu Action;
        private Button OKButton;
        private Button UpdateCheckForUpdateButton;
        private UIItem UpdatesTab;
        [Test]
        public void CheckForUpdatesTest()
        {
            Action = MainWindow.Get<Menu>(SearchCriteria.ByText("Tools"));
            Action.SubMenu("Options").Click();
            MainWindow.WaitWhileBusy();
            var OptionsWindow = MainWindow.MdiChild(SearchCriteria.ByText("Options"));
            OptionsWindow.Click();   
             UpdatesTab =OptionsWindow.Get<UIItem>(SearchCriteria.ByText("Updates"));
            UpdatesTab.Click();
             UpdateCheckForUpdateButton = OptionsWindow.Get<Button>(SearchCriteria.ByText("Check For Updates"));
            UpdateCheckForUpdateButton.Click();
            MainWindow.WaitWhileBusy();
            OKButton = OptionsWindow.Get<Button>(SearchCriteria.ByText("OK"));
            try
            {
                OKButton.Click();
            }
            catch (Exception e)
            {
                ScreenshotsTaker a = new ScreenshotsTaker();
                a.TakeScreenShot();
            }

        }

    }
    }

