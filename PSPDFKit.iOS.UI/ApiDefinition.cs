﻿using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using PSPDFKit.Core;
using AVFoundation;
using CoreAnimation;
using CoreMedia;
using MessageUI;

namespace PSPDFKit.UI {

	[BaseType (typeof (UIActivityViewController))]
	interface PSPDFActivityViewController {

	}

	interface IPSPDFAnalyticsClient { }

	[Protocol]
	interface PSPDFAnalyticsClient {

		[Abstract]
		[Export ("logEvent:attributes:")]
		void LogEvent (string @event, [NullAllowed] NSDictionary attributes);
	}

	[BaseType (typeof (NSObject))]
	interface PSPDFAnalytics : PSPDFAnalyticsClient {

		[Field ("PSPDFAnalyticsEventPrefix", PSPDFKitGlobal.LibraryPath)]
		NSString AnalyticsEventPrefix { get; }

		[Export ("enabled")]
		bool Enabled { get; set; }

		[Export ("addAnalyticsClient:")]
		void AddAnalyticsClient (IPSPDFAnalyticsClient analyticsClient);

		[Export ("removeAnalyticsClient:")]
		void RemoveAnalyticsClient (IPSPDFAnalyticsClient analyticsClient);

		[Export ("logEvent:")]
		void LogEvent (string @event);
	}

	[Static]
	interface PSPDFAnalyticsEventName {

		[Field ("PSPDFAnalyticsEventNameDocumentLoad", PSPDFKitGlobal.LibraryPath)]
		NSString DocumentLoadKey { get; }

		[Field ("PSPDFAnalyticsEventNameSpreadChange", PSPDFKitGlobal.LibraryPath)]
		NSString SpreadChangeKey { get; }

		[Field ("PSPDFAnalyticsEventNameAnnotationCreationModeEnter", PSPDFKitGlobal.LibraryPath)]
		NSString AnnotationCreationModeEnterKey { get; }

		[Field ("PSPDFAnalyticsEventNameAnnotationCreationModeExit", PSPDFKitGlobal.LibraryPath)]
		NSString AnnotationCreationModeExitKey { get; }

		[Field ("PSPDFAnalyticsEventNameAnnotationCreatorDialogShow", PSPDFKitGlobal.LibraryPath)]
		NSString AnnotationCreatorDialogShowKey { get; }

		[Field ("PSPDFAnalyticsEventNameAnnotationCreatorDialogCancel", PSPDFKitGlobal.LibraryPath)]
		NSString AnnotationCreatorDialogCancelKey { get; }

		[Field ("PSPDFAnalyticsEventNameAnnotationCreatorSet", PSPDFKitGlobal.LibraryPath)]
		NSString AnnotationCreatorSetKey { get; }

		[Field ("PSPDFAnalyticsEventNameAnnotationSelect", PSPDFKitGlobal.LibraryPath)]
		NSString AnnotationSelectKey { get; }

		[Field ("PSPDFAnalyticsEventNameAnnotationCreate", PSPDFKitGlobal.LibraryPath)]
		NSString AnnotationCreateKey { get; }

		[Field ("PSPDFAnalyticsEventNameAnnotationDelete", PSPDFKitGlobal.LibraryPath)]
		NSString AnnotationDeleteKey { get; }

		[Field ("PSPDFAnalyticsEventNameAnnotationInspectorShow", PSPDFKitGlobal.LibraryPath)]
		NSString AnnotationInspectorShowKey { get; }

		[Field ("PSPDFAnalyticsEventNameTextSelect", PSPDFKitGlobal.LibraryPath)]
		NSString TextSelectKey { get; }

		[Field ("PSPDFAnalyticsEventNameOutlineOpen", PSPDFKitGlobal.LibraryPath)]
		NSString OutlineOpenKey { get; }

		[Field ("PSPDFAnalyticsEventNameOutlineElementSelect", PSPDFKitGlobal.LibraryPath)]
		NSString OutlineElementSelectKey { get; }

		[Field ("PSPDFAnalyticsEventNameOutlineAnnotationSelect", PSPDFKitGlobal.LibraryPath)]
		NSString OutlineAnnotationSelectKey { get; }

		[Field ("PSPDFAnalyticsEventNameThumbnailGridOpen", PSPDFKitGlobal.LibraryPath)]
		NSString ThumbnailGridOpenKey { get; }

		[Field ("PSPDFAnalyticsEventNameDocumentEditorOpen", PSPDFKitGlobal.LibraryPath)]
		NSString DocumentEditorOpenKey { get; }

		[Field ("PSPDFAnalyticsEventNameDocumentEditorAction", PSPDFKitGlobal.LibraryPath)]
		NSString DocumentEditorActionKey { get; }

		[Field ("PSPDFAnalyticsEventNameBookmarkAdd", PSPDFKitGlobal.LibraryPath)]
		NSString BookmarkAddKey { get; }

		[Field ("PSPDFAnalyticsEventNameBookmarkEdit", PSPDFKitGlobal.LibraryPath)]
		NSString BookmarkEditKey { get; }

		[Field ("PSPDFAnalyticsEventNameBookmarkRemove", PSPDFKitGlobal.LibraryPath)]
		NSString BookmarkRemoveKey { get; }

		[Field ("PSPDFAnalyticsEventNameBookmarkSort", PSPDFKitGlobal.LibraryPath)]
		NSString BookmarkSortKey { get; }

		[Field ("PSPDFAnalyticsEventNameBookmarkRename", PSPDFKitGlobal.LibraryPath)]
		NSString BookmarkRenameKey { get; }

		[Field ("PSPDFAnalyticsEventNameBookmarkSelect", PSPDFKitGlobal.LibraryPath)]
		NSString BookmarkSelectKey { get; }

		[Field ("PSPDFAnalyticsEventNameSearchStart", PSPDFKitGlobal.LibraryPath)]
		NSString SearchStartKey { get; }

		[Field ("PSPDFAnalyticsEventNameSearchResultSelect", PSPDFKitGlobal.LibraryPath)]
		NSString SearchResultSelectKey { get; }

		[Field ("PSPDFAnalyticsEventNameShare", PSPDFKitGlobal.LibraryPath)]
		NSString ShareKey { get; }

		[Field ("PSPDFAnalyticsEventNameToolbarMove", PSPDFKitGlobal.LibraryPath)]
		NSString ToolbarMoveKey { get; }
	}

	[Static]
	interface PSPDFAnalyticsEventAttributeName {

		[Field ("PSPDFAnalyticsEventAttributeNameAnnotationType", PSPDFKitGlobal.LibraryPath)]
		NSString AnnotationTypeKey { get; }

		[Field ("PSPDFAnalyticsEventAttributeNameAction", PSPDFKitGlobal.LibraryPath)]
		NSString ActionKey { get; }

		[Field ("PSPDFAnalyticsEventAttributeNameActivityType", PSPDFKitGlobal.LibraryPath)]
		NSString ActivityTypeKey { get; }
	}

	[Static]
	interface PSPDFAnalyticsEventAttributeValue {

		[Field ("PSPDFAnalyticsEventAttributeValueActionInsertNewPage", PSPDFKitGlobal.LibraryPath)]
		NSString ActionInsertNewPageKey { get; }

		[Field ("PSPDFAnalyticsEventAttributeValueActionRemoveSelectedPages", PSPDFKitGlobal.LibraryPath)]
		NSString ActionRemoveSelectedPagesKey { get; }

		[Field ("PSPDFAnalyticsEventAttributeValueActionDuplicateSelectedPages", PSPDFKitGlobal.LibraryPath)]
		NSString ActionDuplicateSelectedPagesKey { get; }

		[Field ("PSPDFAnalyticsEventAttributeValueActionRotateSelectedPages", PSPDFKitGlobal.LibraryPath)]
		NSString ActionRotateSelectedPagesKey { get; }

		[Field ("PSPDFAnalyticsEventAttributeValueActionExportSelectedPages", PSPDFKitGlobal.LibraryPath)]
		NSString ActionExportSelectedPagesKey { get; }

		[Field ("PSPDFAnalyticsEventAttributeValueActionSelectAllPages", PSPDFKitGlobal.LibraryPath)]
		NSString ActionSelectAllPagesKey { get; }

		[Field ("PSPDFAnalyticsEventAttributeValueActionUndo", PSPDFKitGlobal.LibraryPath)]
		NSString ActionUndoKey { get; }

		[Field ("PSPDFAnalyticsEventAttributeValueActionRedo", PSPDFKitGlobal.LibraryPath)]
		NSString ActionRedoKey { get; }

		[Field ("PSPDFAnalyticsEventAttributeValueToolbarPosition", PSPDFKitGlobal.LibraryPath)]
		NSString ToolbarPositionKey { get; }
	}

	[BaseType (typeof (PSPDFNonAnimatingTableViewCell))]
	interface PSPDFAnnotationCell {

		[Static]
		[Export ("heightForAnnotation:inTableView:")]
		nfloat GetHeight (PSPDFAnnotation annotation, UITableView tableView);

		[Export ("nameLabel")]
		UILabel NameLabel { get; }

		[Export ("dateAndUserLabel")]
		UILabel DateAndUserLabel { get; }

		[NullAllowed, Export ("annotation", ArgumentSemantic.Copy)]
		PSPDFAnnotation Annotation { get; set; }

		// PSPDFAnnotationCell (SubclassingHooks) Category

		[Static]
		[Export ("dateAndUserStringForAnnotation:")]
		string GetDateAndUserString (PSPDFAnnotation annotation);
	}

	interface IPSPDFAnnotationGridViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFAnnotationGridViewControllerDelegate : IPSPDFOverridable {

		[Export ("annotationGridViewControllerDidCancel:")]
		void DidCancel (PSPDFAnnotationGridViewController annotationGridController);

		[Export ("annotationGridViewController:didSelectAnnotationSet:")]
		void DidSelectAnnotationSet (PSPDFAnnotationGridViewController annotationGridController, PSPDFAnnotationSet annotationSet);
	}

	interface IPSPDFAnnotationGridViewControllerDataSource { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFAnnotationGridViewControllerDataSource {

		[Abstract]
		[Export ("numberOfSectionsInAnnotationGridViewController:")]
		nint GetNumberOfSectionsInAnnotationGridViewController (PSPDFAnnotationGridViewController annotationGridController);

		[Abstract]
		[Export ("annotationGridViewController:numberOfAnnotationsInSection:")]
		nint GetNumberOfAnnotationsInSection (PSPDFAnnotationGridViewController annotationGridController, nint section);

		[Abstract]
		[Export ("annotationGridViewController:annotationSetForIndexPath:")]
		PSPDFAnnotationSet GetAnnotationSetForIndexPath (PSPDFAnnotationGridViewController annotationGridController, NSIndexPath indexPath);
	}

	[BaseType (typeof (PSPDFBaseViewController))]
	interface PSPDFAnnotationGridViewController : PSPDFStyleable, IUICollectionViewDelegate, IUICollectionViewDataSource {

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFAnnotationGridViewControllerDelegate Delegate { get; set; }

		[NullAllowed, Export ("dataSource", ArgumentSemantic.Weak)]
		IPSPDFAnnotationGridViewControllerDataSource DataSource { get; set; }

		[Export ("reloadData")]
		void ReloadData ();

		// PSPDFAnnotationGridViewController (SubclassingHooks) category

		[Export ("close:")]
		void Close ([NullAllowed] NSObject sender);

		[Export ("configureCell:forIndexPath:")]
		void ConfigureCell (PSPDFAnnotationSetCell annotationSetCell, NSIndexPath indexPath);

		[NullAllowed, Export ("collectionView")]
		UICollectionView GetCollectionView { get; }

		[Export ("updatePopoverSize")]
		void UpdatePopoverSize ();
	}

	[Category (true)]
	[BaseType (typeof (PSPDFAnnotationGroupItem))]
	interface PSPDFAnnotationGroupItem_PSPDFPresets {

		[Static]
		[Export ("inkConfigurationBlock")]
		PSPDFAnnotationGroupItemConfigurationHandler GetInkConfigurationHandler ();

		[Static]
		[Export ("lineConfigurationBlock")]
		PSPDFAnnotationGroupItemConfigurationHandler GetLineConfigurationHandler ();

		[Static]
		[Export ("freeTextConfigurationBlock")]
		PSPDFAnnotationGroupItemConfigurationHandler GetFreeTextConfigurationHandler ();
	}

	interface IPSPDFAnnotationPresenting { }

	[Protocol]
	interface PSPDFAnnotationPresenting {

		[NullAllowed]
		[Export ("annotation")]
		PSPDFAnnotation GetAnnotation ();

		[Export ("setAnnotation:")]
		void SetAnnotation ([NullAllowed] PSPDFAnnotation annotation);

		[Export ("zIndex")]
		nuint GetZIndex ();

		[Export ("setZIndex:")]
		void SetZIndex (nuint index);

		[Export ("zoomScale")]
		nfloat GetZoomScale ();

		[Export ("setZoomScale:")]
		void SetZoomScale (nfloat zoomScale);

		[Export ("PDFScale")]
		nfloat GetPdfScale ();

		[Export ("setPDFScale:")]
		void SetPdfScale (nfloat pdfScale);

		[Export ("didShowPageView:")]
		void DidShowPageView (PSPDFPageView pageView);

		[Export ("didHidePageView:")]
		void DidHidePageView (PSPDFPageView pageView);

		[Export ("didChangePageBounds:")]
		void DidChangePageBounds (CGRect bounds);

		[Export ("didTapAtPoint:")]
		void DidTapAtPoint (CGPoint point);

		[Export ("shouldSyncRemovalFromSuperview")]
		bool GetShouldSyncRemovalFromSuperview ();

		[Export ("willRemoveFromSuperview")]
		void WillRemoveFromSuperview ();

		[Export ("pageView")]
		PSPDFPageView GetPageView ();

		[Export ("setPageView:")]
		void SetPageView ([NullAllowed] PSPDFPageView PageView);

		[Export ("configuration")]
		PSPDFConfiguration GetConfiguration ();

		[Export ("setConfiguration:")]
		void SetConfiguration (PSPDFConfiguration configuration);

		[Export ("isSelected")]
		bool GetSelected ();

		[Export ("setSelected:")]
		void SetSelected (bool selected);
	}

	[BaseType (typeof (PSPDFSelectableCollectionViewCell))]
	interface PSPDFAnnotationSetCell {

		[NullAllowed, Export ("annotationSet", ArgumentSemantic.Strong)]
		PSPDFAnnotationSet AnnotationSet { get; set; }

		[Export ("edgeInsets", ArgumentSemantic.Assign)]
		UIEdgeInsets EdgeInsets { get; set; }
	}

	[BaseType (typeof (PSPDFTableViewCell))]
	interface PSPDFAnnotationSetsCell : IUICollectionViewDelegate, IUICollectionViewDataSource {

		[Advice ("Allows 'PSPDFAnnotation' or 'PSPDFAnnotationSet' objects.")]
		[NullAllowed, Export ("annotations", ArgumentSemantic.Copy)]
		NSObject [] Annotations { get; set; }

		[Export ("collectionView")]
		UICollectionView CollectionView { get; }

		[Export ("border")]
		nfloat Border { get; set; }

		[NullAllowed, Export ("collectionViewUpdateBlock", ArgumentSemantic.Copy)]
		Action<PSPDFAnnotationSetsCell> CollectionViewUpdateHandler { get; set; }
	}

	interface IPSPDFAnnotationStateManagerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFAnnotationStateManagerDelegate {

		[Export ("annotationStateManager:shouldChangeState:to:variant:to:")]
		bool ShouldChangeState (PSPDFAnnotationStateManager manager, [NullAllowed] NSString currentState, [NullAllowed] NSString proposedState, [NullAllowed] NSString currentVariant, [NullAllowed] NSString proposedVariant);

		[Export ("annotationStateManager:didChangeState:to:variant:to:")]
		void DidChangeState (PSPDFAnnotationStateManager manager, [NullAllowed] NSString oldState, [NullAllowed] NSString newState, [NullAllowed] NSString oldVariant, [NullAllowed] NSString newVariant);

		[Export ("annotationStateManager:didChangeUndoState:redoState:")]
		void DidChangeUndoState (PSPDFAnnotationStateManager manager, bool undoEnabled, bool redoEnabled);
	}

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface PSPDFAnnotationStateManager : IPSPDFOverridable {

		[NullAllowed, Export ("pdfController", ArgumentSemantic.Weak)]
		PSPDFViewController PdfController { get; }

		[Export ("addDelegate:")]
		void AddDelegate (IPSPDFAnnotationStateManagerDelegate @delegate);

		[Export ("removeDelegate:")]
		bool RemoveDelegate (IPSPDFAnnotationStateManagerDelegate @delegate);

		[Advice ("You can use '[Get|Set]State' for a more strongly typed access.")]
		[NullAllowed, Export ("state")]
		NSString State { get; set; }

		[Wrap ("PSPDFAnnotationStringUIExtensions.GetValue (State)")]
		PSPDFAnnotationStringUI GetState ();

		[Wrap ("State = state.GetConstant ()")]
		void SetState (PSPDFAnnotationStringUI state);

		[Export ("toggleState:")]
		void ToggleState (NSString state);

		[Wrap ("ToggleState (state.GetConstant ())")]
		void ToggleState (PSPDFAnnotationStringUI state);

		[Advice ("You can use '[Get|Set]Variant' for a more strongly typed access.")]
		[NullAllowed, Export ("variant")]
		NSString Variant { get; set; }

		[Wrap ("PSPDFAnnotationStringUIExtensions.GetValue (Variant)")]
		PSPDFAnnotationStringUI GetVariant ();

		[Wrap ("Variant = variant.GetConstant ()")]
		void SetVariant (PSPDFAnnotationStringUI variant);

		[Export ("setState:variant:")]
		void SetState ([NullAllowed] NSString state, [NullAllowed] NSString variant);

		[Wrap ("SetState (state.GetConstant (), variant.GetConstant ())")]
		void SetState (PSPDFAnnotationStringUI state, PSPDFAnnotationStringUI variant);

		[Export ("toggleState:variant:")]
		void ToggleState ([NullAllowed] NSString state, [NullAllowed] NSString variant);

		[Wrap ("ToggleState (state.GetConstant (), variant.GetConstant ())")]
		void ToggleState (PSPDFAnnotationStringUI state, PSPDFAnnotationStringUI variant);

		[Advice ("You can use 'GetStateVariantIdentifier' for a more strongly typed access.")]
		[Export ("stateVariantIdentifier")]
		NSString StateVariantIdentifier { get; }

		[Wrap ("PSPDFAnnotationStringUIExtensions.GetValue (StateVariantIdentifier)")]
		PSPDFAnnotationStringUI GetStateVariantIdentifier ();

		[Export ("drawingInputMode", ArgumentSemantic.Assign)]
		PSPDFDrawViewInputMode DrawingInputMode { get; set; }

		[Export ("stylusMode", ArgumentSemantic.Assign)]
		PSPDFAnnotationStateManagerStylusMode StylusMode { get; set; }

		[NullAllowed, Export ("drawColor", ArgumentSemantic.Strong)]
		UIColor DrawColor { get; set; }

		[NullAllowed, Export ("fillColor", ArgumentSemantic.Strong)]
		UIColor FillColor { get; set; }

		[Export ("lineWidth")]
		nfloat LineWidth { get; set; }

		[Export ("lineEnd1", ArgumentSemantic.Assign)]
		PSPDFLineEndType LineEnd1 { get; set; }

		[Export ("lineEnd2", ArgumentSemantic.Assign)]
		PSPDFLineEndType LineEnd2 { get; set; }

		[NullAllowed, Export ("dashArray", ArgumentSemantic.Copy)]
		NSNumber [] DashArray { get; set; }

		[Export ("borderEffect", ArgumentSemantic.Assign)]
		PSPDFAnnotationBorderEffect BorderEffect { get; set; }

		[Export ("borderEffectIntensity")]
		nfloat BorderEffectIntensity { get; set; }

		[NullAllowed, Export ("fontName")]
		string FontName { get; set; }

		[Export ("fontSize")]
		nfloat FontSize { get; set; }

		[Export ("textAlignment", ArgumentSemantic.Assign)]
		UITextAlignment TextAlignment { get; set; }

		[Export ("toggleStylePicker:presentationOptions:")]
		[return: NullAllowed]
		PSPDFAnnotationStyleViewController ToggleStylePicker ([NullAllowed] NSObject sender, [NullAllowed] NSDictionary options);

		[Wrap ("ToggleStylePicker (sender, options: presentationOptions?.Dictionary)")]
		PSPDFAnnotationStyleViewController ToggleStylePicker ([NullAllowed] NSObject sender, PSPDFPresentationOptions presentationOptions);

		[Export ("toggleSignatureController:presentationOptions:")]
		[return: NullAllowed]
		UIViewController ToggleSignatureController ([NullAllowed] NSObject sender, [NullAllowed] NSDictionary options);

		[Wrap ("ToggleSignatureController (sender, options: presentationOptions?.Dictionary)")]
		UIViewController ToggleSignatureController ([NullAllowed] NSObject sender, PSPDFPresentationOptions presentationOptions);

		[Export ("toggleStampController:includeSavedAnnotations:presentationOptions:")]
		[return: NullAllowed]
		UIViewController ToggleStampController ([NullAllowed] NSObject sender, bool includeSavedAnnotations, [NullAllowed] NSDictionary options);

		[Wrap ("ToggleStampController (sender, includeSavedAnnotations, options: presentationOptions?.Dictionary)")]
		UIViewController ToggleStampController ([NullAllowed] NSObject sender, bool includeSavedAnnotations, PSPDFPresentationOptions presentationOptions);

		[Export ("toggleImagePickerController:presentationOptions:")]
		[return: NullAllowed]
		UIViewController ToggleImagePickerController ([NullAllowed] NSObject sender, [NullAllowed] NSDictionary options);

		[Wrap ("ToggleImagePickerController (sender, options: presentationOptions?.Dictionary)")]
		UIViewController ToggleImagePickerController ([NullAllowed] NSObject sender, PSPDFPresentationOptions presentationOptions);

		// PSPDFAnnotationStateManager (StateHelper) category

		[Export ("isDrawingState:")]
		bool IsDrawingState ([NullAllowed] NSString state);

		[Wrap ("IsDrawingState (state.GetConstant ())")]
		void IsDrawingState (PSPDFAnnotationStringUI state);

		[Export ("isMarkupAnnotationState:")]
		bool IsMarkupAnnotationState ([NullAllowed] NSString state);

		[Wrap ("IsMarkupAnnotationState (state.GetConstant ())")]
		void IsMarkupAnnotationState (PSPDFAnnotationStringUI state);

		[Export ("stateShowsStylePicker:")]
		bool StateShowsStylePicker ([NullAllowed] NSString state);

		[Wrap ("StateShowsStylePicker (state.GetConstant ())")]
		void StateShowsStylePicker (PSPDFAnnotationStringUI state);

		// PSPDFAnnotationStateManager (SubclassingHooks) category

		[Export ("cancelDrawingAnimated:")]
		void CancelDrawingAnimated (bool animated);

		[Export ("doneDrawingAnimated:")]
		void DoneDrawingAnimated (bool animated);

		[Export ("setLastUsedColor:annotationString:")]
		void SetLastUsedColor ([NullAllowed] UIColor lastUsedDrawColor, string annotationString);

		[Export ("lastUsedColorForAnnotationString:")]
		[return: NullAllowed]
		UIColor GetLastUsedColor (NSString annotationString);

		[Wrap ("GetLastUsedColor (annotationString.GetConstant ())")]
		UIColor GetLastUsedColor (PSPDFAnnotationStringUI annotationString);

		[Export ("drawViews")]
		NSDictionary<NSNumber, PSPDFDrawView> DrawViews { get; }
	}

	[Static]
	interface PSPDFPresentationKeys {

		[Field ("PSPDFPresentationStyleKey", PSPDFKitGlobal.LibraryPath)]
		NSString StyleKey { get; }

		[Field ("PSPDFPresentationNonAdaptiveKey", PSPDFKitGlobal.LibraryPath)]
		NSString NonAdaptiveKey { get; }

		[Field ("PSPDFPresentationRectBlockKey", PSPDFKitGlobal.LibraryPath)]
		NSString RectBlockKey { get; }

		[Field ("PSPDFPresentationContentSizeKey", PSPDFKitGlobal.LibraryPath)]
		NSString ContentSizeKey { get; }

		[Field ("PSPDFPresentationInNavigationControllerKey", PSPDFKitGlobal.LibraryPath)]
		NSString InNavigationControllerKey { get; }

		[Field ("PSPDFPresentationCloseButtonKey", PSPDFKitGlobal.LibraryPath)]
		NSString CloseButtonKey { get; }

		[Field ("PSPDFPresentationPersistentCloseButtonKey", PSPDFKitGlobal.LibraryPath)]
		NSString PersistentCloseButtonKey { get; }

		[Field ("PSPDFPresentationReuseNavigationControllerKey", PSPDFKitGlobal.LibraryPath)]
		NSString ReuseNavigationControllerKey { get; }

		[Field ("PSPDFPresentationPopoverArrowDirectionsKey", PSPDFKitGlobal.LibraryPath)]
		NSString PopoverArrowDirectionsKey { get; }

		[Field ("PSPDFPresentationPopoverPassthroughViewsKey", PSPDFKitGlobal.LibraryPath)]
		NSString PopoverPassthroughViewsKey { get; }

		[Field ("PSPDFPresentationPopoverBackgroundColorKey", PSPDFKitGlobal.LibraryPath)]
		NSString PopoverBackgroundColorKey { get; }

		[Field ("PSPDFPresentationRectKey", PSPDFKitGlobal.LibraryPath)]
		NSString RectKey { get; }
	}

	[StrongDictionary ("PSPDFPresentationKeys")]
	interface PSPDFPresentationOptions {
		bool NonAdaptive { get; set; }
		CGSize ContentSize { get; set; }
		bool InNavigationController { get; set; }
		bool CloseButton { get; set; }
		bool ReuseNavigationController { get; set; }
		UIView [] PopoverPassthroughViews { get; set; }
		UIColor PopoverBackgroundColor { get; set; }
		CGRect Rect { get; set; }
	}

	interface IPSPDFPresentationActions { }

	[Protocol]
	interface PSPDFPresentationActions {

		[Abstract]
		[Export ("presentViewController:options:animated:sender:completion:")]
		bool PresentViewController (UIViewController viewController, [NullAllowed] NSDictionary options, bool animated, [NullAllowed] NSObject sender, [NullAllowed] Action completion);

		[Abstract]
		[Export ("dismissViewControllerOfClass:animated:completion:")]
		bool DismissViewController ([NullAllowed] Class controllerClass, bool animated, [NullAllowed] Action completion);
	}

	interface IPSPDFAnnotationStyleViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFAnnotationStyleViewControllerDelegate : IPSPDFOverridable {

		[Abstract]
		[Export ("annotationStyleController:didChangeProperties:")]
		void DidChangeProperties (PSPDFAnnotationStyleViewController styleController, string [] propertyNames);

		[Export ("annotationStyleController:willStartChangingProperty:")]
		void WillStartChangingProperty (PSPDFAnnotationStyleViewController styleController, string propertyName);

		[Export ("annotationStyleController:didEndChangingProperty:")]
		void DidEndChangingProperty (PSPDFAnnotationStyleViewController styleController, string propertyName);

		[Export ("annotationStyleController:annotationViewForAnnotation:")]
		[return: NullAllowed]
		IPSPDFAnnotationPresenting GetAnnotationView (PSPDFAnnotationStyleViewController styleController, PSPDFAnnotation annotation);
	}

	[BaseType (typeof (PSPDFStaticTableViewController))]
	[DisableDefaultCtor]
	interface PSPDFAnnotationStyleViewController : PSPDFFontPickerViewControllerDelegate, PSPDFStyleable {

		[Export ("initWithAnnotations:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] PSPDFAnnotation [] annotations);

		[NullAllowed, Export ("annotations", ArgumentSemantic.Copy)]
		PSPDFAnnotation [] Annotations { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFAnnotationStyleViewControllerDelegate Delegate { get; set; }

		[Export ("showPreviewArea")]
		bool ShowPreviewArea { get; set; }

		[Export ("propertiesForAnnotations", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> PropertiesForAnnotations { get; set; }

		[Export ("typesShowingColorPresets", ArgumentSemantic.Assign)]
		PSPDFAnnotationType TypesShowingColorPresets { get; set; }

		[Export ("persistsColorPresetChanges")]
		bool PersistsColorPresetChanges { get; set; }

		// PSPDFAnnotationStyleViewController (SubclassingHooks) category

		[Export ("propertiesForAnnotations:")]
		NSArray<NSString> [] GetProperties (PSPDFAnnotation [] annotations);
	}

	interface IPSPDFAnnotationTableViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFAnnotationTableViewControllerDelegate : IPSPDFOverridable {

		[Abstract]
		[Export ("annotationTableViewController:didSelectAnnotation:")]
		void DidSelectAnnotation (PSPDFAnnotationTableViewController annotationController, PSPDFAnnotation annotation);
	}

	[BaseType (typeof (PSPDFSearchableTableViewController))]
	interface PSPDFAnnotationTableViewController : PSPDFDocumentInfoController, PSPDFStyleable {

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFAnnotationTableViewControllerDelegate Delegate { get; set; }

		[Advice ("You can use 'VisibleAnnotationTypes' for a more strongly typed access.")]
		[NullAllowed, Export ("visibleAnnotationTypes", ArgumentSemantic.Copy)]
		NSSet<NSString> WeakVisibleAnnotationTypes { get; set; }

		[Advice ("You can use 'EditableAnnotationTypes' for a more strongly typed access.")]
		[NullAllowed, Export ("editableAnnotationTypes", ArgumentSemantic.Copy)]
		NSSet<NSString> WeakEditableAnnotationTypes { get; set; }

		[Export ("allowCopy")]
		bool AllowCopy { get; set; }

		[Export ("showDeleteAllOption")]
		bool ShowDeleteAllOption { get; set; }

		[Export ("reloadData")]
		void ReloadData ();

		// PSPDFAnnotationTableViewController (SubclassingHooks) Category

		[Export ("annotationsForPageAtIndex:")]
		PSPDFAnnotation [] GetAnnotations (nuint pageIndex);

		[Export ("annotationForIndexPath:inTableView:")]
		[return: NullAllowed]
		PSPDFAnnotation GetAnnotation (NSIndexPath indexPath, UITableView tableView);

		[Export ("deleteAllAction:")]
		void DeleteAllAction (NSObject sender);

		[NullAllowed, Export ("viewForTableViewFooter")]
		UIView ViewForTableViewFooter { get; }
	}

	[BaseType (typeof (PSPDFFlexibleToolbar))]
	[DisableDefaultCtor]
	interface PSPDFAnnotationToolbar : PSPDFAnnotationStateManagerDelegate {

		[Export ("initWithAnnotationStateManager:")]
		[DesignatedInitializer]
		IntPtr Constructor (PSPDFAnnotationStateManager annotationStateManager);

		[Export ("annotationStateManager", ArgumentSemantic.Strong)]
		PSPDFAnnotationStateManager AnnotationStateManager { get; set; }

		[Advice ("You can use 'EditableAnnotationTypes' for a more strongly typed access.")]
		[NullAllowed, Export ("editableAnnotationTypes", ArgumentSemantic.Copy)]
		NSSet<NSString> WeakEditableAnnotationTypes { get; set; }

		[NullAllowed, Export ("configurations", ArgumentSemantic.Copy)]
		PSPDFAnnotationToolbarConfiguration [] Configurations { get; set; }

		[Export ("annotationGroups")]
		PSPDFAnnotationGroup [] AnnotationGroups { get; }

		[Export ("buttonWithType:variant:createFromGroup:")]
		UIButton GetButton (NSString type, [NullAllowed] NSString variant, bool createFromGroup);

		[Wrap ("GetButton (state.GetConstant (), variant.GetConstant (), createFromGroup)")]
		UIButton GetButton (PSPDFAnnotationStringUI state, PSPDFAnnotationStringUI variant, bool createFromGroup);

		[NullAllowed, Export ("additionalButtons", ArgumentSemantic.Copy)]
		UIButton [] AdditionalButtons { get; set; }

		[Export ("collapseUndoButtonsForCompactSizes")]
		bool CollapseUndoButtonsForCompactSizes { get; set; }

		[Export ("showsStylusButtonAutomatically")]
		bool ShowsStylusButtonAutomatically { get; set; }

		[Export ("showingStylusButton")]
		bool ShowingStylusButton { [Bind ("isShowingStylusButton")] get; set; }

		[Export ("setShowingStylusButton:animated:")]
		void SetShowingStylusButton (bool showingStylusButton, bool animated);

		[Export ("saveAfterToolbarHiding")]
		bool SaveAfterToolbarHiding { get; set; }

		// PSPDFAnnotationToolbar (SubclassingHooks) Category

		[NullAllowed, Export ("doneButton")]
		UIButton DoneButton { get; }

		[NullAllowed, Export ("stylusButton")]
		PSPDFToolbarButton StylusButton { get; }

		[NullAllowed, Export ("undoButton")]
		UIButton UndoButton { get; }

		[NullAllowed, Export ("redoButton")]
		UIButton RedoButton { get; }

		[NullAllowed, Export ("undoRedoButton")]
		PSPDFToolbarDualButton UndoRedoButton { get; }

		[NullAllowed, Export ("strokeColorButton")]
		PSPDFColorButton StrokeColorButton { get; }

		[Export ("done:")]
		void Done ([NullAllowed] NSObject sender);
	}

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface PSPDFFlexibleToolbarController : PSPDFFlexibleToolbarContainerDelegate {

		[Export ("initWithToolbar:")]
		[DesignatedInitializer]
		IntPtr Constructor (PSPDFFlexibleToolbar toolbar);

		[Export ("toolbar")]
		PSPDFFlexibleToolbar Toolbar { get; }

		[NullAllowed, Export ("flexibleToolbarContainer")]
		PSPDFFlexibleToolbarContainer FlexibleToolbarContainer { get; }

		[Export ("toolbarVisible")]
		bool ToolbarVisible { [Bind ("isToolbarVisible")] get; }

		[Export ("toggleToolbarAnimated:")]
		void ToggleToolbar (bool animated);

		[Export ("showToolbarAnimated:")]
		bool ShowToolbar (bool animated);

		[Export ("hideToolbarAnimated:")]
		bool HideToolbar (bool animated);

		[Export ("updateHostView:container:viewController:")]
		void UpdateHostView ([NullAllowed] UIView hostView, [NullAllowed] NSObject container, [NullAllowed] UIViewController viewController);

		[NullAllowed, Export ("hostView")]
		UIView HostView { get; }

		[NullAllowed, Export ("hostToolbar")]
		IPSPDFSystemBar HostToolbar { get; }

		[NullAllowed, Export ("hostViewController", ArgumentSemantic.Weak)]
		UIViewController HostViewController { get; }
	}

	interface PSPDFAnnotationToolbarControllerVisibilityDidChangeNotificationEventArgs {

		[Export ("PSPDFAnnotationToolbarControllerVisibilityAnimatedKey")]
		bool VisibilityAnimated { get; set; }
	}

	[BaseType (typeof (PSPDFFlexibleToolbarController))]
	interface PSPDFAnnotationToolbarController {

		[Field ("PSPDFAnnotationToolbarControllerVisibilityDidChangeNotification", PSPDFKitGlobal.LibraryPath)]
		[Notification (typeof (PSPDFAnnotationToolbarControllerVisibilityDidChangeNotificationEventArgs))]
		NSString VisibilityDidChangeNotification { get; }

		[Export ("initWithAnnotationToolbar:")]
		IntPtr Constructor (PSPDFAnnotationToolbar annotationToolbar);

		[Export ("annotationToolbar")]
		PSPDFAnnotationToolbar AnnotationToolbar { get; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFFlexibleToolbarContainerDelegate Delegate { get; set; }
	}

	[BaseType (typeof (UIView))]
	interface PSPDFAnnotationView : PSPDFAnnotationPresenting {

		// Inlined from PSPDFAnnotationPresenting
		//[NullAllowed, Export ("annotation", ArgumentSemantic.Strong)]
		//PSPDFAnnotation Annotation { get; set; }

		//[NullAllowed, Export ("pageView", ArgumentSemantic.Weak)]
		//PSPDFPageView PageView { get; set; }

		//[Export ("zoomScale")]
		//nfloat ZoomScale { get; set; }

		// PSPDFAnnotationView (SubclassingHooks) Category

		[Export ("annotationChangedNotification:")]
		[Advice ("Requires base call if override.")]
		void AnnotationChangedNotification (NSNotification notification);

		[Export ("shouldAnimatedAnnotationChanges")]
		bool ShouldAnimatedAnnotationChanges { get; set; }

		[Export ("updateFrame")]
		[Advice ("Requires base call if override.")]
		void UpdateFrame ();
	}

	interface IPSPDFAppearanceModeManagerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFAppearanceModeManagerDelegate {

		[Export ("appearanceManager:renderOptionsForMode:")]
		NSDictionary<NSString, NSObject> GetRenderOptions (PSPDFAppearanceModeManager manager, PSPDFAppearanceMode mode);

		[Export ("appearanceManager:applyAppearanceSettingsForMode:")]
		void ApplyAppearanceSettings (PSPDFAppearanceModeManager manager, PSPDFAppearanceMode mode);

		[Export ("appearanceManager:updateConfiguration:forMode:")]
		void UpdateConfiguration (PSPDFAppearanceModeManager manager, PSPDFConfigurationBuilder builder, PSPDFAppearanceMode mode);
	}

	interface PSPDFAppearanceModeChangedNotificationEventArgs {

		[Export ("PSPDFAppearanceModeChangedAnimatedKey")]
		bool Animated { get; set; }
	}

	[BaseType (typeof (NSObject))]
	interface PSPDFAppearanceModeManager {

		[Field ("PSPDFAppearanceModeChangedNotification", PSPDFKitGlobal.LibraryPath)]
		[Notification (typeof (PSPDFAppearanceModeChangedNotificationEventArgs))]
		NSString AppearanceModeChangedNotification { get; }

		[Export ("appearanceMode", ArgumentSemantic.Assign)]
		PSPDFAppearanceMode AppearanceMode { get; set; }

		[Export ("setAppearanceMode:animated:")]
		void SetAppearanceMode (PSPDFAppearanceMode appearanceMode, bool animated);

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFAppearanceModeManagerDelegate Delegate { get; set; }
	}

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface PSPDFApplePencilDriver : PSPDFStylusDriver {

		[Field ("PSPDFApplePencilDetectedNotification", PSPDFKitGlobal.LibraryPath)]
		[Notification]
		NSString PencilDetectedNotification { get; }

		[Field ("PSPDFApplePencilDetectedChangedNotification", PSPDFKitGlobal.LibraryPath)]
		[Notification]
		NSString PencilDetectedChangedNotification { get; }

		[Static]
		[Export ("detected")]
		bool Detected { [Bind ("wasDetected")] get; set; }

		[Export ("initWithDelegate:")]
		[DesignatedInitializer]
		IntPtr Constructor (IPSPDFStylusDriverDelegate @delegate);

		// Inlined from the PSPDFStylusDriver protocol
		//[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		//IPSPDFStylusDriverDelegate Delegate { get; set; }
	}

	interface IPSPDFApplication { }

	[Protocol]
	interface PSPDFApplication {

		[Abstract]
		[Export ("canOpenURL:")]
		bool CanOpenUrl (NSUrl url);

		[Abstract]
		[Export ("openURL:options:completionHandler:")]
		void OpenUrl (NSUrl url, [NullAllowed] NSDictionary options, [NullAllowed] Action<bool> completionHandler);

		[Abstract]
		[Export ("networkIndicatorManager")]
		IPSPDFNetworkActivityIndicatorManager NetworkIndicatorManager { get; }
	}

	[BaseType (typeof (NSObject))]
	interface PSPDFDefaultApplication : PSPDFApplication {

	}

	[BaseType (typeof (PSPDFDefaultApplication))]
	[DisableDefaultCtor]
	interface PSPDFExtensionApplication : PSPDFApplication {

		[Export ("initWithExtensionContext:")]
		[DesignatedInitializer]
		IntPtr Constructor (NSExtensionContext extensionContext);

		[Export ("networkIndicatorManager"), New]
		new IPSPDFNetworkActivityIndicatorManager NetworkIndicatorManager { get; }
	}

	interface IPSPDFAvoidingScrollViewDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFAvoidingScrollViewDelegate : IUIScrollViewDelegate {

		[Export ("scrollViewShouldAvoidKeyboard:")]
		bool ShouldAvoidKeyboard (PSPDFAvoidingScrollView scrollView);
	}

	[BaseType (typeof (UIScrollView))]
	interface PSPDFAvoidingScrollView {

		[Export ("avoidingKeyboard")]
		bool AvoidingKeyboard { [Bind ("isAvoidingKeyboard")] get; }

		[Export ("isHalfModalVisible")]
		bool IsHalfModalVisible { get; }

		[Export ("firstResponderIsTextInput")]
		bool FirstResponderIsTextInput { get; }

		[Export ("enableAvoidance")]
		bool EnableAvoidance { get; set; }
	}

	[BaseType (typeof (PSPDFButton))]
	interface PSPDFBackForwardButton {

		[Static]
		[Export ("backButton")]
		PSPDFBackForwardButton GetBackButton ();

		[Static]
		[Export ("forwardButton")]
		PSPDFBackForwardButton GetForwardButton ();

		[Export ("buttonStyle", ArgumentSemantic.Assign)]
		PSPDFBackButtonStyle ButtonStyle { get; set; }

		[Export ("blurEffectStyle", ArgumentSemantic.Assign)]
		UIBlurEffectStyle BlurEffectStyle { get; set; }

		[Export ("longPressRecognizer")]
		UILongPressGestureRecognizer LongPressRecognizer { get; }
	}

	[BaseType (typeof (UITableViewController))]
	interface PSPDFBaseTableViewController {

	}

	[BaseType (typeof (UIViewController))]
	interface PSPDFBaseViewController {

		// PSPDFBaseViewController (SubclassingHooks)

		[Export ("contentSizeDidChange")]
		[Advice ("Requires base call if override.")]
		void ContentSizeDidChange ();

		// PSPDFBaseViewController (SubclassingWarnings)

		[Export ("viewWillAppear:"), New]
		[Advice ("Requires base call if override.")]
		void ViewWillAppear (bool animated);

		[Export ("viewDidAppear:"), New]
		[Advice ("Requires base call if override.")]
		void ViewDidAppear (bool animated);

		[Export ("viewWillDisappear:"), New]
		[Advice ("Requires base call if override.")]
		void ViewWillDisappear (bool animated);

		[Export ("viewDidDisappear:"), New]
		[Advice ("Requires base call if override.")]
		void ViewDidDisappear (bool animated);

		[Export ("viewWillLayoutSubviews"), New]
		[Advice ("Requires base call if override.")]
		void ViewWillLayoutSubviews ();

		[Export ("viewDidLayoutSubviews"), New]
		[Advice ("Requires base call if override.")]
		void ViewDidLayoutSubviews ();

		[Export ("didReceiveMemoryWarning"), New]
		[Advice ("Requires base call if override.")]
		void DidReceiveMemoryWarning ();
	}

	[BaseType (typeof (UIView))]
	interface PSPDFBlurView {

		[Export ("blurEnabled")]
		bool BlurEnabled { [Bind ("isBlurEnabled")] get; set; }

		[NullAllowed, Export ("renderView", ArgumentSemantic.Weak)]
		UIView RenderView { get; set; }

		[NullAllowed, Export ("containerView", ArgumentSemantic.Weak)]
		UIView ContainerView { get; set; }

		[NullAllowed, Export ("blurEnabledObject", ArgumentSemantic.Strong)]
		NSNumber BlurEnabledObject { get; set; }
	}

	interface IPSPDFBookmarkTableViewCellDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFBookmarkTableViewCellDelegate {

		[Abstract]
		[Export ("bookmarkCell:didUpdateBookmarkString:")]
		void DidUpdateBookmarkString (PSPDFBookmarkCell cell, string bookmarkString);
	}

	[BaseType (typeof (PSPDFNonAnimatingTableViewCell))]
	interface PSPDFBookmarkCell : IUITextFieldDelegate {

		[Export ("bookmarkString")]
		string BookmarkString { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFBookmarkTableViewCellDelegate Delegate { get; set; }

		// PSPDFBookmarkCell (SubclassingHooks)

		[NullAllowed, Export ("textField")]
		UITextField TextField { get; set; }
	}

	[BaseType (typeof (UIButton))]
	interface PSPDFBookmarkIndicatorButton {

		[Export ("imageType", ArgumentSemantic.Assign)]
		PSPDFBookmarkIndicatorImageType ImageType { get; set; }

		[Export ("normalTintColor", ArgumentSemantic.Strong)]
		UIColor NormalTintColor { get; set; }

		[Export ("selectedTintColor", ArgumentSemantic.Strong)]
		UIColor SelectedTintColor { get; set; }
	}

	interface IPSPDFBookmarkViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFBookmarkViewControllerDelegate : IPSPDFOverridable {

		[Abstract]
		[Export ("currentPageForBookmarkViewController:")]
		nuint GetCurrentPage (PSPDFBookmarkViewController bookmarkController);

		[Abstract]
		[Export ("bookmarkViewController:didSelectBookmark:")]
		void DidSelectBookmark (PSPDFBookmarkViewController bookmarkController, PSPDFBookmark bookmark);
	}

	[BaseType (typeof (PSPDFStatefulTableViewController))]
	interface PSPDFBookmarkViewController : PSPDFBookmarkTableViewCellDelegate, PSPDFDocumentInfoController, PSPDFStyleable {

		[Export ("allowCopy")]
		bool AllowCopy { get; set; }

		[Export ("sortOrder", ArgumentSemantic.Assign)]
		PSPDFBookmarkManagerSortOrder SortOrder { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFBookmarkViewControllerDelegate Delegate { get; set; }

		// PSPDFBookmarkViewController (SubclassingHooks) Category

		[Export ("updateBookmarkViewAnimated:")]
		void UpdateBookmarkView (bool animated);

		[Export ("addBookmarkAction:")]
		void AddBookmarkAction ([NullAllowed] NSObject sender);

		[Export ("doneAction:")]
		void DoneAction ([NullAllowed] NSObject sender);
	}

	[BaseType (typeof (NSObject))]
	interface PSPDFBrightnessManager {

		[Export ("wantsSoftwareDimming")]
		bool WantsSoftwareDimming { get; set; }

		[Export ("wantsAdditionalSoftwareDimming")]
		bool WantsAdditionalSoftwareDimming { get; set; }

		[Export ("additionalBrightnessDimmingFactor")]
		nfloat AdditionalBrightnessDimmingFactor { get; set; }

		[Export ("maximumAdditionalBrightnessDimmingFactor")]
		nfloat MaximumAdditionalBrightnessDimmingFactor { get; set; }

		[Export ("idleTimerManagement", ArgumentSemantic.Assign)]
		PSPDFIdleTimerManagement IdleTimerManagement { get; set; }

		[Export ("extendedIdleTime")]
		double ExtendedIdleTime { get; set; }

		[Export ("brightness")]
		nfloat Brightness { get; set; }
	}

	[BaseType (typeof (PSPDFStaticTableViewController))]
	interface PSPDFBrightnessViewController {

		[Export ("brightnessManager")]
		PSPDFBrightnessManager BrightnessManager { get; }

		[NullAllowed, Export ("appearanceModeManager", ArgumentSemantic.Strong)]
		PSPDFAppearanceModeManager AppearanceModeManager { get; set; }

		[Export ("allowedAppearanceModes", ArgumentSemantic.Assign)]
		PSPDFAppearanceMode AllowedAppearanceModes { get; set; }
	}

	delegate void PSPDFButtonActionHandler (PSPDFButton arg0);

	[BaseType (typeof (UIButton))]
	interface PSPDFButton {

		[Export ("touchAreaInsets", ArgumentSemantic.Assign)]
		UIEdgeInsets TouchAreaInsets { get; set; }

		[Export ("positionImageOnRight")]
		bool PositionImageOnRight { get; set; }

		[Export ("actionBlock", ArgumentSemantic.Copy)]
		PSPDFButtonActionHandler ActionHandler { get; set; }

		[Export ("setActionBlock:forControlEvents:")]
		void SetAction ([NullAllowed] PSPDFButtonActionHandler actionHandler, UIControlEvent controlEvents);
	}

	[BaseType (typeof (PSPDFFormElementView))]
	interface PSPDFButtonFormElementView {

	}

	[BaseType (typeof (PSPDFStatefulTableViewController))]
	[DisableDefaultCtor]
	interface PSPDFCertificatePickerViewController {

		[Export ("initWithRegisteredSigners:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] PSPDFSigner [] registeredSigners);

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFCertificatePickerViewControllerDelegate Delegate { get; set; }
	}

	interface IPSPDFCertificatePickerViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFCertificatePickerViewControllerDelegate {

		[Export ("certificatePickerViewController:didPickSigner:")]
		void DidPickSigner (PSPDFCertificatePickerViewController controller, [NullAllowed] PSPDFSigner signer);
	}

	[BaseType (typeof (PSPDFFormElementView))]
	interface PSPDFChoiceFormElementView {

		[Export ("prepareChoiceFormEditorController")]
		NSObject PrepareChoiceFormEditorController ();
	}

	[BaseType (typeof (UICollectionReusableView))]
	interface PSPDFCollectionReusableFilterView {

		[Static]
		[Wrap ("(float) UILayoutPriority.DefaultHigh - 10f")]
		UILayoutPriority CenterPriority { get; }

		[Static]
		[Wrap ("8")]
		nfloat DefaultMargin { get; }

		[NullAllowed, Export ("filterElement", ArgumentSemantic.Strong)]
		UISegmentedControl FilterElement { get; set; }

		[Export ("filterElementOffset", ArgumentSemantic.Assign)]
		CGPoint FilterElementOffset { get; set; }

		[Export ("minimumFilterMargin", ArgumentSemantic.Assign)]
		UIEdgeInsets MinimumFilterMargin { get; set; }

		[Export ("backgroundStyle", ArgumentSemantic.Assign)]
		PSPDFCollectionReusableFilterViewStyle BackgroundStyle { get; set; }
	}

	[BaseType (typeof (PSPDFButton))]
	interface PSPDFColorButton {

		[Export ("color", ArgumentSemantic.Strong)]
		UIColor Color { get; set; }

		[Export ("displayAsEllipse")]
		bool DisplayAsEllipse { get; set; }

		[Export ("borderWidth")]
		nfloat BorderWidth { get; set; }

		[Export ("indicatorSize", ArgumentSemantic.Assign)]
		CGSize IndicatorSize { get; set; }
	}

	[BaseType (typeof (NSObject))]
	interface PSPDFColorPatch {

		[Static]
		[Export ("colorPatchWithColor:")]
		PSPDFColorPatch Create (UIColor color);

		[Static]
		[Export ("colorPatchWithColors:")]
		PSPDFColorPatch Create (UIColor [] colors);

		[Export ("colors", ArgumentSemantic.Copy)]
		UIColor [] Colors { get; }
	}

	[BaseType (typeof (NSObject))]
	interface PSPDFColorPalette {

		[Static]
		[Export ("colorPaletteWithTitle:colorPatches:")]
		PSPDFColorPalette Create (string title, PSPDFColorPatch [] patches);

		[Static]
		[Export ("hsvColorPaletteWithTitle:")]
		PSPDFColorPalette CreateHsv (string title);

		[Export ("title")]
		string Title { get; }

		[Export ("colorPatches", ArgumentSemantic.Copy)]
		PSPDFColorPatch [] ColorPatches { get; }

		// PSPDFColorPalette (PSPDFColorPalettes) Category

		[Static]
		[Export ("monochromeColorPalette")]
		PSPDFColorPalette MonochromeColorPalette { get; }

		[Static]
		[Export ("monochromeTransparentPalette")]
		PSPDFColorPalette MonochromeTransparentPalette { get; }

		[Static]
		[Export ("modernColorPalette")]
		PSPDFColorPalette ModernColorPalette { get; }

		[Static]
		[Export ("vintageColorPalette")]
		PSPDFColorPalette VintageColorPalette { get; }

		[Static]
		[Export ("rainbowColorPalette")]
		PSPDFColorPalette RainbowColorPalette { get; }

		[Static]
		[Export ("paperColorPalette")]
		PSPDFColorPalette PaperColorPalette { get; }

		[Static]
		[Export ("hsvColorPalette")]
		PSPDFColorPalette HsvColorPalette { get; }
	}

	[BaseType (typeof (NSObject))]
	interface PSPDFColorPickerFactory {

		[Static]
		[Export ("colorPalettesInColorSet:")]
		PSPDFColorPalette [] GetColorPalettes (PSPDFColorSet colorSet);
	}

	[BaseType (typeof (PSPDFBaseConfigurationBuilder))]
	interface PSPDFConfigurationBuilder {

		[Export ("overrideClass:withClass:")]
		void OverrideClass (Class builtinClass, [NullAllowed] Class subclass);

		[Wrap ("OverrideClass (builtinClass: new Class (builtinType), subclass: subType == null ? null : new Class (subType))")]
		void OverrideClass (Type builtinType, Type subType);

		[Export ("doubleTapAction")]
		PSPDFTapAction DoubleTapAction { get; set; }

		[Export ("formElementZoomEnabled")]
		bool FormElementZoomEnabled { [Bind ("isFormElementZoomEnabled")] get; set; }

		[Export ("scrollOnTapPageEndEnabled")]
		bool ScrollOnTapPageEndEnabled { [Bind ("isScrollOnTapPageEndEnabled")] get; set; }

		[Export ("scrollOnTapPageEndAnimationEnabled")]
		bool ScrollOnTapPageEndAnimationEnabled { [Bind ("isScrollOnTapPageEndAnimationEnabled")] get; set; }

		[Export ("scrollOnTapPageEndMargin")]
		nfloat ScrollOnTapPageEndMargin { get; set; }

		[Export ("textSelectionEnabled")]
		bool TextSelectionEnabled { [Bind ("isTextSelectionEnabled")] get; set; }

		[Export ("imageSelectionEnabled")]
		bool ImageSelectionEnabled { [Bind ("isImageSelectionEnabled")] get; set; }

		[Export ("linkAction")]
		PSPDFLinkAction LinkAction { get; set; }

		[Export ("allowedMenuActions")]
		PSPDFTextSelectionMenuAction AllowedMenuActions { get; set; }

		[Export ("userInterfaceViewMode")]
		PSPDFUserInterfaceViewMode UserInterfaceViewMode { get; set; }

		[Export ("textSelectionMode")]
		PSPDFTextSelectionMode TextSelectionMode { get; set; }

		[Export ("textSelectionShouldSnapToWord")]
		bool TextSelectionShouldSnapToWord { get; set; }

		[Export ("typesShowingColorPresets")]
		PSPDFAnnotationType TypesShowingColorPresets { get; set; }

		[Export ("propertiesForAnnotations")]
		NSDictionary<NSString, NSObject> PropertiesForAnnotations { get; set; }

		[Export ("freeTextAccessoryViewEnabled")]
		bool FreeTextAccessoryViewEnabled { [Bind ("isFreeTextAccessoryViewEnabled")] get; set; }

		[Export ("bookmarkSortOrder")]
		PSPDFBookmarkManagerSortOrder BookmarkSortOrder { get; set; }

		[Export ("bookmarkIndicatorMode")]
		PSPDFPageBookmarkIndicatorMode BookmarkIndicatorMode { get; set; }

		[Export ("bookmarkIndicatorInteractionEnabled")]
		bool BookmarkIndicatorInteractionEnabled { get; set; }

		[Export ("internalTapGesturesEnabled")]
		bool InternalTapGesturesEnabled { get; set; }

		[Export ("useParentNavigationBar")]
		bool UseParentNavigationBar { get; set; }

		[Export ("userInterfaceViewAnimation")]
		PSPDFUserInterfaceViewAnimation UserInterfaceViewAnimation { get; set; }

		[Export ("thumbnailBarMode")]
		PSPDFThumbnailBarMode ThumbnailBarMode { get; set; }

		[Export ("pageLabelEnabled")]
		bool PageLabelEnabled { [Bind ("isPageLabelEnabled")] get; set; }

		[Export ("documentLabelEnabled")]
		PSPDFAdaptiveConditional DocumentLabelEnabled { get; set; }

		[Export ("shouldHideUserInterfaceOnPageChange")]
		bool ShouldHideUserInterfaceOnPageChange { get; set; }

		[Export ("shouldShowUserInterfaceOnViewWillAppear")]
		bool ShouldShowUserInterfaceOnViewWillAppear { get; set; }

		[Export ("pageGrabberEnabled")]
		bool PageGrabberEnabled { [Bind ("isPageGrabberEnabled")] get; set; }

		[Export ("allowToolbarTitleChange")]
		bool AllowToolbarTitleChange { get; set; }

		[Export ("renderAnimationEnabled")]
		bool RenderAnimationEnabled { [Bind ("isRenderAnimationEnabled")] get; set; }

		[Export ("renderStatusViewPosition")]
		PSPDFRenderStatusViewPosition RenderStatusViewPosition { get; set; }

		[Export ("pageMode")]
		PSPDFPageMode PageMode { get; set; }

		[Export ("scrubberBarType")]
		PSPDFScrubberBarType ScrubberBarType { get; set; }

		[Export ("thumbnailGrouping")]
		PSPDFThumbnailGrouping ThumbnailGrouping { get; set; }

		[Export ("pageTransition")]
		PSPDFPageTransition PageTransition { get; set; }

		[Export ("scrollDirection")]
		PSPDFScrollDirection ScrollDirection { get; set; }

		[Export ("scrollViewInsetAdjustment")]
		PSPDFScrollInsetAdjustment ScrollViewInsetAdjustment { get; set; }

		[Export ("firstPageAlwaysSingle")]
		bool FirstPageAlwaysSingle { [Bind ("isFirstPageAlwaysSingle")] get; set; }

		[Export ("spreadFitting")]
		PSPDFConfigurationSpreadFitting SpreadFitting { get; set; }

		[Export ("clipToPageBoundaries")]
		bool ClipToPageBoundaries { get; set; }

		[Export ("additionalScrollViewFrameInsets")]
		UIEdgeInsets AdditionalScrollViewFrameInsets { get; set; }

		[Export ("additionalContentInsets")]
		UIEdgeInsets AdditionalContentInsets { get; set; }

		[Export ("minimumZoomScale")]
		float MinimumZoomScale { get; set; }

		[Export ("maximumZoomScale")]
		float MaximumZoomScale { get; set; }

		[Export ("shadowEnabled")]
		bool ShadowEnabled { [Bind ("isShadowEnabled")] get; set; }

		[Export ("shadowOpacity")]
		nfloat ShadowOpacity { get; set; }

		[Export ("shouldHideNavigationBarWithUserInterface")]
		bool ShouldHideNavigationBarWithUserInterface { get; set; }

		[Export ("shouldHideStatusBar")]
		bool ShouldHideStatusBar { get; set; }

		[Export ("shouldHideStatusBarWithUserInterface")]
		bool ShouldHideStatusBarWithUserInterface { get; set; }

		[Export ("backgroundColor")]
		UIColor BackgroundColor { get; set; }

		[Export ("allowedAppearanceModes")]
		PSPDFAppearanceMode AllowedAppearanceModes { get; set; }

		[Export ("thumbnailSize")]
		CGSize ThumbnailSize { get; set; }

		[Export ("thumbnailInteritemSpacing")]
		nfloat ThumbnailInteritemSpacing { get; set; }

		[Export ("thumbnailLineSpacing")]
		nfloat ThumbnailLineSpacing { get; set; }

		[Export ("thumbnailMargin")]
		UIEdgeInsets ThumbnailMargin { get; set; }

		[Export ("annotationAnimationDuration")]
		nfloat AnnotationAnimationDuration { get; set; }

		[Export ("annotationGroupingEnabled")]
		bool AnnotationGroupingEnabled { get; set; }

		[Export ("createAnnotationMenuEnabled")]
		bool CreateAnnotationMenuEnabled { [Bind ("isCreateAnnotationMenuEnabled")] get; set; }

		[Export ("createAnnotationMenuGroups", ArgumentSemantic.Copy)]
		PSPDFAnnotationGroup [] CreateAnnotationMenuGroups { get; set; }

		[Export ("naturalDrawingAnnotationEnabled")]
		bool NaturalDrawingAnnotationEnabled { get; set; }

		[Export ("drawCreateMode")]
		PSPDFDrawCreateMode DrawCreateMode { get; set; }

		[Export ("showAnnotationMenuAfterCreation")]
		bool ShowAnnotationMenuAfterCreation { get; set; }

		[Export ("shouldAskForAnnotationUsername")]
		bool ShouldAskForAnnotationUsername { get; set; }

		[Export ("annotationEntersEditModeAfterSecondTapEnabled")]
		bool AnnotationEntersEditModeAfterSecondTapEnabled { get; set; }

		[Advice ("You can use 'EditableAnnotationTypes' for a more strongly typed access.")]
		[NullAllowed, Export ("editableAnnotationTypes", ArgumentSemantic.Copy)]
		NSSet<NSString> WeakEditableAnnotationTypes { get; set; }

		[Export ("autosaveEnabled")]
		bool AutosaveEnabled { [Bind ("isAutosaveEnabled")] get; set; }

		[Export ("allowBackgroundSaving")]
		bool AllowBackgroundSaving { get; set; }

		[Export ("soundAnnotationTimeLimit")]
		double SoundAnnotationTimeLimit { get; set; }

		[Export ("soundAnnotationRecordingOptions")]
		NSDictionary WeakSoundAnnotationRecordingOptions { get; set; }

		[Wrap ("WeakSoundAnnotationRecordingOptions")]
		AudioSettings SoundAnnotationRecordingOptions { get; set; }

		[Export ("shouldCacheThumbnails")]
		bool ShouldCacheThumbnails { get; set; }

		[Export ("shouldScrollToChangedPage")]
		bool ShouldScrollToChangedPage { get; set; }

		[Export ("searchMode")]
		PSPDFSearchMode SearchMode { get; set; }

		[Export ("searchResultZoomScale")]
		nfloat SearchResultZoomScale { get; set; }

		[Export ("signatureSavingStrategy")]
		PSPDFSignatureSavingStrategy SignatureSavingStrategy { get; set; }

		[Export ("signatureCertificateSelectionMode")]
		PSPDFSignatureCertificateSelectionMode SignatureCertificateSelectionMode { get; set; }

		[Export ("signatureBiometricPropertiesOptions")]
		PSPDFSignatureBiometricPropertiesOption SignatureBiometricPropertiesOptions { get; set; }

		[Export ("naturalSignatureDrawingEnabled")]
		bool NaturalSignatureDrawingEnabled { get; set; }

		[Export ("signatureStore")]
		IPSPDFSignatureStore SignatureStore { get; set; }

		[Export ("galleryConfiguration")]
		PSPDFGalleryConfiguration GalleryConfiguration { get; set; }

		[Export ("showBackActionButton")]
		bool ShowBackActionButton { get; set; }

		[Export ("showForwardActionButton")]
		bool ShowForwardActionButton { get; set; }

		[Export ("showBackForwardActionButtonLabels")]
		bool ShowBackForwardActionButtonLabels { get; set; }

		[Export ("soundAnnotationPlayerStyle")]
		PSPDFSoundAnnotationPlayerStyle SoundAnnotationPlayerStyle { get; set; }

		[Export ("dragAndDropConfiguration")]
		PSPDFDragAndDropConfiguration DragAndDropConfiguration { get; set; }

		[Advice ("You can use either 'ApplicationActivitiesAsObjects' or 'ApplicationActivitiesAsTypes' for a strongly typed access")]
		[Export ("applicationActivities", ArgumentSemantic.Copy)]
		NSObject [] ApplicationActivities { get; set; }

		[Advice ("You can use 'ExcludedActivityTypes' for a strongly typed access")]
		[Export ("excludedActivityTypes", ArgumentSemantic.Copy)]
		NSString [] WeakExcludedActivityTypes { get; set; }

		[Export ("printSharingOptions")]
		PSPDFDocumentSharingOptions PrintSharingOptions { get; set; }

		[Export ("printConfiguration")]
		PSPDFPrintConfiguration PrintConfiguration { get; set; }

		[Export ("openInSharingOptions")]
		PSPDFDocumentSharingOptions OpenInSharingOptions { get; set; }

		[Export ("mailSharingOptions")]
		PSPDFDocumentSharingOptions MailSharingOptions { get; set; }

		[Export ("messageSharingOptions")]
		PSPDFDocumentSharingOptions MessageSharingOptions { get; set; }

		[Export ("settingsOptions")]
		PSPDFSettingsOptions SettingsOptions { get; set; }
	}

	[BaseType (typeof (PSPDFBaseConfiguration))]
	interface PSPDFConfiguration : IPSPDFOverridable {

		[Static, New]
		[Export ("defaultConfiguration")]
		PSPDFConfiguration DefaultConfiguration { get; }

		[Export ("initWithBuilder:")]
		IntPtr Constructor (PSPDFConfigurationBuilder builder);

		[Static]
		[Export ("configurationWithBuilder:")]
		PSPDFConfiguration FromConfigurationBuilder ([NullAllowed] Action<PSPDFConfigurationBuilder> builderHandler);

		[Static]
		[Export ("configurationUpdatedWithBuilder:")]
		PSPDFConfiguration ConfigurationUpdated ([NullAllowed] Action<PSPDFConfigurationBuilder> builderHandler);

		[Export ("pageMode")]
		PSPDFPageMode PageMode { get; }

		[Export ("pageTransition")]
		PSPDFPageTransition PageTransition { get; }

		[Export ("firstPageAlwaysSingle")]
		bool FirstPageAlwaysSingle { [Bind ("isFirstPageAlwaysSingle")] get; }

		[Export ("spreadFitting")]
		PSPDFConfigurationSpreadFitting SpreadFitting { get; }

		[Export ("clipToPageBoundaries")]
		bool ClipToPageBoundaries { get; }

		[Export ("additionalScrollViewFrameInsets")]
		UIEdgeInsets AdditionalScrollViewFrameInsets { get; }

		[Export ("additionalContentInsets")]
		UIEdgeInsets AdditionalContentInsets { get; }

		[Export ("shadowEnabled")]
		bool ShadowEnabled { [Bind ("isShadowEnabled")] get; }

		[Export ("shadowOpacity")]
		nfloat ShadowOpacity { get; }

		[Export ("backgroundColor")]
		UIColor BackgroundColor { get; }

		[Export ("allowedAppearanceModes")]
		PSPDFAppearanceMode AllowedAppearanceModes { get; }

		[Export ("scrollDirection")]
		PSPDFScrollDirection ScrollDirection { get; }

		[Export ("scrollViewInsetAdjustment")]
		PSPDFScrollInsetAdjustment ScrollViewInsetAdjustment { get; }

		[Export ("minimumZoomScale")]
		float MinimumZoomScale { get; }

		[Export ("maximumZoomScale")]
		float MaximumZoomScale { get; }

		[Export ("renderAnimationEnabled")]
		bool RenderAnimationEnabled { [Bind ("isRenderAnimationEnabled")] get; }

		[Export ("renderStatusViewPosition")]
		PSPDFRenderStatusViewPosition RenderStatusViewPosition { get; }

		[Export ("doubleTapAction")]
		PSPDFTapAction DoubleTapAction { get; }

		[Export ("formElementZoomEnabled")]
		bool FormElementZoomEnabled { [Bind ("isFormElementZoomEnabled")] get; }

		[Export ("scrollOnTapPageEndEnabled")]
		bool ScrollOnTapPageEndEnabled { [Bind ("isScrollOnTapPageEndEnabled")] get; }

		[Export ("scrollOnTapPageEndAnimationEnabled")]
		bool ScrollOnTapPageEndAnimationEnabled { [Bind ("isScrollOnTapPageEndAnimationEnabled")] get; }

		[Export ("scrollOnTapPageEndMargin")]
		nfloat ScrollOnTapPageEndMargin { get; }

		[Export ("linkAction")]
		PSPDFLinkAction LinkAction { get; }

		[Export ("allowedMenuActions")]
		PSPDFTextSelectionMenuAction AllowedMenuActions { get; }

		[Export ("textSelectionEnabled")]
		bool TextSelectionEnabled { [Bind ("isTextSelectionEnabled")] get; }

		[Export ("imageSelectionEnabled")]
		bool ImageSelectionEnabled { [Bind ("isImageSelectionEnabled")] get; }

		[Export ("textSelectionMode")]
		PSPDFTextSelectionMode TextSelectionMode { get; }

		[Export ("textSelectionShouldSnapToWord")]
		bool TextSelectionShouldSnapToWord { get; }

		[Advice ("You can use 'EditableAnnotationTypes' for a more strongly typed access.")]
		[NullAllowed, Export ("editableAnnotationTypes", ArgumentSemantic.Copy)]
		NSSet<NSString> WeakEditableAnnotationTypes { get; }

		[Export ("typesShowingColorPresets")]
		PSPDFAnnotationType TypesShowingColorPresets { get; }

		[Export ("propertiesForAnnotations")]
		NSDictionary<NSString, NSObject> PropertiesForAnnotations { get; }

		[Export ("freeTextAccessoryViewEnabled")]
		bool FreeTextAccessoryViewEnabled { [Bind ("isFreeTextAccessoryViewEnabled")] get; }

		[Export ("bookmarkSortOrder")]
		PSPDFBookmarkManagerSortOrder BookmarkSortOrder { get; }

		[Export ("bookmarkIndicatorMode")]
		PSPDFPageBookmarkIndicatorMode BookmarkIndicatorMode { get; }

		[Export ("bookmarkIndicatorInteractionEnabled")]
		bool BookmarkIndicatorInteractionEnabled { get; }

		[Export ("userInterfaceViewMode")]
		PSPDFUserInterfaceViewMode UserInterfaceViewMode { get; }

		[Export ("userInterfaceViewAnimation")]
		PSPDFUserInterfaceViewAnimation UserInterfaceViewAnimation { get; }

		[Export ("pageLabelEnabled")]
		bool PageLabelEnabled { [Bind ("isPageLabelEnabled")] get; }

		[Export ("documentLabelEnabled")]
		PSPDFAdaptiveConditional DocumentLabelEnabled { get; }

		[Export ("shouldHideUserInterfaceOnPageChange")]
		bool ShouldHideUserInterfaceOnPageChange { get; }

		[Export ("shouldShowUserInterfaceOnViewWillAppear")]
		bool ShouldShowUserInterfaceOnViewWillAppear { get; }

		[Export ("pageGrabberEnabled")]
		bool PageGrabberEnabled { [Bind ("isPageGrabberEnabled")] get; }

		[Export ("allowToolbarTitleChange")]
		bool AllowToolbarTitleChange { get; }

		[Export ("shouldHideNavigationBarWithUserInterface")]
		bool ShouldHideNavigationBarWithUserInterface { get; }

		[Export ("shouldHideStatusBar")]
		bool ShouldHideStatusBar { get; }

		[Export ("shouldHideStatusBarWithUserInterface")]
		bool ShouldHideStatusBarWithUserInterface { get; }

		[Export ("showBackActionButton")]
		bool ShowBackActionButton { get; }

		[Export ("showForwardActionButton")]
		bool ShowForwardActionButton { get; }

		[Export ("showBackForwardActionButtonLabels")]
		bool ShowBackForwardActionButtonLabels { get; }

		[Export ("thumbnailBarMode")]
		PSPDFThumbnailBarMode ThumbnailBarMode { get; }

		[Export ("scrubberBarType")]
		PSPDFScrubberBarType ScrubberBarType { get; }

		[Export ("thumbnailGrouping")]
		PSPDFThumbnailGrouping ThumbnailGrouping { get; }

		[Export ("thumbnailSize")]
		CGSize ThumbnailSize { get; }

		[Export ("thumbnailInteritemSpacing")]
		nfloat ThumbnailInteritemSpacing { get; }

		[Export ("thumbnailLineSpacing")]
		nfloat ThumbnailLineSpacing { get; }

		[Export ("thumbnailMargin")]
		UIEdgeInsets ThumbnailMargin { get; }

		[Export ("annotationAnimationDuration")]
		nfloat AnnotationAnimationDuration { get; }

		[Export ("annotationGroupingEnabled")]
		bool AnnotationGroupingEnabled { get; }

		[Export ("createAnnotationMenuEnabled")]
		bool CreateAnnotationMenuEnabled { [Bind ("isCreateAnnotationMenuEnabled")] get; }

		[Export ("createAnnotationMenuGroups", ArgumentSemantic.Copy)]
		PSPDFAnnotationGroup [] CreateAnnotationMenuGroups { get; }

		[Export ("naturalDrawingAnnotationEnabled")]
		bool NaturalDrawingAnnotationEnabled { get; }

		[Export ("drawCreateMode")]
		PSPDFDrawCreateMode DrawCreateMode { get; }

		[Export ("showAnnotationMenuAfterCreation")]
		bool ShowAnnotationMenuAfterCreation { get; }

		[Export ("shouldAskForAnnotationUsername")]
		bool ShouldAskForAnnotationUsername { get; }

		[Export ("annotationEntersEditModeAfterSecondTapEnabled")]
		bool AnnotationEntersEditModeAfterSecondTapEnabled { get; }

		[Export ("shouldScrollToChangedPage")]
		bool ShouldScrollToChangedPage { get; }

		[Export ("soundAnnotationPlayerStyle")]
		PSPDFSoundAnnotationPlayerStyle SoundAnnotationPlayerStyle { get; }

		[Export ("autosaveEnabled")]
		bool AutosaveEnabled { [Bind ("isAutosaveEnabled")] get; }

		[Export ("allowBackgroundSaving")]
		bool AllowBackgroundSaving { get; }

		[Export ("soundAnnotationTimeLimit")]
		double SoundAnnotationTimeLimit { get; }

		[Export ("soundAnnotationRecordingOptions")]
		NSDictionary WeakSoundAnnotationRecordingOptions { get; }

		[Wrap ("WeakSoundAnnotationRecordingOptions")]
		AudioSettings SoundAnnotationRecordingOptions { get; }

		[Export ("searchMode")]
		PSPDFSearchMode SearchMode { get; }

		[Export ("searchResultZoomScale")]
		nfloat SearchResultZoomScale { get; }

		[Export ("signatureSavingStrategy")]
		PSPDFSignatureSavingStrategy SignatureSavingStrategy { get; }

		[Export ("signatureCertificateSelectionMode")]
		PSPDFSignatureCertificateSelectionMode SignatureCertificateSelectionMode { get; }

		[Export ("signatureBiometricPropertiesOptions")]
		PSPDFSignatureBiometricPropertiesOption SignatureBiometricPropertiesOptions { get; }

		[Export ("naturalSignatureDrawingEnabled")]
		bool NaturalSignatureDrawingEnabled { get; }

		[Export ("signatureStore")]
		IPSPDFSignatureStore SignatureStore { get; }

		[Advice ("You can use either 'ApplicationActivitiesAsObjects' or 'ApplicationActivitiesAsTypes' for a strongly typed access")]
		[Export ("applicationActivities", ArgumentSemantic.Copy)]
		NSObject [] ApplicationActivities { get; }

		[Advice ("You can use 'ExcludedActivityTypes' for a strongly typed access")]
		[Export ("excludedActivityTypes", ArgumentSemantic.Copy)]
		NSString [] WeakExcludedActivityTypes { get; }

		[Export ("printSharingOptions")]
		PSPDFDocumentSharingOptions PrintSharingOptions { get; }

		[Export ("printConfiguration")]
		PSPDFPrintConfiguration PrintConfiguration { get; }

		[Export ("openInSharingOptions")]
		PSPDFDocumentSharingOptions OpenInSharingOptions { get; }

		[Export ("mailSharingOptions")]
		PSPDFDocumentSharingOptions MailSharingOptions { get; }

		[Export ("messageSharingOptions")]
		PSPDFDocumentSharingOptions MessageSharingOptions { get; }

		[Export ("settingsOptions")]
		PSPDFSettingsOptions SettingsOptions { get; }

		[Export ("internalTapGesturesEnabled")]
		bool InternalTapGesturesEnabled { get; }

		[Export ("useParentNavigationBar")]
		bool UseParentNavigationBar { get; }

		[Export ("shouldCacheThumbnails")]
		bool ShouldCacheThumbnails { get; }

		[Export ("galleryConfiguration")]
		PSPDFGalleryConfiguration GalleryConfiguration { get; }

		[Export ("dragAndDropConfiguration")]
		PSPDFDragAndDropConfiguration DragAndDropConfiguration { get; }

		[Static]
		[Export ("imageConfiguration")]
		PSPDFConfiguration ImageConfiguration { get; }
	}

	interface IPSPDFContainerViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFContainerViewControllerDelegate {

		[Export ("containerViewController:didUpdateSelectedIndex:")]
		void DidUpdateSelectedIndex (PSPDFContainerViewController controller, nuint selectedIndex);
	}

	[BaseType (typeof (PSPDFBaseViewController))]
	interface PSPDFContainerViewController : PSPDFStyleable {

		[Export ("initWithControllers:titles:")]
		IntPtr Constructor ([NullAllowed] UIViewController [] controllers, [NullAllowed] string [] titles);

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFContainerViewControllerDelegate Delegate { get; set; }

		[Export ("addViewController:")]
		void AddViewController (UIViewController controller);

		[Export ("removeViewController:")]
		void RemoveViewController (UIViewController controller);

		[Export ("viewControllers", ArgumentSemantic.Copy)]
		UIViewController [] ViewControllers { get; }

		[Export ("visibleViewControllerIndex")]
		nuint VisibleViewControllerIndex { get; set; }

		[Export ("setVisibleViewControllerIndex:animated:")]
		void SetVisibleViewControllerIndex (nuint visibleViewControllerIndex, bool animated);

		[Export ("shouldAnimateChanges")]
		bool ShouldAnimateChanges { get; set; }

		[NullAllowed, Export ("lastVisibleViewControllerTitleKey", ArgumentSemantic.Strong)]
		string LastVisibleViewControllerTitleKey { get; set; }

		// PSPDFContainerViewController (SubclassingHooks) Category

		[NullAllowed, Export ("filterSegment")]
		UISegmentedControl FilterSegment { get; set; }
	}

	[BaseType (typeof (PSPDFStackViewLayout))]
	interface PSPDFContinuousScrollingLayout {

		[Export ("fillAlongsideTransverseAxis")]
		bool FillAlongsideTransverseAxis { get; set; }
	}

	interface IPSPDFPageControls { }

	[Protocol]
	interface PSPDFPageControls {

		[Abstract]
		[Export ("setPageIndex:animated:")]
		void SetPageIndex (nuint pageIndex, bool animated);

		[Abstract]
		[Export ("setViewMode:animated:")]
		void SetViewMode (PSPDFViewMode viewMode, bool animated);

		[Abstract]
		[Export ("executePDFAction:targetRect:pageIndex:animated:actionContainer:")]
		bool ExecutePdfAction ([NullAllowed] PSPDFAction action, CGRect targetRect, nuint pageIndex, bool animated, [NullAllowed] NSObject actionContainer);

		[Abstract]
		[Export ("searchForString:options:sender:animated:")]
		void SearchForString ([NullAllowed] string searchText, [NullAllowed] NSDictionary options, [NullAllowed] NSObject sender, bool animated);

		[Abstract]
		[Export ("documentActionExecutor")]
		PSPDFDocumentActionExecutor DocumentActionExecutor { get; }

		[Abstract]
		[Export ("presentDocumentInfoViewControllerWithOptions:sender:animated:completion:")]
		[return: NullAllowed]
		UIViewController PresentDocumentInfoViewController ([NullAllowed] NSDictionary options, [NullAllowed] NSObject sender, bool animated, [NullAllowed] Action completion);

		[Abstract]
		[Export ("presentPreviewControllerForURL:title:options:sender:animated:completion:")]
		void PresentPreviewController (NSUrl fileUrl, [NullAllowed] string title, [NullAllowed] NSDictionary options, [NullAllowed] NSObject sender, bool animated, [NullAllowed] Action completion);

		[Abstract]
		[Export ("reloadData")]
		void ReloadData ();
	}

	[Protocol]
	interface PSPDFUserInterfaceControls {

		[Abstract]
		[Export ("shouldShowControls")]
		bool ShouldShowControls { get; }

		[Abstract]
		[Export ("hideControlsAnimated:")]
		bool HideControls (bool animated);

		[Abstract]
		[Export ("hideControlsAndPageElementsAnimated:")]
		bool HideControlsAndPageElements (bool animated);

		[Abstract]
		[Export ("toggleControlsAnimated:")]
		bool ToggleControls (bool animated);

		[Abstract]
		[Export ("showControlsAnimated:")]
		bool ShowControls (bool animated);

		[Abstract]
		[Export ("showMenuIfSelectedAnimated:allowPopovers:")]
		void ShowMenuIfSelected (bool animated, bool allowPopovers);
	}

	interface IPSPDFControlDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFControlDelegate : PSPDFPresentationActions, PSPDFPageControls, PSPDFUserInterfaceControls, PSPDFErrorHandler {

	}

	interface IPSPDFControllerStateHandling { }

	[Protocol]
	interface PSPDFControllerStateHandling {

		[Abstract]
		[NullAllowed, Export ("document", ArgumentSemantic.Weak)]
		PSPDFDocument Document { get; set; }

		[Abstract]
		[Export ("setControllerState:error:animated:")]
		void SetControllerState (PSPDFControllerState state, [NullAllowed] NSError error, bool animated);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	interface PSPDFDigitalSignatureCoordinator {

		// PSPDFDigitalSignatureCoordinator (SubclassingHooks) Category

		[Export ("pathForDigitallySignedDocumentFromOriginalDocument:suggestedFileName:")]
		string GetPathForDigitallySignedDocument (PSPDFDocument originalDocument, string fileName);

		[Export ("presentSignedDocument:showingPageIndex:")]
		void PresentSignedDocument (PSPDFDocument signedDocument, nuint pageIndex);

		[Export ("configureSignatureAppearanceWithBuilder:document:signature:")]
		void ConfigureSignatureAppearance (PSPDFSignatureAppearanceBuilder builder, PSPDFDocument document, PSPDFSignatureContainer signature);
	}

	interface IPSPDFDocumentActionExecutorDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFDocumentActionExecutorDelegate : PSPDFErrorHandler, IPSPDFOverridable {

		[Export ("documentActionExecutor:defaultOptionsForAction:")]
		NSDictionary GetDefaultOptions (PSPDFDocumentActionExecutor documentActionExecutor, NSString action);
	}

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface PSPDFDocumentActionExecutor : PSPDFDocumentSharingCoordinatorDelegate {

		[Export ("initWithSourceViewController:")]
		[DesignatedInitializer]
		IntPtr Constructor (IPSPDFPresentationActions sourceViewController);

		[NullAllowed, Export ("sourceViewController", ArgumentSemantic.Weak)]
		IPSPDFPresentationActions SourceViewController { get; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFDocumentActionExecutorDelegate Delegate { get; set; }

		[NullAllowed, Export ("documents", ArgumentSemantic.Strong)]
		PSPDFDocument [] Documents { get; set; }

		[Export ("canExecuteAction:")]
		bool CanExecuteAction (NSString action);

		[Wrap ("CanExecuteAction (documentAction.GetConstant ())")]
		bool CanExecuteAction (PSPDFDocumentAction documentAction);

		[Async]
		[Export ("executeAction:options:sender:animated:completion:")]
		void ExecuteAction (NSString action, [NullAllowed] NSDictionary options, [NullAllowed] NSObject sender, bool animated, [NullAllowed] Action completion);

		[Async]
		[Wrap ("ExecuteAction (documentAction.GetConstant (), exOptions?.Dictionary, sender, animated, completion)")]
		void ExecuteAction (PSPDFDocumentAction documentAction, PSPDFDocumentActionExecutorOptions exOptions, NSObject sender, bool animated, Action completion);
	}

	interface PSPDFDocumentActionExecutorOptions { }

	[Static]
	interface PSPDFDocumentActionExecutorOptionsKeys {

		[Field ("PSPDFDocumentActionSharingOptionsKey", PSPDFKitGlobal.LibraryPath)]
		NSString SharingOptionsKey { get; }

		[Field ("PSPDFDocumentActionVisiblePagesKey", PSPDFKitGlobal.LibraryPath)]
		NSString VisiblePagesKey { get; }
	}

	[BaseType (typeof (PSPDFPageCell))]
	interface PSPDFDocumentEditorCell {

	}

	[BaseType (typeof (PSPDFFlexibleToolbar))]
	interface PSPDFDocumentEditorToolbar {

		[Export ("addPageButton")]
		PSPDFToolbarButton AddPageButton { get; }

		[Export ("deletePagesButton")]
		PSPDFToolbarButton DeletePagesButton { get; }

		[Export ("duplicatePagesButton")]
		PSPDFToolbarButton DuplicatePagesButton { get; }

		[Export ("rotatePagesButton")]
		PSPDFToolbarButton RotatePagesButton { get; }

		[Export ("exportPagesButton")]
		PSPDFToolbarButton ExportPagesButton { get; }

		[Export ("selectAllPagesButton")]
		PSPDFToolbarButton SelectAllPagesButton { get; }

		[Export ("copyPagesButton")]
		PSPDFToolbarButton CopyPagesButton { get; }

		[Export ("pastePagesButton")]
		PSPDFToolbarButton PastePagesButton { get; }

		[Export ("undoButton")]
		PSPDFToolbarButton UndoButton { get; }

		[Export ("redoButton")]
		PSPDFToolbarButton RedoButton { get; }

		[Export ("doneButton")]
		PSPDFToolbarButton DoneButton { get; }

		[Export ("allPagesSelected")]
		bool AllPagesSelected { get; set; }

		// PSPDFDocumentEditorToolbar (SubclassingHooks) Category

		[Export ("buttonsForWidth:")]
		PSPDFToolbarButton [] GetButtons (nfloat width);
	}

	interface IPSPDFDocumentEditorToolbarControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFDocumentEditorToolbarControllerDelegate : PSPDFFlexibleToolbarContainerDelegate {

		[Abstract]
		[Export ("documentEditorToolbarController:didSelectPages:")]
		void DidSelectPages (PSPDFDocumentEditorToolbarController controller, NSIndexSet pages);

		[Export ("documentEditorToolbarController:indexForNewPageWithConfiguration:")]
		nuint GetIndexForNewPage (PSPDFDocumentEditorToolbarController controller, PSPDFNewPageConfiguration configuration);
	}

	interface PSPDFDocumentEditorToolbarControllerVisibilityDidChangeNotificationEventArgs {

		[Export ("PSPDFDocumentEditorToolbarControllerVisibilityAnimatedKey")]
		bool Animated { get; }
	}

	delegate void PSPDFDocumentEditorToolbarControllerToggleSaveCompletionHandler (bool cancelled);

	[BaseType (typeof (PSPDFFlexibleToolbarController))]
	interface PSPDFDocumentEditorToolbarController : IPSPDFDocumentEditorDelegate, PSPDFNewPageViewControllerDelegate, PSPDFSaveViewControllerDelegate {

		[Field ("PSPDFDocumentEditorToolbarControllerVisibilityDidChangeNotification", PSPDFKitGlobal.LibraryPath)]
		[Notification (typeof (PSPDFDocumentEditorToolbarControllerVisibilityDidChangeNotificationEventArgs))]
		NSString VisibilityDidChangeNotification { get; }

		[Export ("initWithDocumentEditorToolbar:")]
		IntPtr Constructor (PSPDFDocumentEditorToolbar documentEditorToolbar);

		[Export ("documentEditorToolbar")]
		PSPDFDocumentEditorToolbar DocumentEditorToolbar { get; }

		[NullAllowed, Export ("documentEditor", ArgumentSemantic.Strong)]
		PSPDFDocumentEditor DocumentEditor { get; set; }

		[Export ("selectedPages", ArgumentSemantic.Copy)]
		NSIndexSet SelectedPages { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFDocumentEditorToolbarControllerDelegate Delegate { get; set; }

		[NullAllowed, Export ("presentationContext", ArgumentSemantic.Weak)]
		IPSPDFPresentationContext PresentationContext { get; set; }

		[Export ("documentEditorConfiguration")]
		PSPDFDocumentEditorConfiguration DocumentEditorConfiguration { get; }

		[Export ("toggleNewPageController:presentationOptions:")]
		[return: NullAllowed]
		PSPDFNewPageViewController ToggleNewPageController ([NullAllowed] NSObject sender, [NullAllowed] NSDictionary options);

		[Export ("copySelectedPagesToPasteboard")]
		void CopySelectedPagesToPasteboard ();

		[Export ("pastePagesFromPasteboard")]
		void PastePagesFromPasteboard ();

		[Wrap ("ToggleNewPageController (sender, presentationOptions?.Dictionary)")]
		PSPDFNewPageViewController ToggleNewPageController (NSObject sender, PSPDFPresentationOptions presentationOptions);

		[Async]
		[Export ("toggleSaveActionSheet:presentationOptions:completionHandler:")]
		[return: NullAllowed]
		UIAlertController ToggleSaveActionSheet ([NullAllowed] NSObject sender, [NullAllowed] NSDictionary options, [NullAllowed] PSPDFDocumentEditorToolbarControllerToggleSaveCompletionHandler completionHandler);

		[Async]
		[Wrap ("ToggleSaveActionSheet (sender, presentationOptions?.Dictionary, completionHandler)")]
		UIAlertController ToggleSaveActionSheet (NSObject sender, PSPDFPresentationOptions presentationOptions, PSPDFDocumentEditorToolbarControllerToggleSaveCompletionHandler completionHandler);

		[Export ("toggleSaveController:presentationOptions:completionHandler:")]
		[return: NullAllowed]
		PSPDFSaveViewController ToggleSaveController ([NullAllowed] NSObject sender, [NullAllowed] NSDictionary options, [NullAllowed] PSPDFDocumentEditorToolbarControllerToggleSaveCompletionHandler completionHandler);

		[Async]
		[Wrap ("ToggleSaveController (sender, presentationOptions?.Dictionary, completionHandler)")]
		PSPDFSaveViewController ToggleSaveController (NSObject sender, PSPDFPresentationOptions presentationOptions, PSPDFDocumentEditorToolbarControllerToggleSaveCompletionHandler completionHandler);
	}

	[BaseType (typeof (UICollectionViewController))]
	interface PSPDFDocumentEditorViewController : PSPDFViewModePresenter, IPSPDFDocumentEditorDelegate {

		[Export ("cellClass", ArgumentSemantic.Strong)]
		new Class CellClass { get; set; }

		[NullAllowed, Export ("documentEditor", ArgumentSemantic.Strong)]
		PSPDFDocumentEditor DocumentEditor { get; set; }

		[Export ("toolbarController")]
		PSPDFDocumentEditorToolbarController ToolbarController { get; }
	}

	interface IPSPDFDocumentInfoController { }

	[Protocol]
	interface PSPDFDocumentInfoController {

		//TODO: inline
		// Hack: This must be manually bound to any class implementing this potocol
		//[Abstract]
		//[Export ("initWithDocument:")]
		//IntPtr Constructor ([NullAllowed] PSPDFDocument document);

		[Abstract]
		[NullAllowed, Export ("document", ArgumentSemantic.Weak)]
		PSPDFDocument Document { get; set; }

		[return: NullAllowed]
		[Export ("container")]
		PSPDFContainerViewController GetContainer ();

		[Export ("setContainer:")]
		void SetContainer ([NullAllowed] PSPDFContainerViewController container);
	}

	[BaseType (typeof (NSObject))]
	interface PSPDFDocumentInfoCoordinator {

		[Async]
		[Export ("presentToViewController:options:sender:animated:completion:")]
		[return: NullAllowed]
		UIViewController PresentToViewController (IPSPDFPresentationActions targetController, [NullAllowed] NSDictionary options, [NullAllowed] NSObject sender, bool animated, [NullAllowed] Action completion);

		[Export ("available")]
		bool Available { [Bind ("isAvailable")] get; }

		[NullAllowed, Export ("document", ArgumentSemantic.Strong)]
		PSPDFDocument Document { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFOverridable Delegate { get; set; }

		[Protected]
		[Export ("availableControllerOptions", ArgumentSemantic.Copy)]
		NSString [] _AvailableControllerOptions { get; set; }

		[Protected]
		[NullAllowed, Export ("didCreateControllerBlock", ArgumentSemantic.Copy)]
		Action<UIViewController, NSString> _DidCreateControllerHandler { get; set; }

		// PSPDFDocumentInfoCoordinator (SubclassingHooks) Category

		[Protected]
		[Export ("controllerForOption:")]
		[return: NullAllowed]
		UIViewController GetController (NSString option);

		[Wrap ("GetController (infoOption.GetConstant ())")]
		UIViewController GetController (PSPDFDocumentInfoOption infoOption);

		[Protected]
		[Export ("isOptionAvailable:")]
		bool IsOptionAvailable (NSString option);

		[Wrap ("IsOptionAvailable (infoOption.GetConstant ())")]
		bool IsOptionAvailable (PSPDFDocumentInfoOption infoOption);
	}

	[BaseType (typeof (PSPDFTableViewCell))]
	interface PSPDFDocumentPickerCell {

		[Export ("configureWithDocument:useDocumentTitle:detailText:pageIndex:previewImage:")]
		void Configure (PSPDFDocument document, bool useDocumentTitle, [NullAllowed] NSAttributedString detailText, nuint pageIndex, UIImage previewImage);

		[NullAllowed, Export ("document", ArgumentSemantic.Weak)]
		PSPDFDocument Document { get; set; }

		[Export ("pageIndex")]
		nuint PageIndex { get; set; }

		[NullAllowed, Export ("pagePreviewImage", ArgumentSemantic.Strong)]
		UIImage PagePreviewImage { get; set; }

		[Export ("setPagePreviewImage:animated:")]
		void SetPagePreviewImage ([NullAllowed] UIImage pagePreviewImage, bool animated);

		[Export ("pageImageView", ArgumentSemantic.Strong)]
		UIImageView PageImageView { get; set; }

		[Export ("titleLabel", ArgumentSemantic.Strong)]
		UILabel TitleLabel { get; set; }

		[Export ("detailLabel", ArgumentSemantic.Strong)]
		UILabel DetailLabel { get; set; }

		// PSPDFDocumentPickerCell (SubclassingHooks) Category

		[Static]
		[Export ("titleLabelFont", ArgumentSemantic.Strong)]
		UIFont TitleLabelFont { get; }

		[Static]
		[Export ("detailLabelFont", ArgumentSemantic.Strong)]
		UILabel DetailLabelFont { get; }
	}

	interface IPSPDFDocumentPickerControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFDocumentPickerControllerDelegate : IPSPDFOverridable {

		[Abstract]
		[Export ("documentPickerController:didSelectDocument:pageIndex:searchString:")]
		void DidSelectDocument (PSPDFDocumentPickerController controller, PSPDFDocument document, nuint pageIndex, string searchString);

		[Export ("documentPickerControllerWillBeginSearch:")]
		void WillBeginSearch (PSPDFDocumentPickerController controller);

		[Export ("documentPickerControllerDidBeginSearch:")]
		void DidBeginSearch (PSPDFDocumentPickerController controller);

		[Export ("documentPickerControllerWillEndSearch:")]
		void WillEndSearch (PSPDFDocumentPickerController controller);

		[Export ("documentPickerControllerDidEndSearch:")]
		void DidEndSearch (PSPDFDocumentPickerController controller);
	}

	[BaseType (typeof (PSPDFStatefulTableViewController))]
	interface PSPDFDocumentPickerController : IUISearchDisplayDelegate, IUISearchBarDelegate {

		[Static]
		[Export ("documentsFromDirectory:includeSubdirectories:")]
		PSPDFDocument [] GetDocuments ([NullAllowed] string directoryName, bool includeSubdirectories);

		[Export ("initWithDirectory:includeSubdirectories:library:")]
		IntPtr Constructor ([NullAllowed] string directory, bool includeSubdirectories, [NullAllowed] PSPDFLibrary library);

		[Export ("initWithDocuments:library:")]
		[DesignatedInitializer]
		IntPtr Constructor (PSPDFDocument [] documents, [NullAllowed] PSPDFLibrary library);

		[Export ("enqueueDocumentsIfRequired")]
		void EnqueueDocumentsIfRequired ();

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFDocumentPickerControllerDelegate Delegate { get; set; }

		[Export ("documents", ArgumentSemantic.Copy)]
		PSPDFDocument [] Documents { get; }

		[NullAllowed, Export ("directory")]
		string Directory { get; }

		[Export ("useDocumentTitles")]
		bool UseDocumentTitles { get; set; }

		[Export ("showSectionIndexes")]
		bool ShowSectionIndexes { get; set; }

		[Export ("alwaysShowDocuments")]
		bool AlwaysShowDocuments { get; set; }

		[Export ("fullTextSearchEnabled")]
		bool FullTextSearchEnabled { get; set; }

		[Export ("fullTextSearchExactWordMatch")]
		bool FullTextSearchExactWordMatch { get; set; }

		[Export ("isSearchingIndex")]
		bool IsSearchingIndex { get; }

		[Export ("showSearchPageResults")]
		bool ShowSearchPageResults { get; set; }

		[Export ("showSearchPreviewText")]
		bool ShowSearchPreviewText { get; set; }

		[Export ("maximumNumberOfSearchResultsDisplayed")]
		nuint MaximumNumberOfSearchResultsDisplayed { get; set; }

		[Export ("maximumNumberOfSearchResultsPerDocument")]
		nuint MaximumNumberOfSearchResultsPerDocument { get; set; }

		[Export ("maximumNumberOfSearchPreviewLines")]
		nuint MaximumNumberOfSearchPreviewLines { get; set; }

		[NullAllowed, Export ("library")]
		PSPDFLibrary Library { get; }

		// PSPDFDocumentPickerController (SubclassingHooks) Category

		[Export ("updateStatusCell:")]
		void UpdateStatusCell (PSPDFDocumentPickerIndexStatusCell cell);
	}

	[BaseType (typeof (PSPDFSpinnerCell))]
	interface PSPDFDocumentPickerIndexStatusCell {

	}

	interface IPSPDFDocumentSharingCoordinatorDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFDocumentSharingCoordinatorDelegate : IPSPDFOverridable {

		[Abstract]
		[Export ("documentSharingCoordinator:didFinishWithError:")]
		void DidFinish (PSPDFDocumentSharingCoordinator coordinator, [NullAllowed] NSError error);
	}

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface PSPDFDocumentSharingCoordinator : PSPDFDocumentSharingViewControllerDelegate {

		[Export ("initWithDocuments:")]
		[DesignatedInitializer]
		IntPtr Constructor (PSPDFDocument [] documents);

		[Export ("documents", ArgumentSemantic.Copy)]
		PSPDFDocument [] Documents { get; }

		[NullAllowed, Export ("visiblePageIndexes", ArgumentSemantic.Copy)]
		NSIndexSet VisiblePageIndexes { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFDocumentSharingCoordinatorDelegate Delegate { get; set; }

		[Export ("sharingOptions", ArgumentSemantic.Assign)]
		PSPDFDocumentSharingOptions SharingOptions { get; set; }

		[Export ("available")]
		bool Available { [Bind ("isAvailable")] get; }

		[Export ("executing")]
		bool Executing { [Bind ("isExecuting")] get; }

		[Async]
		[Export ("presentToViewController:options:sender:animated:completion:")]
		void PresentToViewController ([NullAllowed] IPSPDFPresentationActions targetController, [NullAllowed] NSDictionary options, [NullAllowed] NSObject sender, bool animated, [NullAllowed] Action completion);

		// PSPDFDocumentSharingCoordinator (SubclassingHooks)

		[Export ("title")]
		string Title { get; }

		[Export ("commitButtonTitle")]
		string CommitButtonTitle { get; }

		[Advice ("Use 'PSPDFPolicyEvents' strings to compare.")]
		[Export ("policyEvent")]
		NSString PolicyEvent { get; }

		[Export ("isAvailableUserInvoked:error:")]
		bool IsAvailableUserInvoked (bool userInvoked, [NullAllowed] out NSError error);

		[Export ("configureSharingController:")]
		[Advice ("Requires base call if override.")]
		bool ConfigureSharingController (PSPDFDocumentSharingViewController sharingController);

		[NullAllowed, Export ("sharingController", ArgumentSemantic.Weak)]
		PSPDFDocumentSharingViewController SharingController { get; }

		[Export ("showActionControllerToViewController:sender:sendOptions:files:annotationSummary:animated:")]
		void ShowActionController (IPSPDFPresentationActions targetController, NSObject sender, PSPDFDocumentSharingOptions sendOptions, PSPDFFile [] files, [NullAllowed] NSAttributedString annotationSummary, bool animated);

		// PSPDFDocumentSharingCoordinator (Dependencies) Category

		[NullAllowed, Export ("policy", ArgumentSemantic.Strong)]
		IPSPDFApplicationPolicy Policy { get; set; }

		[NullAllowed, Export ("fileManager", ArgumentSemantic.Strong)]
		IPSPDFFileManager FileManager { get; set; }
	}

	interface IPSPDFDocumentSharingViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFDocumentSharingViewControllerDelegate : IPSPDFOverridable {

		[Abstract]
		[Export ("documentSharingViewController:didFinishWithSelectedOptions:files:annotationSummary:error:")]
		void DidFinish (PSPDFDocumentSharingViewController shareController, PSPDFDocumentSharingOptions selectedSharingOption, PSPDFFile [] files, [NullAllowed] NSAttributedString annotationSummary, [NullAllowed] NSError error);

		[Export ("documentSharingViewControllerDidCancel:")]
		void DidCancel (PSPDFDocumentSharingViewController shareController);

		[Export ("documentSharingViewController:shouldPrepareWithSelectedOptions:selectedPageRange:")]
		bool ShouldPrepare (PSPDFDocumentSharingViewController shareController, PSPDFDocumentSharingOptions selectedSharingOption, NSRange selectedPageRange);

		[Export ("documentSharingViewController:preparationProgress:")]
		void PreparationProgress (PSPDFDocumentSharingViewController shareController, nfloat progress);

		[Export ("documentSharingViewController:titleForOption:")]
		[return: NullAllowed]
		string GetTitle (PSPDFDocumentSharingViewController shareController, PSPDFDocumentSharingOptions option);

		[Export ("documentSharingViewController:subtitleForOption:")]
		[return: NullAllowed]
		string GetSubtitle (PSPDFDocumentSharingViewController shareController, PSPDFDocumentSharingOptions option);

		[Export ("documentSharingViewController:configureCustomProcessorConfigurationOptions:")]
		void ConfigureCustomProcessorConfigurationOptions (PSPDFDocumentSharingViewController shareController, PSPDFProcessorConfiguration processorConfiguration);

		[Export ("documentSecurityOptionsForDocumentSharingViewController:")]
		PSPDFDocumentSecurityOptions GetDocumentSecurityOptions (PSPDFDocumentSharingViewController shareController);

		[Export ("temporaryDirectoryForDocumentSharingViewController:")]
		[return: NullAllowed]
		string GetTemporaryDirectory (PSPDFDocumentSharingViewController shareController);

		[Export ("documentSharingViewController:willShareFiles:")]
		PSPDFFile [] GetDocumentSharingViewController (PSPDFDocumentSharingViewController shareController, PSPDFFile [] files);
	}

	[BaseType (typeof (PSPDFStaticTableViewController))]
	interface PSPDFDocumentSharingViewController : PSPDFStyleable {

		[Export ("initWithDocuments:visiblePageRange:allowedSharingOptions:")]
		[DesignatedInitializer]
		IntPtr Constructor (PSPDFDocument [] documents, NSRange visiblePageRange, PSPDFDocumentSharingOptions sharingOptions);

		[Export ("checkIfControllerHasOptionsAvailableAndCallDelegateIfNot")]
		bool CheckIfControllerHasOptionsAvailableAndCallDelegateIfNot { get; }

		[Export ("commitWithCurrentSettings")]
		bool CommitWithCurrentSettings ();

		[Export ("documents")]
		PSPDFDocument [] Documents { get; }

		[Export ("sharingOptions", ArgumentSemantic.Assign)]
		PSPDFDocumentSharingOptions SharingOptions { get; set; }

		[Export ("selectedOptions", ArgumentSemantic.Assign)]
		PSPDFDocumentSharingOptions SelectedOptions { get; set; }

		[Export ("commitButtonTitle")]
		string CommitButtonTitle { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFDocumentSharingViewControllerDelegate Delegate { get; set; }

		// PSPDFDocumentSharingViewController (SubclassingHooks)

		[Export ("delegateConfigureCustomProcessorConfigurationOptions:")]
		void DelegateConfigureCustomProcessor (PSPDFProcessorConfiguration processorConfiguration);

		[NullAllowed, Export ("delegateDocumentSecurityOptions")]
		PSPDFDocumentSecurityOptions DelegateDocumentSecurityOptions { get; }
	}

	interface IPSPDFDocumentViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFDocumentViewControllerDelegate {

		[Export ("documentViewController:didChangeSpreadIndex:")]
		void DidChangeSpreadIndex (PSPDFDocumentViewController documentViewController, nint oldSpreadIndex);

		[Export ("documentViewController:didChangeContinuousSpreadIndex:")]
		void DidChangeContinuousSpreadIndex (PSPDFDocumentViewController documentViewController, nfloat oldContinuousSpreadIndex);

		[Export ("documentViewController:didUpdateZoomScale:forSpreadAtIndex:")]
		void DidUpdateZoomScale (PSPDFDocumentViewController documentViewController, nfloat zoomScale, nint spreadIndex);

		[Export ("documentViewController:willBeginDisplayingSpreadView:forSpreadAtIndex:")]
		void WillBeginDisplayingSpreadView (PSPDFDocumentViewController documentViewController, PSPDFSpreadView spreadView, nint spreadIndex);

		[Export ("documentViewController:didEndDisplayingSpreadView:forSpreadAtIndex:")]
		void DidEndDisplayingSpreadView (PSPDFDocumentViewController documentViewController, PSPDFSpreadView spreadView, nint spreadIndex);

		[Export ("documentViewController:didConfigureSpreadView:forSpreadAtIndex:")]
		void DidConfigureSpreadView (PSPDFDocumentViewController documentViewController, PSPDFSpreadView spreadView, nint spreadIndex);

		[Export ("documentViewController:didCleanupSpreadView:forSpreadAtIndex:")]
		void DidCleanupSpreadView (PSPDFDocumentViewController documentViewController, PSPDFSpreadView spreadView, nint spreadIndex);

		[Export ("documentViewController:configureScrollView:")]
		void ConfigureScrollView (PSPDFDocumentViewController documentViewController, UIScrollView scrollView);

		[Export ("documentViewController:configureZoomView:forSpreadAtIndex:")]
		void ConfigureZoomView (PSPDFDocumentViewController documentViewController, UIScrollView zoomView, nint spreadIndex);
	}

	interface PSPDFDocumentViewControllerSpreadViewEventArgs {

		[Export ("PSPDFDocumentViewControllerSpreadViewKey")]
		PSPDFSpreadView SpreadView { get; set; }
	}

	[BaseType (typeof (UIViewController))]
	[DisableDefaultCtor]
	interface PSPDFDocumentViewController {

		[Field ("PSPDFDocumentViewControllerWillBeginDisplayingSpreadViewNotification", PSPDFKitGlobal.LibraryPath)]
		[Notification (typeof (PSPDFAnnotationToolbarControllerVisibilityDidChangeNotificationEventArgs))]
		NSString WillBeginDisplayingSpreadViewNotification { get; }

		[Field ("PSPDFDocumentViewControllerDidEndDisplayingSpreadViewNotification", PSPDFKitGlobal.LibraryPath)]
		[Notification (typeof (PSPDFAnnotationToolbarControllerVisibilityDidChangeNotificationEventArgs))]
		NSString DidEndDisplayingSpreadViewNotification { get; }

		[Field ("PSPDFDocumentViewControllerDidConfigureSpreadViewNotification", PSPDFKitGlobal.LibraryPath)]
		[Notification (typeof (PSPDFAnnotationToolbarControllerVisibilityDidChangeNotificationEventArgs))]
		NSString DidConfigureSpreadViewNotification { get; }

		[Field ("PSPDFDocumentViewControllerDidCleanupSpreadViewNotification", PSPDFKitGlobal.LibraryPath)]
		[Notification (typeof (PSPDFAnnotationToolbarControllerVisibilityDidChangeNotificationEventArgs))]
		NSString DidCleanupSpreadViewNotification { get; }

		[Field ("PSPDFDocumentViewControllerSpreadIndexDidChangeNotification", PSPDFKitGlobal.LibraryPath)]
		[Notification]
		NSString SpreadIndexDidChangeNotification { get; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFDocumentViewControllerDelegate Delegate { get; set; }

		[Export ("layout", ArgumentSemantic.Strong)]
		PSPDFDocumentViewLayout Layout { get; set; }

		[Export ("spreadIndex")]
		nint SpreadIndex { get; set; }

		[Export ("setSpreadIndex:animated:")]
		void SetSpreadIndex (nint spreadIndex, bool animated);

		[Export ("scrollToSpreadAtIndex:scrollPosition:animated:")]
		void ScrollToSpread (nint spreadIndex, PSPDFSpreadScrollPosition scrollPosition, bool animated);

		[Export ("continuousSpreadIndex")]
		nfloat ContinuousSpreadIndex { get; set; }

		[Export ("setContinuousSpreadIndex:animated:")]
		void SetContinuousSpreadIndex (nfloat continuousSpreadIndex, bool animated);

		[Export ("scrollToNextSpreadAnimated:")]
		bool ScrollToNextSpread (bool animated);

		[Export ("scrollToPreviousSpreadAnimated:")]
		bool ScrollToPreviousSpread (bool animated);

		[Export ("zoomToPDFRect:forPageAtIndex:animated:")]
		void ZoomTo (CGRect pdfRect, nint pageIndex, bool animated);

		[Export ("scrollEnabled")]
		bool ScrollEnabled { [Bind ("isScrollEnabled")] get; set; }

		[Export ("zoomEnabled")]
		bool ZoomEnabled { [Bind ("isZoomEnabled")] get; set; }

		[Export ("alwaysBounce")]
		bool AlwaysBounce { get; set; }

		[Export ("showsScrollIndicator")]
		bool ShowsScrollIndicator { get; set; }

		[Export ("visibleSpreadViews", ArgumentSemantic.Copy)]
		PSPDFSpreadView [] VisibleSpreadViews { get; }
	}

	[BaseType (typeof (UICollectionViewLayoutInvalidationContext))]
	interface PSPDFDocumentViewLayoutInvalidationContext {

	}

	[BaseType (typeof (UICollectionViewLayout))]
	interface PSPDFDocumentViewLayout {

		[Export ("document")]
		PSPDFDocument Document { get; }

		[Export ("spreadBasedZooming")]
		bool SpreadBasedZooming { get; set; }

		[Export ("scrollViewFrameInsets")]
		UIEdgeInsets ScrollViewFrameInsets { get; }

		[Export ("additionalScrollViewFrameInsets", ArgumentSemantic.Assign)]
		UIEdgeInsets AdditionalScrollViewFrameInsets { get; set; }

		[Export ("continuousSpreadIndexForContentOffset:")]
		nfloat GetContinuousSpreadIndex (CGPoint contentOffset);

		[Export ("contentOffsetForContinuousSpreadIndex:")]
		CGPoint GetContentOffset (nfloat continuousSpreadIndex);

		[Export ("numberOfSpreads")]
		nint NumberOfSpreads { get; }

		[Export ("spreadIndexForPageAtIndex:")]
		nint GetSpreadIndex (nint pageIndex);

		[Export ("pageRangeForSpreadAtIndex:")]
		NSRange GetPageRange (nint spreadIndex);

		[Export ("spreadMode")]
		PSPDFDocumentViewLayoutSpreadMode SpreadMode { get; }

		[Export ("invalidateConfiguration")]
		void InvalidateConfiguration ();

		// PSPDFDocumentViewLayout (Subclassing)

		[Export ("configureScrollView:")]
		void ConfigureScrollView (UIScrollView scrollView);

		[Export ("configureZoomView:forSpreadIndex:")]
		void ConfigureZoomView (UIScrollView zoomView, nint spreadIndex);

		[Export ("viewport")]
		CGRect Viewport { get; }

		[Export ("shouldInvalidateLayoutForViewportChange:")]
		bool ShouldInvalidateLayout (CGRect newViewport);

		[Export ("invalidationContextForViewportChange:")]
		UICollectionViewLayoutInvalidationContext GetInvalidationContext (CGRect newViewport);

		[Export ("invalidateLayoutWithContext:"), New]
		[Advice ("Requires base call if override.")]
		void InvalidateLayout (UICollectionViewLayoutInvalidationContext context);

		// PSPDFDocumentViewLayout (Convenience)

		[Static]
		[Export ("scrollPerSpreadLayout")]
		PSPDFScrollPerSpreadLayout ScrollPerSpreadLayout { get; }

		[Static]
		[Export ("continuousScrollingLayout")]
		PSPDFContinuousScrollingLayout ContinuousScrollingLayout { get; }

		[Static]
		[Export ("pageCurlLayout")]
		PSPDFDocumentViewLayout PageCurlLayout { get; }
	}

	[Category (true)]
	[BaseType (typeof (NSIndexPath))]
	interface NSIndexPath_PSPDFDocumentViewLayout {

		[Static]
		[Export ("pspdf_indexPathForSpreadAtIndex:")]
		NSIndexPath GetPsPdfIndexPathForSpread (nint spreadIndex);

		[Export ("pspdf_spreadIndex")]
		nint GetPsPdfSpreadIndex ();
	}

	[BaseType (typeof (PSPDFBaseConfigurationBuilder))]
	interface PSPDFDragAndDropConfigurationBuilder {

		[Export ("allowedDragTypes")]
		PSPDFDragType AllowedDragTypes { get; set; }

		[Export ("acceptedDropTypes")]
		PSPDFDropType AcceptedDropTypes { get; set; }

		[Export ("allowedDropTargets")]
		PSPDFDropTarget AllowedDropTargets { get; set; }

		[Export ("allowDraggingToExternalApps")]
		bool AllowDraggingToExternalApps { get; set; }
	}

	[BaseType (typeof (PSPDFBaseConfiguration))]
	interface PSPDFDragAndDropConfiguration {

		[Static, New]
		[Export ("defaultConfiguration")]
		PSPDFDragAndDropConfiguration DefaultConfiguration { get; }

		[Export ("initWithBuilder:")]
		IntPtr Constructor (PSPDFDragAndDropConfigurationBuilder builder);

		[Static]
		[Export ("configurationWithBuilder:")]
		PSPDFDragAndDropConfiguration FromConfigurationBuilder ([NullAllowed] Action<PSPDFDragAndDropConfigurationBuilder> builderHandler);

		[Static]
		[Export ("configurationUpdatedWithBuilder:")]
		PSPDFDragAndDropConfiguration ConfigurationUpdated ([NullAllowed] Action<PSPDFDragAndDropConfigurationBuilder> builderHandler);

		[Export ("allowedDragTypes")]
		PSPDFDragType AllowedDragTypes { get; }

		[Export ("acceptedDropTypes")]
		PSPDFDropType AcceptedDropTypes { get; }

		[Export ("allowedDropTargets")]
		PSPDFDropTarget AllowedDropTargets { get; }

		[Export ("allowDraggingToExternalApps")]
		bool AllowDraggingToExternalApps { get; }
	}

	[BaseType (typeof (UIView))]
	interface PSPDFDrawView : IPSPDFAnnotationPresenting, IPSPDFOverridable {

		[Export ("annotationType", ArgumentSemantic.Assign)]
		PSPDFAnnotationType AnnotationType { get; set; }

		[NullAllowed, Export ("annotationVariant", ArgumentSemantic.Strong)]
		string AnnotationVariant { get; set; }

		[Export ("inputMode", ArgumentSemantic.Assign)]
		PSPDFDrawViewInputMode InputMode { get; set; }

		[NullAllowed, Export ("currentDrawLayer")]
		NSObject /* PSPDFDrawLayer */ CurrentDrawLayer { get; }

		[Export ("drawLayers")]
		NSObject /* PSPDFDrawLayer */ [] DrawLayers { get; }

		[Export ("clearAllLayers")]
		void ClearAllLayers ();

		[Export ("drawGestureRecognizer")]
		UIGestureRecognizer DrawGestureRecognizer { get; }

		[Export ("annotations")]
		PSPDFAnnotation [] Annotations { get; }

		[Export ("drawCreateMode", ArgumentSemantic.Assign)]
		PSPDFDrawCreateMode DrawCreateMode { get; set; }

		[Export ("naturalDrawingEnabled")]
		bool NaturalDrawingEnabled { get; set; }

		[Export ("predictiveTouchesEnabled")]
		bool PredictiveTouchesEnabled { get; set; }

		[NullAllowed, Export ("strokeColor", ArgumentSemantic.Strong)]
		UIColor StrokeColor { get; set; }

		[NullAllowed, Export ("fillColor", ArgumentSemantic.Strong)]
		UIColor FillColor { get; set; }

		[Export ("lineWidth")]
		nfloat LineWidth { get; set; }

		[Export ("lineEnd1", ArgumentSemantic.Assign)]
		PSPDFLineEndType LineEnd1 { get; set; }

		[Export ("lineEnd2", ArgumentSemantic.Assign)]
		PSPDFLineEndType LineEnd2 { get; set; }

		[NullAllowed, Export ("dashArray", ArgumentSemantic.Copy)]
		NSNumber [] DashArray { get; set; }

		[Export ("borderEffect", ArgumentSemantic.Assign)]
		PSPDFAnnotationBorderEffect BorderEffect { get; set; }

		[Export ("borderEffectIntensity")]
		nfloat BorderEffectIntensity { get; set; }

		[NullAllowed, Export ("guideBorderColor", ArgumentSemantic.Strong)]
		UIColor GuideBorderColor { get; set; }

		[Export ("updateActionsForAnnotations:")]
		NSObject /* PSPDFDrawLayer */ [] UpdateActions (PSPDFInkAnnotation [] annotations);

		[Export ("scale")]
		nfloat Scale { get; set; }

		[Export ("zoomScale")]
		nfloat ZoomScale { get; set; }

		[Export ("startDrawingAtPoint:")]
		void StartDrawing (PSPDFDrawingPoint location);

		[Export ("continueDrawingAtPoints:predictedPoints:")]
		void ContinueDrawing (NSValue [] locationsPoints, NSValue [] predictedLocationsPoints);

		[Export ("endDrawing")]
		void EndDrawing ();

		[Export ("cancelDrawing")]
		void CancelDrawing ();

		[Export ("guideSnapAllowance")]
		nfloat GuideSnapAllowance { get; set; }

		[Export ("eraseAt:")]
		void EraseAt (NSValue [] locationPoints);

		[Export ("endErase")]
		void EndErase ();
	}

	[BaseType (typeof (PSPDFNonAnimatingTableViewCell))]
	interface PSPDFEmbeddedFileCell {

	}

	interface IPSPDFEmbeddedFilesViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFEmbeddedFilesViewControllerDelegate {

		[Abstract]
		[Export ("embeddedFilesController:didSelectFile:sender:")]
		void DidSelectFile (PSPDFEmbeddedFilesViewController embeddedFilesController, PSPDFEmbeddedFile embeddedFile, [NullAllowed] NSObject sender);
	}

	[BaseType (typeof (PSPDFStatefulTableViewController))]
	interface PSPDFEmbeddedFilesViewController : PSPDFDocumentInfoController {

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFEmbeddedFilesViewControllerDelegate Delegate { get; set; }
	}

	interface IPSPDFEraseOverlayDataSource { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFEraseOverlayDataSource {

		[Abstract]
		[Export ("zoomScaleForEraseOverlay:")]
		nfloat GetZoomScale (PSPDFEraseOverlay overlay);
	}

	[BaseType (typeof (UIView))]
	interface PSPDFEraseOverlay {

		[Export ("circleVisible")]
		bool CircleVisible { get; set; }

		[Export ("circleLineWidth")]
		nfloat CircleLineWidth { get; set; }

		[Export ("circleRadius")]
		nfloat CircleRadius { get; set; }

		[Export ("circleColor", ArgumentSemantic.Strong)]
		UIColor CircleColor { get; set; }

		[Export ("shapeLayer")]
		CAShapeLayer ShapeLayer { get; }

		[Export ("touchPosition", ArgumentSemantic.Assign)]
		CGPoint TouchPosition { get; set; }

		[Export ("tracking")]
		bool Tracking { get; set; }

		[Export ("setTracking:animated:")]
		void SetTracking (bool tracking, bool animated);

		[NullAllowed, Export ("dataSource", ArgumentSemantic.Weak)]
		IPSPDFEraseOverlayDataSource DataSource { get; set; }
	}

	interface IPSPDFErrorHandler { }

	[Protocol]
	interface PSPDFErrorHandler {

		[Abstract]
		[Export ("handleError:title:message:")]
		void HandleError ([NullAllowed] NSError error, [NullAllowed] string title, [NullAllowed] string message);
	}

	interface IPSPDFExternalURLHandler { }

	[Protocol]
	interface PSPDFExternalURLHandler {

		[Abstract]
		[Export ("handleExternalURL:completionBlock:")]
		bool handleExternalUrl (NSUrl url, [NullAllowed] Action<bool> completionHandler);
	}

	interface IPSPDFFlexibleToolbarDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFFlexibleToolbarDelegate {

		[Export ("flexibleToolbarWillShow:")]
		void WillShow (PSPDFFlexibleToolbar toolbar);

		[Export ("flexibleToolbarDidShow:")]
		void DidShow (PSPDFFlexibleToolbar toolbar);

		[Export ("flexibleToolbarWillHide:")]
		void WillHide (PSPDFFlexibleToolbar toolbar);

		[Export ("flexibleToolbarDidHide:")]
		void DidHide (PSPDFFlexibleToolbar toolbar);

		[Export ("flexibleToolbar:didChangePosition:")]
		void DidChangePosition (PSPDFFlexibleToolbar toolbar, PSPDFFlexibleToolbarPosition position);
	}

	delegate void PSPDFToolbarCompletionHandler (bool finished);

	[BaseType (typeof (PSPDFToolbar))]
	interface PSPDFFlexibleToolbar {

		[Field ("PSPDFFlexibleToolbarHeight", PSPDFKitGlobal.LibraryPath)]
		nfloat Height { get; }

		[Field ("PSPDFFlexibleToolbarHeightCompact", PSPDFKitGlobal.LibraryPath)]
		nfloat HeightCompact { get; }

		[Field ("PSPDFFlexibleToolbarTopAttachedExtensionHeight", PSPDFKitGlobal.LibraryPath)]
		nfloat TopAttachedExtensionHeight { get; }

		[Wrap ("position == PSPDFFlexibleToolbarPosition.Right ? PSPDFToolbarGroupButtonIndicatorPosition.BottomLeft : PSPDFToolbarGroupButtonIndicatorPosition.BottomRight")]
		PSPDFToolbarGroupButtonIndicatorPosition GetGroupIndicatorPositionForToolbarPosition (PSPDFFlexibleToolbarPosition position);

		[Wrap ("position == PSPDFFlexibleToolbarPosition.InTopBar")]
		bool IsHorizontalPosition (PSPDFFlexibleToolbarPosition position);

		[Wrap ("position == PSPDFFlexibleToolbarPosition.Left || position == PSPDFFlexibleToolbarPosition.Right")]
		bool IsVerticalPosition (PSPDFFlexibleToolbarPosition position);

		[Export ("supportedToolbarPositions", ArgumentSemantic.Assign)]
		PSPDFFlexibleToolbarPosition SupportedToolbarPositions { get; set; }

		[Export ("toolbarPosition", ArgumentSemantic.Assign)]
		PSPDFFlexibleToolbarPosition ToolbarPosition { get; set; }

		[Export ("setToolbarPosition:animated:")]
		void SetToolbarPosition (PSPDFFlexibleToolbarPosition toolbarPosition, bool animated);

		[NullAllowed, Export ("toolbarDelegate", ArgumentSemantic.Weak)]
		IPSPDFFlexibleToolbarDelegate ToolbarDelegate { get; set; }

		[Export ("dragEnabled")]
		bool DragEnabled { [Bind ("isDragEnabled")] get; set; }

		[NullAllowed, Export ("selectedButton", ArgumentSemantic.Strong)]
		UIButton SelectedButton { get; set; }

		[Export ("setSelectedButton:animated:")]
		void SetSelectedButton ([NullAllowed] UIButton button, bool animated);

		[Async]
		[Export ("showToolbarAnimated:completion:")]
		void ShowToolbarAnimated (bool animated, [NullAllowed] PSPDFToolbarCompletionHandler completion);

		[Async]
		[Export ("hideToolbarAnimated:completion:")]
		void HideToolbarAnimated (bool animated, [NullAllowed] PSPDFToolbarCompletionHandler completionBlock);

		[Export ("dragView")]
		PSPDFFlexibleToolbarDragView DragView { get; }

		[Export ("selectedTintColor", ArgumentSemantic.Strong)]
		UIColor SelectedTintColor { get; set; }

		[Export ("selectedBackgroundColor", ArgumentSemantic.Strong)]
		UIColor SelectedBackgroundColor { get; set; }

		[Export ("borderedToolbarPositions", ArgumentSemantic.Assign)]
		PSPDFFlexibleToolbarPosition BorderedToolbarPositions { get; set; }

		[Export ("shadowedToolbarPositions", ArgumentSemantic.Assign)]
		PSPDFFlexibleToolbarPosition ShadowedToolbarPositions { get; set; }

		[Export ("matchUIBarAppearance:")]
		void MatchUIBarAppearance (IPSPDFSystemBar navigationBarOrToolbar);

		[Export ("preferredSizeFitting:forToolbarPosition:")]
		CGSize GetPreferredSizeFitting (CGSize availableSize, PSPDFFlexibleToolbarPosition position);

		[Export ("showMenuWithItems:target:animated:")]
		void ShowMenu (PSPDFMenuItem [] menuItems, UIView target, bool animated);

		[Export ("showMenuForCollapsedButtons:fromButton:animated:")]
		void ShowMenuForCollapsedButtons (UIButton [] buttons, UIButton sourceButton, bool animated);

		[Export ("menuItemForButton:")]
		PSPDFMenuItem GetMenuItem (UIButton button);
	}

	interface IPSPDFFlexibleToolbarContainerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFFlexibleToolbarContainerDelegate {

		[Export ("flexibleToolbarContainerWillShow:")]
		void WillShow (PSPDFFlexibleToolbarContainer container);

		[Export ("flexibleToolbarContainerDidShow:")]
		void DidShow (PSPDFFlexibleToolbarContainer container);

		[Export ("flexibleToolbarContainerWillHide:")]
		void WillHide (PSPDFFlexibleToolbarContainer container);

		[Export ("flexibleToolbarContainerDidHide:")]
		void DidHide (PSPDFFlexibleToolbarContainer container);

		[Export ("flexibleToolbarContainerContentRect:forToolbarPosition:")]
		CGRect GetFlexibleToolbarContainerContentRect (PSPDFFlexibleToolbarContainer container, PSPDFFlexibleToolbarPosition position);

		[Export ("flexibleToolbarContainerWillStartDragging:")]
		void WillStartDragging (PSPDFFlexibleToolbarContainer container);

		[Export ("flexibleToolbarContainerDidEndDragging:withPosition:")]
		void DidEndDragging (PSPDFFlexibleToolbarContainer container, PSPDFFlexibleToolbarPosition position);
	}

	interface IPSPDFSystemBar { }

	[Protocol]
	interface PSPDFSystemBar {

	}

	[BaseType (typeof (UIView))]
	interface PSPDFFlexibleToolbarContainer {

		[NullAllowed, Export ("flexibleToolbar", ArgumentSemantic.Strong)]
		PSPDFFlexibleToolbar FlexibleToolbar { get; set; }

		[NullAllowed, Export ("overlaidBar", ArgumentSemantic.Weak)]
		IPSPDFSystemBar OverlaidBar { get; set; }

		[Export ("dragging")]
		bool Dragging { get; }

		[Export ("flickToCloseEnabled")]
		bool FlickToCloseEnabled { [Bind ("isFlickToCloseEnabled")] get; set; }

		[NullAllowed, Export ("containerDelegate", ArgumentSemantic.Weak)]
		IPSPDFFlexibleToolbarContainerDelegate ContainerDelegate { get; set; }

		[Export ("anchorViewBackgroundColor", ArgumentSemantic.Strong)]
		UIColor AnchorViewBackgroundColor { get; set; }

		[Async]
		[Export ("showAnimated:completion:")]
		void Show (bool animated, [NullAllowed] PSPDFToolbarCompletionHandler completion);

		[Async]
		[Export ("hideAnimated:completion:")]
		void Hide (bool animated, [NullAllowed] PSPDFToolbarCompletionHandler completion);

		[Async]
		[Export ("hideAndRemoveAnimated:completion:")]
		void HideAndRemove (bool animated, [NullAllowed] PSPDFToolbarCompletionHandler completion);

		// PSPDFFlexibleToolbarContainer (SubclassingHooks) Category

		[Export ("rectForToolbarPosition:")]
		CGRect GetRect (PSPDFFlexibleToolbarPosition toolbarPosition);

		[Export ("animateToolbarPositionChangeFrom:to:")]
		void AnimateToolbarPositionChange (PSPDFFlexibleToolbarPosition currentPosition, PSPDFFlexibleToolbarPosition newPosition);
	}

	[BaseType (typeof (UIView))]
	interface PSPDFFlexibleToolbarDragView {

		[Export ("barColor", ArgumentSemantic.Strong)]
		UIColor BarColor { get; set; }

		[Export ("inverted")]
		bool Inverted { get; set; }

		[Export ("setInverted:animated:")]
		void SetInverted (bool inverted, bool animated);
	}

	interface IPSPDFFontPickerViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFFontPickerViewControllerDelegate : IPSPDFOverridable {

		[Abstract]
		[Export ("fontPickerViewController:didSelectFont:")]
		void DidSelectFont (PSPDFFontPickerViewController fontPickerViewController, [NullAllowed] UIFont selectedFont);
	}

	[BaseType (typeof (PSPDFStaticTableViewController))]
	interface PSPDFFontPickerViewController {

		[Export ("initWithFontFamilyDescriptors:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] UIFontDescriptor [] fontFamilyDescriptors);

		[Export ("fontFamilyDescriptors", ArgumentSemantic.Copy)]
		UIFontDescriptor [] FontFamilyDescriptors { get; }

		[NullAllowed, Export ("selectedFont", ArgumentSemantic.Strong)]
		UIFont SelectedFont { get; set; }

		[NullAllowed, Export ("highlightedFontFamilyDescriptors", ArgumentSemantic.Strong)]
		UIFontDescriptor [] HighlightedFontFamilyDescriptors { get; set; }

		[Export ("searchEnabled")]
		bool SearchEnabled { get; set; }

		[Export ("showDownloadableFonts")]
		bool ShowDownloadableFonts { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFFontPickerViewControllerDelegate Delegate { get; set; }

		// UIFontDescriptor (Blacklisting) Category

		[Static]
		[Export ("pspdf_defaultBlacklist")]
		string [] DefaultFontBlacklist { get; [Bind ("setPSPDFDefaultBlacklist:")] set; }
	}

	[BaseType (typeof (PSPDFHostingAnnotationView))]
	interface PSPDFFormElementView : PSPDFFormInputAccessoryViewDelegate {

	}

	[BaseType (typeof (UIView))]
	interface PSPDFFormInputAccessoryView {

		[Export ("displayDoneButton")]
		bool DisplayDoneButton { get; set; }

		[Export ("displayClearButton")]
		bool DisplayClearButton { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFFormInputAccessoryViewDelegate Delegate { get; set; }

		[Export ("updateToolbar")]
		void UpdateToolbar ();

		// PSPDFFormInputAccessoryView (SubclassingHooks) Category

		[Export ("nextButton")]
		UIBarButtonItem NextButton { get; }

		[Export ("prevButton")]
		UIBarButtonItem PrevButton { get; }

		[Export ("doneButton")]
		UIBarButtonItem DoneButton { get; }

		[Export ("clearButton")]
		UIBarButtonItem ClearButton { get; }

		[Export ("nextButtonPressed:")]
		void NextButtonPressed ([NullAllowed] NSObject sender);

		[Export ("prevButtonPressed:")]
		void PrevButtonPressed ([NullAllowed] NSObject sender);

		[Export ("doneButtonPressed:")]
		void DoneButtonPressed ([NullAllowed] NSObject sender);

		[Export ("clearButtonPressed:")]
		void ClearButtonPressed ([NullAllowed] NSObject sender);
	}

	interface IPSPDFFormInputAccessoryViewDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFFormInputAccessoryViewDelegate {

		[Abstract]
		[Export ("doneButtonPressedOnFormInputView:")]
		void DoneButtonPressed (PSPDFFormInputAccessoryView inputView);

		[Abstract]
		[Export ("previousButtonPressedOnFormInputView:")]
		void PreviousButtonPressed (PSPDFFormInputAccessoryView inputView);

		[Abstract]
		[Export ("nextButtonPressedOnFormInputView:")]
		void NextButtonPressed (PSPDFFormInputAccessoryView inputView);

		[Abstract]
		[Export ("clearButtonPressedOnFormInputView:")]
		void ClearButtonPressed (PSPDFFormInputAccessoryView inputView);

		[Abstract]
		[Export ("formInputViewShouldEnablePreviousButton:")]
		bool ShouldEnablePreviousButton (PSPDFFormInputAccessoryView inputView);

		[Abstract]
		[Export ("formInputViewShouldEnableNextButton:")]
		bool ShouldEnableNextButton (PSPDFFormInputAccessoryView inputView);

		[Abstract]
		[Export ("formInputViewShouldEnableClearButton:")]
		bool ShouldEnableClearButton (PSPDFFormInputAccessoryView inputView);
	}

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface PSPDFFormRequest {

		[Export ("initWithFormat:values:request:")]
		[DesignatedInitializer]
		IntPtr Constructor (PSPDFSubmitFormActionFormat format, NSDictionary<NSString, NSObject> values, NSUrlRequest request);

		[Export ("submissionFormat")]
		PSPDFSubmitFormActionFormat SubmissionFormat { get; }

		[Export ("formValues")]
		NSDictionary<NSString, NSObject> FormValues { get; }

		[Export ("request")]
		NSUrlRequest Request { get; }
	}

	interface IPSPDFFormSubmissionDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFFormSubmissionDelegate {

		[Export ("formSubmissionController:shouldSubmitFormRequest:")]
		bool ShouldSubmitFormRequest (NSObject /* PSPDFFormSubmissionController */ formSubmissionController, PSPDFFormRequest formRequest);

		[Export ("formSubmissionController:willSubmitFormValues:")]
		void WillSubmitFormValues (NSObject /* PSPDFFormSubmissionController */ formSubmissionController, PSPDFFormRequest formRequest);

		[Export ("formSubmissionController:didReceiveResponseData:")]
		void DidReceiveResponseData (NSObject /* PSPDFFormSubmissionController */ formSubmissionController, NSData responseData);

		[Export ("formSubmissionController:didFailWithError:")]
		void DidFail (NSObject /* PSPDFFormSubmissionController */ formSubmissionController, NSError error);

		[Export ("formSubmissionControllerShouldPresentResponseInWebView:")]
		bool ShouldPresentResponseInWebView (NSObject /* PSPDFFormSubmissionController */ formSubmissionController);
	}

	interface IPSPDFFreeTextAccessoryViewDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFFreeTextAccessoryViewDelegate {

		[Export ("doneButtonPressedOnFreeTextAccessoryView:")]
		void DoneButtonPressed (PSPDFFreeTextAccessoryView inputView);

		[Export ("clearButtonPressedOnFreeTextAccessoryView:")]
		void ClearButtonPressed (PSPDFFreeTextAccessoryView inputView);

		[Export ("freeTextAccessoryViewDidRequestInspector:")]
		[return: NullAllowed]
		PSPDFAnnotationStyleViewController DidRequestInspector (PSPDFFreeTextAccessoryView inputView);

		[Export ("freeTextAccessoryView:shouldChangeProperty:")]
		bool ShouldChangeProperty (PSPDFFreeTextAccessoryView styleController, string propertyName);

		[Export ("freeTextAccessoryView:didChangeProperty:")]
		void DidChangeProperty (PSPDFFreeTextAccessoryView styleController, string propertyName);
	}

	[BaseType (typeof (PSPDFToolbar))]
	interface PSPDFFreeTextAccessoryView : PSPDFFontPickerViewControllerDelegate, PSPDFAnnotationStyleViewControllerDelegate {

		[Field ("PSPDFFreeTextAccessoryViewDidPressClearButtonNotification", PSPDFKitGlobal.LibraryPath)]
		[Notification]
		NSString DidPressClearButtonNotification { get; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFFreeTextAccessoryViewDelegate Delegate { get; set; }

		[NullAllowed, Export ("presentationContext", ArgumentSemantic.Weak)]
		IPSPDFPresentationContext PresentationContext { get; set; }

		[Export ("annotation", ArgumentSemantic.Strong)]
		PSPDFFreeTextAnnotation Annotation { get; set; }

		[Export ("propertiesForAnnotations", ArgumentSemantic.Copy)]
		NSDictionary PropertiesForAnnotations { get; set; }

		[Export ("borderVisible")]
		bool BorderVisible { [Bind ("isBorderVisible")] get; set; }

		[Export ("separatorColor", ArgumentSemantic.Strong)]
		UIColor SeparatorColor { get; set; }

		// PSPDFFreeTextAccessoryView (SubclassingHooks) Category

		[Export ("buttonsForWidth:")]
		PSPDFToolbarButton [] GetButtons (nfloat width);

		[Export ("dismissPresentedViewControllersAnimated:")]
		[Advice ("Requires base call if override.")]
		void DismissPresentedViewControllers (bool animated);

		[Export ("fontNameButton")]
		PSPDFToolbarButton FontNameButton { get; }

		[Export ("fontSizeButton")]
		PSPDFToolbarButton FontSizeButton { get; }

		[Export ("increaseFontSizeButton")]
		PSPDFToolbarButton IncreaseFontSizeButton { get; }

		[Export ("decreaseFontSizeButton")]
		PSPDFToolbarButton DecreaseFontSizeButton { get; }

		[Export ("leftAlignButton")]
		PSPDFToolbarSelectableButton LeftAlignButton { get; }

		[Export ("centerAlignButton")]
		PSPDFToolbarSelectableButton CenterAlignButton { get; }

		[Export ("rightAlignButton")]
		PSPDFToolbarSelectableButton RightAlignButton { get; }

		[Export ("colorButton")]
		PSPDFToolbarButton ColorButton { get; }

		[Export ("clearButton")]
		PSPDFToolbarButton ClearButton { get; }

		[Export ("doneButton")]
		PSPDFToolbarButton DoneButton { get; }
	}

	[BaseType (typeof (PSPDFHostingAnnotationView))]
	interface PSPDFFreeTextAnnotationView : IUITextViewDelegate {

		[Export ("beginEditing")]
		bool BeginEditing ();

		[Export ("endEditing")]
		void EndEditing ();

		[NullAllowed, Export ("textView")]
		UITextView TextView { get; }

		[NullAllowed, Export ("resizableView", ArgumentSemantic.Weak)]
		PSPDFResizableView ResizableView { get; set; }

		// PSPDFFreeTextAnnotationView (SubclassingHooks) Category

		[NullAllowed, Export ("textViewForEditing")]
		UITextView TextViewForEditing { get; }
	}

	[BaseType (typeof (PSPDFBaseConfigurationBuilder))]
	interface PSPDFGalleryConfigurationBuilder {

		[Export ("maximumConcurrentDownloads")]
		nuint MaximumConcurrentDownloads { get; set; }

		[Export ("maximumPrefetchDownloads")]
		nuint MaximumPrefetchDownloads { get; set; }

		[Export ("displayModeUserInteractionEnabled")]
		bool DisplayModeUserInteractionEnabled { get; set; }

		[Export ("fullscreenDismissPanThreshold")]
		nfloat FullscreenDismissPanThreshold { get; set; }

		[Export ("fullscreenZoomEnabled")]
		bool FullscreenZoomEnabled { get; set; }

		[Export ("maximumFullscreenZoomScale")]
		nfloat MaximumFullscreenZoomScale { get; set; }

		[Export ("minimumFullscreenZoomScale")]
		nfloat MinimumFullscreenZoomScale { get; set; }

		[Export ("loopEnabled")]
		bool LoopEnabled { get; set; }

		[Export ("loopHUDEnabled")]
		bool LoopHudEnabled { get; set; }

		[Export ("usesExternalPlaybackWhileExternalScreenIsActive")]
		bool UsesExternalPlaybackWhileExternalScreenIsActive { get; set; }

		[Export ("allowPlayingMultipleInstances")]
		bool AllowPlayingMultipleInstances { get; set; }
	}

	[BaseType (typeof (PSPDFBaseConfiguration))]
	interface PSPDFGalleryConfiguration {

		[Static, New]
		[Export ("defaultConfiguration")]
		PSPDFGalleryConfiguration DefaultConfiguration { get; }

		[Export ("initWithBuilder:")]
		IntPtr Constructor (PSPDFGalleryConfigurationBuilder builder);

		[Static]
		[Export ("configurationWithBuilder:")]
		PSPDFGalleryConfiguration FromConfigurationBuilder ([NullAllowed] Action<PSPDFGalleryConfigurationBuilder> builderHandler);

		[Static]
		[Export ("configurationUpdatedWithBuilder:")]
		PSPDFGalleryConfiguration ConfigurationUpdated ([NullAllowed] Action<PSPDFGalleryConfigurationBuilder> builderHandler);

		[Export ("maximumConcurrentDownloads")]
		nuint MaximumConcurrentDownloads { get; }

		[Export ("maximumPrefetchDownloads")]
		nuint MaximumPrefetchDownloads { get; }

		[Export ("displayModeUserInteractionEnabled")]
		bool DisplayModeUserInteractionEnabled { get; }

		[Export ("fullscreenDismissPanThreshold")]
		nfloat FullscreenDismissPanThreshold { get; }

		[Export ("fullscreenZoomEnabled")]
		bool FullscreenZoomEnabled { [Bind ("isFullscreenZoomEnabled")] get; }

		[Export ("maximumFullscreenZoomScale")]
		nfloat MaximumFullscreenZoomScale { get; }

		[Export ("minimumFullscreenZoomScale")]
		nfloat MinimumFullscreenZoomScale { get; }

		[Export ("loopEnabled")]
		bool LoopEnabled { [Bind ("isLoopEnabled")] get; }

		[Export ("loopHUDEnabled")]
		bool LoopHudEnabled { [Bind ("isLoopHUDEnabled")] get; }

		[Export ("usesExternalPlaybackWhileExternalScreenIsActive")]
		bool UsesExternalPlaybackWhileExternalScreenIsActive { get; }

		[Export ("allowPlayingMultipleInstances")]
		bool AllowPlayingMultipleInstances { get; }
	}

	[BaseType (typeof (PSPDFBlurView))]
	interface PSPDFGalleryEmbeddedBackgroundView {

	}

	[BaseType (typeof (PSPDFBlurView))]
	interface PSPDFGalleryFullscreenBackgroundView {

	}

	[BaseType (typeof (UIView))]
	interface PSPDFGalleryContainerView {

		[Export ("initWithFrame:overrideDelegate:")]
		IntPtr Constructor (CGRect frame, [NullAllowed] IPSPDFOverridable overrideDelegate);

		[NullAllowed, Export ("overrideDelegate", ArgumentSemantic.Weak)]
		IPSPDFOverridable OverrideDelegate { get; }

		[Export ("contentState", ArgumentSemantic.Assign)]
		PSPDFGalleryContainerViewContentState ContentState { get; set; }

		[Export ("presentationMode", ArgumentSemantic.Assign)]
		PSPDFGalleryContainerViewPresentationMode PresentationMode { get; set; }

		[Export ("galleryView", ArgumentSemantic.Strong)]
		PSPDFGalleryView GalleryView { get; set; }

		[Export ("loadingView", ArgumentSemantic.Strong)]
		IPSPDFGalleryContentViewLoading LoadingView { get; set; }

		[Export ("backgroundView", ArgumentSemantic.Strong)]
		PSPDFGalleryEmbeddedBackgroundView BackgroundView { get; set; }

		[Export ("fullscreenBackgroundView", ArgumentSemantic.Strong)]
		PSPDFGalleryFullscreenBackgroundView FullscreenBackgroundView { get; set; }

		[Export ("statusHUDView", ArgumentSemantic.Strong)]
		PSPDFStatusHUDView StatusHudView { get; set; }

		[Export ("contentContainerView")]
		UIView ContentContainerView { get; }

		[Export ("presentStatusHUDWithTimeout:animated:")]
		void PresentStatusHud (double timeout, bool animated);

		[Export ("dismissStatusHUDAnimated:")]
		void DismissStatusHud (bool animated);
	}

	[BaseType (typeof (UIView))]
	interface PSPDFGalleryContentCaptionView : PSPDFGalleryContentViewCaption {

		// Inlined from PSPDFGalleryContentViewCaption protocol
		//[NullAllowed, Export ("caption")]
		//string Caption { get; set; }

		[Export ("label")]
		UILabel Label { get; }

		[Export ("contentInset", ArgumentSemantic.Assign)]
		UIEdgeInsets ContentInset { get; set; }
	}

	[BaseType (typeof (UIView))]
	interface PSPDFGalleryContentView : INativeObject {

		[Export ("initWithReuseIdentifier:")]
		IntPtr Constructor ([NullAllowed] string reuseIdentifier);

		[Export ("contentView")]
		UIView ContentView { get; }

		[Export ("loadingView")]
		IPSPDFGalleryContentViewLoading LoadingView { get; }

		[Export ("captionView")]
		IPSPDFGalleryContentViewCaption CaptionView { get; }

		[Export ("errorView")]
		IPSPDFGalleryContentViewError ErrorView { get; }

		[NullAllowed, Export ("reuseIdentifier")]
		string ReuseIdentifier { get; set; }

		[NullAllowed, Export ("content", ArgumentSemantic.Strong)]
		PSPDFGalleryItem Content { get; set; }

		[Export ("shouldHideCaption")]
		bool ShouldHideCaption { get; set; }

		// PSPDFGalleryContentView (SubclassingHooks) Category

		[Static]
		[Export ("contentViewClass")]
		Class ContentViewClass { get; }

		[Static]
		[Export ("loadingViewClass")]
		Class LoadingViewClass { get; }

		[Static]
		[Export ("captionViewClass")]
		Class CaptionViewClass { get; }

		[Static]
		[Export ("errorViewClass")]
		Class ErrorViewClass { get; }

		[Export ("contentViewFrame")]
		CGRect ContentViewFrame { get; }

		[Export ("loadingViewFrame")]
		CGRect LoadingViewFrame { get; }

		[Export ("captionViewFrame")]
		CGRect CaptionViewFrame { get; }

		[Export ("errorViewFrame")]
		CGRect ErrorViewFrame { get; }

		[Export ("updateContentView")]
		void UpdateContentView ();

		[Export ("updateCaptionView")]
		[Advice ("Requires base call if override.")]
		void UpdateCaptionView ();

		[Export ("updateErrorView")]
		[Advice ("Requires base call if override.")]
		void UpdateErrorView ();

		[Export ("updateLoadingView")]
		[Advice ("Requires base call if override.")]
		void UpdateLoadingView ();

		[Export ("prepareForReuse")]
		[Advice ("Requires base call if override.")]
		void PrepareForReuse ();

		[Export ("contentDidChange")]
		[Advice ("Requires base call if override.")]
		void ContentDidChange ();

		[Export ("updateSubviewVisibility")]
		[Advice ("Requires base call if override.")]
		void UpdateSubviewVisibility ();
	}

	interface IPSPDFGalleryContentViewLoading { }

	[Protocol]
	interface PSPDFGalleryContentViewLoading {

		[Abstract]
		[Export ("progress")]
		nfloat Progress { get; set; }

		[Export ("hasUnspecifiedProgress")]
		bool HasUnspecifiedProgress { get; set; }
	}

	interface IPSPDFGalleryContentViewError { }

	[Protocol]
	interface PSPDFGalleryContentViewError {

		[Abstract]
		[NullAllowed, Export ("error", ArgumentSemantic.Strong)]
		NSError Error { get; set; }
	}

	interface IPSPDFGalleryContentViewCaption { }

	[Protocol]
	interface PSPDFGalleryContentViewCaption {

		[Abstract]
		[NullAllowed, Export ("caption")]
		string Caption { get; set; }
	}

	[BaseType (typeof (PSPDFGalleryContentView))]
	interface PSPDFGalleryImageContentView {

		[Export ("zoomEnabled")]
		bool ZoomEnabled { [Bind ("isZoomEnabled")] get; set; }

		[Export ("maximumZoomScale")]
		nfloat MaximumZoomScale { get; set; }

		[Export ("minimumZoomScale")]
		nfloat MinimumZoomScale { get; set; }

		[Export ("zoomScale")]
		nfloat ZoomScale { get; set; }

		[Export ("setZoomScale:animated:")]
		void SetZoomScale (nfloat zoomScale, bool animated);

		[NullAllowed, Export ("content", ArgumentSemantic.Strong), New]
		PSPDFGalleryImageItem Content { get; set; }

		[Export ("contentView"), New]
		UIImageView ContentView { get; }
	}

	[BaseType (typeof (PSPDFGalleryItem))]
	interface PSPDFGalleryImageItem {

		[NullAllowed, Export ("content"), New]
		UIImage Content { get; }
	}

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface PSPDFGalleryItem {

		[Export ("contentURL", ArgumentSemantic.Copy)]
		NSUrl ContentUrl { get; }

		[NullAllowed, Export ("caption")]
		string Caption { get; }

		[Advice ("Use 'ItemOptions' for a strongly typed access.")]
		[NullAllowed, Export ("options", ArgumentSemantic.Copy)]
		NSDictionary Options { get; }

		[Wrap ("Options")]
		PSPDFGalleryItemOptions ItemOptions { get; }

		[Export ("contentState")]
		PSPDFGalleryItemContentState ContentState { get; }

		[NullAllowed, Export ("content")]
		NSObject Content { get; }

		[Export ("validContent")]
		bool ValidContent { [Bind ("hasValidContent")] get; }

		[NullAllowed, Export ("error")]
		NSError Error { get; }

		[Export ("progress")]
		nfloat Progress { get; }

		[Static]
		[Export ("itemsFromJSONData:error:")]
		[return: NullAllowed]
		PSPDFGalleryItem [] GetItemsFromJson (NSData jsonData, [NullAllowed] out NSError error);

		[Static]
		[Export ("itemFromLinkAnnotation:error:")]
		[return: NullAllowed]
		PSPDFGalleryItem GetItemFromLinkAnnotation (PSPDFLinkAnnotation annotation, [NullAllowed] out NSError error);

		[Export ("initWithDictionary:")]
		[DesignatedInitializer]
		IntPtr Constructor (NSDictionary dictionary);

		[Wrap ("this (options?.Dictionary)")]
		IntPtr Constructor (PSPDFGalleryItemOptions options);

		[Export ("initWithContentURL:caption:options:")]
		IntPtr Constructor (NSUrl contentUrl, [NullAllowed] string caption, [NullAllowed] NSDictionary options);

		[Wrap ("this (contentUrl,caption, options?.Dictionary)")]
		IntPtr Constructor (NSUrl contentUrl, string caption, PSPDFGalleryItemOptions options);

		[Export ("controlsEnabled")]
		bool ControlsEnabled { get; set; }

		[Export ("fullscreenEnabled")]
		bool FullscreenEnabled { [Bind ("isFullscreenEnabled")] get; set; }
	}

	[Static]
	interface PSPDFGalleryItemKeys {

		[Field ("PSPDFGalleryItemTypeKey", PSPDFKitGlobal.LibraryPath)]
		NSString TypeKey { get; }

		[Field ("PSPDFGalleryItemContentURLKey", PSPDFKitGlobal.LibraryPath)]
		NSString ContentUrlKey { get; }

		[Field ("PSPDFGalleryItemCaptionKey", PSPDFKitGlobal.LibraryPath)]
		NSString CaptionKey { get; }

		[Field ("PSPDFGalleryItemOptionsKey", PSPDFKitGlobal.LibraryPath)]
		NSString OptionsKey { get; }
	}

	[StrongDictionary ("PSPDFGalleryItemKeys")]
	interface PSPDFGalleryItemOptions {
		string Type { get; set; }
		string ContentUrl { get; set; }
		string Caption { get; set; }

		[StrongDictionary]
		PSPDFGalleryOptions Options { get; set; }
	}

	[Static]
	interface PSPDFGalleryOptionKeys {

		[Field ("PSPDFGalleryOptionAutoplay", PSPDFKitGlobal.LibraryPath)]
		NSString AutoplayKey { get; }

		[Field ("PSPDFGalleryOptionControls", PSPDFKitGlobal.LibraryPath)]
		NSString ControlsKey { get; }

		[Field ("PSPDFGalleryOptionLoop", PSPDFKitGlobal.LibraryPath)]
		NSString LoopKey { get; }

		[Field ("PSPDFGalleryOptionFullscreen", PSPDFKitGlobal.LibraryPath)]
		NSString FullscreenKey { get; }
	}

	[StrongDictionary ("PSPDFGalleryOptionKeys")]
	interface PSPDFGalleryOptions {
		bool Autoplay { get; set; }
		bool Controls { get; set; }
		bool Loop { get; set; }
		bool Fullscreen { get; set; }
	}

	delegate void PSPDFGalleryManifestCompletionHandler ([NullAllowed] NSObject [] items, [NullAllowed] NSError error);

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface PSPDFGalleryManifest {

		[Export ("initWithLinkAnnotation:")]
		[DesignatedInitializer]
		IntPtr Constructor (PSPDFLinkAnnotation linkAnnotation);

		[Export ("linkAnnotation")]
		PSPDFLinkAnnotation LinkAnnotation { get; }

		[Export ("loadItemsWithCompletionBlock:")]
		void LoadItems ([NullAllowed] PSPDFGalleryManifestCompletionHandler completionHandler);

		[Export ("cancel")]
		void Cancel ();

		[Export ("loading")]
		bool Loading { [Bind ("isLoading")] get; }
	}

	[BaseType (typeof (PSPDFGalleryItem))]
	interface PSPDFGalleryUnknownItem {

	}

	[BaseType (typeof (PSPDFGalleryContentView))]
	interface PSPDFGalleryVideoContentView {

	}

	[BaseType (typeof (PSPDFGalleryItem))]
	interface PSPDFGalleryVideoItem {

		[Export ("autoplayEnabled")]
		bool AutoplayEnabled { get; set; }

		[Export ("loopEnabled")]
		bool LoopEnabled { get; set; }

		[Export ("preferredVideoQualities", ArgumentSemantic.Copy)]
		NSNumber [] PreferredVideoQualities { get; set; }

		[Export ("seekTime")]
		double SeekTime { get; set; }

		[NullAllowed, Export ("startTime", ArgumentSemantic.Strong)]
		NSNumber StartTime { get; set; }

		[NullAllowed, Export ("endTime", ArgumentSemantic.Strong)]
		NSNumber EndTime { get; set; }

		[Export ("playableRange")]
		CMTimeRange PlayableRange { get; }

		[Export ("coverMode", ArgumentSemantic.Assign)]
		PSPDFGalleryVideoItemCoverMode CoverMode { get; set; }

		[NullAllowed, Export ("coverImageURL", ArgumentSemantic.Copy)]
		NSUrl CoverImageUrl { get; set; }

		[NullAllowed, Export ("coverPreviewCaptureTime", ArgumentSemantic.Strong)]
		NSNumber CoverPreviewCaptureTime { get; set; }

		[NullAllowed, Export ("content"), New]
		NSUrl Content { get; }
	}

	[BaseType (typeof (UIScrollView))]
	interface PSPDFGalleryView {

		[NullAllowed, Export ("dataSource", ArgumentSemantic.Weak)]
		IPSPDFGalleryViewDataSource DataSource { get; set; }

		[Export ("contentPadding")]
		nfloat ContentPadding { get; set; }

		[NullAllowed, Export ("delegate"), New]
		IPSPDFGalleryViewDelegate Delegate { get; set; }

		[Export ("reload")]
		void Reload ();

		[Export ("contentViewForItemAtIndex:")]
		[return: NullAllowed]
		PSPDFGalleryContentView GetContentView (nuint itemIndex);

		[Export ("itemIndexForContentView:")]
		nuint GetItemIndex (PSPDFGalleryContentView contentView);

		[Export ("dequeueReusableContentViewWithIdentifier:")]
		[return: NullAllowed]
		PSPDFGalleryContentView DequeueReusableContentView (string identifier);

		[Export ("currentItemIndex")]
		nuint CurrentItemIndex { get; set; }

		[Export ("setCurrentItemIndex:animated:")]
		void SetCurrentItemIndex (nuint currentItemIndex, bool animated);

		[Export ("activeContentViews")]
		NSSet<PSPDFGalleryContentView> ActiveContentViews { get; }

		[Export ("loopEnabled")]
		bool LoopEnabled { [Bind ("isLoopEnabled")] get; set; }
	}

	interface IPSPDFGalleryViewDataSource { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFGalleryViewDataSource {

		[Abstract]
		[Export ("numberOfItemsInGalleryView:")]
		nuint GetNumberOfItems (PSPDFGalleryView galleryView);

		[Abstract]
		[Export ("galleryView:contentViewForItemAtIndex:")]
		PSPDFGalleryContentView GetContentView (PSPDFGalleryView galleryView, nuint index);
	}

	interface IPSPDFGalleryViewDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFGalleryViewDelegate : IUIScrollViewDelegate {

		[Export ("galleryView:willScrollToItemAtIndex:")]
		void WillScrollToItem (PSPDFGalleryView galleryView, nuint index);

		[Export ("galleryView:didScrollToItemAtIndex:")]
		void DidScrollToItem (PSPDFGalleryView galleryView, nuint index);

		[Export ("galleryView:willReuseContentView:")]
		void WillReuseContentView (PSPDFGalleryView galleryView, PSPDFGalleryContentView contentView);
	}

	[BaseType (typeof (PSPDFBaseViewController))]
	[DisableDefaultCtor]
	interface PSPDFGalleryViewController : IPSPDFOverridable, PSPDFMultimediaViewController {

		[Export ("initWithLinkAnnotation:")]
		[DesignatedInitializer]
		IntPtr Constructor (PSPDFLinkAnnotation linkAnnotation);

		[Export ("configuration", ArgumentSemantic.Strong)]
		PSPDFGalleryConfiguration Configuration { get; set; }

		[Export ("state")]
		PSPDFGalleryViewControllerState State { get; }

		[NullAllowed, Export ("items", ArgumentSemantic.Copy)]
		PSPDFGalleryItem [] Items { get; }

		[Export ("linkAnnotation")]
		PSPDFLinkAnnotation LinkAnnotation { get; }

		// Inlined from PSPDFMultimediaViewController
		//[Export ("fullscreen")]
		//bool Fullscreen { [Bind ("isFullscreen")] get; set; }

		//[Export ("setFullscreen:animated:")]
		//void SetFullscreen (bool fullscreen, bool animated);

		//[Export ("zoomScale")]
		//nfloat ZoomScale { get; set; }

		[Export ("singleTapGestureRecognizer")]
		UITapGestureRecognizer SingleTapGestureRecognizer { get; }

		[Export ("doubleTapGestureRecognizer")]
		UITapGestureRecognizer DoubleTapGestureRecognizer { get; }

		[Export ("panGestureRecognizer")]
		UIPanGestureRecognizer PanGestureRecognizer { get; }
	}

	[BaseType (typeof (PSPDFGalleryContentView))]
	interface PSPDFGalleryWebContentView {

		[NullAllowed, Export ("webView")]
		UIView WebView { get; }
	}

	[BaseType (typeof (PSPDFGalleryItem))]
	interface PSPDFGalleryWebItem {

	}

	[BaseType (typeof (PSPDFAnnotationView))]
	interface PSPDFHostingAnnotationView : IPSPDFRenderTaskDelegate {

		[NullAllowed, Export ("annotationImageView")]
		UIImageView AnnotationImageView { get; }
	}

	interface IPSPDFIdentifiable { }

	[Protocol]
	interface PSPDFIdentifiable {

		[Abstract]
		[NullAllowed, Export ("uniqueIdentifier")]
		string UniqueIdentifier { get; set; }
	}

	interface IPSPDFImagePickerControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFImagePickerControllerDelegate {

		[Export ("imagePickerController:didSelectImage:")]
		void DidSelectImage (PSPDFImagePickerController picker, UIImage image);

		[Export ("imagePickerController:didFinishWithImage:andInfo:")]
		void DidFinishWithImage (PSPDFImagePickerController picker, UIImage image, NSDictionary info);

		[Export ("imagePickerControllerCancelled:")]
		void ImagePickerControllerCancelled (PSPDFImagePickerController picker);
	}

	[BaseType (typeof (UIImagePickerController))]
	interface PSPDFImagePickerController {

		[NullAllowed, Export ("imageDelegate", ArgumentSemantic.Weak)]
		IPSPDFImagePickerControllerDelegate ImageDelegate { get; set; }

		[Export ("shouldShowImageEditor")]
		bool ShouldShowImageEditor { get; set; }

		[Export ("allowedImageQualities", ArgumentSemantic.Assign)]
		PSPDFImageQuality AllowedImageQualities { get; set; }

		// PSPDFImagePickerController (SubclassingHooks)

		[Export ("availableImagePickerSourceTypes")]
		NSNumber[] AvailableImagePickerSourceTypes { get; }
	}

	interface IPSPDFInlineSearchManagerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFInlineSearchManagerDelegate : IPSPDFTextSearchDelegate, IPSPDFOverridable {

		[Export ("inlineSearchManager:didFocusSearchResult:")]
		void DidFocusSearchResult (PSPDFInlineSearchManager manager, PSPDFSearchResult searchResult);

		[Export ("inlineSearchManagerDidClearAllSearchResults:")]
		void DidClearAllSearchResults (PSPDFInlineSearchManager manager);

		[Export ("inlineSearchManagerSearchWillAppear:")]
		void SearchWillAppear (PSPDFInlineSearchManager manager);

		[Export ("inlineSearchManagerSearchDidAppear:")]
		void SearchDidAppear (PSPDFInlineSearchManager manager);

		[Export ("inlineSearchManagerSearchWillDisappear:")]
		void SearchWillDisappear (PSPDFInlineSearchManager manager);

		[Export ("inlineSearchManagerSearchDidDisappear:")]
		void SearchDidDisappear (PSPDFInlineSearchManager manager);

		[Abstract]
		[Export ("inlineSearchManagerContainerView:")]
		UIView GetContainerView (PSPDFInlineSearchManager manager);
	}

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface PSPDFInlineSearchManager {

		[Export ("initWithPresentationContext:")]
		[DesignatedInitializer]
		IntPtr Constructor (IPSPDFPresentationContext presentationContext);

		[Export ("presentInlineSearchWithSearchText:animated:")]
		void PresentInlineSearch ([NullAllowed] string text, bool animated);

		[Export ("hideInlineSearchAnimated:")]
		bool HideInlineSearch (bool animated);

		[Export ("hideKeyboard")]
		void HideKeyboard ();

		[Export ("searchVisible")]
		bool SearchVisible { [Bind ("isSearchVisible")] get; }

		[NullAllowed, Export ("presentationContext", ArgumentSemantic.Weak)]
		IPSPDFPresentationContext PresentationContext { get; }

		[NullAllowed, Export ("textSearch")]
		PSPDFTextSearch TextSearch { get; }

		[Export ("searchText")]
		string SearchText { get; }

		[Export ("searchResults", ArgumentSemantic.Copy)]
		PSPDFSearchResult [] SearchResults { get; }

		[Export ("searchStatus")]
		PSPDFSearchStatus SearchStatus { get; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFInlineSearchManagerDelegate Delegate { get; set; }

		[NullAllowed, Export ("document", ArgumentSemantic.Strong)]
		PSPDFDocument Document { get; set; }

		[Export ("maximumNumberOfSearchResultsDisplayed")]
		nuint MaximumNumberOfSearchResultsDisplayed { get; set; }

		[Export ("searchableAnnotationTypes", ArgumentSemantic.Assign)]
		PSPDFAnnotationType SearchableAnnotationTypes { get; set; }

		[Export ("beingPresented")]
		bool BeingPresented { [Bind ("isBeingPresented")] get; }

		[Export ("beingDismissed")]
		bool BeingDismissed { [Bind ("isBeingDismissed")] get; }

		[Export ("searchResultsLabelDistance")]
		nfloat SearchResultsLabelDistance { get; set; }
	}

	[Category]
	[BaseType (typeof (PSPDFKitGlobal))]
	interface PSPDFKit_Analytics {

		[Export ("analytics")]
		PSPDFAnalytics GetAnalytics ();
	}

	[Category]
	[BaseType (typeof (PSPDFKitGlobal))]
	interface PSPDFKit_Services {

		[Export ("application")]
		IPSPDFApplication GetApplication ();

		[Export ("setApplication:")]
		void SetApplication (IPSPDFApplication application);

		[Export ("speechController")]
		PSPDFSpeechController GetSpeechController ();

		[return: NullAllowed]
		[Export ("stylusManager")]
		PSPDFStylusManager GetStylusManager ();

		[Export ("screenController")]
		PSPDFScreenController GetScreenController ();

		[Export ("brightnessManager")]
		PSPDFBrightnessManager GetBrightnessManager ();
	}

	[BaseType (typeof (UIView))]
	interface PSPDFLabelView {

		[Export ("label")]
		UILabel Label { get; }

		[Export ("labelMargin")]
		nfloat LabelMargin { get; set; }

		[Export ("labelStyle", ArgumentSemantic.Assign)]
		PSPDFLabelStyle LabelStyle { get; set; }

		[Export ("blurEffectStyle", ArgumentSemantic.Assign)]
		UIBlurEffectStyle BlurEffectStyle { get; set; }

		[Export ("textColor", ArgumentSemantic.Strong)]
		UIColor TextColor { get; set; }
	}

	[BaseType (typeof (UIView))]
	interface PSPDFLinkAnnotationBaseView : PSPDFAnnotationPresenting {

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		[Export ("linkAnnotation")]
		PSPDFLinkAnnotation LinkAnnotation { get; }

		// Inlined from PSPDFAnnotationPresenting
		//[Export ("zIndex")]
		//nuint ZIndex { get; set; }

		[Export ("contentView")]
		UIView ContentView { get; }

		// Inlined from PSPDFAnnotationPresenting
		//[NullAllowed, Export ("pageView", ArgumentSemantic.Weak)]
		//PSPDFPageView PageView { get; set; }

		// PSPDFLinkAnnotationBaseView (SubclassingHooks)

		[Export ("prepareForReuse")]
		[Advice ("Requires base call if override.")]
		void PrepareForReuse ();

		[Export ("populateContentView")]
		void PopulateContentView ();

		[Export ("setContentViewVisible:animated:")]
		void SetContentViewVisible (bool visible, bool animated);

		[Export ("contentViewVisible")]
		bool ContentViewVisible { [Bind ("isContentViewVisible")] get; }
	}

	[BaseType (typeof (PSPDFLinkAnnotationBaseView))]
	interface PSPDFLinkAnnotationView {

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		[NullAllowed, Export ("borderColor", ArgumentSemantic.Strong)]
		UIColor BorderColor { get; set; }

		[Export ("cornerRadius")]
		nfloat CornerRadius { get; set; }

		[Export ("strokeWidth")]
		nfloat StrokeWidth { get; set; }
	}

	[BaseType (typeof (PSPDFDocumentSharingCoordinator))]
	interface PSPDFMailCoordinator : IMFMailComposeViewControllerDelegate {

		[NullAllowed, Export ("mailComposeViewController", ArgumentSemantic.Weak)]
		MFMailComposeViewController MailComposeViewController { get; set; }

		[Export ("addAttachmentData:mimeType:fileName:")]
		void AddAttachmentData (NSData attachment, string mimeType, string filename);
	}

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface PSPDFMediaPlayerController {

		[Field ("PSPDFMediaPlayerControllerPlaybackDidStartNotification", PSPDFKitGlobal.LibraryPath)]
		[Notification]
		NSString PlaybackDidStartNotification { get; }

		[Field ("PSPDFMediaPlayerControllerPlaybackDidPauseNotification", PSPDFKitGlobal.LibraryPath)]
		[Notification]
		NSString PlaybackDidPauseNotification { get; }

		[Field ("PSPDFMediaPlayerControllerPlaybackDidFinishNotification", PSPDFKitGlobal.LibraryPath)]
		[Notification]
		NSString PlaybackDidFinishNotification { get; }

		[Export ("initWithContentURL:")]
		[DesignatedInitializer]
		IntPtr Constructor (NSUrl contentUrl);

		[Export ("contentURL", ArgumentSemantic.Copy)]
		NSUrl ContentUrl { get; }

		[NullAllowed, Export ("contentError")]
		NSError ContentError { get; }

		[Export ("play")]
		void Play ();

		[Export ("pause")]
		void Pause ();

		[Static]
		[Export ("pauseAllInstances")]
		void PauseAllInstances ();

		[Export ("seekToTime:")]
		void Seek (CMTime time);

		[Export ("didFinishPlaying")]
		bool DidFinishPlaying { get; }

		[Export ("playing")]
		bool Playing { [Bind ("isPlaying")] get; }

		[Export ("externalPlaybackActive")]
		bool ExternalPlaybackActive { [Bind ("isExternalPlaybackActive")] get; }

		[Export ("contentState")]
		PSPDFMediaPlayerControllerContentState ContentState { get; }

		[Export ("coverMode", ArgumentSemantic.Assign)]
		PSPDFMediaPlayerCoverMode CoverMode { get; set; }

		[NullAllowed, Export ("coverImageURL", ArgumentSemantic.Strong)]
		NSUrl CoverImageUrl { get; set; }

		[Export ("coverImagePreviewCaptureTime", ArgumentSemantic.Assign)]
		CMTime CoverImagePreviewCaptureTime { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFMediaPlayerControllerDelegate Delegate { get; set; }

		[Export ("shouldHideToolbar")]
		bool ShouldHideToolbar { get; set; }

		[Export ("setShouldHideToolbar:animated:")]
		void SetShouldHideToolbar (bool shouldHideToolbar, bool animated);

		[Export ("didStartPlaying")]
		bool DidStartPlaying { get; }

		[Export ("tapGestureRecognizer")]
		UITapGestureRecognizer TapGestureRecognizer { get; }

		[Export ("loopEnabled")]
		bool LoopEnabled { get; set; }

		[Export ("usesExternalPlaybackWhileExternalScreenIsActive")]
		bool UsesExternalPlaybackWhileExternalScreenIsActive { get; set; }

		[Export ("controlStyle", ArgumentSemantic.Assign)]
		PSPDFMediaPlayerControlStyle ControlStyle { get; set; }

		[Export ("playableRange", ArgumentSemantic.Assign)]
		CMTimeRange PlayableRange { get; set; }

		// PSPDFMediaPlayerController (Advanced) Category

		[NullAllowed, Export ("internalPlayer")]
		AVPlayer InternalPlayer { get; }
	}

	interface IPSPDFMediaPlayerControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFMediaPlayerControllerDelegate {

		[Export ("mediaPlayerControllerShouldPauseOtherInstances:")]
		bool ShouldPauseOtherInstances (PSPDFMediaPlayerController controller);

		[Export ("mediaPlayerControllerDidStartPlaying:")]
		void DidStartPlaying (PSPDFMediaPlayerController controller);

		[Export ("mediaPlayerControllerDidPause:")]
		void DidPause (PSPDFMediaPlayerController controller);

		[Export ("mediaPlayerControllerDidFinishPlaying:")]
		void DidFinishPlaying (PSPDFMediaPlayerController controller);

		[Export ("mediaPlayerController:didSeekToTime:")]
		void DidSeekToTime (PSPDFMediaPlayerController controller, CMTime seekTime);

		[Export ("mediaPlayerController:didHideToolbar:")]
		void DidHideToolbar (PSPDFMediaPlayerController controller, bool hidden);

		[Export ("mediaPlayerController:contentStateDidChange:")]
		void ContentStateDidChange (PSPDFMediaPlayerController controller, PSPDFMediaPlayerControllerContentState contentState);

		[Export ("mediaPlayerController:externalPlaybackActiveDidChange:")]
		void ExternalPlaybackActiveDidChange (PSPDFMediaPlayerController controller, bool externalPlaybackActive);
	}

	[BaseType (typeof (UIView))]
	interface PSPDFMediaPlayerCoverView {

		[NullAllowed, Export ("playButtonColor", ArgumentSemantic.Strong)]
		UIColor PlayButtonColor { get; set; }

		[NullAllowed, Export ("playButtonImage", ArgumentSemantic.Strong)]
		UIImage PlayButtonImage { get; set; }
	}

	[BaseType (typeof (UIMenuItem))]
	interface PSPDFMenuItem {

		[Export ("initWithTitle:block:")]
		IntPtr Constructor (string title, Action action);

		[Export ("initWithTitle:block:identifier:")]
		IntPtr Constructor (string title, Action action, [NullAllowed] string identifier);

		[Export ("initWithTitle:image:block:identifier:")]
		IntPtr Constructor (string title, [NullAllowed] UIImage image, Action action, [NullAllowed] string identifier);

		[Export ("initWithTitle:image:block:identifier:allowImageColors:")]
		[DesignatedInitializer]
		IntPtr Constructor (string title, [NullAllowed] UIImage image, Action action, [NullAllowed] string identifier, bool allowImageColors);

		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		[Export ("shouldInvokeAutomatically")]
		bool ShouldInvokeAutomatically { get; set; }

		[NullAllowed, Export ("identifier")]
		string Identifier { get; set; }

		[NullAllowed, Export ("ps_image", ArgumentSemantic.Strong)]
		UIImage PsImage { get; set; }

		[Export ("actionBlock", ArgumentSemantic.Copy)]
		Action ActionHandler { get; set; }

		[Static]
		[Export ("installMenuHandlerForObject:")]
		void InstallMenuHandler (NSObject @object);

		// PSPDFMenuItem (PSPDFAnalytics) Category

		[Export ("performBlock")]
		void PerformHandler ();
	}

	[BaseType (typeof (PSPDFDocumentSharingCoordinator))]
	interface PSPDFMessageCoordinator : IMFMessageComposeViewControllerDelegate {

		[Export ("sharingOptions", ArgumentSemantic.Assign), New]
		PSPDFDocumentSharingOptions SharingOptions { get; set; }

		// PSPDFMessageCoordinator (SubclassingHooks) Category

		[Export ("messageComposeViewController", ArgumentSemantic.Weak)]
		MFMessageComposeViewController MessageComposeViewController { get; }
	}

	interface IPSPDFMultiDocumentListControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFMultiDocumentListControllerDelegate {

		[Export ("multiDocumentListController:didSelectDocumentAtIndex:")]
		void DidSelectDocument (PSPDFMultiDocumentListController multiDocumentListController, nuint idx);

		[Export ("multiDocumentListControllerDidCancel:")]
		void DidCancel (PSPDFMultiDocumentListController multiDocumentListController);
	}

	[BaseType (typeof (PSPDFBaseTableViewController))]
	interface PSPDFMultiDocumentListController {

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFMultiDocumentListControllerDelegate Delegate { get; set; }

		[NullAllowed, Export ("tabbedViewController", ArgumentSemantic.Weak)]
		PSPDFTabbedViewController TabbedViewController { get; set; }
	}

	interface IPSPDFMultiDocumentViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFMultiDocumentViewControllerDelegate {

		[Export ("multiPDFController:willChangeDocuments:")]
		void WillChangeDocuments (PSPDFMultiDocumentViewController multiPdfController, PSPDFDocument [] newDocuments);

		[Export ("multiPDFController:didChangeDocuments:")]
		void DidChangeDocuments (PSPDFMultiDocumentViewController multiPdfController, PSPDFDocument [] oldDocuments);

		[Export ("multiPDFController:willChangeVisibleDocument:")]
		void WillChangeVisibleDocument (PSPDFMultiDocumentViewController multiPdfController, [NullAllowed] PSPDFDocument newDocument);

		[Export ("multiPDFController:didChangeVisibleDocument:")]
		void DidChangeVisibleDocument (PSPDFMultiDocumentViewController multiPdfController, [NullAllowed] PSPDFDocument oldDocument);
	}

	[BaseType (typeof (PSPDFBaseViewController))]
	interface PSPDFMultiDocumentViewController {

		[Export ("initWithPDFViewController:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] PSPDFViewController pdfController);

		[NullAllowed, Export ("visibleDocument", ArgumentSemantic.Strong)]
		PSPDFDocument VisibleDocument { get; set; }

		[Export ("documents", ArgumentSemantic.Copy)]
		PSPDFDocument [] Documents { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFMultiDocumentViewControllerDelegate Delegate { get; set; }

		[Export ("enableAutomaticStatePersistence")]
		bool EnableAutomaticStatePersistence { get; set; }

		[Export ("persistState")]
		void PersistState ();

		[Export ("restoreState")]
		bool RestoreState { get; }

		[Export ("restoreStateAndMergeWithDocuments:")]
		bool RestoreStateAndMerge (PSPDFDocument [] documents);

		[Export ("statePersistenceKey")]
		string StatePersistenceKey { get; set; }

		[Export ("pdfController")]
		PSPDFViewController PdfController { get; }

		[Export ("thumbnailViewIncludesAllDocuments")]
		bool ThumbnailViewIncludesAllDocuments { get; set; }

		[Export ("showTitle")]
		bool ShowTitle { get; set; }

		// PSPDFMultiDocumentViewController (SubclassingHooks) Category

		[Export ("commonInitWithPDFController:")]
		[Advice ("Requires base call if override.")]
		void CommonInit ([NullAllowed] PSPDFViewController pdfController);

		[Export ("titleForDocumentAtIndex:")]
		string GetTitleForDocument (nuint idx);

		[Export ("titleDidChangeForDocumentAtIndex:")]
		void TitleDidChangeForDocument (nuint idx);

		[Export ("persistViewStateForCurrentVisibleDocument")]
		void PersistViewStateForCurrentVisibleDocument ();

		[Export ("restoreViewStateForCurrentVisibleDocument")]
		void RestoreViewStateForCurrentVisibleDocument ();
	}

	[BaseType (typeof (PSPDFLinkAnnotationBaseView))]
	interface PSPDFMultimediaAnnotationView {

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		[Export ("multimediaViewController")]
		IPSPDFMultimediaViewController MultimediaViewController { get; }
	}

	interface IPSPDFMultimediaViewController { }

	[Protocol]
	interface PSPDFMultimediaViewController {

		[Abstract]
		[Export ("fullscreen")]
		bool Fullscreen { [Bind ("isFullscreen")] get; set; }

		[Abstract]
		[Export ("setFullscreen:animated:")]
		void SetFullscreen (bool fullscreen, bool animated);

		[Abstract]
		[Export ("zoomScale")]
		nfloat ZoomScale { get; set; }

		[Abstract]
		[NullAllowed, Export ("overrideDelegate", ArgumentSemantic.Weak)]
		IPSPDFOverridable OverrideDelegate { get; set; }

		[Abstract]
		[Export ("performAction:")]
		void PerformAction (PSPDFAction action);

		[Export ("configure:")]
		void Configure (PSPDFConfiguration configuration);
	}

	[BaseType (typeof (UINavigationController))]
	interface PSPDFNavigationController : IUINavigationControllerDelegate {

		[Export ("rotationForwardingEnabled")]
		bool RotationForwardingEnabled { [Bind ("isRotationForwardingEnabled")] get; set; }

		[Export ("persistentCloseButtonMode", ArgumentSemantic.Assign)]
		PSPDFPersistentCloseButtonMode PersistentCloseButtonMode { get; set; }

		[NullAllowed, Export ("persistentCloseButton", ArgumentSemantic.Strong)]
		UIBarButtonItem PersistentCloseButton { get; set; }
	}

	[BaseType (typeof (UINavigationItem))]
	interface PSPDFNavigationItem {

		[NullAllowed, Export ("closeBarButtonItem", ArgumentSemantic.Strong)]
		UIBarButtonItem CloseBarButtonItem { get; set; }

		[Export ("leftBarButtonItemsForViewMode:")]
		[return: NullAllowed]
		UIBarButtonItem [] LeftBarButtonItemsForViewMode (PSPDFViewMode viewMode);

		[Export ("setLeftBarButtonItems:forViewMode:animated:")]
		void SetLeftBarButtonItems (UIBarButtonItem [] barButtonItems, PSPDFViewMode viewMode, bool animated);

		[Export ("setLeftBarButtonItems:animated:"), New]
		void SetLeftBarButtonItems ([NullAllowed] UIBarButtonItem [] items, bool animated);

		[Export ("rightBarButtonItemsForViewMode:")]
		[return: NullAllowed]
		UIBarButtonItem [] GetRightBarButtonItems (PSPDFViewMode viewMode);

		[Export ("setRightBarButtonItems:forViewMode:animated:")]
		void SetRightBarButtonItems (UIBarButtonItem [] barButtonItems, PSPDFViewMode viewMode, bool animated);

		[Export ("setRightBarButtonItems:animated:"), New]
		void SetRightBarButtonItems ([NullAllowed] UIBarButtonItem [] items, bool animated);
	}

	interface IPSPDFNetworkActivityIndicatorManager { }

	[Protocol]
	interface PSPDFNetworkActivityIndicatorManager {

		[Abstract]
		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		[Abstract]
		[Export ("isNetworkActivityIndicatorVisible")]
		bool IsNetworkActivityIndicatorVisible { get; }

		[Abstract]
		[Export ("incrementActivityCount")]
		void IncrementActivityCount ();

		[Abstract]
		[Export ("decrementActivityCount")]
		void DecrementActivityCount ();
	}

	[BaseType (typeof (NSObject))]
	interface PSPDFDefaultNetworkActivityIndicatorManager : PSPDFNetworkActivityIndicatorManager {

		[Field ("PSPDFNetworkActivityDidStartNotification", PSPDFKitGlobal.LibraryPath)]
		[Notification]
		NSString ActivityDidStartNotification { get; }

		[Field ("PSPDFNetworkActivityDidFinishNotification", PSPDFKitGlobal.LibraryPath)]
		[Notification]
		NSString ActivityDidFinishNotification { get; }
	}

	interface IPSPDFNewPageViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFNewPageViewControllerDelegate : IPSPDFOverridable {

		[Abstract]
		[Export ("newPageController:didFinishSelectingConfiguration:")]
		void DidFinishSelectingConfiguration (PSPDFNewPageViewController controller, [NullAllowed] PSPDFNewPageConfiguration configuration);
	}

	[BaseType (typeof (PSPDFStaticTableViewController))]
	[DisableDefaultCtor]
	interface PSPDFNewPageViewController : IPSPDFDocumentEditorConfigurationConfigurable {

		[Export ("initWithDocumentEditorConfiguration:")]
		[DesignatedInitializer]
		IntPtr Constructor (PSPDFDocumentEditorConfiguration configuration);

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFNewPageViewControllerDelegate Delegate { get; set; }

		[Export ("documentEditorConfiguration")]
		new PSPDFDocumentEditorConfiguration DocumentEditorConfiguration { get; }
	}

	[BaseType (typeof (PSPDFAnnotationView))]
	[DisableDefaultCtor]
	interface PSPDFNoteAnnotationView {

		[Export ("initWithAnnotation:")]
		IntPtr Constructor (PSPDFAnnotation noteAnnotation);

		[NullAllowed, Export ("annotationImageView", ArgumentSemantic.Strong)]
		UIImageView AnnotationImageView { get; set; }

		// PSPDFNoteAnnotationView (SubclassingHooks)

		[NullAllowed, Export ("renderNoteImage")]
		UIImage RenderNoteImage { get; }

		[Export ("updateImageAnimated:")]
		IntPtr UpdateImage (bool animated);
	}

	interface IPSPDFNoteAnnotationViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFNoteAnnotationViewControllerDelegate : IPSPDFOverridable {

		[Export ("noteAnnotationController:didDeleteAnnotation:")]
		void DidDeleteAnnotation (PSPDFNoteAnnotationViewController noteController, PSPDFAnnotation annotation);

		[Export ("noteAnnotationController:didClearContentsForAnnotation:")]
		void DidClearContentsForAnnotation (PSPDFNoteAnnotationViewController noteController, PSPDFAnnotation annotation);

		[Export ("noteAnnotationController:didChangeAnnotation:")]
		void DidChangeAnnotation (PSPDFNoteAnnotationViewController noteController, PSPDFAnnotation annotation);

		[Export ("noteAnnotationController:willDismissWithAnnotation:")]
		void WillDismissWithAnnotation (PSPDFNoteAnnotationViewController noteController, [NullAllowed] PSPDFAnnotation annotation);
	}

	[BaseType (typeof (PSPDFBaseViewController))]
	interface PSPDFNoteAnnotationViewController : IUIGestureRecognizerDelegate, IUITextViewDelegate, PSPDFStyleable {

		[Export ("initWithAnnotation:")]
		IntPtr Constructor (PSPDFAnnotation annotation);

		[NullAllowed, Export ("annotation", ArgumentSemantic.Strong)]
		PSPDFAnnotation Annotation { get; set; }

		[Export ("allowEditing")]
		bool AllowEditing { get; set; }

		[Export ("showColorAndIconOptions")]
		bool ShowColorAndIconOptions { get; set; }

		[Export ("showCopyButton")]
		bool ShowCopyButton { get; set; }

		[Export ("shouldBeginEditModeWhenPresented")]
		bool ShouldBeginEditModeWhenPresented { get; set; }

		[Export ("textView")]
		UITextView TextView { get; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFNoteAnnotationViewControllerDelegate Delegate { get; set; }

		// PSPDFNoteAnnotationViewController (SubclassingHooks)

		[Export ("deleteAnnotation:")]
		void DeleteAnnotation (UIBarButtonItem barButtonItem);

		[Export ("deleteOrClearAnnotationWithoutConfirmation")]
		void DeleteOrClearAnnotationWithoutConfirmation ();

		[Export ("deleteAnnotationActionTitle")]
		string DeleteAnnotationActionTitle { get; }

		[Export ("beginEditing")]
		bool BeginEditing ();

		[Export ("updateTextView")]
		[Advice ("Requires base call if override.")]
		void UpdateTextView ();

		[Export ("backgroundView")]
		UIView BackgroundView { get; }

		[Export ("optionsView")]
		UIView OptionsView { get; }

		[NullAllowed, Export ("borderColor", ArgumentSemantic.Strong)]
		UIColor BorderColor { get; set; }

		[Export ("tapGesture")]
		UITapGestureRecognizer TapGesture { get; }

		[Export ("setupToolbar")]
		void SetupToolbar ();

		[Export ("updateToolbar")]
		void UpdateToolbar ();
	}

	[BaseType (typeof (PSPDFDocumentSharingCoordinator))]
	interface PSPDFOpenInCoordinator : IUIDocumentInteractionControllerDelegate {

		[Field ("PSPDFDocumentInteractionControllerWillBeginSendingToApplicationNotification", PSPDFKitGlobal.LibraryPath)]
		[Notification]
		NSString DocumentInteractionControllerWillBeginSendingToApplicationNotification { get; }

		[Field ("PSPDFDocumentInteractionControllerDidEndSendingToApplicationNotification", PSPDFKitGlobal.LibraryPath)]
		[Notification]
		NSString DocumentInteractionControllerWillDidEndSendingToApplicationNotification { get; }
	}

	interface IPSPDFOutlineCellDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFOutlineCellDelegate {

		[Abstract]
		[Export ("outlineCellDidTapDisclosureButton:")]
		void DidTapDisclosureButton (PSPDFOutlineCell outlineCell);
	}

	[BaseType (typeof (PSPDFTableViewCell))]
	interface PSPDFOutlineCell {

		[Export ("configureWithOutlineElement:documentProvider:")]
		void Configure (PSPDFOutlineElement outlineElement, [NullAllowed] PSPDFDocumentProvider documentProvider);

		[NullAllowed, Export ("outlineElement")]
		PSPDFOutlineElement OutlineElement { get; }

		[NullAllowed, Export ("pageLabelString")]
		string PageLabelString { get; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFOutlineCellDelegate Delegate { get; set; }

		[Export ("showExpandCollapseButton")]
		bool ShowExpandCollapseButton { get; set; }

		[Export ("showPageLabel")]
		bool ShowPageLabel { get; set; }

		// PSPDFOutlineCell (SubclassingHooks) Category

		[Export ("disclosureButton", ArgumentSemantic.Strong)]
		UIButton DisclosureButton { get; set; }

		[Export ("nameLabel", ArgumentSemantic.Strong)]
		UILabel NameLabel { get; set; }

		[Export ("pageLabel", ArgumentSemantic.Strong)]
		UILabel PageLabel { get; set; }

		[Static]
		[Export ("fontForOutlineElement:")]
		UIFont GetFontForOutlineElement ([NullAllowed] PSPDFOutlineElement outlineElement);

		[Static]
		[Export ("pageLabelFontForOutlineElement:")]
		UIFont GetPageLabelFont ([NullAllowed] PSPDFOutlineElement outlineElement);

		[Export ("updateDisclosureButton")]
		void UpdateDisclosureButton ();

		[Export ("expandOrCollapse")]
		void ExpandOrCollapse ();

		[Export ("maximumNumberOfLines")]
		nuint MaximumNumberOfLines { get; set; }

		[Export ("outlineIntentLeftOffset")]
		nfloat OutlineIntentLeftOffset { get; set; }

		[Export ("outlineIndentMultiplier")]
		nfloat OutlineIndentMultiplier { get; set; }
	}

	interface IPSPDFOutlineViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFOutlineViewControllerDelegate : IPSPDFOverridable {

		[Abstract]
		[Export ("outlineController:didTapAtElement:")]
		bool DidTapAtElement (PSPDFOutlineViewController outlineController, PSPDFOutlineElement outlineElement);
	}

	[BaseType (typeof (PSPDFSearchableTableViewController))]
	interface PSPDFOutlineViewController : PSPDFDocumentInfoController, IUISearchDisplayDelegate, PSPDFStyleable {

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFOutlineViewControllerDelegate Delegate { get; set; }

		[Export ("allowCopy")]
		bool AllowCopy { get; set; }

		[Export ("showPageLabels")]
		bool ShowPageLabels { get; set; }

		[Export ("maximumNumberOfLines")]
		nuint MaximumNumberOfLines { get; set; }

		[Export ("outlineIntentLeftOffset")]
		nfloat OutlineIntentLeftOffset { get; set; }

		[Export ("outlineIndentMultiplier")]
		nfloat OutlineIndentMultiplier { get; set; }

		// PSPDFOutlineViewController (SubclassingHooks) Category

		[Export ("shouldExpandCollapseOnRowSelection")]
		bool ShouldExpandCollapseOnRowSelection { get; }

		[Export ("outlineCellDidTapDisclosureButton:")]
		bool DidTapDisclosureButton (PSPDFOutlineCell searchController);

		[Export ("searchController")]
		UISearchController SearchController { get; }
	}

	interface IPSPDFPageCellImageRequestToken { }

	[Protocol]
	interface PSPDFPageCellImageRequestToken {

		[Abstract]
		[Export ("expectedSize")]
		CGSize ExpectedSize { get; }

		[return: NullAllowed]
		[Export ("placeholderImage")]
		UIImage GetPlaceholderImage ();

		[Export ("cancel")]
		void Cancel ();
	}

	interface IPSPDFPageCellImageLoading { }

	[Protocol]
	interface PSPDFPageCellImageLoading {

		[Abstract]
		[Export ("requestImageForPageAtIndex:availableSize:completionHandler:")]
		IPSPDFPageCellImageRequestToken RequestImageForPage (nuint pageIndex, CGSize size, Action<UIImage, NSError> completionHandler);
	}

	[BaseType (typeof (UICollectionViewCell))]
	interface PSPDFPageCell {

		[Export ("pageIndex")]
		nuint PageIndex { get; set; }

		[Export ("edgeInsets", ArgumentSemantic.Assign)]
		UIEdgeInsets EdgeInsets { get; set; }

		[Export ("shadowEnabled")]
		bool ShadowEnabled { [Bind ("isShadowEnabled")] get; set; }

		[Export ("pageLabelEnabled")]
		bool PageLabelEnabled { [Bind ("isPageLabelEnabled")] get; set; }

		[Export ("setNeedsUpdateImage")]
		void SetNeedsUpdateImage ();

		[NullAllowed, Export ("imageLoader", ArgumentSemantic.Strong)]
		IPSPDFPageCellImageLoading ImageLoader { get; set; }

		// PSPDFPageCell (Subviews) Category

		[Export ("pageLabel")]
		UILabel PageLabel { get; }

		[Export ("imageView")]
		UIImageView ImageView { get; }

		// PSPDFPageCell (SubclassingHooks) Category

		[NullAllowed, Export ("image")]
		UIImage Image { get; }

		[return: NullAllowed]
		[Export ("pathShadowForView:")]
		UIBezierPath GetPathShadow (UIView view);

		[Export ("contentRectForBounds:")]
		CGRect GetContentRect (CGRect bounds);

		[Export ("imageRectForContentRect:")]
		CGRect GetImageRect (CGRect contentRect);
	}

	interface IPSPDFPageGrabberView { }

	[Protocol]
	interface PSPDFPageGrabberView {

		[Export ("setCollapsed:animated:")]
		void SetCollapsed (bool collapsed, bool animated);
	}

	[BaseType (typeof (UIView))]
	interface PSPDFPageGrabber {

		[Export ("grabberView", ArgumentSemantic.Strong)]
		IPSPDFPageGrabberView GrabberView { get; set; }

		[Export ("grabbing")]
		bool Grabbing { [Bind ("isGrabbing")] get; }
	}

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface PSPDFPageGrabberController {

		[Export ("pageGrabber")]
		PSPDFPageGrabber PageGrabber { get; }
	}

	interface IPSPDFPageLabelViewDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFPageLabelViewDelegate {

		[Abstract]
		[Export ("pageLabelView:didPressThumbnailGridButton:")]
		void DidPressThumbnailGridButton (PSPDFPageLabelView pageLabelView, UIButton sender);
	}

	[BaseType (typeof (PSPDFLabelView))]
	interface PSPDFPageLabelView {

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFPageLabelViewDelegate Delegate { get; set; }

		[Export ("showThumbnailGridButton")]
		bool ShowThumbnailGridButton { get; set; }

		[Export ("thumbnailGridButton", ArgumentSemantic.Strong)]
		UIButton ThumbnailGridButton { get; set; }

		[Export ("thumbnailButtonColor", ArgumentSemantic.Strong)]
		UIColor ThumbnailButtonColor { get; set; }

		[NullAllowed, Export ("labelFormatter", ArgumentSemantic.Copy)]
		PSPDFPageLabelFormatter LabelFormatter { get; set; }

		// PSPDFPageLabelView (SubclassingHooks) Category

		[Export ("updateFrame")]
		void UpdateFrame ();
	}

	[BaseType (typeof (PSPDFRelayTouchesView))]
	interface PSPDFAnnotationContainerView {

	}

	[BaseType (typeof (UIView))]
	[DisableDefaultCtor]
	interface PSPDFPageView : IPSPDFRenderTaskDelegate, PSPDFResizableViewDelegate, PSPDFAnnotationGridViewControllerDelegate, PSPDFSignatureViewControllerDelegate, PSPDFSignatureSelectorViewControllerDelegate, PSPDFAnnotationStyleViewControllerDelegate, PSPDFNoteAnnotationViewControllerDelegate, PSPDFFontPickerViewControllerDelegate, PSPDFTextSelectionViewDelegate {

		[Field ("PSPDFPageViewSelectedAnnotationsDidChangeNotification", PSPDFKitGlobal.LibraryPath)]
		[Notification]
		NSString SelectedAnnotationsDidChangeNotification { get; }

		[NullAllowed, Export ("presentationContext", ArgumentSemantic.Weak)]
		IPSPDFPresentationContext PresentationContext { get; }

		[Export ("prepareForReuse")]
		[Advice ("Requires base call if override.")]
		void PrepareForReuse ();

		[Export ("updateRenderView")]
		void UpdateRenderView ();

		[Export ("updateView")]
		void UpdateView ();

		[Export ("annotationViewForAnnotation:")]
		[return: NullAllowed]
		IPSPDFAnnotationPresenting GetAnnotationView (PSPDFAnnotation annotation);

		[Export ("contentView")]
		UIImageView ContentView { get; }

		[Export ("renderView")]
		UIImageView RenderView { get; }

		[Export ("annotationContainerView")]
		PSPDFAnnotationContainerView AnnotationContainerView { get; }

		[Export ("selectionView")]
		PSPDFTextSelectionView SelectionView { get; }

		[Export ("renderStatusView", ArgumentSemantic.Strong)]
		NSObject /* PSPDFRenderStatusView */ RenderStatusView { get; set; }

		[Export ("renderStatusViewOffset")]
		nfloat RenderStatusViewOffset { get; set; }

		[Export ("PDFScale")]
		nfloat PdfScale { get; }

		[Export ("visibleRect")]
		CGRect VisibleRect { get; }

		[Export ("highlightColor", ArgumentSemantic.Strong)]
		UIColor HighlightColor { get; set; }

		[Export ("convertViewPointToPDFPoint:")]
		CGPoint ConvertViewPointToPdfPoint (CGPoint viewPoint);

		[Export ("convertPDFPointToViewPoint:")]
		CGPoint ConvertPdfPointToViewPoint (CGPoint pdfPoint);

		[Export ("convertViewRectToPDFRect:")]
		CGRect ConvertViewRectToPdfRect (CGRect viewRect);

		[Export ("convertPDFRectToViewRect:")]
		CGRect ConvertPdfRectToViewRect (CGRect pdfRect);

		[Export ("objectsAtPoint:options:")]
		NSDictionary GetObjects (CGPoint viewPoint, [NullAllowed] NSDictionary<NSString, NSNumber> options);

		[Export ("objectsAtRect:options:")]
		NSDictionary GetObjects (CGRect viewRect, [NullAllowed] NSDictionary<NSString, NSNumber> options);

		[NullAllowed, Export ("zoomView")]
		UIScrollView ZoomView { get; }

		[Export ("visibleAnnotationViews")]
		IPSPDFAnnotationPresenting [] VisibleAnnotationViews { get; }

		[Export ("pageIndex")]
		nuint PageIndex { get; }

		[NullAllowed, Export ("pageInfo")]
		PSPDFPageInfo PageInfo { get; }

		// PSPDFPageView (AnnotationViews) Category

		[Export ("setAnnotation:forAnnotationView:")]
		void SetAnnotation (PSPDFAnnotation annotation, IPSPDFAnnotationPresenting annotationView);

		[Export ("annotationForAnnotationView:")]
		[return: NullAllowed]
		PSPDFAnnotation GetAnnotation (IPSPDFAnnotationPresenting annotationView);

		[Export ("selectedAnnotations", ArgumentSemantic.Copy)]
		PSPDFAnnotation [] SelectedAnnotations { get; set; }

		[Export ("singleTapped:")]
		bool SingleTapped (UITapGestureRecognizer recognizer);

		[Export ("longPress:")]
		bool LongPress (UILongPressGestureRecognizer recognizer);

		[Export ("addAnnotation:options:animated:")]
		void AddAnnotation (PSPDFAnnotation annotation, [NullAllowed] NSDictionary<NSString, NSNumber> options, bool animated);

		[Export ("removeAnnotation:options:animated:")]
		bool RemoveAnnotation (PSPDFAnnotation annotation, [NullAllowed] NSDictionary<NSString, NSNumber> options, bool animated);

		[Export ("selectAnnotation:animated:")]
		void SelectAnnotation (PSPDFAnnotation annotation, bool animated);

		// PSPDFPageView (SubclassingHooks) Category

		[Export ("updateShadowAnimated:")]
		void UpdateShadow (bool animated);

		[Export ("insertAnnotations:")]
		void InsertAnnotations (PSPDFAnnotation [] annotations);

		[Export ("insertAnnotations:forPageAtIndex:inDocument:")]
		void InsertAnnotations (PSPDFAnnotation [] annotations, nuint pageIndex, PSPDFDocument document);

		[Export ("tappableAnnotationsAtPoint:")]
		PSPDFAnnotation [] GetTappableAnnotations (CGPoint viewPoint);

		[Export ("tappableAnnotationsForLongPressAtPoint:")]
		PSPDFAnnotation [] GetTappableAnnotationsForLongPress (CGPoint viewPoint);

		[Export ("hitTestRectForPoint:")]
		CGRect GetHitTestRect (CGPoint viewPoint);

		[Export ("singleTappedAtViewPoint:")]
		bool SingleTapped (CGPoint viewPoint);

		[Export ("didSelectAnnotations:")]
		[Advice ("Requires base call if override.")]
		void DidSelectAnnotations ([NullAllowed] PSPDFAnnotation [] annotations);

		[Export ("didDeselectAnnotations:")]
		[Advice ("Requires base call if override.")]
		void DidDeselectAnnotations (PSPDFAnnotation [] annotations);

		[Export ("rectForAnnotations:")]
		CGRect GetRectForAnnotations (PSPDFAnnotation [] annotations);

		[Export ("renderOptionsDictWithZoomScale:animated:")]
		NSDictionary GetRenderOptionsDict (nfloat zoomScale, bool animated);

		[Export ("annotationSelectionView")]
		PSPDFResizableView AnnotationSelectionView { get; }

		[Export ("centerAnnotation:aroundPDFPoint:")]
		void CenterAnnotation (PSPDFAnnotation annotation, CGPoint pdfPoint);

		[Export ("loadPageAnnotationsAnimated:blockWhileParsing:")]
		void LoadPageAnnotations (bool animated, bool blockWhileParsing);

		[Export ("scaleForPageView")]
		nfloat ScaleForPageView { get; }

		[Export ("annotationsAddedNotification:")]
		[Advice ("Requires base call if override.")]
		void AnnotationsAddedNotification (NSNotification notification);

		[Export ("annotationsRemovedNotification:")]
		[Advice ("Requires base call if override.")]
		void AnnotationsRemovedNotification (NSNotification notification);

		[Export ("annotationChangedNotification:")]
		[Advice ("Requires base call if override.")]
		void AnnotationChangedNotification (NSNotification notification);

		[Export ("shouldScaleAnnotationWhenResizing:usesResizeKnob:")]
		bool ShouldScaleAnnotationWhenResizing (PSPDFAnnotation annotation, bool usesResizeKnob);

		[Export ("updateAnnotationSelectionView")]
		void UpdateAnnotationSelectionView ();

		// PSPDFPageView (AnnotationMenu) Category

		[Export ("menuItemsForAnnotations:")]
		PSPDFMenuItem [] GetMenuItemsForAnnotations (PSPDFAnnotation [] annotations);

		[Export ("menuItemsForNewAnnotationAtPoint:")]
		PSPDFMenuItem [] GetMenuItemsForNewAnnotation (CGPoint point);

		[Export ("colorMenuItemsForAnnotation:")]
		PSPDFMenuItem [] GetColorMenuItems (PSPDFAnnotation annotation);

		[Export ("fillColorMenuItemsForAnnotation:")]
		PSPDFMenuItem [] GetFillColorMenuItems (PSPDFAnnotation annotation);

		[Export ("opacityMenuItemForAnnotation:withColor:")]
		PSPDFMenuItem GetOpacityMenuItem (PSPDFAnnotation annotation, [NullAllowed] UIColor color);

		[Export ("showInspectorForAnnotations:options:animated:")]
		[return: NullAllowed]
		PSPDFAnnotationStyleViewController ShowInspector (PSPDFAnnotation [] annotations, [NullAllowed] NSDictionary options, bool animated);

		[Export ("showMenuForAnnotations:targetRect:allowPopovers:animated:")]
		void ShowMenu (PSPDFAnnotation [] annotations, CGRect targetRect, bool allowPopovers, bool animated);

		[Export ("showNoteControllerForAnnotation:showKeyboard:animated:")]
		PSPDFNoteAnnotationViewController ShowNoteController (PSPDFAnnotation annotation, bool showKeyboard, bool animated);

		[Export ("showFontPickerForAnnotation:animated:")]
		void ShowFontPicker (PSPDFFreeTextAnnotation annotation, bool animated);

		[Export ("showColorPickerForAnnotation:animated:")]
		void ShowColorPicker (PSPDFAnnotation annotation, bool animated);

		[Export ("showSignatureControllerAtRect:withTitle:options:animated:")]
		void ShowSignatureController (CGRect viewRect, [NullAllowed] string title, [NullAllowed] NSDictionary options, bool animated);

		[Export ("availableFontSizes")]
		NSNumber [] AvailableFontSizes { get; }

		[Export ("availableLineWidths")]
		NSNumber [] AvailableLineWidths { get; }

		[Export ("passthroughViewsForPopoverController")]
		UIView [] PassthroughViewsForPopoverController { get; }

		// PSPDFPageView (AnnotationMenuSubclassingHooks) Category

		[Export ("showNewSignatureMenuAtRect:options:animated:")]
		void ShowNewSignatureMenu (CGRect viewRect, [NullAllowed] NSDictionary options, bool animated);

		[Export ("showDigitalSignatureMenuForSignatureField:animated:")]
		bool ShowDigitalSignatureMenu (PSPDFSignatureFormElement signatureField, bool animated);

		[Export ("defaultColorOptionsForAnnotationType:")]
		UIColor [] GetDefaultColorOptions (PSPDFAnnotationType annotationType);

		[Export ("useAnnotationInspectorForAnnotations:")]
		bool UseAnnotationInspector (PSPDFAnnotation [] annotations);

		[Export ("selectColorForAnnotation:isFillColor:")]
		void SelectColor (PSPDFAnnotation annotation, bool isFillColor);

		[Export ("shouldMoveStyleMenuEntriesIntoSubmenu")]
		bool ShouldMoveStyleMenuEntriesIntoSubmenu { get; }

		[Export ("showLinkPreviewActionSheetForAnnotation:fromRect:animated:")]
		bool ShowLinkPreviewActionSheet (PSPDFLinkAnnotation annotation, CGRect viewRect, bool animated);

		[Export ("showMenuIfSelectedAnimated:")]
		void ShowMenuIfSelected (bool animated);

		[Export ("showMenuIfSelectedAnimated:allowPopovers:")]
		void ShowMenuIfSelected (bool animated, bool allowPopovers);
	}

	interface IPSPDFPresentationContext { }

	[Protocol]
	interface PSPDFPresentationContext : IPSPDFOverridable, PSPDFVisiblePagesDataSource, PSPDFErrorHandler {

		[Abstract]
		[Export ("configuration", ArgumentSemantic.Copy)]
		PSPDFConfiguration Configuration { get; }

		[Abstract]
		[Export ("pspdfkit")]
		PSPDFKitGlobal PsPdfKit { get; }

		[Abstract]
		[Export ("displayingViewController")]
		UIViewController DisplayingViewController { get; }

		[Abstract]
		[Export ("documentViewController")]
		PSPDFDocumentViewController DocumentViewController { get; }

		[Abstract]
		[NullAllowed, Export ("document")]
		PSPDFDocument Document { get; }

		[Abstract]
		[Export ("viewMode")]
		PSPDFViewMode ViewMode { get; }

		[Abstract]
		[Export ("contentRect")]
		CGRect ContentRect { get; }

		[Abstract]
		[Export ("rotationActive")]
		bool RotationActive { [Bind ("isRotationActive")] get; }

		[Abstract]
		[Export ("userInterfaceVisible")]
		bool UserInterfaceVisible { [Bind ("isUserInterfaceVisible")] get; }

		[Abstract]
		[Export ("viewWillAppearing")]
		bool ViewWillAppearing { [Bind ("isViewWillAppearing")] get; }

		[Abstract]
		[Export ("reloading")]
		bool Reloading { [Bind ("isReloading")] get; }

		[Abstract]
		[Export ("viewLoaded")]
		bool ViewLoaded { [Bind ("isViewLoaded")] get; }

		[Abstract]
		[Export ("visiblePageViews")]
		PSPDFPageView [] VisiblePageViews { get; }

		[Abstract]
		[Export ("pageViewForPageAtIndex:")]
		[return: NullAllowed]
		PSPDFPageView GetPageView (nuint pageIndex);

		[Abstract]
		[Export ("annotationStateManager")]
		PSPDFAnnotationStateManager AnnotationStateManager { get; }

		[Abstract]
		[Export ("annotationToolbarController")]
		PSPDFAnnotationToolbarController AnnotationToolbarController { get; }

		[Abstract]
		[NullAllowed, Export ("actionDelegate")]
		IPSPDFControlDelegate ActionDelegate { get; }

		[Abstract]
		[Export ("pdfController")]
		PSPDFViewController PdfController { get; }
	}

	[BaseType (typeof (PSPDFBaseConfigurationBuilder))]
	interface PSPDFPrintConfigurationBuilder {

		[Export ("printMode")]
		PSPDFPrintMode PrintMode { get; set; }

		[NullAllowed, Export ("defaultPrinter")]
		UIPrinter DefaultPrinter { get; set; }
	}

	[BaseType (typeof (PSPDFBaseConfiguration))]
	interface PSPDFPrintConfiguration {

		[Static, New]
		[Export ("defaultConfiguration")]
		PSPDFPrintConfiguration DefaultConfiguration { get; }

		[Export ("initWithBuilder:")]
		IntPtr Constructor (PSPDFPrintConfigurationBuilder builder);

		[Static]
		[Export ("configurationWithBuilder:")]
		PSPDFPrintConfiguration FromConfigurationBuilder ([NullAllowed] Action<PSPDFPrintConfigurationBuilder> builderHandler);

		[Static]
		[Export ("configurationUpdatedWithBuilder:")]
		PSPDFPrintConfiguration ConfigurationUpdated ([NullAllowed] Action<PSPDFPrintConfigurationBuilder> builderHandler);

		[Export ("printMode")]
		PSPDFPrintMode PrintMode { get; }

		[NullAllowed, Export ("defaultPrinter")]
		UIPrinter DefaultPrinter { get; }
	}

	[BaseType (typeof (PSPDFDocumentSharingCoordinator))]
	interface PSPDFPrintCoordinator : IUIPrintInteractionControllerDelegate, IUIPrinterPickerControllerDelegate {

		[Export ("printConfiguration", ArgumentSemantic.Strong)]
		PSPDFPrintConfiguration PrintConfiguration { get; set; }

		// PSPDFPrintCoordinator (SubclassingHooks) Category

		[NullAllowed, Export ("printInfo")]
		UIPrintInfo PrintInfo { get; }

		[NullAllowed, Export ("printInteractionController", ArgumentSemantic.Weak)]
		UIPrintInteractionController PrintInteractionController { get; }
	}

	[BaseType (typeof (UIView))]
	interface PSPDFRelayTouchesView {

	}

	interface IPSPDFResizableViewDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFResizableViewDelegate {

		[Export ("resizableViewDidBeginEditing:")]
		void DidBeginEditing (PSPDFResizableView resizableView);

		[Export ("resizableViewChangedFrame:outerKnobType:isInitialChange:")]
		void ChangedFrame (PSPDFResizableView resizableView, PSPDFResizableViewOuterKnob outerKnobType, bool isInitialChange);

		[Export ("resizableView:adjustedProperty:ofAnnotation:")]
		void AdjustedProperty (PSPDFResizableView resizableView, string propertyName, PSPDFAnnotation annotation);

		[Export ("resizableViewDidEndEditing:didChangeFrame:")]
		void DidEndEditing (PSPDFResizableView resizableView, bool didChangeFrame);
	}

	interface IPSPDFKnobView { }

	[Protocol]
	interface PSPDFKnobView {

		[Abstract]
		[Export ("type", ArgumentSemantic.Assign)]
		PSPDFKnobType Type { get; set; }

		[Abstract]
		[Export ("knobSize")]
		CGSize KnobSize { get; }
	}

	[BaseType (typeof (UIView))]
	interface PSPDFResizableView {

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFResizableViewDelegate Delegate { get; set; }

		[Export ("mode", ArgumentSemantic.Assign)]
		PSPDFResizableViewMode Mode { get; set; }

		[NullAllowed, Export ("trackedViews", ArgumentSemantic.Copy)]
		NSSet<UIView> TrackedViews { get; set; }

		[Export ("zoomScale")]
		nfloat ZoomScale { get; set; }

		[Export ("innerEdgeInsets", ArgumentSemantic.Assign)]
		UIEdgeInsets InnerEdgeInsets { get; set; }

		[Export ("outerEdgeInsets", ArgumentSemantic.Assign)]
		UIEdgeInsets OuterEdgeInsets { get; set; }

		[Export ("allowEditing")]
		bool AllowEditing { get; set; }

		[Export ("allowResizing")]
		bool AllowResizing { get; set; }

		[Export ("allowAdjusting")]
		bool AllowAdjusting { get; set; }

		[Export ("enableResizingGuides")]
		bool EnableResizingGuides { get; set; }

		[Export ("showBoundingBox")]
		bool ShowBoundingBox { get; set; }

		[Export ("guideSnapAllowance")]
		nfloat GuideSnapAllowance { get; set; }

		[Export ("minWidth")]
		nfloat MinWidth { get; set; }

		[Export ("minHeight")]
		nfloat MinHeight { get; set; }

		[Export ("selectionBorderWidth")]
		nfloat SelectionBorderWidth { get; set; }

		[NullAllowed, Export ("guideBorderColor", ArgumentSemantic.Strong)]
		UIColor GuideBorderColor { get; set; }

		[Export ("cornerRadius")]
		nuint CornerRadius { get; set; }

		// PSPDFResizableView (SubclassingHooks) Category

		[Export ("longPress:")]
		bool LongPress (UILongPressGestureRecognizer recognizer);

		[Export ("outerKnobOfType:")]
		[return: NullAllowed]
		IPSPDFKnobView GetOuterKnob (PSPDFResizableViewOuterKnob knobType);

		[Export ("centerPointForOuterKnob:inFrame:")]
		CGPoint GetCenterPointForOuterKnob (PSPDFResizableViewOuterKnob knobType, CGRect frame);

		[Export ("newKnobViewForType:")]
		IPSPDFKnobView GetNewKnobView (PSPDFKnobType type);

		[Export ("trackedAnnotations")]
		NSSet<PSPDFAnnotation> TrackedAnnotations { get; }

		[Export ("updateKnobsAnimated:")]
		void UpdateKnobs (bool animated);

		[Export ("configureGuideLayer:withZoomScale:")]
		[Advice ("Requires base call if override.")]
		void ConfigureGuideLayer (CAShapeLayer layer, nfloat zoomScale);
	}

	[BaseType (typeof (UILabel))]
	interface PSPDFRoundedLabel {

		[Export ("cornerRadius")]
		nfloat CornerRadius { get; set; }

		[NullAllowed, Export ("rectColor", ArgumentSemantic.Strong)]
		UIColor RectColor { get; set; }
	}

	interface IPSPDFAnnotationSetStore { }

	[Protocol]
	interface PSPDFAnnotationSetStore {

		[Abstract]
		[Export ("annotationSets", ArgumentSemantic.Copy)]
		PSPDFAnnotationSet [] AnnotationSets { get; set; }
	}

	[BaseType (typeof (NSObject))]
	interface PSPDFKeychainAnnotationSetsStore : PSPDFAnnotationSetStore {

	}

	[BaseType (typeof (PSPDFAnnotationGridViewController))]
	interface PSPDFSavedAnnotationsViewController : PSPDFAnnotationGridViewControllerDataSource, PSPDFStyleable {

		[Static]
		[Export ("sharedAnnotationStore")]
		IPSPDFAnnotationSetStore SharedAnnotationStore { get; }

		[Export ("annotationStore", ArgumentSemantic.Strong)]
		IPSPDFAnnotationSetStore AnnotationStore { get; set; }

		// PSPDFSavedAnnotationsViewController (SubclassingHooks) Category

		[Export ("updateToolbarAnimated:")]
		void UpdateToolbar (bool animated);
	}

	interface IPSPDFSaveViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFSaveViewControllerDelegate {

		[Abstract]
		[Export ("saveViewControllerDidEnd:shouldSave:")]
		void DidEnd (PSPDFSaveViewController controller, bool shouldSave);

		[Export ("saveViewControllerShouldSave:toPath:error:")]
		bool ShouldSave (PSPDFSaveViewController controller, string path, [NullAllowed] out NSError error);
	}

	[BaseType (typeof (PSPDFStaticTableViewController))]
	[DisableDefaultCtor]
	interface PSPDFSaveViewController : IPSPDFDocumentEditorConfigurationConfigurable {

		[Export ("initWithDocumentEditorConfiguration:")]
		[DesignatedInitializer]
		IntPtr Constructor (PSPDFDocumentEditorConfiguration configuration);

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFSaveViewControllerDelegate Delegate { get; set; }

		[NullAllowed, Export ("fileName")]
		string FileName { get; set; }

		[NullAllowed, Export ("fullFilePath")]
		string FullFilePath { get; }

		[Export ("showDirectoryPicker")]
		bool ShowDirectoryPicker { get; set; }

		[Export ("documentEditorConfiguration")]
		new PSPDFDocumentEditorConfiguration DocumentEditorConfiguration { get; }
	}

	interface IPSPDFScreenControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFScreenControllerDelegate {

		[Export ("screenController:didStartMirroringForScreen:")]
		void DidStartMirroring (PSPDFScreenController screenController, UIScreen screen);

		[Export ("screenController:didStopMirroringForScreen:")]
		void DidStopMirroring (PSPDFScreenController screenController, UIScreen screen);

		[Export ("createPDFViewControllerForMirroring:")]
		PSPDFViewController CreatePdfViewControllerForMirroring (PSPDFScreenController screenController);
	}

	[BaseType (typeof (NSObject))]
	interface PSPDFScreenController {

		[NullAllowed, Export ("pdfControllerToMirror", ArgumentSemantic.Strong)]
		PSPDFViewController PdfControllerToMirror { get; set; }

		[Export ("mirrorControllerForScreen:")]
		[return: NullAllowed]
		PSPDFViewController MirrorController (UIScreen screen);

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFScreenControllerDelegate Delegate { get; set; }
	}

	[BaseType (typeof (PSPDFStackViewLayout))]
	interface PSPDFScrollPerSpreadLayout {

		[Export ("contentScale", ArgumentSemantic.Assign)]
		PSPDFScrollPerSpreadLayoutContentScale ContentScale { get; set; }
	}

	interface IPSPDFScrubberBarDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFScrubberBarDelegate {

		[Abstract]
		[Export ("scrubberBar:didSelectPageAtIndex:")]
		void DidSelectPage (PSPDFScrubberBar scrubberBar, nuint pageIndex);
	}

	[BaseType (typeof (UIView))]
	interface PSPDFScrubberBar {

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFScrubberBarDelegate Delegate { get; set; }

		[NullAllowed, Export ("dataSource", ArgumentSemantic.Weak)]
		IPSPDFPresentationContext DataSource { get; set; }

		[Export ("scrubberBarType", ArgumentSemantic.Assign)]
		PSPDFScrubberBarType ScrubberBarType { get; set; }

		[Export ("updateToolbarAnimated:")]
		void UpdateToolbar (bool animated);

		[Export ("updateToolbarForced")]
		void UpdateToolbarForced ();

		[Export ("pageIndex")]
		nuint PageIndex { get; set; }

		[Export ("allowTapsOutsidePageArea")]
		bool AllowTapsOutsidePageArea { get; set; }

		[NullAllowed, Export ("barTintColor", ArgumentSemantic.Strong)]
		UIColor BarTintColor { get; set; }

		[Export ("translucent")]
		bool Translucent { [Bind ("isTranslucent")] get; set; }

		[Export ("leftBorderMargin")]
		nfloat LeftBorderMargin { get; set; }

		[Export ("rightBorderMargin")]
		nfloat RightBorderMargin { get; set; }

		[NullAllowed, Export ("thumbnailBorderColor", ArgumentSemantic.Strong)]
		UIColor ThumbnailBorderColor { get; set; }

		[Export ("toolbar")]
		UIToolbar Toolbar { get; }

		// PSPDFScrubberBar (SubclassingHooks) Category

		[Export ("smallToolbar")]
		bool SmallToolbar { [Bind ("isSmallToolbar")] get; }

		[Export ("scrubberBarHeight")]
		nfloat ScrubberBarHeight { get; }

		[Export ("scrubberBarThumbSize")]
		CGSize ScrubberBarThumbSize { get; }

		[Export ("emptyThumbnailImageView")]
		UIImageView EmptyThumbnailImageView { get; }

		[Export ("processTouch:")]
		bool ProcessTouch (UITouch touch);

		[Export ("thumbnailMargin")]
		nfloat ThumbnailMargin { get; set; }

		[Export ("pageMarkerSizeMultiplier")]
		nfloat PageMarkerSizeMultiplier { get; set; }
	}

	[BaseType (typeof (PSPDFStatefulTableViewController))]
	interface PSPDFSearchableTableViewController {

		[Export ("searchEnabled")]
		bool SearchEnabled { get; set; }
	}

	[BaseType (typeof (UIView))]
	interface PSPDFSearchHighlightView : PSPDFAnnotationPresenting {

		[Export ("popupAnimation")]
		void PopupAnimation ();

		[NullAllowed, Export ("searchResult", ArgumentSemantic.Strong)]
		PSPDFSearchResult SearchResult { get; set; }

		[NullAllowed, Export ("selectionBackgroundColor", ArgumentSemantic.Strong)]
		UIColor SelectionBackgroundColor { get; set; }

		[Export ("cornerRadiusProportion")]
		nfloat CornerRadiusProportion { get; set; }
	}

	interface IPSPDFSearchHighlightViewManagerDataSource { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFSearchHighlightViewManagerDataSource : IPSPDFOverridable {

		[Abstract]
		[Export ("shouldHighlightSearchResults")]
		bool ShouldHighlightSearchResults { get; }

		[Abstract]
		[Export ("visiblePageViews")]
		PSPDFPageView [] VisiblePageViews { get; }
	}

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface PSPDFSearchHighlightViewManager {

		[Export ("initWithDataSource:")]
		[DesignatedInitializer]
		IntPtr Constructor (IPSPDFSearchHighlightViewManagerDataSource dataSource);

		[NullAllowed, Export ("dataSource", ArgumentSemantic.Weak)]
		IPSPDFSearchHighlightViewManagerDataSource DataSource { get; }

		[Export ("hasVisibleSearchResults")]
		bool HasVisibleSearchResults { get; }

		[Export ("clearHighlightedSearchResultsAnimated:")]
		void ClearHighlightedSearchResults (bool animated);

		[Export ("addHighlightSearchResults:animated:")]
		void AddHighlightSearchResults (PSPDFSearchResult [] searchResults, bool animated);

		[Export ("animateSearchHighlight:")]
		void AnimateSearchHighlight (PSPDFSearchResult searchResult);
	}

	interface IPSPDFSearchResultViewable { }

	[Protocol]
	interface PSPDFSearchResultViewable {

		[Abstract]
		[Export ("configureWithSearchResult:")]
		void ConfigureWithSearchResult (PSPDFSearchResult searchResult);
	}

	interface IPSPDFSearchScopeViewable { }

	[Protocol]
	interface PSPDFSearchScopeViewable {

		[Abstract]
		[Export ("configureWithDocument:scope:pageIndexRange:results:")]
		void ConfigureWithDocument (PSPDFDocument document, PSPDFSearchResultScope scope, NSRange pageIndexRange, nuint results);
	}

	interface IPSPDFSearchStatusViewable { }

	[Protocol]
	interface PSPDFSearchStatusViewable {

		[Abstract]
		[Export ("configureWithSearchStatus:results:pageIndex:pageCount:")]
		void ConfigureWithSearchStatus (PSPDFSearchStatus searchStatus, nuint results, nuint pageIndex, nuint pageCount);
	}

	interface IPSPDFSearchViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFSearchViewControllerDelegate : IPSPDFTextSearchDelegate, IPSPDFOverridable {

		[Export ("searchViewController:didTapSearchResult:")]
		void DidTapSearchResult (PSPDFSearchViewController searchController, PSPDFSearchResult searchResult);

		[Export ("searchViewControllerDidClearAllSearchResults:")]
		void DidClearAllSearchResults (PSPDFSearchViewController searchController);

		[Export ("searchViewControllerGetVisiblePages:")]
		NSIndexSet GetVisiblePages (PSPDFSearchViewController searchController);

		[Export ("searchViewController:searchRangeForScope:")]
		[return: NullAllowed]
		NSIndexSet GetSearchRange (PSPDFSearchViewController searchController, string scope);

		[Export ("searchViewControllerTextSearchObject:")]
		PSPDFTextSearch GetTextSearchObject (PSPDFSearchViewController searchController);
	}

	[BaseType (typeof (PSPDFBaseTableViewController))]
	interface PSPDFSearchViewController : IUISearchDisplayDelegate, IUISearchBarDelegate, IPSPDFTextSearchDelegate, PSPDFStyleable {

		[Static]
		[Export ("resultCellClass")]
		Class ResultCellClass { get; }

		[Static]
		[Export ("scopeHeaderClass")]
		Class ScopeHeaderClass { get; }

		[Static]
		[Export ("statusFooterClass")]
		Class StatusFooterClass { get; }

		[Export ("initWithDocument:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] PSPDFDocument document);

		[NullAllowed, Export ("document", ArgumentSemantic.Strong)]
		PSPDFDocument Document { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFSearchViewControllerDelegate Delegate { get; set; }

		[NullAllowed, Export ("searchText")]
		string SearchText { get; set; }

		[Export ("showsCancelButton")]
		bool ShowsCancelButton { get; set; }

		[Export ("searchBar")]
		UISearchBar SearchBar { get; }

		[Export ("searchStatus")]
		PSPDFSearchStatus SearchStatus { get; }

		[Export ("clearHighlightsWhenClosed")]
		bool ClearHighlightsWhenClosed { get; set; }

		[Export ("maximumNumberOfSearchResultsDisplayed")]
		nuint MaximumNumberOfSearchResultsDisplayed { get; set; }

		[Export ("searchVisiblePagesFirst")]
		bool SearchVisiblePagesFirst { get; set; }

		[Export ("numberOfPreviewTextLines")]
		nuint NumberOfPreviewTextLines { get; set; }

		[Export ("useOutlineForPageNames")]
		bool UseOutlineForPageNames { get; set; }

		[Export ("restoreLastSearchResult")]
		bool RestoreLastSearchResult { get; set; }

		[Export ("searchableAnnotationTypes", ArgumentSemantic.Assign)]
		PSPDFAnnotationType SearchableAnnotationTypes { get; set; }

		[Export ("searchBarPinning", ArgumentSemantic.Assign)]
		PSPDFSearchBarPinning SearchBarPinning { get; set; }

		[NullAllowed, Export ("textSearch")]
		PSPDFTextSearch TextSearch { get; }

		[Export ("restartSearch")]
		void RestartSearch ();

		// PSPDFSearchViewController (SubclassingHooks) Category

		[Export ("filterContentForSearchText:scope:")]
		void FilterContent (string searchText, [NullAllowed] string scope);

		[Export ("setSearchStatus:updateTable:")]
		void SetSearchStatus (PSPDFSearchStatus searchStatus, bool updateTable);

		[Export ("searchResultForIndexPath:")]
		PSPDFSearchResult GetSearchResult (NSIndexPath indexPath);

		[Export ("createSearchBar")]
		UISearchBar CreateSearchBar { get; }

		[Export ("searchResults")]
		PSPDFSearchResult [] SearchResults { get; }
	}

	[BaseType (typeof (UISegmentedControl))]
	interface PSPDFSegmentedControl {

		[Export ("hitTestEdgeInsets", ArgumentSemantic.Assign)]
		UIEdgeInsets HitTestEdgeInsets { get; set; }
	}

	[BaseType (typeof (UICollectionViewCell))]
	interface PSPDFSelectableCollectionViewCell {

		[Export ("selectableCellStyle", ArgumentSemantic.Assign)]
		PSPDFSelectableCollectionViewCellStyle SelectableCellStyle { get; set; }

		[NullAllowed, Export ("selectableCellColor", ArgumentSemantic.Strong)]
		UIColor SelectableCellColor { get; set; }
	}

	[BaseType (typeof (NSObject))]
	interface PSPDFSelectionState : INSSecureCoding {

		[Static]
		[Export ("stateForSelectionView:")]
		[return: NullAllowed]
		PSPDFSelectionState FromSelectionView (PSPDFTextSelectionView selectionView);

		[Export ("UID")]
		string Uid { get; }

		[Export ("selectionPageIndex")]
		nuint SelectionPageIndex { get; }

		[NullAllowed, Export ("selectedGlyphs")]
		PSPDFGlyph [] SelectedGlyphs { get; }

		[NullAllowed, Export ("selectedImage")]
		PSPDFImageInfo SelectedImage { get; }

		[Export ("isEqualToSelectionState:")]
		bool IsEqualTo ([NullAllowed] PSPDFSelectionState selectionState);
	}

	interface IPSPDFSelectionViewDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFSelectionViewDelegate {

		[Export ("selectionView:shouldStartSelectionAtPoint:")]
		bool ShouldStartSelection (PSPDFSelectionView selectionView, CGPoint point);

		[Export ("selectionView:updateSelectedRect:")]
		void UpdateSelectedRect (PSPDFSelectionView selectionView, CGRect rect);

		[Export ("selectionView:finishedWithSelectedRect:")]
		void FinishedWithSelectedRect (PSPDFSelectionView selectionView, CGRect rect);

		[Export ("selectionView:cancelledWithSelectedRect:")]
		void CancelledWithSelectedRect (PSPDFSelectionView selectionView, CGRect rect);

		[Export ("selectionView:singleTappedWithGestureRecognizer:")]
		void SingleTappedWithGestureRecognizer (PSPDFSelectionView selectionView, UITapGestureRecognizer gestureRecognizer);
	}

	[BaseType (typeof (UIView))]
	interface PSPDFSelectionView {

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFSelectionViewDelegate Delegate { get; set; }

		[Export ("selectionAlpha")]
		nfloat SelectionAlpha { get; set; }

		[NullAllowed, Export ("rects", ArgumentSemantic.Copy)]
		NSValue [] Rects { get; set; }

		[Export ("allowedTouchTypes", ArgumentSemantic.Copy)]
		NSNumber [] AllowedTouchTypes { get; set; }

		// PSPDFSelectionView (SubclassingHooks) Category

		[Export ("tapGestureRecognizer")]
		UITapGestureRecognizer TapGestureRecognizer { get; }

		[Export ("panGestureRecognizer")]
		UIPanGestureRecognizer PanGestureRecognizer { get; }
	}

	[BaseType (typeof (PSPDFStaticTableViewController))]
	interface PSPDFSettingsViewController {

		[NullAllowed, Export ("pdfViewController", ArgumentSemantic.Weak)]
		PSPDFViewController PdfViewController { get; set; }
	}

	[BaseType (typeof (UITableViewCell))]
	interface PSPDFSignatureCell {

		[Export ("certificateLabel")]
		UIControl CertificateLabel { get; }

		[Export ("signatureImageView")]
		UIImageView SignatureImageView { get; }

		[Export ("updateCellForSigner:")]
		void UpdateCell ([NullAllowed] PSPDFSigner signer);
	}

	interface IPSPDFSignatureSelectorViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFSignatureSelectorViewControllerDelegate : IPSPDFOverridable {

		[Abstract]
		[Export ("signatureSelectorViewController:didSelectSignature:")]
		void DidSelectSignature (PSPDFSignatureSelectorViewController signatureSelectorController, PSPDFSignatureContainer signature);

		[Abstract]
		[Export ("signatureSelectorViewControllerWillCreateNewSignature:")]
		void WillCreateNewSignature (PSPDFSignatureSelectorViewController signatureSelectorController);
	}

	[BaseType (typeof (PSPDFStatefulTableViewController))]
	interface PSPDFSignatureSelectorViewController : PSPDFStyleable {

		[NullAllowed, Export ("signatureStore", ArgumentSemantic.Strong)]
		IPSPDFSignatureStore SignatureStore { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFSignatureSelectorViewControllerDelegate Delegate { get; set; }

		// PSPDFSelectionView (SubclassingHooks) Category

		[Export ("addSignatureButtonItem")]
		UIBarButtonItem AddSignatureButtonItem { get; }

		[Export ("doneButtonItem")]
		UIBarButtonItem DoneButtonItem { get; }

		[Export ("doneAction:")]
		void DoneAction ([NullAllowed] NSObject sender);

		[Export ("addSignatureAction:")]
		void AddSignatureAction ([NullAllowed] NSObject sender);
	}

	interface IPSPDFSignatureStore { }

	[Protocol]
	interface PSPDFSignatureStore : INSSecureCoding {

		// Hack: this must be manually inlined in to any object implementing IPSPDFSignatureStore
		//[Abstract]
		//[Export ("initWithStoreName:")]
		//IntPtr Constructor (string storeName);

		[Abstract]
		[Export ("addSignature:")]
		void AddSignature (PSPDFSignatureContainer signature);

		[Abstract]
		[Export ("removeSignature:")]
		bool RemoveSignature (PSPDFSignatureContainer signature);

		[Abstract]
		[Export ("signatures", ArgumentSemantic.Copy)]
		PSPDFSignatureContainer [] Signatures { get; set; }

		[Abstract]
		[Export ("storeName")]
		string StoreName { get; }
	}

	[BaseType (typeof (NSObject))]
	interface PSPDFKeychainSignatureStore : PSPDFSignatureStore {

		[Field ("PSPDFKeychainSignatureStoreDefaultStoreName", PSPDFKitGlobal.LibraryPath)]
		NSString DefaultStoreName { get; }

		[Export ("initWithStoreName:")]
		IntPtr Constructor (string storeName);
	}

	interface IPSPDFSignatureViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFSignatureViewControllerDelegate : IPSPDFOverridable {

		[Export ("signatureViewControllerDidCancel:")]
		void DidCancel (PSPDFSignatureViewController signatureController);

		[Export ("signatureViewControllerDidFinish:withSigner:shouldSaveSignature:")]
		void DidFinish (PSPDFSignatureViewController signatureController, [NullAllowed] PSPDFSigner signer, bool shouldSaveSignature);
	}

	[BaseType (typeof (PSPDFBaseViewController))]
	interface PSPDFSignatureViewController : PSPDFStyleable {

		[Export ("lines")]
		NSArray<NSValue> [] Lines { get; }

		[Export ("naturalDrawingEnabled")]
		bool NaturalDrawingEnabled { get; set; }

		[Export ("menuColors", ArgumentSemantic.Copy)]
		UIColor [] MenuColors { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFSignatureViewControllerDelegate Delegate { get; set; }

		[Export ("savingStrategy", ArgumentSemantic.Assign)]
		PSPDFSignatureSavingStrategy SavingStrategy { get; set; }

		[Export ("certificateSelectionMode", ArgumentSemantic.Assign)]
		PSPDFSignatureCertificateSelectionMode CertificateSelectionMode { get; set; }

		[Export ("keepLandscapeAspectRatio")]
		bool KeepLandscapeAspectRatio { get; set; }

		// PSPDFSignatureViewController (SubclassingHooks) Category

		[Export ("drawView")]
		PSPDFDrawView DrawView { get; }

		[Export ("colorButtonForColor:")]
		PSPDFColorButton ColorButtonForColor (UIColor color);

		[Export ("cancel:")]
		void Cancel ([NullAllowed] NSObject sender);

		[Export ("done:")]
		void Done ([NullAllowed] NSObject sender);

		[Export ("clear:")]
		void Clear ([NullAllowed] NSObject sender);

		[Export ("color:")]
		void Color (PSPDFColorButton sender);
	}

	[BaseType (typeof (PSPDFBaseTableViewController))]
	[DisableDefaultCtor]
	interface PSPDFSignedFormElementViewController {

		[Export ("initWithSignatureFormElement:")]
		[DesignatedInitializer]
		IntPtr Constructor (PSPDFSignatureFormElement element);

		[Export ("formElement", ArgumentSemantic.Strong)]
		PSPDFSignatureFormElement FormElement { get; }

		[Export ("verifySignatureWithTrustedCertificates:error:")]
		[return: NullAllowed]
		PSPDFSignatureStatus VerifySignature ([NullAllowed] PSPDFX509 [] trustedCertificates, [NullAllowed] out NSError error);

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFSignedFormElementViewControllerDelegate Delegate { get; set; }
	}

	interface IPSPDFSignedFormElementViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFSignedFormElementViewControllerDelegate {

		[Export ("signedFormElementViewController:removedSignatureFromDocument:")]
		void RemovedSignatureFromDocument (PSPDFSignedFormElementViewController controller, PSPDFDocument document);
	}

	[BaseType (typeof (NSObject))]
	interface PSPDFSpeechController {

		[Export ("speakText:options:delegate:")]
		void SpeakText (string speechString, [NullAllowed] NSDictionary options, [NullAllowed] IAVSpeechSynthesizerDelegate @delegate);

		[Wrap ("SpeakText (speechString, speechOptions?.Dictionary, @delegate)")]
		void SpeakText (string speechString, PSPDFSpeechSynthesizerOptions speechOptions, IAVSpeechSynthesizerDelegate @delegate);

		[Export ("stopSpeakingForDelegate:")]
		bool StopSpeaking ([NullAllowed] IAVSpeechSynthesizerDelegate @delegate);

		[Export ("speechSynthesizer")]
		AVSpeechSynthesizer SpeechSynthesizer { get; }

		[Export ("selectedLanguage")]
		string SelectedLanguage { get; set; }

		[Export ("languageCodes", ArgumentSemantic.Copy)]
		string [] LanguageCodes { get; }

		[Export ("speakRate")]
		float SpeakRate { get; set; }

		[Export ("pitchMultiplier")]
		float PitchMultiplier { get; set; }
	}

	[Static]
	interface PSPDFSpeechSynthesizerOptionKeys {

		[Field ("PSPDFSpeechSynthesizerAutoDetectLanguage", PSPDFKitGlobal.LibraryPath)]
		NSString AutoDetectLanguageKey { get; }

		[Field ("PSPDFSpeechSynthesizerLanguageKey", PSPDFKitGlobal.LibraryPath)]
		NSString LanguageKey { get; }

		[Field ("PSPDFSpeechSynthesizerLanguageHintKey", PSPDFKitGlobal.LibraryPath)]
		NSString LanguageHintKey { get; }
	}

	[StrongDictionary ("PSPDFSpeechSynthesizerOptionKeys")]
	interface PSPDFSpeechSynthesizerOptions {
		bool AutoDetectLanguage { get; }
		string Language { get; }
		string LanguageHint { get; }
	}

	[BaseType (typeof (PSPDFTableViewCell))]
	interface PSPDFSpinnerCell {

		// PSPDFSpinnerCell (SubclassingHooks) Category

		[Export ("spinner")]
		UIActivityIndicatorView Spinner { get; }

		[Export ("alignTextLabel")]
		void AlignTextLabel ();

	}

	[BaseType (typeof (UIView))]
	interface PSPDFSpreadView {

		[NullAllowed, Export ("layout")]
		PSPDFDocumentViewLayout Layout { get; }

		[Export ("spreadIndex")]
		nint SpreadIndex { get; }

		[Export ("pageViews", ArgumentSemantic.Copy)]
		PSPDFPageView [] PageViews { get; }

		[Export ("pageViewForPageAtIndex:")]
		[return: NullAllowed]
		PSPDFPageView GetPageViewForPage (nuint pageIndex);
	}

	[BaseType (typeof (PSPDFDocumentViewLayout))]
	interface PSPDFStackViewLayout {

		[Export ("contentInsets")]
		UIEdgeInsets ContentInsets { get; }

		[Export ("additionalContentInsets", ArgumentSemantic.Assign)]
		UIEdgeInsets AdditionalContentInsets { get; set; }

		[Export ("interitemSpacing")]
		nfloat InteritemSpacing { get; set; }

		[Export ("direction", ArgumentSemantic.Assign)]
		PSPDFStackViewLayoutDirection Direction { get; set; }

		// PSPDFStackViewLayout (Subclassing) Category

		[Export ("sizeForSpreadAtIndex:")]
		CGSize GetSizeForSpread (nint spreadIndex);
	}

	[BaseType (typeof (PSPDFAnnotationGridViewController))]
	interface PSPDFStampViewController : PSPDFAnnotationGridViewControllerDataSource, PSPDFTextStampViewControllerDelegate {

		[Static]
		[Export ("defaultStampAnnotations")]
		PSPDFStampAnnotation [] DefaultStampAnnotations { get; set; }

		[Export ("stamps", ArgumentSemantic.Copy)]
		PSPDFStampAnnotation [] Stamps { get; set; }

		[Export ("customStampEnabled")]
		bool CustomStampEnabled { get; set; }

		[Export ("dateStampsEnabled")]
		bool DateStampsEnabled { get; set; }

		// PSPDFStackViewLayout (Subclassing) Category

		[Export ("defaultDateStamps")]
		PSPDFStampAnnotation [] DefaultDateStamps { get; }
	}

	[BaseType (typeof (PSPDFBaseTableViewController))]
	interface PSPDFStatefulTableViewController : PSPDFStatefulViewControlling {

		// All of the following come from PSPDFStatefulViewControlling interface

		//[NullAllowed, Export ("emptyView", ArgumentSemantic.Strong)]
		//UIView EmptyView { get; set; }

		//[NullAllowed, Export ("loadingView", ArgumentSemantic.Strong)]
		//UIView LoadingView { get; set; }

		//[Export ("controllerState", ArgumentSemantic.Assign)]
		//PSPDFStatefulViewState ControllerState { get; set; }

		//[Export ("setControllerState:animated:")]
		//void SetControllerState (PSPDFStatefulViewState controllerState, bool animated);

		[Export ("preferredContentSize"), New]
		new CGSize PreferredContentSize { get; }
	}

	interface IPSPDFStatefulViewControlling { }

	[Protocol]
	interface PSPDFStatefulViewControlling : IUIContentContainer {

		[Abstract]
		[NullAllowed, Export ("emptyView", ArgumentSemantic.Strong)]
		UIView EmptyView { get; set; }

		[Abstract]
		[NullAllowed, Export ("loadingView", ArgumentSemantic.Strong)]
		UIView LoadingView { get; set; }

		[Abstract]
		[Export ("controllerState", ArgumentSemantic.Assign)]
		PSPDFStatefulViewState ControllerState { get; set; }

		[Export ("setControllerState:animated:")]
		void SetControllerState (PSPDFStatefulViewState controllerState, bool animated);
	}

	[BaseType (typeof (PSPDFBaseTableViewController))]
	interface PSPDFStaticTableViewController {

	}

	[BaseType (typeof (NSObject))]
	interface PSPDFStatusHUDItem {

		[NullAllowed, Export ("title")]
		string Title { get; set; }

		[NullAllowed, Export ("subtitle")]
		string Subtitle { get; set; }

		[NullAllowed, Export ("text")]
		string Text { get; set; }

		[Export ("progress")]
		nfloat Progress { get; set; }

		[NullAllowed, Export ("view", ArgumentSemantic.Strong)]
		UIView View { get; set; }

		[Static]
		[Export ("progressWithText:")]
		PSPDFStatusHUDItem CreateProgress ([NullAllowed] string text);

		[Static]
		[Export ("indeterminateProgressWithText:")]
		PSPDFStatusHUDItem CreateIndeterminateProgress ([NullAllowed] string text);

		[Static]
		[Export ("successWithText:")]
		PSPDFStatusHUDItem CreateSuccess ([NullAllowed] string text);

		[Static]
		[Export ("errorWithText:")]
		PSPDFStatusHUDItem CreateError ([NullAllowed] string text);

		[Static]
		[Export ("itemWithText:image:")]
		PSPDFStatusHUDItem CreateItem ([NullAllowed] string text, [NullAllowed] UIImage image);

		[Export ("setHUDStyle:")]
		void SetHudStyle (PSPDFStatusHUDStyle style);

		[Async]
		[Export ("pushAnimated:completion:")]
		void Push (bool animated, [NullAllowed] Action completion);

		[Async]
		[Export ("pushAndPopWithDelay:animated:completion:")]
		void PushAndPop (double delayInterval, bool animated, [NullAllowed] Action completion);

		[Async]
		[Export ("popAnimated:completion:")]
		void Pop (bool animated, [NullAllowed] Action completion);
	}

	[BaseType (typeof (NSObject))]
	interface PSPDFStatusHUD {

		[Static]
		[Export ("items")]
		PSPDFStatusHUDItem [] GetItems ();

		[Static]
		[Async]
		[Export ("popAllItemsAnimated:completion:")]
		void PopAllItems (bool animated, [NullAllowed] Action completion);
	}

	[BaseType (typeof (UIView))]
	interface PSPDFStatusHUDView {

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		[NullAllowed, Export ("item", ArgumentSemantic.Strong)]
		PSPDFStatusHUDItem Item { get; set; }
	}

	interface IPSPDFStyleable { }

	[Protocol]
	interface PSPDFStyleable {

		[Export ("barStyle")]
		UIBarStyle GetBarStyle ();

		[Export ("setBarStyle:")]
		void SetBarStyle (UIBarStyle style);

		[Export ("isBarTranslucent")]
		bool GetIsBarTranslucent ();

		[Export ("setIsBarTranslucent:")]
		void SetIsBarTranslucent (bool isBarTranslucent);

		[Export ("forcesStatusBarHidden")]
		bool GetForcesStatusBarHidden ();

		[Export ("setForcesStatusBarHidden:")]
		void SetForcesStatusBarHidden (bool val);
	}

	interface IPSPDFStylusDriver { }

	[Protocol]
	interface PSPDFStylusDriver {

		[Static, Abstract]
		[Export ("driverInfo")]
		NSDictionary DriverInfo { get; }

		// Hack: must be manually inlined on any class implementing this protocol
		//[Abstract]
		//[Export ("initWithDelegate:")]
		//IntPtr Constructor (IPSPDFStylusDriverDelegate @delegate);

		[Abstract]
		[Export ("enableDriverWithOptions:error:")]
		bool EnableDriver ([NullAllowed] NSDictionary options, [NullAllowed] out NSError error);

		[Abstract]
		[Export ("disableDriver")]
		void DisableDriver ();

		[Abstract]
		[Export ("connectedStylusInfo")]
		NSDictionary ConnectedStylusInfo { get; }

		[Abstract]
		[Export ("connectionStatus")]
		PSPDFStylusConnectionStatus ConnectionStatus { get; }

		[Abstract]
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFStylusDriverDelegate Delegate { get; }

		[Export ("touchInfoForTouch:")]
		[return: NullAllowed]
		IPSPDFStylusTouch GetTouchInfo (UITouch touch);

		[NullAllowed, Export ("settingsController")]
		UIViewController GetSettingsController ();

		[NullAllowed, Export ("settingsControllerInfo")]
		NSDictionary GetSettingsControllerInfo ();

		[Export ("registerView:")]
		void RegisterView (UIView view);

		[Export ("unregisterView:")]
		void UnregisterView (UIView view);
	}

	[Static]
	interface PSPDFStylusDriverInfoKeys {

		[Field ("PSPDFStylusDriverIdentifierKey", PSPDFKitGlobal.LibraryPath)]
		NSString IdentifierKey { get; }

		[Field ("PSPDFStylusDriverNameKey", PSPDFKitGlobal.LibraryPath)]
		NSString NameKey { get; }

		[Field ("PSPDFStylusDriverSDKNameKey", PSPDFKitGlobal.LibraryPath)]
		NSString SDKNameKey { get; }

		[Field ("PSPDFStylusDriverSDKVersionKey", PSPDFKitGlobal.LibraryPath)]
		NSString SDKVersionKey { get; }

		[Field ("PSPDFStylusDriverProtocolVersionKey", PSPDFKitGlobal.LibraryPath)]
		NSString ProtocolVersionKey { get; }

		[Field ("PSPDFStylusDriverPriorityKey", PSPDFKitGlobal.LibraryPath)]
		NSString PriorityKey { get; }
	}

	[Static]
	interface PSPDFConnectedStylusInfoKeys {

		[Field ("PSPDFStylusNameKey", PSPDFKitGlobal.LibraryPath)]
		NSString StylusNameKey { get; }
	}

	[Static]
	interface PSPDFStylusSettingsControllerInfoKeys {

		[Field ("PSPDFStylusSettingsEmbeddedSizeKey", PSPDFKitGlobal.LibraryPath)]
		NSString EmbeddedSizeKey { get; }
	}

	interface IPSPDFStylusDriverDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFStylusDriverDelegate {

		[Abstract]
		[Export ("connectionStatusChanged")]
		void ConnectionStatusChanged ();

		[Export ("buttonFired:")]
		bool ButtonFired (nuint buttonNumber);

		[Export ("classificationsDidChangeForTouches:")]
		void ClassificationsDidChangeForTouches (NSSet touches);

		[Export ("stylusTouchBegan:")]
		void StylusTouchBegan (NSSet touches);

		[Export ("stylusTouchMoved:")]
		void StylusTouchMoved (NSSet touches);

		[Export ("stylusTouchEnded:")]
		void StylusTouchEnded (NSSet touches);

		[Export ("stylusTouchCancelled:")]
		void StylusTouchCancelled (NSSet touches);

		[Export ("stylusSuggestsToDisableGestures")]
		void StylusSuggestsToDisableGestures ();

		[Export ("stylusSuggestsToEnableGestures")]
		void StylusSuggestsToEnableGestures ();
	}

	[BaseType (typeof (NSObject))]
	interface PSPDFStylusManager {

		[Field ("PSPDFStylusManagerConnectionStatusChangedNotification", PSPDFKitGlobal.LibraryPath)]
		[Notification]
		NSString ConnectionStatusChangedNotification { get; }

		[Export ("automaticallyEnablesApplePencil")]
		bool AutomaticallyEnablesApplePencil { get; set; }

		[Export ("applePencilEnabled")]
		bool ApplePencilEnabled { [Bind ("isApplePencilEnabled")] get; set; }

		[NullAllowed, Export ("currentDriverClass", ArgumentSemantic.Strong)]
		Class CurrentDriverClass { get; set; }

		[Export ("connectionStatus")]
		PSPDFStylusConnectionStatus ConnectionStatus { get; }

		[NullAllowed, Export ("stylusName")]
		string StylusName { get; }

		[Export ("availableDriverClasses", ArgumentSemantic.Copy)]
		NSOrderedSet AvailableDriverClasses { get; set; }

		[Export ("enableLastDriver")]
		bool EnableLastDriver ();

		[Export ("stylusController")]
		PSPDFStylusViewController StylusController { get; }

		[NullAllowed, Export ("settingsControllerForCurrentDriver")]
		UIViewController SettingsControllerForCurrentDriver { get; }

		[Export ("embeddedSizeForSettingsController")]
		CGSize EmbeddedSizeForSettingsController { get; }

		[Export ("buttonActionMapping", ArgumentSemantic.Strong)]
		NSDictionary<NSNumber, NSString> ButtonActionMapping { get; set; }

		[Export ("hasSettingsControllerForDriverClass:")]
		bool HasSettingsController ([NullAllowed] Class driver);

		[Export ("registerView:")]
		void RegisterView (UIView view);

		[Export ("unregisterView:")]
		void UnregisterView (UIView view);

		[Export ("driverAllowsClassification")]
		bool DriverAllowsClassification { get; }

		[Export ("touchInfoForTouch:")]
		[return: NullAllowed]
		IPSPDFStylusTouch GetTouchInfo (UITouch touch);

		[Export ("showsStatusHUDForConnectionStatusChanges")]
		bool ShowsStatusHusForConnectionStatusChanges { get; set; }

		[Export ("addDelegate:")]
		void AddDelegate (IPSPDFStylusDriverDelegate @delegate);

		[Export ("removeDelegate:")]
		bool RemoveDelegate (IPSPDFStylusDriverDelegate @delegate);
	}

	interface IPSPDFStylusTouch { }

	[Protocol]
	interface PSPDFStylusTouch {

		[Export ("locationInView:")]
		CGPoint GetLocationInView (UIView view);

		[Export ("classification")]
		PSPDFStylusTouchClassification GetClassification ();

		[Export ("pressure")]
		nfloat GetPressure ();
	}

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface PSPDFDefaultStylusTouch : PSPDFStylusTouch {

		[Export ("initWithClassification:pressure:")]
		[DesignatedInitializer]
		IntPtr Constructor (PSPDFStylusTouchClassification classification, nfloat pressure);

		// They come from PSPDFStylusTouch protocol
		//[Export ("classification")]
		//PSPDFStylusTouchClassification Classification { get; }

		//[Export ("pressure")]
		//nfloat Pressure { get; }
	}

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface PSPDFStylusTouchClassificationInfo {

		[Export ("initWithTouch:touchID:oldValue:newValue:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] UITouch touch, nint touchId, PSPDFStylusTouchClassification oldValue, PSPDFStylusTouchClassification newValue);

		[NullAllowed, Export ("touch", ArgumentSemantic.Weak)]
		UITouch Touch { get; }

		[Export ("touchID")]
		nint TouchId { get; }

		[Export ("oldValue")]
		PSPDFStylusTouchClassification OldValue { get; }

		[Export ("newValue")]
		PSPDFStylusTouchClassification NewValue { get; }
	}

	interface IPSPDFStylusViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFStylusViewControllerDelegate {

		[Abstract]
		[Export ("stylusViewControllerDidUpdateSelectedType:")]
		void DidUpdateSelectedType (PSPDFStylusViewController stylusViewController);

		[Abstract]
		[Export ("stylusViewControllerDidTapSettingsButton:")]
		void DidTapSettingsButton (PSPDFStylusViewController stylusViewController);
	}

	[BaseType (typeof (PSPDFStaticTableViewController))]
	[DisableDefaultCtor]
	interface PSPDFStylusViewController {

		[Export ("initWithStylusManager:")]
		[DesignatedInitializer]
		IntPtr Constructor (PSPDFStylusManager stylusManager);

		[NullAllowed, Export ("selectedDriverClass", ArgumentSemantic.Strong)]
		Class SelectedDriverClass { get; set; }

		[Export ("stylusManager")]
		PSPDFStylusManager StylusManager { get; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFStylusViewControllerDelegate Delegate { get; set; }
	}

	[BaseType (typeof (UIView))]
	interface PSPDFTabbedBar {

		[Export ("barHeight")]
		nfloat BarHeight { get; set; }

		[Export ("tabbedBarStyle", ArgumentSemantic.Assign)]
		PSPDFTabbedBarStyle TabbedBarStyle { get; set; }

		[Export ("minTabWidth")]
		nfloat MinTabWidth { get; set; }

		[Export ("tabTitleFont", ArgumentSemantic.Strong)]
		UIFont TabTitleFont { get; set; }

		[Export ("closeButtonImage", ArgumentSemantic.Strong)]
		UIImage CloseButtonImage { get; set; }

		[Export ("backgroundView", ArgumentSemantic.Strong)]
		UIView BackgroundView { get; set; }

		[Export ("documentPickerButton")]
		UIButton DocumentPickerButton { get; }

		[Export ("overviewButton")]
		UIButton OverviewButton { get; }

		[Export ("overviewThreshold")]
		nint OverviewThreshold { get; set; }

		[Export ("leftViews", ArgumentSemantic.Copy)]
		UIView [] LeftViews { get; set; }

		[Export ("rightViews", ArgumentSemantic.Copy)]
		UIView [] RightViews { get; set; }

		[NullAllowed, Export ("interactiveReorderingGestureRecognizer")]
		UILongPressGestureRecognizer InteractiveReorderingGestureRecognizer { get; }
	}

	interface IPSPDFTabbedViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFTabbedViewControllerDelegate : PSPDFMultiDocumentViewControllerDelegate {

		[Export ("tabbedPDFController:shouldChangeVisibleDocument:")]
		bool ShouldChangeVisibleDocument (PSPDFTabbedViewController tabbedPdfController, [NullAllowed] PSPDFDocument newVisibleDocument);

		[Export ("tabbedPDFController:didChangeVisibleDocument:")]
		void DidChangeVisibleDocument (PSPDFTabbedViewController tabbedPdfController, [NullAllowed] PSPDFDocument oldVisibleDocument);

		[Export ("tabbedPDFController:shouldCloseDocument:")]
		bool ShouldCloseDocument (PSPDFTabbedViewController tabbedPdfController, PSPDFDocument document);

		[Export ("tabbedPDFController:didCloseDocument:")]
		void DidCloseDocument (PSPDFTabbedViewController tabbedPdfController, PSPDFDocument document);
	}

	[BaseType (typeof (PSPDFMultiDocumentViewController))]
	interface PSPDFTabbedViewController {

		[Export ("addDocument:makeVisible:animated:")]
		void AddDocument (PSPDFDocument document, bool shouldMakeDocumentVisible, bool animated);

		[Export ("insertDocumentAfterVisibleDocument:makeVisible:animated:")]
		void InsertDocumentAfterVisibleDocument (PSPDFDocument document, bool shouldMakeDocumentVisible, bool animated);

		[Export ("insertDocument:atIndex:makeVisible:animated:")]
		void InsertDocument (PSPDFDocument document, nuint idx, bool shouldMakeDocumentVisible, bool animated);

		[Export ("removeDocumentAtIndex:animated:")]
		void RemoveDocument (nuint idx, bool animated);

		[Export ("removeDocument:animated:")]
		bool RemoveDocument (PSPDFDocument document, bool animated);

		[Export ("setVisibleDocument:scrollToPosition:animated:")]
		void SetVisibleDocument ([NullAllowed] PSPDFDocument visibleDocument, bool scrollToPosition, bool animated);

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak), New]
		IPSPDFTabbedViewControllerDelegate Delegate { get; set; }

		[Export ("statePersistenceKey"), New]
		string StatePersistenceKey { get; set; }

		[Export ("tabbedBar")]
		PSPDFTabbedBar TabbedBar { get; }

		[NullAllowed, Export ("documentPickerController", ArgumentSemantic.Strong)]
		PSPDFDocumentPickerController DocumentPickerController { get; set; }

		[Export ("barHidingMode", ArgumentSemantic.Assign)]
		PSPDFTabbedViewControllerBarHidingMode BarHidingMode { get; set; }

		[Export ("closeMode", ArgumentSemantic.Assign)]
		PSPDFTabbedViewControllerCloseMode CloseMode { get; set; }

		[Export ("openDocumentActionInNewTab")]
		bool OpenDocumentActionInNewTab { get; set; }

		[Export ("updateTabbedBarFrameAnimated:")]
		void UpdateTabbedBarFrame (bool animated);
	}

	[BaseType (typeof (UITableViewCell))]
	interface PSPDFTableViewCell {

	}

	[BaseType (typeof (PSPDFTableViewCell))]
	interface PSPDFNonAnimatingTableViewCell {

	}

	[BaseType (typeof (PSPDFTableViewCell))]
	interface PSPDFNeverAnimatingTableViewCell {

	}

	[BaseType (typeof (PSPDFFormElementView))]
	interface PSPDFTextFieldFormElementView : IUITextViewDelegate, IUITextFieldDelegate {

		[Export ("beginEditing")]
		void BeginEditing ();

		[Export ("endEditing")]
		void EndEditing ();

		[NullAllowed, Export ("textView")]
		UITextView TextView { get; }

		[NullAllowed, Export ("textField")]
		UITextField TextField { get; }

		[Export ("isMultiline")]
		bool IsMultiline { get; }

		[Export ("isPassword")]
		bool IsPassword { get; }

		[Export ("editMode")]
		bool EditMode { get; set; }

		[NullAllowed, Export ("resizableView", ArgumentSemantic.Weak)]
		PSPDFResizableView ResizableView { get; set; }

		// PSPDFTextFieldFormElementView (SubclassingHooks) Category

		[Export ("setTextViewForEditing")]
		UITextView SetTextViewForEditing { get; }
	}

	interface IPSPDFTextSelectionViewDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFTextSelectionViewDelegate {

		[Abstract]
		[Export ("textSelectionView:updateMenuAnimated:")]
		bool UpdateMenuAnimated (PSPDFTextSelectionView textSelectionView, bool animated);

		[Export ("textSelectionView:shouldSelectText:withGlyphs:atRect:")]
		bool ShouldSelectText (PSPDFTextSelectionView textSelectionView, string text, PSPDFGlyph [] glyphs, CGRect rect);

		[Export ("textSelectionView:didSelectText:withGlyphs:atRect:")]
		void DidSelectText (PSPDFTextSelectionView textSelectionView, string text, PSPDFGlyph [] glyphs, CGRect rect);
	}

	[BaseType (typeof (UIView))]
	interface PSPDFTextSelectionView : IAVSpeechSynthesizerDelegate {

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFTextSelectionViewDelegate Delegate { get; set; }

		[Export ("selectedGlyphs", ArgumentSemantic.Copy)]
		PSPDFGlyph [] SelectedGlyphs { get; set; }

		[NullAllowed, Export ("selectedText")]
		string SelectedText { get; }

		[NullAllowed, Export ("selectedImage", ArgumentSemantic.Strong)]
		PSPDFImageInfo SelectedImage { get; set; }

		[Export ("selectionAlpha")]
		nfloat SelectionAlpha { get; set; }

		[NullAllowed, Export ("trimmedSelectedText")]
		string TrimmedSelectedText { get; }

		[Export ("selectionHitTestExtension")]
		nfloat SelectionHitTestExtension { get; set; }

		[Export ("selectionRects")]
		NSValue [] SelectionRects { get; }

		[Export ("rectForFirstBlock")]
		CGRect RectForFirstBlock { get; }

		[Export ("rectForLastBlock")]
		CGRect RectForLastBlock { get; }

		[Export ("updateMenuAnimated:")]
		bool UpdateMenu (bool animated);

		[Export ("updateSelectionAnimated:")]
		void UpdateSelection (bool animated);

		[Export ("discardSelectionAnimated:")]
		void DiscardSelection (bool animated);

		[Export ("clearCache")]
		void ClearCache ();

		[Export ("hasSelection")]
		bool HasSelection { get; }

		// PSPDFTextSelectionView (Advanced) Category

		[Export ("sortedGlyphs:")]
		PSPDFGlyph [] SortedGlyphs (PSPDFGlyph [] glyphs);

		// PSPDFTextSelectionView (Debugging) Category

		[Export ("showTextFlowData:animated:")]
		void ShowTextFlowData (bool show, bool animated);
	}

	interface IPSPDFTextStampViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFTextStampViewControllerDelegate : IPSPDFOverridable {

		[Export ("textStampViewController:didCreateAnnotation:")]
		void DidCreateAnnotation (PSPDFTextStampViewController stampController, PSPDFStampAnnotation stampAnnotation);
	}

	[BaseType (typeof (PSPDFStaticTableViewController))]
	interface PSPDFTextStampViewController {

		[Export ("initWithStampAnnotation:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] PSPDFStampAnnotation stampAnnotation);

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFTextStampViewControllerDelegate Delegate { get; set; }

		[Export ("stampAnnotation")]
		PSPDFStampAnnotation StampAnnotation { get; }

		[NullAllowed, Export ("defaultStampText")]
		string DefaultStampText { get; set; }
	}

	interface IPSPDFThumbnailBarDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFThumbnailBarDelegate {

		[Export ("thumbnailBar:didSelectPageAtIndex:")]
		void DidSelectPage (PSPDFThumbnailBar thumbnailBar, nuint pageIndex);
	}

	[BaseType (typeof (UICollectionView))]
	interface PSPDFThumbnailBar : IUICollectionViewDataSource, IUICollectionViewDelegate {

		[NullAllowed, Export ("thumbnailBarDelegate", ArgumentSemantic.Weak)]
		IPSPDFThumbnailBarDelegate ThumbnailBarDelegate { get; set; }

		[NullAllowed, Export ("thumbnailBarDataSource", ArgumentSemantic.Weak)]
		IPSPDFPresentationContext ThumbnailBarDataSource { get; set; }

		[Export ("scrollToPageAtIndex:animated:")]
		void ScrollToPage (nuint pageIndex, bool animated);

		[Export ("stopScrolling")]
		void StopScrolling ();

		[Export ("reloadDataAndKeepSelection")]
		void ReloadDataAndKeepSelection ();

		[Export ("thumbnailSize", ArgumentSemantic.Assign)]
		CGSize ThumbnailSize { get; set; }

		[Export ("thumbnailBarHeight")]
		nfloat ThumbnailBarHeight { get; set; }

		[Export ("showPageLabels")]
		bool ShowPageLabels { get; set; }
	}

	[BaseType (typeof (UICollectionViewLayoutAttributes))]
	interface PSPDFThumbnailFlowLayoutAttributes {

		[Export ("pageMode", ArgumentSemantic.Assign)]
		PSPDFDocumentViewLayoutPageMode PageMode { get; set; }
	}

	[BaseType (typeof (UICollectionViewLayout))]
	interface PSPDFThumbnailFlowLayout {

		[Export ("sectionInset", ArgumentSemantic.Assign)]
		UIEdgeInsets SectionInset { get; set; }

		[Export ("interitemSpacing")]
		nfloat InteritemSpacing { get; set; }

		[Export ("lineSpacing")]
		nfloat LineSpacing { get; set; }

		[Export ("singleLineMode")]
		bool SingleLineMode { get; set; }

		[Export ("incompleteLineAlignment", ArgumentSemantic.Assign)]
		PSPDFThumbnailFlowLayoutLineAlignment IncompleteLineAlignment { get; set; }

		[Export ("stickyHeaderEnabled")]
		bool StickyHeaderEnabled { get; set; }
	}

	interface IPSPDFCollectionViewDelegateThumbnailFlowLayout { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFCollectionViewDelegateThumbnailFlowLayout {

		[Export ("collectionView:layout:itemSizeAtIndexPath:")]
		CGSize GetItemSizeAtIndexPath (UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath);

		[Export ("collectionView:layout:itemSizeAtIndexPath:completionHandler:")]
		CGSize GetItemSizeAtIndexPath (UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath, Action<CGSize> completionHandler);

		[Export ("collectionView:layout:referenceSizeForHeaderInSection:")]
		CGSize GetReferenceSizeForHeaderInSection (UICollectionView collectionView, UICollectionViewLayout layout, nint section);

		[Export ("collectionView:layout:pageModeForItemAtIndexPath:")]
		PSPDFDocumentViewLayoutPageMode GetPageModeForItemAtIndexPath (UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath);
	}

	[BaseType (typeof (PSPDFPageCell))]
	interface PSPDFThumbnailGridViewCell {

		[NullAllowed, Export ("document", ArgumentSemantic.Strong)]
		PSPDFDocument Document { get; set; }

		[NullAllowed, Export ("bookmarkImageColor", ArgumentSemantic.Strong)]
		UIColor BookmarkImageColor { get; set; }

		// PSPDFThumbnailGridViewCell (SubclassingHooks) Category

		[NullAllowed, Export ("bookmarkImageView")]
		UIImageView BookmarkImageView { get; }

		[Export ("updatePageLabel")]
		void UpdatePageLabel ();

		[Export ("updateBookmarkImage")]
		void UpdateBookmarkImage ();
	}

	[BaseType (typeof (PSPDFSegmentedControl))]
	interface PSPDFThumbnailFilterSegmentedControl {

	}

	interface IPSPDFThumbnailViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFThumbnailViewControllerDelegate {

		[Export ("thumbnailViewController:didSelectPageAtIndex:inDocument:")]
		void DidSelectPageAtIndex (PSPDFThumbnailViewController thumbnailViewController, nuint pageIndex, PSPDFDocument document);
	}

	[BaseType (typeof (UICollectionViewController))]
	interface PSPDFThumbnailViewController : IUICollectionViewDataSource, IUICollectionViewDelegate, PSPDFViewModePresenter, PSPDFCollectionViewDelegateThumbnailFlowLayout {

		[NullAllowed, Export ("dataSource", ArgumentSemantic.Weak)]
		IPSPDFPresentationContext DataSource { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFThumbnailViewControllerDelegate Delegate { get; set; }

		[Export ("cellForPageAtIndex:document:")]
		[return: NullAllowed]
		UICollectionViewCell GetCellForPage (nuint pageIndex, [NullAllowed] PSPDFDocument document);

		[Export ("scrollToPageAtIndex:document:animated:")]
		void ScrollToPage (nuint pageIndex, [NullAllowed] PSPDFDocument document, bool animated);

		[Export ("stopScrolling")]
		void StopScrolling ();

		[Export ("updateFilterAndVisibleCellsAnimated:")]
		void UpdateFilterAndVisibleCells (bool animated);

		[Export ("filterOptions", ArgumentSemantic.Copy)]
		string [] FilterOptions { get; set; }

		[Export ("activeFilter")]
		string ActiveFilter { get; set; }

		[Export ("setActiveFilter:animated:")]
		void SetActiveFilter (string activeFilter, bool animated);

		[Export ("cellClass", ArgumentSemantic.Strong)]
		new Class CellClass { get; set; }

		[Static]
		[Export ("automaticThumbnailSizeForPageWithSize:referencePageSize:containerSize:interitemSpacing:")]
		CGSize GetAutomaticThumbnailSizeForPage (CGSize pageSize, CGSize referencePageSize, CGSize containerSize, nfloat interitemSpacing);

		// PSPDFThumbnailViewController (SubclassingHooks) Category

		[Export ("configureCell:forIndexPath:")]
		void ConfigureCell (PSPDFThumbnailGridViewCell cell, NSIndexPath indexPath);

		[Export ("pageForIndexPath:")]
		nuint GetPageForIndexPath (NSIndexPath indexPath);

		[NullAllowed, Export ("filterSegment")]
		PSPDFThumbnailFilterSegmentedControl FilterSegment { get; }

		[Export ("updateFilterSegment")]
		void UpdateFilterSegment ();

		[Export ("pagesForFilter:")]
		[return: NullAllowed]
		NSNumber [] GetPages (string filter);

		[Export ("emptyContentLabelForFilter:")]
		[return: NullAllowed]
		string GetEmptyContentLabel (string filter);

		[Export ("updateEmptyView")]
		void UpdateEmptyView ();

		[Export ("collectionView:viewForSupplementaryElementOfKind:atIndexPath:")]
		[return: NullAllowed]
		UICollectionReusableView GetCollectionView (UICollectionView collectionView, string kind, NSIndexPath indexPath);
	}

	[BaseType (typeof (UIView))]
	interface PSPDFToolbar {

		[Field ("PSPDFToolbarDefaultFixedDimensionLength", PSPDFKitGlobal.LibraryPath)]
		nfloat DefaultFixedDimensionLength { get; }

		[Export ("buttons", ArgumentSemantic.Copy)]
		UIButton [] Buttons { get; set; }

		[Export ("setButtons:animated:")]
		void SetButtons (UIButton [] buttons, bool animated);

		[NullAllowed, Export ("backgroundView", ArgumentSemantic.Strong)]
		UIView BackgroundView { get; set; }

		[Export ("contentView")]
		UIView ContentView { get; }

		[NullAllowed, Export ("barTintColor", ArgumentSemantic.Strong)]
		UIColor BarTintColor { get; set; }

		[Export ("fixedDimension")]
		nfloat FixedDimension { get; set; }

		[Export ("collapsedButtons", ArgumentSemantic.Copy)]
		UIButton [] CollapsedButtons { get; }

		[Export ("collapsedButton")]
		UIButton CollapsedButton { get; }

		// PSPDFToolbar (SubclassingHooks) Category

		[Export ("layoutMainSubviews")]
		void LayoutMainSubviews ();

		[Export ("setCollapsedButtonVisible:")]
		void SetCollapsedButtonVisible (bool visible);

		[Export ("horizontal")]
		bool Horizontal { [Bind ("isHorizontal")] get; }

		[Export ("buttonSpacing")]
		nfloat ButtonSpacing { get; }
	}

	[BaseType (typeof (PSPDFButton))]
	interface PSPDFToolbarButton {

		[NullAllowed, Export ("image", ArgumentSemantic.Strong)]
		UIImage Image { get; set; }

		[NullAllowed, Export ("smallSizeImage", ArgumentSemantic.Strong)]
		UIImage SmallSizeImage { get; set; }

		[Export ("styleForHighlightedState:")]
		void StyleForHighlightedState (bool highlighted);

		[NullAllowed, Export ("userInfo", ArgumentSemantic.Strong)]
		NSObject UserInfo { get; set; }

		[Export ("setEnabled:animated:")]
		void SetEnabled (bool enabled, bool animated);

		[Export ("collapsible")]
		bool Collapsible { [Bind ("isCollapsible")] get; set; }

		[Export ("length")]
		nfloat Length { get; set; }

		[Export ("setLengthToFit")]
		void SetLengthToFit ();

		[Export ("flexible")]
		bool Flexible { [Bind ("isFlexible")] get; set; }

		[NullAllowed, Export ("tintColorDidChangeBlock", ArgumentSemantic.Copy)]
		Action<UIColor> TintColorDidChangeHandler { get; set; }
	}

	[BaseType (typeof (PSPDFToolbarButton))]
	interface PSPDFToolbarSpacerButton {

		[Static]
		[Export ("flexibleSpacerButton")]
		PSPDFToolbarSpacerButton Create ();
	}

	[BaseType (typeof (PSPDFToolbarButton))]
	interface PSPDFToolbarTickerButton {

		[Export ("timeInterval")]
		double TimeInterval { get; set; }

		[Export ("accelerate")]
		bool Accelerate { get; set; }
	}

	[BaseType (typeof (PSPDFToolbarSpacerButton))]
	interface PSPDFToolbarSeparatorButton {

		[Export ("hairlineView")]
		UIView HairlineView { get; }
	}

	[BaseType (typeof (PSPDFToolbarButton))]
	interface PSPDFToolbarSelectableButton {

		[Export ("setSelected:animated:")]
		void SetSelected (bool selected, bool animated);

		[Export ("selectedTintColor", ArgumentSemantic.Strong)]
		UIColor SelectedTintColor { get; set; }

		[Export ("selectedBackgroundColor", ArgumentSemantic.Strong)]
		UIColor SelectedBackgroundColor { get; set; }

		[Export ("selectionPadding")]
		nfloat SelectionPadding { get; set; }

		[Export ("highlightsSelection")]
		bool HighlightsSelection { get; set; }
	}

	[BaseType (typeof (PSPDFToolbarButton))]
	interface PSPDFToolbarGroupButton {

		[Export ("longPressRecognizer")]
		UILongPressGestureRecognizer LongPressRecognizer { get; }

		[Export ("groupIndicatorPosition", ArgumentSemantic.Assign)]
		PSPDFToolbarGroupButtonIndicatorPosition GroupIndicatorPosition { get; set; }
	}

	[BaseType (typeof (PSPDFToolbarButton))]
	interface PSPDFToolbarDualButton {

		[Export ("longPressRecognizer")]
		UILongPressGestureRecognizer LongPressRecognizer { get; }

		[NullAllowed, Export ("primaryImage", ArgumentSemantic.Strong)]
		UIImage PrimaryImage { get; set; }

		[NullAllowed, Export ("secondaryImage", ArgumentSemantic.Strong)]
		UIImage SecondaryImage { get; set; }

		[Export ("primaryEnabled")]
		bool PrimaryEnabled { get; set; }

		[Export ("secondaryEnabled")]
		bool SecondaryEnabled { get; set; }
	}

	[BaseType (typeof (PSPDFToolbarGroupButton))]
	interface PSPDFToolbarCollapsedButton {

		[NullAllowed, Export ("mimickedButton", ArgumentSemantic.Strong)]
		UIButton MimickedButton { get; set; }
	}

	[BaseType (typeof (PSPDFLabelView))]
	interface PSPDFDocumentLabelView {

	}

	[BaseType (typeof (PSPDFRelayTouchesView))]
	interface PSPDFUserInterfaceView : PSPDFThumbnailBarDelegate, PSPDFScrubberBarDelegate, PSPDFPageLabelViewDelegate {

		[Export ("initWithFrame:dataSource:")]
		IntPtr Constructor (CGRect frame, IPSPDFPresentationContext dataSource);

		[NullAllowed, Export ("dataSource", ArgumentSemantic.Weak)]
		IPSPDFPresentationContext DataSource { get; set; }

		[Export ("layoutSubviewsAnimated:")]
		void LayoutSubviews (bool animated);

		[Export ("reloadData")]
		void ReloadData ();

		[Export ("pageLabelInsets", ArgumentSemantic.Assign)]
		UIEdgeInsets PageLabelInsets { get; set; }

		[Export ("documentLabelInsets", ArgumentSemantic.Assign)]
		UIEdgeInsets DocumentLabelInsets { get; set; }

		[Export ("thumbnailBarInsets", ArgumentSemantic.Assign)]
		UIEdgeInsets ThumbnailBarInsets { get; set; }

		[Export ("scrubberBarInsets", ArgumentSemantic.Assign)]
		UIEdgeInsets ScrubberBarInsets { get; set; }

		// PSPDFUserInterfaceView (Subviews) Category

		[Export ("documentLabel")]
		PSPDFDocumentLabelView DocumentLabel { get; }

		[Export ("pageLabel")]
		PSPDFPageLabelView PageLabel { get; }

		[Export ("scrubberBar")]
		PSPDFScrubberBar ScrubberBar { get; }

		[Export ("thumbnailBar")]
		PSPDFThumbnailBar ThumbnailBar { get; }

		[Export ("backButton")]
		PSPDFBackForwardButton BackButton { get; }

		[Export ("forwardButton")]
		PSPDFBackForwardButton ForwardButton { get; }

		// PSPDFUserInterfaceView (SubclassingHooks) Category

		[Export ("updateDocumentLabelFrameAnimated:")]
		void UpdateDocumentLabelFrame (bool animated);

		[Export ("updatePageLabelFrameAnimated:")]
		void UpdatePageLabelFrame (bool animated);

		[Export ("updateThumbnailBarFrameAnimated:")]
		void UpdateThumbnailBarFrame (bool animated);

		[Export ("updateScrubberBarFrameAnimated:")]
		void UpdateScrubberBarFrame (bool animated);
	}

	delegate void PSPDFUsernameHelperCompletionHandler (string userName);

	[BaseType (typeof (NSObject))]
	interface PSPDFUsernameHelper {

		[Field ("PSPDFUsernameHelperWillDismissAlertNotification", PSPDFKitGlobal.LibraryPath)]
		[Notification]
		NSString WillDismissAlertNotification { get; }

		[Static]
		[Export ("defaultAnnotationUsername", ArgumentSemantic.Strong)]
		string DefaultAnnotationUsername { get; set; }

		[Static]
		[Export ("isDefaultAnnotationUserNameSet")]
		bool IsDefaultAnnotationUserNameSet { get; }

		[Static]
		[Async]
		[Export ("askForDefaultAnnotationUsernameIfNeeded:completionBlock:")]
		void AskForDefaultAnnotationUsernameIfNeeded (PSPDFViewController pdfViewController, PSPDFUsernameHelperCompletionHandler completion);

		[Async]
		[Export ("askForDefaultAnnotationUsername:suggestedName:completionBlock:")]
		void AskForDefaultAnnotationUsername (UIViewController viewController, [NullAllowed] string suggestedName, PSPDFUsernameHelperCompletionHandler completion);
	}

	[BaseType (typeof (PSPDFBaseViewController))]
	interface PSPDFViewController : PSPDFPresentationContext, PSPDFControlDelegate, IPSPDFOverridable, IPSPDFTextSearchDelegate, PSPDFInlineSearchManagerDelegate, PSPDFErrorHandler, PSPDFExternalURLHandler, PSPDFOutlineViewControllerDelegate, PSPDFBookmarkViewControllerDelegate, PSPDFWebViewControllerDelegate, PSPDFSearchViewControllerDelegate, PSPDFAnnotationTableViewControllerDelegate, IPSPDFBackForwardActionListDelegate, PSPDFFlexibleToolbarContainerDelegate, IMFMailComposeViewControllerDelegate, IMFMessageComposeViewControllerDelegate, PSPDFEmbeddedFilesViewControllerDelegate {

		[Export ("initWithDocument:configuration:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] PSPDFDocument document, [NullAllowed] PSPDFConfiguration configuration);

		[Export ("initWithDocument:")]
		IntPtr Constructor ([NullAllowed] PSPDFDocument document);

		[NullAllowed, Export ("document", ArgumentSemantic.Strong)]
		new PSPDFDocument Document { get; set; }

		[NullAllowed, Export ("documentViewController")]
		new PSPDFDocumentViewController DocumentViewController { get; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFViewControllerDelegate Delegate { get; set; }

		[NullAllowed, Export ("formSubmissionDelegate", ArgumentSemantic.Weak)]
		IPSPDFFormSubmissionDelegate FormSubmissionDelegate { get; set; }

		[Export ("reloadData")]
		new void ReloadData ();

		[Export ("reloadPageAtIndex:animated:")]
		void ReloadPage (nuint pageIndex, bool animated);

		[Export ("pageIndex")]
		new nuint PageIndex { get; set; }

		[Export ("setPageIndex:animated:")]
		new void SetPageIndex (nuint pageIndex, bool animated);

		[NullAllowed, Export ("viewState")]
		PSPDFViewState ViewState { get; }

		[Export ("applyViewState:animateIfPossible:")]
		void ApplyViewState (PSPDFViewState viewState, bool animateIfPossible);

		[Export ("searchForString:options:sender:animated:")]
		new void SearchForString ([NullAllowed] string searchText, [NullAllowed] NSDictionary options, [NullAllowed] NSObject sender, bool animated);

		[Export ("cancelSearchAnimated:")]
		void CancelSearch (bool animated);

		[Export ("searchActive")]
		bool SearchActive { [Bind ("isSearchActive")] get; }

		[Export ("searchHighlightViewManager")]
		PSPDFSearchHighlightViewManager SearchHighlightViewManager { get; }

		[Export ("inlineSearchManager")]
		PSPDFInlineSearchManager InlineSearchManager { get; }

		[Export ("appearanceModeManager")]
		PSPDFAppearanceModeManager AppearanceModeManager { get; }

		[Export ("brightnessManager")]
		PSPDFBrightnessManager BrightnessManager { get; }

		[Export ("textSearch")]
		PSPDFTextSearch TextSearch { get; }

		[Export ("executePDFAction:targetRect:pageIndex:animated:actionContainer:")]
		new bool ExecutePdfAction ([NullAllowed] PSPDFAction action, CGRect targetRect, nuint pageIndex, bool animated, [NullAllowed] NSObject actionContainer);

		[Export ("backForwardList")]
		PSPDFBackForwardActionList BackForwardList { get; }

		[Export ("userInterfaceView")]
		PSPDFUserInterfaceView UserInterfaceView { get; }

		[Export ("userInterfaceVisible")]
		new bool UserInterfaceVisible { [Bind ("isUserInterfaceVisible")] get; set; }

		[Export ("setUserInterfaceVisible:animated:")]
		bool SetUserInterfaceVisible (bool show, bool animated);

		[Export ("showControlsAnimated:")]
		new bool ShowControls (bool animated);

		[Export ("hideControlsAnimated:")]
		new bool HideControls (bool animated);

		[Export ("hideControlsAndPageElementsAnimated:")]
		new bool HideControlsAndPageElements (bool animated);

		[Export ("toggleControlsAnimated:")]
		new bool ToggleControls (bool animated);

		[Export ("contentView")]
		PSPDFRelayTouchesView ContentView { get; }

		[Export ("navigationBarHidden")]
		bool NavigationBarHidden { [Bind ("isNavigationBarHidden")] get; }

		[Export ("controllerState")]
		PSPDFControllerState ControllerState { get; }

		[NullAllowed, Export ("controllerStateError")]
		NSError ControllerStateError { get; }

		[NullAllowed, Export ("overlayViewController", ArgumentSemantic.Strong)]
		IPSPDFControllerStateHandling OverlayViewController { get; set; }

		[NullAllowed, Export ("pageGrabberController")]
		PSPDFPageGrabberController PageGrabberController { get; }

		[Export ("pageViewForPageAtIndex:")]
		[return: NullAllowed]
		new PSPDFPageView GetPageView (nuint pageIndex);

		[Export ("viewMode", ArgumentSemantic.Assign)]
		new PSPDFViewMode ViewMode { get; set; }

		[Export ("setViewMode:animated:")]
		new void SetViewMode (PSPDFViewMode viewMode, bool animated);

		[Export ("thumbnailController")]
		PSPDFThumbnailViewController ThumbnailController { get; }

		[Export ("documentEditorController")]
		PSPDFDocumentEditorViewController DocumentEditorController { get; }

		[Export ("visiblePageViews")]
		new PSPDFPageView [] VisiblePageViews { get; }

		[Export ("setUpdateSettingsForBoundsChangeBlock:")]
		void SetUpdateSettingsForBoundsChangeHandler (Action<PSPDFViewController> handler);

		// PSPDFViewController (Configuration) Category

		[Export ("configuration", ArgumentSemantic.Copy)]
		new PSPDFConfiguration Configuration { get; }

		[Export ("updateConfigurationWithBuilder:")]
		void UpdateConfiguration (Action<PSPDFConfigurationBuilder> builderHandler);

		[Export ("updateConfigurationWithoutReloadingWithBuilder:")]
		void UpdateConfigurationWithoutReloading (Action<PSPDFConfigurationBuilder> builderHandler);

		// PSPDFViewController (Presentation) Category

		[Async]
		[Export ("presentViewController:options:animated:sender:completion:")]
		new bool PresentViewController (UIViewController controller, [NullAllowed] NSDictionary options, bool animated, [NullAllowed] NSObject sender, [NullAllowed] Action completion);

		[Async]
		[Export ("dismissViewControllerOfClass:animated:completion:")]
		new bool DismissViewController ([NullAllowed] Class controllerClass, bool animated, [NullAllowed] Action completion);

		[Async]
		[Export ("presentPDFViewControllerWithDocument:options:sender:animated:configurationBlock:completion:")]
		void PresentPdfViewController (PSPDFDocument document, [NullAllowed] NSDictionary options, [NullAllowed] NSObject sender, bool animated, [NullAllowed] Action<PSPDFViewController> configurationHandler, [NullAllowed] Action completion);

		[Async]
		[Export ("presentPreviewControllerForURL:title:options:sender:animated:completion:")]
		new void PresentPreviewController (NSUrl fileUrl, [NullAllowed] string title, [NullAllowed] NSDictionary options, [NullAllowed] NSObject sender, bool animated, [NullAllowed] Action completion);

		[Export ("activityViewControllerWithSender:")]
		[return: NullAllowed]
		UIActivityViewController GetActivityViewController (NSObject sender);

		// PSPDFViewController (Annotations) Category

		[Export ("annotationStateManager")]
		new PSPDFAnnotationStateManager AnnotationStateManager { get; }

		// PSPDFViewController (Toolbar) Category

		[Export ("navigationItem"), New]
		PSPDFNavigationItem NavigationItem { get; }

		[Export ("closeButtonItem")]
		UIBarButtonItem CloseButtonItem { get; }

		[Export ("outlineButtonItem")]
		UIBarButtonItem OutlineButtonItem { get; }

		[Export ("searchButtonItem")]
		UIBarButtonItem SearchButtonItem { get; }

		[Export ("thumbnailsButtonItem")]
		UIBarButtonItem ThumbnailsButtonItem { get; }

		[Export ("documentEditorButtonItem")]
		UIBarButtonItem DocumentEditorButtonItem { get; }

		[Export ("printButtonItem")]
		UIBarButtonItem PrintButtonItem { get; }

		[Export ("openInButtonItem")]
		UIBarButtonItem OpenInButtonItem { get; }

		[Export ("emailButtonItem")]
		UIBarButtonItem EmailButtonItem { get; }

		[Export ("messageButtonItem")]
		UIBarButtonItem MessageButtonItem { get; }

		[Export ("annotationButtonItem")]
		UIBarButtonItem AnnotationButtonItem { get; }

		[Export ("bookmarkButtonItem")]
		UIBarButtonItem BookmarkButtonItem { get; }

		[Export ("brightnessButtonItem")]
		UIBarButtonItem BrightnessButtonItem { get; }

		[Export ("activityButtonItem")]
		UIBarButtonItem ActivityButtonItem { get; }

		[Export ("settingsButtonItem")]
		UIBarButtonItem SettingsButtonItem { get; }

		[Export ("barButtonItemsAlwaysEnabled", ArgumentSemantic.Copy)]
		UIBarButtonItem [] BarButtonItemsAlwaysEnabled { get; set; }

		[Export ("documentActionExecutor")]
		new PSPDFDocumentActionExecutor DocumentActionExecutor { get; }

		[Export ("documentInfoCoordinator")]
		PSPDFDocumentInfoCoordinator DocumentInfoCoordinator { get; }

		[NullAllowed, Export ("annotationToolbarController")]
		new PSPDFAnnotationToolbarController AnnotationToolbarController { get; }

		// PSPDFViewController (SubclassingHooks) Category

		[Export ("commonInitWithDocument:configuration:")]
		[Advice ("Requires base call if override.")]
		void CommonInit ([NullAllowed] PSPDFDocument document, PSPDFConfiguration configuration);

		[Export ("documentViewControllerDidLoad")]
		void DocumentViewControllerDidLoad ();

		[Export ("updateToolbarAnimated:")]
		void UpdateToolbar (bool animated);

		[Export ("contentRect")]
		new CGRect ContentRect { get; }

		[Export ("annotationButtonPressed:")]
		void AnnotationButtonPressed ([NullAllowed] NSObject sender);
	}

	interface IPSPDFViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFViewControllerDelegate {

		[Export ("pdfViewController:shouldChangeDocument:")]
		bool ShouldChangeDocument (PSPDFViewController pdfController, [NullAllowed] PSPDFDocument document);

		[Export ("pdfViewController:didChangeDocument:")]
		void DidChangeDocument (PSPDFViewController pdfController, [NullAllowed] PSPDFDocument document);

		[Export ("pdfViewController:willScheduleRenderTaskForPageView:")]
		void WillScheduleRenderTask (PSPDFViewController pdfController, PSPDFPageView pageView);

		[Export ("pdfViewController:didFinishRenderTaskForPageView:")]
		void DidFinishRenderTask (PSPDFViewController pdfController, PSPDFPageView pageView);

		[Export ("pdfViewController:didUpdateContentImageForPageView:isPlaceholder:")]
		void DidUpdateContentImage (PSPDFViewController pdfController, PSPDFPageView pageView, bool placeholder);

		[Export ("pdfViewController:willBeginDisplayingPageView:forPageAtIndex:")]
		void WillBeginDisplayingPageView (PSPDFViewController pdfController, PSPDFPageView pageView, nint pageIndex);

		[Export ("pdfViewController:didEndDisplayingPageView:forPageAtIndex:")]
		void DidEndDisplayingPageView (PSPDFViewController pdfController, PSPDFPageView pageView, nint pageIndex);

		[Export ("pdfViewController:didConfigurePageView:forPageAtIndex:")]
		void DidConfigurePageView (PSPDFViewController pdfController, PSPDFPageView pageView, nint pageIndex);

		[Export ("pdfViewController:didCleanupPageView:forPageAtIndex:")]
		void DidCleanupPageView (PSPDFViewController pdfController, PSPDFPageView pageView, nint pageIndex);

		[Export ("pdfViewController:documentForRelativePath:")]
		[return: NullAllowed]
		PSPDFDocument GetDocumentForRelativePath (PSPDFViewController pdfController, string relativePath);

		[Export ("pdfViewController:didTapOnPageView:atPoint:")]
		bool DidTapOnPageView (PSPDFViewController pdfController, PSPDFPageView pageView, CGPoint viewPoint);

		[Export ("pdfViewController:didLongPressOnPageView:atPoint:gestureRecognizer:")]
		bool DidLongPressOnPageView (PSPDFViewController pdfController, PSPDFPageView pageView, CGPoint viewPoint, UILongPressGestureRecognizer gestureRecognizer);

		[Export ("pdfViewController:shouldSelectText:withGlyphs:atRect:onPageView:")]
		bool ShouldSelectText (PSPDFViewController pdfController, string text, PSPDFGlyph [] glyphs, CGRect rect, PSPDFPageView pageView);

		[Export ("pdfViewController:didSelectText:withGlyphs:atRect:onPageView:")]
		void DidSelectText (PSPDFViewController pdfController, string text, PSPDFGlyph [] glyphs, CGRect rect, PSPDFPageView pageView);

		[Export ("pdfViewController:shouldShowMenuItems:atSuggestedTargetRect:forSelectedText:inRect:onPageView:")]
		PSPDFMenuItem [] ShouldShowMenuItemsForSelectedText (PSPDFViewController pdfController, PSPDFMenuItem [] menuItems, CGRect rect, string selectedText, CGRect textRect, PSPDFPageView pageView);

		[Export ("pdfViewController:shouldShowMenuItems:atSuggestedTargetRect:forSelectedImage:inRect:onPageView:")]
		PSPDFMenuItem [] ShouldShowMenuItemsForSelectedImage (PSPDFViewController pdfController, PSPDFMenuItem [] menuItems, CGRect rect, PSPDFImageInfo selectedImage, CGRect textRect, PSPDFPageView pageView);

		[Export ("pdfViewController:shouldShowMenuItems:atSuggestedTargetRect:forAnnotations:inRect:onPageView:")]
		PSPDFMenuItem [] ShouldShowMenuItemsForAnnotations (PSPDFViewController pdfController, PSPDFMenuItem [] menuItems, CGRect rect, [NullAllowed] PSPDFAnnotation [] annotations, CGRect annotationRect, PSPDFPageView pageView);

		[Export ("pdfViewController:shouldDisplayAnnotation:onPageView:")]
		bool ShouldDisplayAnnotation (PSPDFViewController pdfController, PSPDFAnnotation annotation, PSPDFPageView pageView);

		[Export ("pdfViewController:didTapOnAnnotation:annotationPoint:annotationView:pageView:viewPoint:")]
		bool DidTapOnAnnotation (PSPDFViewController pdfController, PSPDFAnnotation annotation, CGPoint annotationPoint, [NullAllowed] IPSPDFAnnotationPresenting annotationView, PSPDFPageView pageView, CGPoint viewPoint);

		[Export ("pdfViewController:shouldSelectAnnotations:onPageView:")]
		PSPDFAnnotation [] ShouldSelectAnnotations (PSPDFViewController pdfController, PSPDFAnnotation [] annotations, PSPDFPageView pageView);

		[Export ("pdfViewController:didSelectAnnotations:onPageView:")]
		void DidSelectAnnotations (PSPDFViewController pdfController, PSPDFAnnotation [] annotations, PSPDFPageView pageView);

		[Export ("pdfViewController:didDeselectAnnotations:onPageView:")]
		void DidDeselectAnnotations (PSPDFViewController pdfController, PSPDFAnnotation [] annotations, PSPDFPageView pageView);

		[Export ("pdfViewController:annotationView:forAnnotation:onPageView:")]
		[return: NullAllowed]
		IPSPDFAnnotationPresenting GetAnnotationView (PSPDFViewController pdfController, [NullAllowed] IPSPDFAnnotationPresenting annotationView, PSPDFAnnotation annotation, PSPDFPageView pageView);

		[Export ("pdfViewController:willShowAnnotationView:onPageView:")]
		void WillShowAnnotationView (PSPDFViewController pdfController, IPSPDFAnnotationPresenting annotationView, PSPDFPageView pageView);

		[Export ("pdfViewController:didShowAnnotationView:onPageView:")]
		void DidShowAnnotationView (PSPDFViewController pdfController, IPSPDFAnnotationPresenting annotationView, PSPDFPageView pageView);

		[Export ("pdfViewController:shouldShowController:options:animated:")]
		bool ShouldShowController (PSPDFViewController pdfController, UIViewController controller, [NullAllowed] NSDictionary options, bool animated);

		[Export ("pdfViewController:didShowController:options:animated:")]
		void DidShowController (PSPDFViewController pdfController, UIViewController controller, [NullAllowed] NSDictionary options, bool animated);

		[Export ("pdfViewController:didChangeViewMode:")]
		void DidChangeViewMode (PSPDFViewController pdfController, PSPDFViewMode viewMode);

		[Export ("pdfViewControllerWillDismiss:")]
		void PdfViewControllerWillDismiss (PSPDFViewController pdfController);

		[Export ("pdfViewControllerDidDismiss:")]
		void PdfViewControllerDidDismiss (PSPDFViewController pdfController);

		[Export ("pdfViewControllerDidChangeControllerState:")]
		void PdfViewControllerDidChangeControllerState (PSPDFViewController pdfController);

		[Export ("pdfViewController:shouldShowUserInterface:")]
		bool ShouldShowUserInterface (PSPDFViewController pdfController, bool animated);

		[Export ("pdfViewController:didShowUserInterface:")]
		void DidShowUserInterface (PSPDFViewController pdfController, bool animated);

		[Export ("pdfViewController:shouldHideUserInterface:")]
		bool ShouldHideUserInterface (PSPDFViewController pdfController, bool animated);

		[Export ("pdfViewController:didHideUserInterface:")]
		void DidHideUserInterface (PSPDFViewController pdfController, bool animated);

		[Export ("pdfViewController:shouldExecuteAction:")]
		bool ShouldExecuteAction (PSPDFViewController pdfController, PSPDFAction action);

		[Export ("pdfViewController:didExecuteAction:")]
		void DidExecuteAction (PSPDFViewController pdfController, PSPDFAction action);
	}

	interface IPSPDFViewModePresenter { }

	[Protocol]
	interface PSPDFViewModePresenter {

		[Abstract]
		[Export ("initWithCollectionViewLayout:")]
		IntPtr Constructor ([NullAllowed] UICollectionViewLayout layout);

		[Abstract]
		[Export ("initWithDocument:")]
		IntPtr Constructor ([NullAllowed] PSPDFDocument document);

		[Abstract]
		[NullAllowed, Export ("document", ArgumentSemantic.Strong)]
		PSPDFDocument Document { get; set; }

		[Abstract]
		[NullAllowed, Export ("presentationContext", ArgumentSemantic.Weak)]
		IPSPDFPresentationContext PresentationContext { get; set; }

		[Abstract]
		[Export ("cellClass", ArgumentSemantic.Strong)]
		Class CellClass { get; set; }

		[Abstract]
		[Export ("fixedItemSizeEnabled")]
		bool FixedItemSizeEnabled { get; set; }

		[Abstract]
		[Export ("updateInsetsForTopOverlapHeight:")]
		void UpdateInsetsForTopOverlapHeight (nfloat overlapHeight);
	}

	[BaseType (typeof (PSPDFModel))]
	interface PSPDFViewState : INSSecureCoding {

		[Export ("initWithPageIndex:viewPort:selectionState:")]
		[DesignatedInitializer]
		IntPtr Constructor (nuint pageIndex, CGRect viewPort, [NullAllowed] PSPDFSelectionState selectionState);

		[Export ("initWithPageIndex:selectionState:")]
		IntPtr Constructor (nuint pageIndex, [NullAllowed] PSPDFSelectionState selectionState);

		[Export ("initWithPageIndex:viewPort:")]
		IntPtr Constructor (nuint pageIndex, CGRect viewPort);

		[Export ("initWithPageIndex:")]
		IntPtr Constructor (nuint pageIndex);

		[Export ("pageIndex")]
		nuint PageIndex { get; }

		[Export ("viewPort")]
		CGRect ViewPort { get; }

		[Export ("hasViewPort")]
		bool HasViewPort { get; }

		[NullAllowed, Export ("selectionState")]
		PSPDFSelectionState SelectionState { get; }

		[Export ("isEqualToViewState:withAccuracy:")]
		bool IsEqualTo ([NullAllowed] PSPDFViewState other, nfloat leeway);
	}

	interface IPSPDFVisiblePagesDataSource { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFVisiblePagesDataSource {

		[Abstract]
		[Export ("pageIndex")]
		nuint PageIndex { get; }

		[Abstract]
		[Export ("visiblePageIndexes")]
		NSIndexSet VisiblePageIndexes { get; }
	}

	interface IPSPDFWebViewControllerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PSPDFWebViewControllerDelegate : PSPDFExternalURLHandler {

		[Export ("webViewControllerDidStartLoad:")]
		void DidStartLoad (PSPDFWebViewController controller);

		[Export ("webViewControllerDidFinishLoad:")]
		void DidFinishLoad (PSPDFWebViewController controller);

		[Export ("webViewController:didFailLoadWithError:")]
		void DidFailLoad (PSPDFWebViewController controller, NSError error);
	}

	[BaseType (typeof (PSPDFBaseViewController))]
	interface PSPDFWebViewController : PSPDFStyleable, IUIWebViewDelegate {

		[Static]
		[Export ("modalWebViewWithURL:")]
		UINavigationController GetModalWebView (NSUrl url);

		[Export ("initWithURLRequest:")]
		IntPtr Constructor (NSUrlRequest request);

		[Export ("initWithURL:")]
		IntPtr Constructor (NSUrl url);

		[Export ("availableActions", ArgumentSemantic.Assign)]
		PSPDFWebViewControllerAvailableActions AvailableActions { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPSPDFWebViewControllerDelegate Delegate { get; set; }

		[Export ("showProgressIndicator")]
		bool ShowProgressIndicator { get; set; }

		[Export ("useCustomErrorPage")]
		bool UseCustomErrorPage { get; set; }

		[Export ("shouldUpdateTitleFromWebContent")]
		bool ShouldUpdateTitleFromWebContent { get; set; }

		[Export ("useModernWebKit")]
		bool UseModernWebKit { get; set; }

		[Export ("excludedActivities", ArgumentSemantic.Copy)]
		NSString [] ExcludedActivities { get; set; }

		[Export ("suppressesIncrementalRendering")]
		bool SuppressesIncrementalRendering { get; set; }

		// PSPDFWebViewController (SubclassingHooks) Category

		[Export ("webView")]
		UIView WebView { get; }

		[Export ("showHTMLWithError:")]
		void ShowHtml (NSError error);

		[NullAllowed, Export ("createDefaultActivityViewController")]
		UIActivityViewController CreateDefaultActivityViewController { get; }

		[Export ("goBack:")]
		void GoBack ([NullAllowed] NSObject sender);

		[Export ("goForward:")]
		void GoForward ([NullAllowed] NSObject sender);

		[Export ("reload:")]
		void Reload ([NullAllowed] NSObject sender);

		[Export ("stop:")]
		void Stop ([NullAllowed] NSObject sender);

		[Export ("action:")]
		void Action ([NullAllowed] UIBarButtonItem sender);

		[Export ("done:")]
		void Done ([NullAllowed] NSObject sender);
	}

	[Category]
	[BaseType (typeof (UISearchController))]
	interface UISearchController_PSPDFKitAdditions {

		[NullAllowed, Export ("pspdf_searchResultsTableView")]
		UITableView GetPsPdfSearchResultsTableView ();

		[Export ("pspdf_installWorkaroundsOn:")]
		void PsPdf_InstallWorkarounds (UIViewController controller);
	}
}