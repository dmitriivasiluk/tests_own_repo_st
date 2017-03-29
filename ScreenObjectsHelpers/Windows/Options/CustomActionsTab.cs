using System;
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
        #endregion

        #region Methods 
        public EditCustomActionWindow ClickAddCustomActionButton()
        {
            AddCustomActionButton.Click();
            var editCustomActionsWindow = MainWindow.MdiChild(SearchCriteria.ByText("Edit Custom Action"));
            return new EditCustomActionWindow(MainWindow, customActionsTab, editCustomActionsWindow);
        }
        
        //public EditCustomActionWindow ClickEditCustomActionButton()
        //{
        //    EditCustomActionButton.Click();
        //    var editCustomActionsWindow = MainWindow.MdiChild(SearchCriteria.ByText("Edit Custom Action"));
        //    return new EditCustomActionWindow(MainWindow, customActionsTab, editCustomActionsWindow);
        //}
        #endregion
    }
}