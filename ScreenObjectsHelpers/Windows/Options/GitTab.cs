﻿using System;
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

        public GitTab(Window mainWindow, UIItemContainer optionsWindow) : base(mainWindow, optionsWindow)
        {
        }

        public override void ValidateWindow()
        {
            // Need verify opened tab in this method, need implementation! If validation is fail, throw exception!
            Console.WriteLine("WAIT FOR OPENING TAB");
        }


        #region UI Elements
        public override UIItem UIElementTab
        {
            get
            {
                return OptionsWindowContainer.Get<UIItem>(SearchCriteria.ByText("Git"));
            }
        }
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
                return OptionsWindowContainer.Get<Button>(SearchCriteria.ByText("Use System Git"));
            }
        }
        #endregion

        #region Methods
        public void UseEmbeddedGit()
        {
            if(UseEmbededGitButton.Enabled)
            {
                this.ClickOnButton(UseEmbededGitButton);
            }
        }

        public bool IsUseEmbeddedGitEnabled()
        {
            return UseEmbededGitButton.Enabled;
        }

        public bool IsUseSystemGitEnabled()
        {
            return SystemGitButton.Enabled;
        }

        public string VersionText()
        {
            return OptionsWindowContainer.HelpText;
        }
        #endregion
    }
}


