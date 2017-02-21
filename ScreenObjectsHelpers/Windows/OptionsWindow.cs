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
   
        private Button OKButton;
        private Button UpdateCheckForUpdateButton;
        private UIItemContainer optionsWindow;
        private Window mainWindow;

        public OptionsWindow(UIItemContainer optionsWindow, Window mainWindow)
        {
            this.optionsWindow = optionsWindow;
            this.mainWindow = mainWindow;
        }

        public UpdatesWindow GetUpdatesWindow()
        {
            var UpdatesFromOptionTab = optionsWindow.Get<UIItem>(SearchCriteria.ByText("Updates"));
            UpdatesFromOptionTab.Click();
            return new UpdatesWindow(UpdatesFromOptionTab, mainWindow);


        }
        public UIItem ClickOkButton()
        {
            UpdateCheckForUpdateButton = optionsWindow.Get<Button>(SearchCriteria.ByText("Check For Updates"));
            UpdateCheckForUpdateButton.Click();
            OKButton = optionsWindow.Get<Button>(SearchCriteria.ByText("OK"));
            OKButton.Click();
            return OKButton;

        }
    }
}
