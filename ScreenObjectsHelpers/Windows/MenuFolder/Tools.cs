using ScreenObjectsHelpers.Windows.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;

namespace ScreenObjectsHelpers.Windows.MenuFolder
{
    public class Tools : MenuBar
    {
        private const string launchSSHAgent = "Launch SSH Agent...";
        private const string createImportSSHKeys = "Create or Import SSH Keys";
        private const string options = "Options";

        public Tools(Window mainWindow) : base(mainWindow)
        {
        }

        public override Menu UIElementMenu
        {
            get
            {
                return MainWindow.Get<Menu>(SearchCriteria.ByText("Tools"));
            }
        }

        public OptionsWindow OpenOptions()
        {
            UIElementMenu.SubMenu(options).Click();
            var optionsWindow = MainWindow.MdiChild(SearchCriteria.ByText(options));
            return new OptionsWindow(MainWindow, optionsWindow);
        }

   
    }
}
