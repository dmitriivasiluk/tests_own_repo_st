using ScreenObjectsHelpers.Windows.Options;
using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace ScreenObjectsHelpers.Windows
{
    public class EditCustomActionWindow : GeneralWindow
    {
        private UIItemContainer customActionsWindow;
        private UIItemContainer customActionsTab;

        public EditCustomActionWindow(Window mainWindow, UIItemContainer customActionsTab, UIItemContainer customActionsWindow)
            : base(mainWindow)
        {
            this.customActionsWindow = customActionsWindow;
            this.customActionsTab = customActionsTab;
        }

        public override void ValidateWindow()
        {
            // Need verify opened tab in this method, need implementation! If validation is fail, throw exception!
            Console.WriteLine("WAIT FOR OPENING _Edit_Custom_action_Window");
        }

        #region UIItems
        public TextBox MenuCaption => customActionsWindow.Get<TextBox>(SearchCriteria.ByAutomationId("CaptionBox"));
        public CheckBox OpenInASeparateWindow 
        {
            get
            {
                return customActionsWindow.Get<CheckBox>(SearchCriteria.ByText("Open in a separate window"));
            }
        }
        public CheckBox ShowFullOutput
        {
            get
            {
                return customActionsWindow.Get<CheckBox>(SearchCriteria.ByText("Show Full Output"));
            }
        }
        public TextBox ScriptToRun => customActionsWindow.Get<TextBox>(SearchCriteria.ByAutomationId(""/*required automation ID*/));
        public TextBox Parameters => customActionsWindow.Get<TextBox>(SearchCriteria.ByAutomationId(""/*required automation ID*/));
        public Button OkButton => customActionsWindow.Get<Button>(SearchCriteria.ByText("OK"));
        public Button CancelButton => customActionsWindow.Get<Button>(SearchCriteria.ByText("Cancel"));
        #endregion

        #region Methods
        public void SetMenuCaption(string menuCaption)
        {
            MenuCaption.Text = menuCaption;
        }

        public void SetScriptToRun(string scriptToRun)
        {
            SetScriptToRun.Text = scriptToRun;
        }

        public CustomActionsTab ClickOnOKButton()
        {
            OkButton.Click();
            return new CustomActionsTab(MainWindow, customActionsTab);
        }
        public CustomActionsTab ClickOnCancelButton()
        {
            CancelButton.Click();
            return new CustomActionsTab(MainWindow, customActionsTab);
        }
        #endregion
    }
}
