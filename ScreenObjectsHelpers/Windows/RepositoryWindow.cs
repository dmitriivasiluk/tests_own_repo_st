using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;


namespace ScreenObjectsHelpers.Windows
{
   public class RepositoryWindow : BasicWindow
    {
        private Menu toolsMenu;
        public RepositoryWindow(Window mainWindow) : base(mainWindow)
        {
        }
        public OptionsWindow SwithToOptionsWindow()
        {
            toolsMenu = MainWindow.Get<Menu>(SearchCriteria.ByText("Tools"));
            toolsMenu.SubMenu("Options").Click();
            var optionsWindow = MainWindow.MdiChild(SearchCriteria.ByText("Options"));
            optionsWindow.Click();
            return new OptionsWindow(optionsWindow, MainWindow);
        }
    }
}
