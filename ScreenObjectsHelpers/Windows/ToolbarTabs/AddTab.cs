using ScreenObjectsHelpers.Helpers;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace ScreenObjectsHelpers.Windows.ToolbarTabs
{
    public class AddTab : NewTabWindow
    {
        public AddTab(TestStack.White.UIItems.WindowItems.Window mainWindow) : base(mainWindow)
        {
        }

        #region UIElements
        public override UIItem ToolbarTabButton => MainWindow.Get<UIItem>(SearchCriteria.ByText("Add"));

        public Button BrowseButton => MainWindow.Get<Button>(SearchCriteria.ByText("Browse"));

        public Button AddButton => MainWindow.Get<Button>(SearchCriteria.ByText("Add"));

        private UIItem GitRepoValidText => MainWindow.Get<UIItem>(SearchCriteria.ByText("This is a Git repository"));

        private UIItem MercurialRepoValidText => MainWindow.Get<UIItem>(SearchCriteria.ByText("This is a Mercurial repository"));

        private UIItem NotValidSourcePathText => MainWindow.Get<UIItem>(SearchCriteria.ByText("This is not a valid working copy path."));

        private UIItem NoWorkingCopyPathSuppliedText => MainWindow.Get<UIItem>(SearchCriteria.ByText("No working copy path supplied"));


        //AutomationID_required Temporary workaround
        public IUIItem WorkingCopyPathTextBox => MainWindow.GetMultiple(SearchCriteria.ByClassName("TextBox"))[0];

        public IUIItem NameTextBox => MainWindow.GetMultiple(SearchCriteria.ByClassName("TextBox"))[1];

        //AutomationID_required
        /*
        public TextBox WorkingCopyPathTextBox => MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId(""));

        public TextBox NameTextBox => MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId(""));

        public ComboBox LocalFolderComboBox => MainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId(""));
        */
        #endregion

        #region Methods
        public void ValidateFolder()
        {
            NameTextBox.Focus();
            Utils.ThreadWait(2000);
        }

        public string GetGitValidationMessage()
        {
            ValidateFolder();

            if (GitRepoValidText.Enabled && GitRepoValidText.Visible)
            {
                return ConstantsList.gitRepoType;
            }
            return null;
        }

        public string GetMercurialValidationMessage()
        {
            ValidateFolder();

            if (MercurialRepoValidText.Enabled && MercurialRepoValidText.Visible)
            {
                return ConstantsList.mercurialRepoType;
            }
            return null;
        }

        public string GetInvalidRepoMessage()
        {
            ValidateFolder();

            if (NotValidSourcePathText.Enabled && NotValidSourcePathText.Visible)
            {
                return ConstantsList.invalidFolder;
            }
            return null;
        }

        public string GetEmptyPathMessage()
        {
            ValidateFolder();

            if (NoWorkingCopyPathSuppliedText.Enabled && NoWorkingCopyPathSuppliedText.Visible)
            {
                return ConstantsList.emptyPath;
            }
            return null;
        }

        //TODO return OpenWorkingCopyWindow class
        public void ClickBrowseButton()
        {
            ClickButton(BrowseButton);
        }

        #endregion
    }
}
