using System;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using ScreenObjectsHelpers.Helpers;
using System.Windows.Automation;
using TestStack.White.InputDevices;

namespace ScreenObjectsHelpers.Windows.Repository
{
    public class GitFlowInitialiseWindow : GeneralWindow
    {
        public GitFlowInitialiseWindow(Window mainWindow) : base(mainWindow)
        {
        }
        public override void ValidateWindow()
        {
            // Need verify opened tab in this method, need implementation! If validation is fail, throw exception!
            Console.WriteLine("WAIT FOR OPENING TAB");
        }

        #region UIItems
        public TextBox ProductionBranch => MainWindow.Get<TextBox>(SearchCriteria.ByControlType(ControlType.Edit).AndIndex(1));
        public TextBox DevelopmentBranch => MainWindow.Get<TextBox>(SearchCriteria.ByControlType(ControlType.Edit).AndIndex(2));
        public TextBox FeatureBranch => MainWindow.Get<TextBox>(SearchCriteria.ByControlType(ControlType.Edit).AndIndex(3));
        public TextBox ReleaseBranch => MainWindow.Get<TextBox>(SearchCriteria.ByControlType(ControlType.Edit).AndIndex(4));
        public TextBox HotfixBranch => MainWindow.Get<TextBox>(SearchCriteria.ByControlType(ControlType.Edit).AndIndex(5));
        public TextBox VersionTag => MainWindow.Get<TextBox>(SearchCriteria.ByControlType(ControlType.Edit).AndIndex(6));
        public TextBox OKButton => MainWindow.Get<TextBox>(SearchCriteria.ByText("OK"));
        public TextBox CancelButton => MainWindow.Get<TextBox>(SearchCriteria.ByText("Cancel"));
        public TextBox UseDefaultsButton => MainWindow.Get<TextBox>(SearchCriteria.ByText("UseDefaults"));
        #endregion

        #region Methods
        public void ClickOkButton()
        {
            OKButton.Click();
        }
        public RepositoryTab ClickCancelButton()
        {
            CancelButton.Click();
            return new RepositoryTab(MainWindow);
        }
        public void ClickUseDefaultsButton()
        {
            UseDefaultsButton.Click();
        }
        public bool TextboxDefaultContent(TextBox textbox, string expectedContent)
        {
            return textbox.Text.Equals(expectedContent);
        }
        public bool IsVersionTagEmpty()
        {
            return VersionTag.Text.Equals("");
        }
        public void SetTextboxContent(TextBox textbox, string content)
        {
            textbox.Focus();
            Keyboard.Instance.Enter(content);
        }
        #endregion

    }
}
