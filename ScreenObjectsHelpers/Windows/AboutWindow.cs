using System;
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
        public Label HeaderOfAboutWindow => AboutWindowContainer.Get<Label>(SearchCriteria.ByText("About SourceTree"));

        public Label AppVersion => AboutWindowContainer.Get<Label>(SearchCriteria.ByText("Version 2.0.14.1"));

        public Label CopyrightCaption => AboutWindowContainer.Get<Label>(SearchCriteria.ByText("Copyright Atlassian 2012-2017. All Rights Reserved."));

        public Button CloseAboutWindowButton => AboutWindowContainer.Get<Button>(SearchCriteria.ByAutomationId("CloseWindow"));
        #endregion
        
        #region Methods
        public string GetHeader()
        {
            return HeaderOfAboutWindow.Text;
        }
        public string GetAppVersion()
        {
            return HeaderOfAboutWindow.Text;
        }
        public string GetCopyrightCaption()
        {
            return HeaderOfAboutWindow.Text;
        }
        public NewTabWindow CloseAboutWindowButtonClick()
        {
            CloseAboutWindowButton.Click();
            return new NewTabWindow(MainWindow);
        }
        #endregion

    }
}
