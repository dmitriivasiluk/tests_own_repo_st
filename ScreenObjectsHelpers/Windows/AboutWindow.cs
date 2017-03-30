using System;
using System.Windows.Automation;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace ScreenObjectsHelpers.Windows
{
    public class AboutWindow : GeneralWindow
    {
        public AboutWindow(Window mainWindow, UIItemContainer aboutWindow) : base(mainWindow)
        {
            AboutWindowContainer = aboutWindow;
        }

        public UIItemContainer AboutWindowContainer { get; }
        public override void ValidateWindow()
        {
            // Need verify opened tab in this method, need implementation! If validation is fail, throw exception!
            Console.WriteLine("WAIT FOR OPENING _ABOUT_ WINDOW");
        }
        #region UIItems

        public TextBox HeaderOfAboutWindow
        {
            get
            {
                var controlElement = AboutWindowContainer.GetElement(SearchCriteria.ByText("About SourceTree").AndControlType(ControlType.Text));
                return controlElement != null ? new TextBox(controlElement, AboutWindowContainer.ActionListener) : null;
            }
        }
        public TextBox AppVersion 
        {
            get
            {
                var controlElement = AboutWindowContainer.GetElement(SearchCriteria.ByText("Version 2.0.14.1").AndControlType(ControlType.Text));
                return controlElement != null ? new TextBox(controlElement, AboutWindowContainer.ActionListener) : null;
            }
        }
        public TextBox CopyrightCaption
        {
            get
            {
                var controlElement = AboutWindowContainer.GetElement(SearchCriteria.ByText("Copyright Atlassian 2012-2017. All Rights Reserved.").AndControlType(ControlType.Text));
                return controlElement != null ? new TextBox(controlElement, AboutWindowContainer.ActionListener) : null;
            }
        }
        public Button CloseAboutWindowButton => AboutWindowContainer.Get<Button>(SearchCriteria.ByAutomationId("CloseWindow"));
        #endregion
        
        #region Methods

        public string GetHeader()
        {
            return HeaderOfAboutWindow.Name;
        }
        public string GetAppVersion()
        {
            return AppVersion.Name;
        }
        public string GetCopyrightCaption()
        {
            return CopyrightCaption.Name;
        }
        public NewTabWindow CloseAboutWindowButtonClick()
        {
            CloseAboutWindowButton.Click();
            return new NewTabWindow(MainWindow);
        }
        #endregion
    }
}