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
        private Menu ToolsMenu;
        public RepositoryWindow(Window mainWindow) : base(mainWindow)
        {
        }


        public void getOptionsWindow()
        {
            ToolsMenu = MainWindow.Get<Menu>(SearchCriteria.ByText("Tools"));
            ToolsMenu.SubMenu("Options").Click();


        }
        public OptionsWindow SwithToOptionsWindow()
        {
            var OptionsWindow = MainWindow.MdiChild(SearchCriteria.ByText("Options"));
            OptionsWindow.Click();
            return new OptionsWindow(OptionsWindow, MainWindow);
        }
    }
}
