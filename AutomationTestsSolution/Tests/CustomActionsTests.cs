using NUnit.Framework;
using ScreenObjectsHelpers.Windows;
using ScreenObjectsHelpers.Windows.Options;
using ScreenObjectsHelpers.Windows.MenuFolder;
using System.IO;
using System;

namespace AutomationTestsSolution.Tests
{
    class CustomActionsTests : BasicTest
    {
        [SetUp]
        public override void SetUp()
        {
            var resourceName = Resources.customactions;
            var customActionsFilePath = Environment.ExpandEnvironmentVariables(@"%localappdata%\Atlassian\SourceTree\customactions.xml");
            RestoreFile(customActionsFilePath);
            File.WriteAllText(customActionsFilePath, resourceName);
            base.SetUp();
        }

        [Test]
        public void AddCustomAction()
        {
            const string testData = "test1";
            NewTabWindow mainWindow = new NewTabWindow(MainWindow);
            OptionsWindow optionsWindows = mainWindow.OpenMenu<ToolsMenu>().OpenOptions();
            CustomActionsTab customActionsTab = optionsWindows.OpenTab<CustomActionsTab>();

            var isMenuCaptionExistsBeforeTest = customActionsTab.IsMenuCaptionExists(testData);
            var editCustomActionWindow = customActionsTab.ClickAddCustomActionButton();

            editCustomActionWindow.SetMenuCaption(testData);
            editCustomActionWindow.SetScriptToRun(testData);
            editCustomActionWindow.ClickOnOKButton();

            Assert.IsFalse(isMenuCaptionExistsBeforeTest);
            Assert.IsTrue(customActionsTab.IsMenuCaptionExists(testData));
        }

        [Test]
        public void EditCustomAction()
        {
            const string newMenuCaption = "editedCustomAction";

            NewTabWindow mainWindow = new NewTabWindow(MainWindow);
            OptionsWindow optionsWindows = mainWindow.OpenMenu<ToolsMenu>().OpenOptions();
            CustomActionsTab customActionsTab = optionsWindows.OpenTab<CustomActionsTab>();

            var isEditCustomActionButtonEnabled = customActionsTab.IsEditCustomActionButtonEnabled();
            var isMenuCaptionExistsBeforeTest = customActionsTab.IsMenuCaptionExists(newMenuCaption);
            var editCustomActionWindow = customActionsTab.ClickEditCustomActionButton();

            editCustomActionWindow.SetMenuCaption(newMenuCaption);
            editCustomActionWindow.ClickOnOKButton();

            Assert.IsFalse(isEditCustomActionButtonEnabled);
            Assert.IsFalse(isMenuCaptionExistsBeforeTest);
            Assert.IsTrue(customActionsTab.IsMenuCaptionExists(newMenuCaption));
        }

        [Test]
        public void DeleteCustomAction()
        {
            const string customActionToBeDeleted = "customActionToBeEdited";

            NewTabWindow mainWindow = new NewTabWindow(MainWindow);
            OptionsWindow optionsWindows = mainWindow.OpenMenu<ToolsMenu>().OpenOptions();
            CustomActionsTab customActionsTab = optionsWindows.OpenTab<CustomActionsTab>();

            var isDeleteCustomActionButtonEnabled = customActionsTab.IsDeleteCustomActionButtonEnabled();
            var isMenuCaptionExistsBeforeTest = customActionsTab.IsMenuCaptionExists(customActionToBeDeleted);

            customActionsTab.ClickDeleteCustomActionButton();

            var confirmDeletionWindow = customActionsTab.SwitchToConfirmDeletionDialogWindow();

            confirmDeletionWindow.ClickOkButton();

            var isMenuCaptionExistsAfterTest = customActionsTab.IsMenuCaptionExists(customActionToBeDeleted);

            Assert.IsFalse(isDeleteCustomActionButtonEnabled);
            Assert.IsTrue(isMenuCaptionExistsBeforeTest);
            Assert.IsFalse(isMenuCaptionExistsAfterTest);
        }
    }
}