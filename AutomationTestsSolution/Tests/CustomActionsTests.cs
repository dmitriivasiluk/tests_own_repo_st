﻿//using NUnit.Framework;
//using ScreenObjectsHelpers.Helpers;
//using ScreenObjectsHelpers.Windows.Options;
//using ScreenObjectsHelpers.Windows.MenuFolder;
//using ScreenObjectsHelpers.Windows.ToolbarTabs;
//using System.IO;
//using System;

//namespace AutomationTestsSolution.Tests
//{
//    class CustomActionsTests : BasicTest
//    {
//        [SetUp]
//        public override void SetUp()
//        {
//            var resourceName = Resources.customactions;
//            var customActionsFilePath = Environment.ExpandEnvironmentVariables(@"%localappdata%\Atlassian\SourceTree\customactions.xml");
//            RestoreFile(customActionsFilePath);
//            File.WriteAllText(customActionsFilePath, resourceName);
//            base.SetUp();
//        }

//        //[Test]
//        //public void AddCustomAction()
//        //{
//        //    LocalTab mainWindow = new LocalTab(MainWindow);
//        //    OptionsWindow optionsWindows = mainWindow.OpenMenu<ToolsMenu>().OpenOptions();
//        //    CustomActionsTab customActionsTab = optionsWindows.OpenTab<CustomActionsTab>();

//        //    var isMenuCaptionExistsBeforeTest = customActionsTab.IsMenuCaptionExists(ConstantsList.addCustomActionName);
//        //    var editCustomActionWindow = customActionsTab.ClickAddCustomActionButton();

//        //    editCustomActionWindow.SetMenuCaption(ConstantsList.addCustomActionName);
//        //    editCustomActionWindow.SetScriptToRun(ConstantsList.addCustomActionName);
//        //    editCustomActionWindow.ClickOKButton();

//        //    Assert.IsFalse(isMenuCaptionExistsBeforeTest);
//        //    Assert.IsTrue(customActionsTab.IsMenuCaptionExists(ConstantsList.addCustomActionName));
//        //}

//        //[Test]
//        //public void EditCustomAction()
//        //{
//        //    LocalTab mainWindow = new LocalTab(MainWindow);
//        //    OptionsWindow optionsWindows = mainWindow.OpenMenu<ToolsMenu>().OpenOptions();
//        //    CustomActionsTab customActionsTab = optionsWindows.OpenTab<CustomActionsTab>();

//        //    var isEditCustomActionButtonEnabled = customActionsTab.IsEditCustomActionButtonEnabled();
//        //    var isMenuCaptionExistsBeforeTest = customActionsTab.IsMenuCaptionExists(ConstantsList.editedCustomActionName);
//        //    var editCustomActionWindow = customActionsTab.ClickEditCustomActionButton();

//        //    editCustomActionWindow.SetMenuCaption(ConstantsList.editedCustomActionName);
//        //    editCustomActionWindow.ClickOKButton();

//        //    Assert.IsFalse(isEditCustomActionButtonEnabled);
//        //    Assert.IsFalse(isMenuCaptionExistsBeforeTest);
//        //    Assert.IsTrue(customActionsTab.IsMenuCaptionExists(ConstantsList.editedCustomActionName));
//        //}

//        //[Test]
//        //public void DeleteCustomAction()
//        //{
//        //    LocalTab mainWindow = new LocalTab(MainWindow);
//        //    OptionsWindow optionsWindows = mainWindow.OpenMenu<ToolsMenu>().OpenOptions();
//        //    CustomActionsTab customActionsTab = optionsWindows.OpenTab<CustomActionsTab>();

//        //    var isDeleteCustomActionButtonEnabled = customActionsTab.IsDeleteCustomActionButtonEnabled();
//        //    var isMenuCaptionExistsBeforeTest = customActionsTab.IsMenuCaptionExists(ConstantsList.customActionToBeDeleted);

//        //    customActionsTab.ClickDeleteCustomActionButton();

//        //    var confirmDeletionWindow = customActionsTab.SwitchToConfirmDeletionDialogWindow();

//        //    confirmDeletionWindow.ClickOkButton();

//        //    var isMenuCaptionExistsAfterTest = customActionsTab.IsMenuCaptionExists(ConstantsList.customActionToBeDeleted);

//        //    Assert.IsFalse(isDeleteCustomActionButtonEnabled);
//        //    Assert.IsTrue(isMenuCaptionExistsBeforeTest);
//        //    Assert.IsFalse(isMenuCaptionExistsAfterTest);
//        //}
//    }
//}