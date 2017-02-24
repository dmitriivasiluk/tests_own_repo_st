using ScreenObjectsHelpers.Windows.Options;
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
    /// <summary>
    /// This is general class for give other window common method like Menu Bar, workings with tab etc.
    /// </summary>
    public abstract class GeneralWindow : BasicWindow
    {
     
        public GeneralWindow(Window mainWindow) : base(mainWindow)
        {
        }

        #region Elements Menu
        private Menu ToolsMenu
        {
            get 
            {
                return MainWindow.Get<Menu>(SearchCriteria.ByText("Tools"));
            }
        }
        #endregion

        #region Methods
        public OptionsWindow SwitchToOptionsWindow()
        {
            ToolsMenu.SubMenu("Options").Click();
            var optionsWindow = MainWindow.MdiChild(SearchCriteria.ByText("Options"));
            optionsWindow.Click();
            return new OptionsWindow(MainWindow, optionsWindow);
        }
        #endregion
    }
}
