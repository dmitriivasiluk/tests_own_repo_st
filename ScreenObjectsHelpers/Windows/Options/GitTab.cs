using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace ScreenObjectsHelpers.Windows.Options
{
  public class GitTab : OptionsWindow
    {
            private UIItem generalTabActions;
        public GitTab(Window mainWindow, UIItemContainer optionsWindow) : base(mainWindow, optionsWindow)
            {
            }

        public GitTab(Window mainWindow, UIItemContainer optionsWindow, UIItem generalTab ) : base(mainWindow, optionsWindow)
            {
                generalTabActions = generalTab;
            }


            #region UI Elements
            public Button UseEmbededGitButton 
            {
                get
                {
                    return OptionsWindowContainer.Get<Button>(SearchCriteria.ByText("Use Embedded Git"));
                }
            }
            private Button OK
            {
                get
                {
                    return OptionsWindowContainer.Get<Button>(SearchCriteria.ByText("OK"));
                }
            }

        private Button EmbeddedGitButton
        {
            get
            {
                return OptionsWindowContainer.Get<Button>(SearchCriteria.ByText("Use Embedded Git"));
            }
        }

        private Button SystemGitButton
        {
            get
            {
                return OptionsWindowContainer.Get<Button>(SearchCriteria.ByText("Use Sustem Git"));
            }
        }

        #endregion
        #region Methods
        public void UseEmbeddedGit()
            {
                this.ClickOnButton(UseEmbededGitButton);
                this.ClickOnButton(OK);
            }

        public bool isUseEmbeddedGitEnabled() {
          return  isElementAvaliable(UseEmbededGitButton);
        }

        public bool isUseSystemGitEnabled()
        {
            return isElementAvaliable(SystemGitButton);
        }

        public String VersionText()
        {
                return OptionsWindowContainer.HelpText;
        }

        #endregion
    }
}


