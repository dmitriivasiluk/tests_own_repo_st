using ScreenObjectsHelpers.Windows.Options;
using ScreenObjectsHelpers.Windows.MenuFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White;
using System.Threading;

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
        public Button ContinueButton
        {
            get
            {
                return MainWindow.Get<Button>(SearchCriteria.ByText("Continue"));
            }
        }

        public CheckBox LicenceAgreementCheckbox
        {
            get
            {
                return MainWindow.Get<CheckBox>(SearchCriteria.ByText("I agree to the "));
            }
        }

        public Button UseExistingAccount
        {
            get
            {
                return MainWindow.Get<Button>(SearchCriteria.ByText("Use an existing account"));
            }
        }
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
                bool found = false;
                try
                {
                    var item = c.Get<Button>(SearchCriteria.ByText("Log in with Google"));
                    found = true;
                }
                catch (Exception)
                {
                }
                return c.IsModal == false && found;
            }); // Login window is opened without Name (title), so it is best way to find a window.
            return new AuthorizationWindow(MainWindow, authorizationWindow);
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

        #endregion


    }
}
