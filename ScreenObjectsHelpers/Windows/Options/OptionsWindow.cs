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

namespace ScreenObjectsHelpers.Windows.Options
{
   public class OptionsWindow : BasicWindow
    {
   
        public OptionsWindow(Window mainWindow, UIItemContainer optionsWindow) : base(mainWindow)
        {
            OptionsWindowContainer = optionsWindow;
        }
        public override void ValidateWindow()
        {
            // Need verify opened tab in this method, need implementation! If validation is fail, throw exception!
            Console.WriteLine("WAIT FOR OPENING _OPTION_ WINDOW");
        }

        public UIItemContainer OptionsWindowContainer { get; }

        public UpdatesTab SwitchUpdatesTab()
        {
            var toolsOptionsUpdatesTab = OptionsWindowContainer.Get<UIItem>(SearchCriteria.ByText("Updates"));
            toolsOptionsUpdatesTab.Click();
            return new UpdatesTab(MainWindow, OptionsWindowContainer, updatesFromOptionTab);
        }
 
    }
}
