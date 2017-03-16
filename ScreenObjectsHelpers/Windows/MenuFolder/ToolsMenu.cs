using ScreenObjectsHelpers.Windows.Options;
using System;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;

namespace ScreenObjectsHelpers.Windows.MenuFolder
{
    public class ToolsMenu : MenuBar
    {
        private const string launchSSHAgent = "Launch SSH Agent...";
        private const string createImportSSHKeys = "Create or Import SSH Keys";
        private const string options = "Options";

        public ToolsMenu(Window mainWindow) : base(mainWindow)
        {
        }

        public override Menu UIElementMenu
        {
            get
            {
                return MainWindow.Get<Menu>(SearchCriteria.ByText("Tools"));
            }
        }

        public void LaunchSSHAgent()
        {
            UIElementMenu.SubMenu(launchSSHAgent).Click();
        }

        public object CreateImportSSHKeys()
        {
            UIElementMenu.SubMenu(createImportSSHKeys).Click();
            throw new NotImplementedException("No corresponding class");
        }

        public OptionsWindow OpenOptions()
        {
            UIElementMenu.SubMenu(options).Click();
            var optionsWindow = MainWindow.MdiChild(SearchCriteria.ByText(options));
            return new GeneralTab(MainWindow, optionsWindow);
        }


    }
}
