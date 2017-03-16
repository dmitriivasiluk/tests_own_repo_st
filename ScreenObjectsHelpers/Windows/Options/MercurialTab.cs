using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace ScreenObjectsHelpers.Windows.Options
{
    public class MercurialTab : OptionsWindow
    {
        public MercurialTab(Window mainWindow, UIItemContainer optionsWindow) : base(mainWindow, optionsWindow)
        {
        }

        public override void ValidateWindow()
        {
            // Need verify opened tab in this method, need implementation! If validation is fail, throw exception!
            Console.WriteLine("WAIT FOR OPENING TAB");
        }

        public override UIItem UIElementTab
        {
            get
            {
                return OptionsWindowContainer.Get<UIItem>(SearchCriteria.ByText("Mercurial"));
            }
        }

        public Button UseEmbeddedMercurialButton
        {
            get
            {
                return OptionsWindowContainer.Get<Button>(SearchCriteria.ByText("Use Embedded Mercurial"));
            }
        }

        private Button UseSystemMercurialButton
        {
            get
            {
                return OptionsWindowContainer.Get<Button>(SearchCriteria.ByText("Use System Mercurial"));
            }
        }

        private Button UpdateEmbeddedMercurialButton
        {
            get
            {
                return OptionsWindowContainer.Get<Button>(SearchCriteria.ByText("Update Embedded Mercurial"));
            }
        }

        private Button OK
        {
            get
            {
                return OptionsWindowContainer.Get<Button>(SearchCriteria.ByText("OK"));
            }
        }

        public void UseEmbeddedMercurial()
        {
            if (UseEmbeddedMercurialButton.Enabled)
            {
                this.ClickOnButton(UseEmbeddedMercurialButton);
            }
        }

        public void UseSystemMercurial()
        {
            if (UseSystemMercurialButton.Enabled)
            {
                this.ClickOnButton(UseSystemMercurialButton);
            }
        }

        /*
        public void UpdateEmbeddedMercurial()
        {
            if (UpdateEmbeddedMercurialButton.Enabled)
            {
                this.ClickOnButton(UpdateEmbeddedMercurialButton);
            }
        } */

        public DownloadHgWindow UpdateEmbeddedMercurial()
        {
            if (UpdateEmbeddedMercurialButton.Enabled)
            {
                this.ClickOnButton(UpdateEmbeddedMercurialButton);                
                var downloadHgWindow = MainWindow.MdiChild(SearchCriteria.ByText("Download Embedded HG"));
                return new DownloadHgWindow(MainWindow, downloadHgWindow);
            }
            else
            {
                // TODO discuss how to process this case
                return null;
            }            
        }

        public bool IsUseEmbeddedMercurialEnabled()
        {
            return UseEmbeddedMercurialButton.Enabled;
        }

        public bool IsUseSystemMercurialEnabled()
        {
            return UseSystemMercurialButton.Enabled;
        }

        public bool IsUpdateEmbeddedMercurialEnabled()
        {
            return UpdateEmbeddedMercurialButton.Enabled;
        }

        public string VersionText()
        {
            return OptionsWindowContainer.HelpText;
        }
    }
}