using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace ScreenObjectsHelpers.Windows.Options
{
    public class NetworkTab : OptionsWindow
    {
        public NetworkTab(Window mainWindow, UIItemContainer optionsWindow) : base(mainWindow, optionsWindow)
        {
        }

        public override void ValidateWindow()
        {
            // Need verify opened tab in this method, need implementation! If validation is fail, throw exception!
            Console.WriteLine("WAIT FOR OPENING TAB");
        }

        #region UIElements        
        public override UIItem UIElementTab
        {
            get
            {
                return OptionsWindowContainer.Get<UIItem>(SearchCriteria.ByText("Network"));
            }
        }

        public RadioButton UseDefaultProxy
        {
            get
            {
                return OptionsWindowContainer.Get<RadioButton>(SearchCriteria.ByText("Use default operating system settings"));
            }
        }

        public RadioButton UseCustomProxy
        {
            get
            {
                return OptionsWindowContainer.Get<RadioButton>(SearchCriteria.ByText("Use custom proxy settings"));
            }
        }

        // Automation IDs required
        /*
        public TextBox ServerField
        {
            get
            {
                return OptionsWindowContainer.Get<TextBox>(SearchCriteria.ByAutomationId(""));
            }
        }

        public TextBox PortField
        {
            get
            {
                return OptionsWindowContainer.Get<TextBox>(SearchCriteria.ByAutomationId(""));
            }
        }
        */

        public CheckBox ProxyRequiresPassword
        {
            get
            {
                return OptionsWindowContainer.Get<CheckBox>(SearchCriteria.ByText("Proxy server requires username and password"));
            }
        }

        public CheckBox AddProxyConfiguration
        {
            get
            {
                return OptionsWindowContainer.Get<CheckBox>(SearchCriteria.ByText("Add proxy server configuration to Git / Mercurial"));
            }
        }

        public CheckBox EnableSsl
        {
            get
            {
                return OptionsWindowContainer.Get<CheckBox>(SearchCriteria.ByText("Enable SSL3"));
            }
        }

        public CheckBox EnableTls11
        {
            get
            {
                return OptionsWindowContainer.Get<CheckBox>(SearchCriteria.ByText("Enable TLS 1.1"));
            }
        }

        public CheckBox EnableTls12
        {
            get
            {
                return OptionsWindowContainer.Get<CheckBox>(SearchCriteria.ByText("Enable TLS 1.2"));
            }
        }

        public Button UsernameAndPassword
        {
            get
            {
                return OptionsWindowContainer.Get<Button>(SearchCriteria.ByText("Username and Password..."));
            }
        }
        #endregion

        #region Methods        
        public ProxyAuthenticationWindow OpenUsernameAndPassword()
        {
            UsernameAndPassword.Click();
            var proxyAuthenticationWindow = MainWindow.MdiChild(SearchCriteria.ByText("Authenticate"));
            return new ProxyAuthenticationWindow(MainWindow, OptionsWindowContainer, proxyAuthenticationWindow);
        }
        #endregion
    }
}