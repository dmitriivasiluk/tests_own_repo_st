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
       
        #region UIElementss
        public UIItemContainer OptionsWindowContainer { get; }
        #endregion
        #region Methods
        public UpdatesTab SwitchUpdatesTab()
        {
            var toolsOptionsUpdatesTab = OptionsWindowContainer.Get<UIItem>(SearchCriteria.ByText("Updates"));
            toolsOptionsUpdatesTab.Click();
            return new UpdatesTab(MainWindow, OptionsWindowContainer, toolsOptionsUpdatesTab);
        }
        public GitTab SwitchGitTab()
        {
            var toolsOptionsGitTab = OptionsWindowContainer.Get<UIItem>(SearchCriteria.ByText("Git"));
            toolsOptionsGitTab.Click();
            return new GitTab(MainWindow, OptionsWindowContainer, toolsOptionsGitTab);
        }
        #endregion

    }
}
