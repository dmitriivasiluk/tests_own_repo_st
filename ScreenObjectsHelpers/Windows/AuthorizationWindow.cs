using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using static TestStack.White.WindowsAPI.KeyboardInput;

namespace ScreenObjectsHelpers.Windows
{
    public class AuthorizationWindow : BasicWindow
    {
        private readonly Window authorizationWindow;

        public AuthorizationWindow(Window mainWindow, Window authorizationWindow) : base(mainWindow)
        {
            this.authorizationWindow = authorizationWindow;
            ValidateWindow();
        }

        public void ValidateWindow()
        {
            var logInByGoogleButton = LogInByGoogle; // Check that this element exist in current window.
        }

        #region UIElements
        public Button LogInByGoogle => authorizationWindow.Get<Button>(SearchCriteria.ByText("Log in with Google"));
        public TextBox EmailTextBox => authorizationWindow.Get<TextBox>(SearchCriteria.ByText("Email"));
        public TextBox PasswordTextBox => authorizationWindow.Get<TextBox>(SearchCriteria.ByText("Password"));
        public Button NextButton => authorizationWindow.Get<Button>(SearchCriteria.ByText("NextLog inLoading"));
        #endregion

        #region Methods
        public InstallationWindow SignIn(string loginEmail, string password)
        {
            // It is workaround method, because I can't catch TextEdit fields from authorization window. Need time to resolve this issue
            // Need to reimplement in future. 
            ThreadWait(1000);
            Keyboard.Instance.Enter(loginEmail);
            ClickOnElement(NextButton);
            ThreadWait(1000);
            Keyboard.Instance.Enter(password);
            ClickOnElement(NextButton);
            ThreadWait(1000);
            Keyboard.Instance.PressSpecialKey(SpecialKeys.RETURN);
            ThreadWait(8000);
            return new InstallationWindow(MainWindow);
        }
        #endregion

    }
}
