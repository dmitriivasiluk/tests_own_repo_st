using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WPFUIItems;

namespace ScreenObjectsHelpers.Windows
{
    public class UpdatesWindow 
    {
        private Button UpdateCheckForUpdateButton;
        private Button OKButton;
        private UIItem updatesFromOptionTab;
        private Window mainWindow;

        public UpdatesWindow(UIItem updatesFromOptionTab, Window mainWindow)
        {
            this.updatesFromOptionTab = updatesFromOptionTab;
            this.mainWindow = mainWindow;
        }

        public void ClickCheckForUpdateButton()
        {
            UpdateCheckForUpdateButton = mainWindow.Get<Button>(SearchCriteria.ByText("Check For Updates"));
            UpdateCheckForUpdateButton.Click();
            OKButton = mainWindow.Get<Button>(SearchCriteria.ByText("OK"));
            OKButton.Click();

        }
    }
}
