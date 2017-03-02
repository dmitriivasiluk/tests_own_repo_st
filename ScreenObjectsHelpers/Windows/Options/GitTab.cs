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
  public  class GitTab : OptionsWindow
    {
            private Button oKButton;
            private UIItem generalTabActions;

        public GitTab(Window mainWindow, UIItemContainer optionsWindow) : base(mainWindow, optionsWindow)
        {
        }

        public GitTab(Window mainWindow, UIItemContainer optionsWindow, UIItem generalTab ) : base(mainWindow, optionsWindow)
            {
                generalTabActions = generalTab;
            }

            public override void ValidateWindow()
            {
                // Need verify opened tab in this method, need implementation! If validation is fail, throw exception!
                Console.WriteLine("WAIT FOR OPENING TAB");
            }

            #region UI Elements
            public Button UseEmbededGit 
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
            #endregion

            public void UseEmbeddedGit()
            {
                this.ClickOnButton(UseEmbededGit);
                this.ClickOnButton(OK);
            }
        }
    }


