using System;
using System.Windows.Automation;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace ScreenObjectsHelpers.Windows.Options
{
    public class CustomActionsTab : OptionsWindow
    {
        private readonly UIItemContainer customActionsTab;
        public CustomActionsTab(Window mainWindow, UIItemContainer optionsWindow) : base(mainWindow, optionsWindow)
        {
            customActionsTab = optionsWindow;
        }

        public override void ValidateWindow()
        {
            // Need verify opened tab in this method, need implementation! If validation is fail, throw exception!
            Console.WriteLine("WAIT FOR OPENING TAB");
        }

        #region UIItems
        public override UIItem UIElementTab
        {
            get
            {
                return OptionsWindowContainer.Get<UIItem>(SearchCriteria.ByText("Custom Actions"));
            }
        }

        public Button AddCustomActionButton => customActionsTab.Get<Button>(SearchCriteria.ByText("Add"));
        public Button EditCustomActionButton => customActionsTab.Get<Button>(SearchCriteria.ByText("Edit"));
        public Button DeleteCustomActionButton => customActionsTab.Get<Button>(SearchCriteria.ByText("Delete"));
        public ListView AllCustomActions => customActionsTab.Get<ListView>(SearchCriteria.ByClassName("ListView"));
        #endregion

        #region Methods 
        public EditCustomActionWindow ClickAddCustomActionButton()
        {
            AddCustomActionButton.Click();
            var editCustomActionsWindow = MainWindow.MdiChild(SearchCriteria.ByText("Edit Custom Action"));
            return new EditCustomActionWindow(MainWindow, customActionsTab, editCustomActionsWindow);
        }
        public bool IsMenuCaptionExists(string condition)
        {
            for (int i = 0; i < AllCustomActions.Items.Count; i++)
            {
                if (AllCustomActions.Items[i].Contains(condition))
                {
                    AllCustomActions.Select(i);
                    return true;
                }
            }
            return false;
         }
        #endregion
    }
}