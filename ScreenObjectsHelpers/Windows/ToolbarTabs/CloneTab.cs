using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Finders;
using System.Windows.Automation;
using ScreenObjectsHelpers.Helpers;

namespace ScreenObjectsHelpers.Windows.ToolbarTabs
{
    public class CloneTab : NewTabWindow
    {
        public CloneTab(TestStack.White.UIItems.WindowItems.Window mainWindow) : base(mainWindow)
        {
        }

        #region UIElements
        public override UIItem ToolbarTabButton => MainWindow.Get<UIItem>(SearchCriteria.ByText("Clone"));
        public Label RemoteAccountLabel => MainWindow.Get<Label>(SearchCriteria.ByAutomationId("remote account"));
        public TextBox SourcePathTextBox => MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("SourceTextBox"));
        private Button DetailsButton => MainWindow.Get<Button>(SearchCriteria.ByText("Details..."));

        private UIItem NoPathUrlSuppliedText => MainWindow.Get<UIItem>(SearchCriteria.ByText("No path / URL supplied"));
        private UIItem NotValidSourcePathText => MainWindow.Get<UIItem>(SearchCriteria.ByText("This is not a valid source path / URL"));
        private UIItem CheckingSourceText => MainWindow.Get<UIItem>(SearchCriteria.ByText("Checking source..."));
        private UIItem GitRepoValidText => MainWindow.Get<UIItem>(SearchCriteria.ByText("This is a Git repository"));
        private UIItem MercurialRepoValidText => MainWindow.Get<UIItem>(SearchCriteria.ByText("This is a Mercurial repository"));

        public ComboBox LocalFolderComboBox => MainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("CloneBookmarksFolderList"));
        public Button CloneButton => MainWindow.Get<Button>(SearchCriteria.ByText("Clone"));
        public Button AdvancedOptionsButton => MainWindow.Get<Button>(SearchCriteria.ByAutomationId("HeaderSite"));
        public CheckBox RecurseSubmodulesCheckBox => MainWindow.Get<CheckBox>(SearchCriteria.ByText("Recurse submodules"));
        public CheckBox NoHardlinksCheckBox => MainWindow.Get<CheckBox>(SearchCriteria.ByText("No hardlinks"));

        //AutomationID_required
        /*
        public TextBox DestinationPathTextBox => MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId(""));

        public TextBox NameTextBox => MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId(""));

        public Button SourcePathButton => MainWindow.Get<Button>(SearchCriteria.ByAutomationId(""));

        public Button DestinationPathButton => MainWindow.Get<Button>(SearchCriteria.ByAutomationId(""));

        public ComboBox CheckoutBranchComboBox => MainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId(""));

        public TextBox CloneDepthTextBox => MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId(""));
        */
        #endregion

        #region Methods 

        public Boolean IsAdvancedOptionsExpanded()
        {
            if (AdvancedOptionsButton.State == ToggleState.On)
            {
                return true;
            }
            return false;
        }

        public void AdvancedOptionsExpand()
        {
            if (IsAdvancedOptionsExpanded())
            {
                return;
            }
            else
            {
                AdvancedOptionsButton.Click();
            }
        }

        public void AdvancedOptionsCollapse()
        {
            if (!IsAdvancedOptionsExpanded())
            {
                return;
            }
            else
            {
                AdvancedOptionsButton.Click();
            }
        }       

        public void ValidateRepoLinkEnableCloneButton()
        {
            //AutomationID_required - temporary workaround
            var DestinationPathTextBox = MainWindow.GetMultiple(SearchCriteria.ByClassName("TextBox"))[1];
            var NameTextBox = MainWindow.GetMultiple(SearchCriteria.ByClassName("TextBox"))[2];

            DestinationPathTextBox.Focus();
            Utils.ThreadWait(6000);
            NameTextBox.Focus();
        }

        public string ValidateMercurialLink()
        {
            ValidateRepoLinkEnableCloneButton();

            if (MercurialRepoValidText.Enabled)
            {
                return ConstantsList.mercurial;
            }
            return null;
        }

        public string ValidateGitLink()
        {
            ValidateRepoLinkEnableCloneButton();

            if (GitRepoValidText.Enabled)
            {
                return ConstantsList.git;
            }
            return null;
        }

        public Boolean IsCloneButtonEnabled()
        {
            ValidateRepoLinkEnableCloneButton();

            return CloneButton.Enabled;
        }

        //TODO return repository tab
        public void ClickCloneButton()
        {
            if (IsCloneButtonEnabled())
            {
                CloneButton.Click();
            }
        }
        #endregion
    }
}
