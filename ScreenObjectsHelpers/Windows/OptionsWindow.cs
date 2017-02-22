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
   public class OptionsWindow 
    {
   
        private Button oKButton;
        private Button checkForUpdateButton;
        private UIItemContainer optionsWindow;
        private Window mainWindow;

        public OptionsWindow(UIItemContainer optionsWindow, Window mainWindow)
        {
            this.optionsWindow = optionsWindow;
            this.mainWindow = mainWindow;
        }

        public UpdatesWindow GetUpdatesWindow()
        {
            var updatesFromOptionTab = optionsWindow.Get<UIItem>(SearchCriteria.ByText("Updates"));
            updatesFromOptionTab.Click();
            return new UpdatesWindow(updatesFromOptionTab, mainWindow);


        }
        public UIItem ClickOkButton()
        {
            checkForUpdateButton = optionsWindow.Get<Button>(SearchCriteria.ByText("Check For Updates"));
            checkForUpdateButton.Click();
            oKButton = optionsWindow.Get<Button>(SearchCriteria.ByText("OK"));
            oKButton.Click();
            return oKButton;

        }
    }
}
