using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WPFUIItems;

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

        public Button UseEmbededMercurialButton
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

        private Button OK
        {
            get
            {
                return OptionsWindowContainer.Get<Button>(SearchCriteria.ByText("OK"));
            }
        }

        public void UseEmbeddedMercurial()
        {
            if (UseEmbededMercurialButton.Enabled)
            {
                this.ClickOnButton(UseEmbededMercurialButton);
            }
        }

        public void UseSystemMercurial()
        {
            if (UseSystemMercurialButton.Enabled)
            {
                this.ClickOnButton(UseSystemMercurialButton);
            }
        }

        public bool IsUseEmbeddedMercurialEnabled()
        {
            return UseEmbededMercurialButton.Enabled;
        }

        public bool IsUseSystemMercurialEnabled()
        {
            return UseSystemMercurialButton.Enabled;
        }

        public string VersionText()
        {
            return OptionsWindowContainer.HelpText;
        }
    }
}