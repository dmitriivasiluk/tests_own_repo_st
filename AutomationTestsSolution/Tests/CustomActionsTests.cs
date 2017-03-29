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
            NewTabWindow mainWindow = new NewTabWindow(MainWindow);
            OptionsWindow optionsWindows = mainWindow.OpenMenu<ToolsMenu>().OpenOptions();
            CustomActionsTab customActionsTab = optionsWindows.OpenTab<CustomActionsTab>();
            var editCustomActionWindow = customActionsTab.ClickAddCustomActionButton();
            editCustomActionWindow.SetMenuCaption("test1");
            editCustomActionWindow.SetScriptToRun("test1");
        }
        
        
    }

}


