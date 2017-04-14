using System;
using System.Linq;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White;
using System.Windows.Automation;
using TestStack.White.UIItems.ListBoxItems;
using ScreenObjectsHelpers.Helpers;

namespace ScreenObjectsHelpers.Windows
{

    public class InstallationWindow : BasicWindow
    {

        public InstallationWindow(Window mainWindow) : base(mainWindow)
        {
            ValidateWindow();
        }

        public void ValidateWindow()
        {

        }

        #region UIElements
        public Button ContinueButton => MainWindow.Get<Button>(SearchCriteria.ByText("Continue"));
        public Button UseExistingAccount => MainWindow.Get<Button>(SearchCriteria.ByText("Use an existing account"));
        public Button SkipSetupButton => MainWindow.Get<Button>(SearchCriteria.ByText("Skip Setup"));
        public CheckBox LicenceAgreementCheckbox => MainWindow.Get<CheckBox>(SearchCriteria.ByText("I agree to the "));
        public CheckBox ConfigureAutomaticLineEndingCheckBox => MainWindow.Get<CheckBox>(SearchCriteria.ByText("Configure automatic line ending handling by default (recommended)"));
        public Label RegistrationCompleteText => MainWindow.Get<Label>(SearchCriteria.ByText("Registration Complete!"));
        public Label EmailLoggedAs => MainWindow.Get<Label>(SearchCriteria.ByText("")); 
        public Label DownloadingVersionControlLabel => (Label) MainWindow.Get(SearchCriteria.ByText("Downloading version control systems..."), TimeSpan.FromSeconds(10));
        public Label ToolInstallCompletedLabel => MainWindow.Get<Label>(SearchCriteria.ByText("Tool installation completed."));
        public ListItem GitHubImageButton => MainWindow.Get<ListBox>(SearchCriteria.ByControlType(ControlType.List)).Item("GitHub");
        public ListItem BitbucketImageButton => MainWindow.Get<ListBox>(SearchCriteria.ByControlType(ControlType.List)).Item("Bitbucket");
        public ListItem BitbucketServerImageButton => MainWindow.Get<ListBox>(SearchCriteria.ByControlType(ControlType.List)).Item("Bitbucket Server");
        public ComboBox AuthenticationComboBox => MainWindow.Get<ComboBox>(SearchCriteria.ByControlType(ControlType.ComboBox));
        public TextBox UsernameField => MainWindow.Get<TextBox>(SearchCriteria.ByClassName("TextBox").AndIndex(1));
        public TextBox PasswordField => MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("Password"));
        public TextBox HostUrlField => MainWindow.Get<TextBox>(SearchCriteria.ByClassName("TextBox").AndIndex(0));
        public ProgressBar InstallTollsProgressBar => MainWindow.Get<ProgressBar>(SearchCriteria.ByControlType(ControlType.ProgressBar));
        #endregion

        #region Methods
        public void ClickContinueButton()
        {
            ClickOnButton(ContinueButton);
        }

        public AuthorizationWindow ClickUseExistingAccount()
        {
            ClickOnButton(UseExistingAccount);
            Window authorizationWindow = Desktop.Instance.Windows().FirstOrDefault(c =>
            {
                var found = false;
                try
                {
                    var item = c.Get<Button>(SearchCriteria.ByText("Log in with Google"));
                    found = true;
                }
                catch (Exception)
                {
                    // ignored
                }
                return c.IsModal == false && found;
            }); // Login window is opened without Name (title), so it is best way to find a window.
            return new AuthorizationWindow(MainWindow, authorizationWindow);
        }

        public void FillBasicAuthenticationGithub(string userName, string password)
        {
            ChooseGitHubAccount();
            AuthenticationComboBox.Select("Basic");
            UsernameField.Text = userName;
            PasswordField.Text = password;
        }

        public void FillAuthenticationBitBucketServer(string hostURL, string userName, string password)
        {
            ChooseBitBucketServerAccount();
            HostUrlField.Text = hostURL;
            UsernameField.Text = userName;
            PasswordField.Text = password;
        }

        public void FillBasicAuthenticationBitbucket(string userName, string password)
        {
            ChooseBitBucketAccount();
            AuthenticationComboBox.Select("Basic");
            UsernameField.Text = userName;
            PasswordField.Text = password;
        }

        public string DownloadingVersionText()
        {
            return DownloadingVersionControlLabel.Text;
        }

        public string ToolInstallCompleteText()
        {
            return ToolInstallCompletedLabel.Text;
        }

        public void CheckConfigureAutomaticLineEncodingCheckbox()
        {
            if (!ConfigureAutomaticLineEndingCheckBox.Checked)
            {
                ConfigureAutomaticLineEndingCheckBox.Click();
            }
        }

        public void WaitCompleteInstallToolsProgressBar()
        {
            var currentProcent = InstallTollsProgressBar.Value;
            var secondPass = 0;
            while (currentProcent < InstallTollsProgressBar.Maximum)
            {
                Utils.ThreadWait(1000);
                secondPass++;
                currentProcent = InstallTollsProgressBar.Value;
                if (secondPass > 180) // pass 3 minutes
                {
                    throw new TimeoutException();
                }
            }
        }

        public void UncheckConfigureAutomaticLineEncodingCheckbox()
        {
            if (ConfigureAutomaticLineEndingCheckBox.Checked)
            {
                ConfigureAutomaticLineEndingCheckBox.Click();
            }
        }

        public string LoggedAsEmail()
        {
            return EmailLoggedAs.Text;
        }

        public string CompleteText()
        {
            return RegistrationCompleteText.Text;
        }

        public bool IsContinueButtonActive() {
            return ContinueButton.Enabled;
        }

        public void CheckLicenceAgreementCheckbox() {
            bool isChecked = LicenceAgreementCheckbox.Checked;
            if (!isChecked)
            {
                LicenceAgreementCheckbox.Click();
            }
        }

        public void UncheckLicenceAgreementCheckbox()
        {
            bool isChecked = LicenceAgreementCheckbox.Checked;
            if (isChecked)
            {
                LicenceAgreementCheckbox.Click();
            }
        }

        public void ChooseGitHubAccount()
        {
            GitHubImageButton.Click();
        }

        public void ChooseBitBucketAccount()
        {
            BitbucketImageButton.Click();
        }

        public void ChooseBitBucketServerAccount()
        {
            BitbucketServerImageButton.Click();
        }

        public ErrorDialogWindow SwitchToErrorDialogWindow()
        {
            SearchCriteria searchCriteria = SearchCriteria.ByAutomationId("window");
            var errorDialog = this.WaitMdiChildAppears(searchCriteria, 10);
            return new ErrorDialogWindow(MainWindow, errorDialog);
        }
        #endregion
    }

    public class ErrorDialogWindow
    {
        private readonly UIItemContainer errorWindow;
        private readonly Window mainWindow;

        public ErrorDialogWindow(Window mainWindow, UIItemContainer errorWindow)
        {
            this.mainWindow = mainWindow;
            this.errorWindow = errorWindow;
        }

        public Label TitleOfMessageError => errorWindow.Get<Label>(SearchCriteria.ByText("Bad credentials"));
        public Label TitleOfWindowLabel => errorWindow.Get<Label>(SearchCriteria.ByText("Login failed"));
        public Button CancelButton => errorWindow.Get<Button>(SearchCriteria.ByText("Cancel"));

        public string GetTitleOfMessageError()
        {
            return TitleOfMessageError.Text;
        }

        public Window ClickCancelButton()
        {
            CancelButton.Click();
            return mainWindow;
        }

        public string GetTitle()
        {
            return TitleOfWindowLabel.Text;
        }
    }
}
