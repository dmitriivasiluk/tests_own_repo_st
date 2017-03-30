using NUnit.Framework;
using ScreenObjectsHelpers.Windows;
using ScreenObjectsHelpers.Windows.Options;
using ScreenObjectsHelpers.Windows.MenuFolder;

namespace AutomationTestsSolution.Tests
{
    class CustomActionsTests : BasicTest
    {

        [Test]
        public void AddCustomAction()
        {
            const string testData = "test1";
            NewTabWindow mainWindow = new NewTabWindow(MainWindow);
            OptionsWindow optionsWindows = mainWindow.OpenMenu<ToolsMenu>().OpenOptions();
            CustomActionsTab customActionsTab = optionsWindows.OpenTab<CustomActionsTab>();
            var isMenuCaptionExistsBeforeTest = customActionsTab.IsMenuCaptionExists(testData);
            var editCustomActionWindow = customActionsTab.ClickAddCustomActionButton();
            editCustomActionWindow.SetMenuCaption(testData);
            editCustomActionWindow.SetScriptToRun(testData);
            editCustomActionWindow.ClickOnOKButton();

            Assert.IsFalse(isMenuCaptionExistsBeforeTest);
            Assert.IsTrue(customActionsTab.IsMenuCaptionExists(testData));
         }
     }

}


