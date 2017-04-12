using System;

namespace ScreenObjectsHelpers.Helpers
{
    public class ConstantsList
    {
        //Constants for Help Menu (about window) tests
        public const string appVersion = "Version 2.0.18.1";
        public const string copyrightCaption = "Copyright Atlassian 2012-2017. All Rights Reserved.";
        public const string aboutWindowHeader = "About SourceTree";

        //Constants for custom actions tests
        public const string addCustomActionName = "test1";
        public const string editedCustomActionName = "editedCustomAction";
        public const string customActionToBeDeleted = "customActionToBeEdited";

        //Constants for Clone Tab tests
        public const string pathToTestRepoDirectory = @"%userprofile%\Documents\test_bb_git_publ_che";
        public const string pathToBookmarks = @"%localappdata%\Atlassian\SourceTree\bookmarks.xml";
        public const string GitRepoLink = "https://github.com/GitHubNoTwoStepVerification/test_gh_git_publ_che.git";
        public const string MercurialRepoLink = "https://UserAccountNo2FA@bitbucket.org/UserAccountNo2FA/test_bb_hg_publ_che";
        public const string git = "Git";
        public const string mercurial = "Mercurial";
    }
}
