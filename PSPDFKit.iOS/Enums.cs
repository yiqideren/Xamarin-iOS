﻿using System;
using Foundation;
using ObjCRuntime;

namespace PSPDFKit.Core {

	[Native]
	//[ErrorDomain ("PSPDFErrorDomain")] TODO: enable once generator bug is fixed
	public enum PSPDFErrorCode : long {
		OutOfMemory = 10,
		PageInvalid = 100,
		DocumentContainsNoPages = 101,
		DocumentNotValid = 102,
		DocumentLocked = 103,
		DocumentInvalidFormat = 104,
		UnableToOpenPDF = 200,
		UnableToGetPageReference = 210,
		UnableToGetStream = 211,
		DocumentNotSet = 212,
		DocumentProviderNotSet = 213,
		StreamPathNotSet = 214,
		AssetNameNotSet = 215,
		CantCreateStreamFile = 216,
		CantCreateStream = 217,
		CoreAnnotationNotSet = 218,
		PageRenderSizeIsEmpty = 220,
		PageRenderClipRectTooLarge = 230,
		PageRenderGraphicsContextNil = 240,
		DocumentUnsupportedSecurityScheme = 302,
		FailedToLoadAnnotations = 400,
		FailedToWriteAnnotations = 410,
		CannotEmbedAnnotations = 420,
		FailedToSaveBookmarks = 460,
		FailedToSaveDocument = 470,
		FailedToSaveDocumentCheckpoint = 480,
		FailedToDeleteDocumentCheckpoint = 490,
		OutlineParser = 500,
		UnableToConvertToDataRepresentation = 600,
		RemoveCacheError = 700,
		FailedToConvertToPDF = 800,
		FailedToGeneratePDFInvalidArguments = 810,
		FailedToGeneratePDFDocumentInvalid = 820,
		FailedToGeneratePDFCouldNotCreateContext = 830,
		FailedToCopyPages = 840,
		FailedToUpdatePageObject = 850,
		FailedToMemoryMapFile = 860,
		MicPermissionNotGranted = 900,
		XFDFParserLackingInputStream = 1000,
		XFDFParserAlreadyCompleted = 1010,
		XFDFParserAlreadyStarted = 1020,
		XMLParserError = 1100,
		DigitalSignatureVerificationFailed = 1150,
		DigitalSignatureSigningFailed = 1151,
		XFDFWriterCannotWriteToStream = 1200,
		FDFWriterCannotWriteToStream = 1250,
		SoundEncoderInvalidInput = 1300,
		GalleryInvalidManifest = 1400,
		GalleryUnknownItem = 1450,
		InvalidRemoteContent = 1500,
		FailedToSendStatistics = 1600,
		LibraryFailedToInitialize = 1700,
		FormValidationError = 5000,
		FormRemovalError = 5500,
		FormInsertionError = 5501,
		ImageProcessorInvalidImage = 6000,
		OpenInNoApplicationsFound = 7000,
		MessageNotSent = 7100,
		EmailNotConfigured = 7200,
		ProcessorAnnotationModificationError = 7300,
		ProcessorUnableToInsertPage = 7301,
		ProcessorUnableToFlattenAnnotation = 7302,
		ProcessorUnableToRemoveAnnotation = 7304,
		ProcessorUnableToIncludeDrawingBlock = 7305,
		ProcessorUnableToAddItem = 7306,
		ProcessorUnableToWriteFile = 7307,
		ProcessorMiscError = 7308,
		DocumentEditorUnableToWriteFile = 7400,
		DocumentEditorInvalidDocument = 7401,
		DocumentEditorInaccessibleDocument = 7402,
		FailedToFetchResource = 8000,
		FailedToSetResource = 8500,
		JsonDeserializationError = 9500,
		JsonSerializationError = 9501,
		JsonSerializationUnsupportedAnnotationTypeError = 9502,
		FeatureNotEnabled = 100000,
		SecurityNoPermission = 200000,
		SecurityOwnerPasswordNotSet = 200001,
		SecurityInvalidKeyLength = 200002,
		PKCS12CannotReadData = 300000,
		PKCS12CannotCopyData = 300001,
		PKCS12UnlockFailed = 300002,
		PKCS12NoItemsFound = 300003,
		PKCS12NoPrivateKeyFound = 300004,
		PKCS12PrivateKeyError = 300005,
		PKCS12CertificateNotFound = 300006,
		PKCS12CertificateError = 300007,
		PKCS12WrongPassword = 300008,
		SearchCouldNotLoadDocument = 400000,

		Unknown = long.MaxValue
	}

	[Native]
	public enum PSPDFLineEndType : long {
		None,
		Square,
		Circle,
		Diamond,
		OpenArrow,
		ClosedArrow,
		Butt,
		ReverseOpenArrow,
		ReverseClosedArrow,
		Slash
	}

	public enum PSPDFActionType : byte {
		Url,
		GoTo,
		RemoteGoTo,
		Named,
		Launch,
		JavaScript,
		Rendition,
		RichMediaExecute,
		SubmitForm,
		ResetForm,
		Sound,
		Movie,
		Hide,
		Thread,
		ImportData,
		SetOCGState,
		Trans,
		GoTo3DView,
		GoToEmbedded,
		Unknown = 255
	}

	[Native]
	//[ErrorDomain ("PSPDFAESCryptoInputStreamErrorDomain")] TODO: enable once generator bug is fixed
	public enum PSPDFAESCryptoInputStreamErrorCode : long {
		UnknownVersionInFileHeader = 110,
		WrongCloseCalled = 120,
		CryptorCreationFailed = 130,
		CryptorResetToIVFailed = 140,
		CloseExpectedInsteadOfRead = 150,
		ErrorDecryptingBlock = 160,
		CryptorFinalFailed = 170,
		HMACCheckFailed = 180,
		IncorrectHMACInFile = 190,
		FailedToAllocateMemory = 200,
		Unknown = long.MaxValue
	}

	[Native]
	public enum PSPDFAESCryptoOutputStreamErrorCode : long {
		EncryptionFailed = 100,
		CryptorFinalFailed = 170,
		WritingToParentStreamFailed = 120,
		FailedToAllocateMemory = 200,
		Unknown = long.MaxValue
	}

	public enum PSPDFAnnotationString {
		[DefaultEnumValue]
		[Field (null)]
		Null,
		[Field ("PSPDFAnnotationStringLink", PSPDFKitLibraryPath.LibraryPath)]
		Link,
		[Field ("PSPDFAnnotationStringHighlight", PSPDFKitLibraryPath.LibraryPath)]
		Highlight,
		[Field ("PSPDFAnnotationStringStrikeOut", PSPDFKitLibraryPath.LibraryPath)]
		StrikeOut,
		[Field ("PSPDFAnnotationStringUnderline", PSPDFKitLibraryPath.LibraryPath)]
		Underline,
		[Field ("PSPDFAnnotationStringSquiggly", PSPDFKitLibraryPath.LibraryPath)]
		Squiggly,
		[Field ("PSPDFAnnotationStringNote", PSPDFKitLibraryPath.LibraryPath)]
		Note,
		[Field ("PSPDFAnnotationStringFreeText", PSPDFKitLibraryPath.LibraryPath)]
		FreeText,
		[Field ("PSPDFAnnotationStringInk", PSPDFKitLibraryPath.LibraryPath)]
		Ink,
		[Field ("PSPDFAnnotationStringSquare", PSPDFKitLibraryPath.LibraryPath)]
		Square,
		[Field ("PSPDFAnnotationStringCircle", PSPDFKitLibraryPath.LibraryPath)]
		Circle,
		[Field ("PSPDFAnnotationStringLine", PSPDFKitLibraryPath.LibraryPath)]
		Line,
		[Field ("PSPDFAnnotationStringPolygon", PSPDFKitLibraryPath.LibraryPath)]
		Polygon,
		[Field ("PSPDFAnnotationStringPolyLine", PSPDFKitLibraryPath.LibraryPath)]
		PolyLine,
		[Field ("PSPDFAnnotationStringSignature", PSPDFKitLibraryPath.LibraryPath)]
		Signature,
		[Field ("PSPDFAnnotationStringStamp", PSPDFKitLibraryPath.LibraryPath)]
		Stamp,
		[Field ("PSPDFAnnotationStringEraser", PSPDFKitLibraryPath.LibraryPath)]
		Eraser,
		[Field ("PSPDFAnnotationStringSound", PSPDFKitLibraryPath.LibraryPath)]
		Sound,
		[Field ("PSPDFAnnotationStringImage", PSPDFKitLibraryPath.LibraryPath)]
		Image,
		[Field ("PSPDFAnnotationStringWidget", PSPDFKitLibraryPath.LibraryPath)]
		Widget,
		[Field ("PSPDFAnnotationStringFile", PSPDFKitLibraryPath.LibraryPath)]
		File,
		[Field ("PSPDFAnnotationStringRichMedia", PSPDFKitLibraryPath.LibraryPath)]
		RichMedia,
		[Field ("PSPDFAnnotationStringScreen", PSPDFKitLibraryPath.LibraryPath)]
		Screen,
		[Field ("PSPDFAnnotationStringCaret", PSPDFKitLibraryPath.LibraryPath)]
		Caret,
		[Field ("PSPDFAnnotationStringPopup", PSPDFKitLibraryPath.LibraryPath)]
		Popup,
		[Field ("PSPDFAnnotationStringWatermark", PSPDFKitLibraryPath.LibraryPath)]
		Watermark,
		[Field ("PSPDFAnnotationStringTrapNet", PSPDFKitLibraryPath.LibraryPath)]
		TrapNet,
		[Field ("PSPDFAnnotationString3D", PSPDFKitLibraryPath.LibraryPath)]
		_3D,
		[Field ("PSPDFAnnotationStringRedact", PSPDFKitLibraryPath.LibraryPath)]
		Redact,
		[Field ("PSPDFAnnotationStringInkVariantPen", PSPDFKitLibraryPath.LibraryPath)]
		InkVariantPen,
		[Field ("PSPDFAnnotationStringInkVariantHighlighter", PSPDFKitLibraryPath.LibraryPath)]
		InkVariantHighlighter,
		[Field ("PSPDFAnnotationStringLineVariantArrow", PSPDFKitLibraryPath.LibraryPath)]
		LineVariantArrow,
		[Field ("PSPDFAnnotationStringFreeTextVariantCallout", PSPDFKitLibraryPath.LibraryPath)]
		FreeTextVariantCallout,
	}

	[Native]
	[Flags]
	public enum PSPDFAnnotationType : ulong {
		None = 0,
		Undefined = 1 << 0,
		Link = 1 << 1,
		Highlight = 1 << 2,
		FreeText = 1 << 3,
		Ink = 1 << 4,
		Square = 1 << 5,
		Line = 1 << 6,
		Note = 1 << 7,
		Stamp = 1 << 8,
		Caret = 1 << 9,
		RichMedia = 1 << 10,
		Screen = 1 << 11,
		Widget = 1 << 12,
		File = 1 << 13,
		Sound = 1 << 14,
		Polygon = 1 << 15,
		PolyLine = 1 << 16,
		StrikeOut = 1 << 17,
		Underline = 1 << 18,
		Squiggly = 1 << 19,
		Circle = 1 << 20,
		Popup = 1 << 21,
		Watermark = 1 << 22,
		TrapNet = 1 << 23,
		ThreeDimensional = 1 << 24,
		Redact = 1 << 25,
		All = ulong.MaxValue
	}

	[Native]
	public enum PSPDFAnnotationBorderStyle : ulong {
		None,
		Solid,
		Dashed,
		Beveled,
		Inset,
		Underline,
		Unknown
	}

	[Native]
	public enum PSPDFAnnotationBorderEffect : ulong {
		NoEffect = 0,
		Cloudy
	}

	[Native]
	[Flags]
	public enum PSPDFAnnotationFlags : ulong {
		Invisible = 1 << 0,
		Hidden = 1 << 1,
		Print = 1 << 2,
		NoZoom = 1 << 3,
		NoRotate = 1 << 4,
		NoView = 1 << 5,
		ReadOnly = 1 << 6,
		Locked = 1 << 7,
		ToggleNoView = 1 << 8,
		LockedContents = 1 << 9
	}

	public enum PSPDFAnnotationTriggerEvent : byte {
		CursorEnters,
		CursorExits,
		MouseDown,
		MouseUp,
		ReceiveFocus,
		LoseFocus,
		PageOpened,
		PageClosed,
		PageVisible,
		FormChanged,
		FieldFormat,
		FormValidate,
		FormCalculate
	}

	[Native]
	public enum PSPDFVerticalAlignment : ulong {
		Top = 0,
		Center = 1,
		Bottom = 2
	}

	[Native]
	public enum PSPDFBookmarkManagerSortOrder : ulong {
		Custom,
		PageBased
	}

	[Native]
	[Flags]
	public enum PSPDFButtonFlag : ulong {
		NoToggleToOff = 1 << (15 - 1),
		Radio = 1 << (16 - 1),
		PushButton = 1 << (17 - 1),
		RadiosInUnison = 1 << (26 - 1)
	}

	[Native]
	public enum PSPDFCacheStoragePolicy : long {
		Automatic = 0,
		Allowed,
		AllowedInMemoryOnly,
		NotAllowed
	}

	[Native]
	public enum PSPDFCacheStatus : long {
		NotCached,
		InMemory,
		OnDisk
	}

	[Native]
	[Flags]
	public enum PSPDFCacheImageSizeMatching : ulong {
		Exact = 0,
		AllowLarger = 1 << 0,
		AllowSmaller = 1 << 1,
		Default = Exact
	}

	[Native]
	[Flags]
	public enum PSPDFChoiceFlag : ulong {
		Combo = 1 << (18 - 1),
		Edit = 1 << (19 - 1),
		Sort = 1 << (20 - 1),
		MultiSelect = 1 << (22 - 1),
		DoNotSpellCheck = 1 << (23 - 1),
		CommitOnSelChange = 1 << (27 - 1)
	}

	[Native]
	public enum PSPDFCryptorErrorCode : long {
		FailedToInitCryptor = 100,
		FailedToProcessFile = 110,
		InvalidIV = 200,
		WritingOutputFile = 600,
		ReadingInputFile = 700
	}

	[Native]
	public enum PSPDFDataProvidingAdditionalOperations : ulong {
		None = 0,
		Write = 1
	}

	[Native]
	public enum PSPDFDataSinkOptions : ulong {
		None = 0,
		Append = 1
	}

	[Native]
	[Flags]
	public enum PSPDFDigitalSignatureReferenceTransformMethod : ulong {
		DocMdp = 1 << (1 - 1),
		Ur = 1 << (2 - 1),
		FieldMdp = 1 << (3 - 1),
		Identity = 1 << (4 - 1)
	}

	[Native]
	public enum PSPDFDiskCacheFileFormat : long {
		Jpeg,
		Png
	}

	[Native]
	public enum PSPDFAnnotationSaveMode : long {
		Disabled,
		ExternalFile,
		Embedded,
		EmbeddedWithExternalFileAsFallback
	}

	[Native]
	[Flags]
	public enum PSPDFTextCheckingType : ulong {
		None = 0,
		Link = 1 << 0,
		PhoneNumber = 1 << 1,
		All = ulong.MaxValue
	}

	public enum PSPDFMetadataName {
		[Field ("PSPDFMetadataTitleKey", PSPDFKitLibraryPath.LibraryPath)]
		Title,
		[Field ("PSPDFMetadataAuthorKey", PSPDFKitLibraryPath.LibraryPath)]
		Author,
		[Field ("PSPDFMetadataSubjectKey", PSPDFKitLibraryPath.LibraryPath)]
		Subject,
		[Field ("PSPDFMetadataKeywordsKey", PSPDFKitLibraryPath.LibraryPath)]
		Keywords,
		[Field ("PSPDFMetadataCreatorKey", PSPDFKitLibraryPath.LibraryPath)]
		Creator,
		[Field ("PSPDFMetadataProducerKey", PSPDFKitLibraryPath.LibraryPath)]
		Producer,
		[Field ("PSPDFMetadataCreationDateKey", PSPDFKitLibraryPath.LibraryPath)]
		CreationDate,
		[Field ("PSPDFMetadataModDateKey", PSPDFKitLibraryPath.LibraryPath)]
		ModDate,
		[Field ("PSPDFMetadataTrappedKey", PSPDFKitLibraryPath.LibraryPath)]
		Trapped,
	}

	[Native]
	public enum PSPDFDocumentCheckpointingStrategy : ulong {
		Manual,
		Timed,
		Immediate
	}

	[Native]
	public enum PSPDFDocumentOrientation : long {
		Portrait,
		Landscape
	}

	[Native]
	[Flags]
	public enum PSPDFDocumentPermissions : ulong {
		NoFlags = 0,
		Printing = 1 << 0,
		Modification = 1 << 1,
		Extract = 1 << 2,
		AnnotationsAndForms = 1 << 3,
		FillForms = 1 << 4,
		ExtractAccessibility = 1 << 5,
		Assemble = 1 << 6,
		PrintHighQuality = 1 << 7
	}

	[Native]
	public enum PSPDFDocumentEncryptionAlgorithm : ulong {
		Aes,
		Rc4
	}

	[Native]
	public enum PSPDFDownloadManagerObjectState : ulong {
		NotHandled,
		Waiting,
		Loading,
		Failed
	}

	[Native]
	public enum PSPDFEditingOperation : ulong {
		Remove,
		Move,
		Insert,
		Rotate
	}

	[Native]
	public enum PSPDFEmbeddedGoToActionTarget : ulong {
		ParentOfCurrentDocument,
		ChildOfCurrentDocument
	}

	[Native]
	[Flags]
	public enum PSPDFFormElementFlag : ulong {
		ReadOnly = 1 << (1 - 1),
		Required = 1 << (2 - 1),
		NoExport = 1 << (3 - 1)
	}

	[Native]
	public enum PSPDFFormFieldType : ulong {
		Unknown,
		PushButton,
		RadioButton,
		CheckBox,
		Text,
		ListBox,
		ComboBox,
		Signature
	}

	[Native]
	public enum PSPDFFreeTextAnnotationIntent : long {
		FreeText,
		Callout,
		TypeWriter
	}

	[Native]
	[Flags]
	public enum PSPDFFeatureMask : ulong {
		None = 0,
		PdfViewer = 1 << 0,
		TextSelection = 1 << 1,
		StrongEncryption = 1 << 2,
		PdfCreation = 1 << 3,
		AnnotationEditing = 1 << 4,
		AcroForms = 1 << 5,
		IndexedFts = 1 << 6,
		DigitalSignatures = 1 << 7,
		RequireSignedSource = 1 << 8,
		DocumentEditing = 1 << 9,
		UI = 1 << 10,

		All = ulong.MaxValue
	}

	[Native]
	public enum PSPDFLogLevelMask : ulong {
		Nothing = 0,
		Critical = 1 << 0,
		Error = 1 << 1,
		Warning = 1 << 2,
		Info = 1 << 3,
		Debug = 1 << 4,
		Verbose = 1 << 5,
		All = ulong.MaxValue
	}

	[Native]
	public enum PSPDFLibraryIndexStatus : ulong {
		Unknown,
		Queued,
		Partial,
		PartialAndIndexing,
		Finished
	}

	[Native]
	public enum PSPDFLibraryFTSVersion : ulong {
		HighestAvailable,
		Version4,
		Version5
	}

	[Native]
	public enum PSPDFLibraryIndexingPriority : ulong {
		Background,
		Low,
		High
	}

	[Native]
	public enum PSPDFLibrarySpotlightIndexingType : ulong {
		Disabled = 0,
		Enabled = 1,
		EnabledWithFullText = 2
	}

	public enum PSPDFLinkAnnotationType : byte {
		Page = 0,
		WebURL,
		Document,
		Video,
		YouTube,
		Audio,
		Image,
		Browser,
		Custom
	}

	[Native]
	public enum PSPDFNamedActionType : ulong
	{
		None,
		NextPage,
		PreviousPage,
		FirstPage,
		LastPage,
		GoBack,
		GoForward,
		GoToPage,
		Find,
		Print,
		Outline,
		Search,
		Brightness,
		ZoomIn,
		ZoomOut,
		SaveAs,
		Info,
		Unknown = ulong.MaxValue
	}

	[Native]
	public enum PSPDFNewPageType : long {
		EmptyPage,
		TiledPatternPage,
		FromDocument
	}

	public enum PSPDFNewPagePattern {
		[Field ("PSPDFNewPagePatternDot5mm", PSPDFKitLibraryPath.LibraryPath)]
		Dot5mm,
		[Field ("PSPDFNewPagePatternGrid5mm", PSPDFKitLibraryPath.LibraryPath)]
		Grid5mm,
		[Field ("PSPDFNewPagePatternLines5mm", PSPDFKitLibraryPath.LibraryPath)]
		Lines5mm,
		[Field ("PSPDFNewPagePatternLines7mm", PSPDFKitLibraryPath.LibraryPath)]
		Lines7mm,
	}

	public enum PSPDFPageBinding : long {
		Unknown,
		LeftEdge,
		RightEdge
	}

	[Native]
	public enum PSPDFPageTriggerEvent : ulong {
		Open,
		Close
	}

	[Native]
	public enum PSPDFPolygonAnnotationIntent : long {
		None = 0,
		PolygonCloud,
		PolygonDimension
	}

	[Native]
	public enum PSPDFAnnotationChange : long {
		Flatten,
		Remove,
		Embed,
		Print
	}

	[Native]
	public enum PSPDFItemZPosition : long {
		Foreground,
		Background
	}

	[Native]
	public enum PSPDFReachability : ulong {
		Unknown,
		Unreachable,
		WiFi,
		Wwan
	}

	[Native]
	public enum PSPDFRectAlignment : long {
		Center = 0,
		Top,
		TopLeft,
		TopRight,
		Left,
		Bottom,
		BottomLeft,
		BottomRight,
		Right
	}

	[Native]
	public enum PSPDFRenderType : ulong {
		Page,
		Processor,
		All = ulong.MaxValue
	}

	[Native]
	[Flags]
	public enum PSPDFRenderFilter : ulong {
		Grayscale = 1 << 0,
		ColorCorrectInverted = 1 << 1,
		Sepia = 1 << 2
	}

	[Native]
	public enum PSPDFRenderQueuePriority : ulong {
		Unspecified = 0,
		Background = 100,
		Utility = 200,
		UserInitiated = 300,
		UserInteractive = 400
	}

	[Native]
	public enum PSPDFRenderRequestCachePolicy : long {
		Default = 0,
		ReloadIgnoringCacheData,
		ReturnCacheDataElseLoad,
		ReturnCacheDataDontLoad
	}

	[Native]
	public enum PSPDFRenditionActionType : long {
		Unknown = -1,
		PlayStop,
		Stop,
		Pause,
		Resume,
		Play
	}

	[Native]
	[Flags]
	public enum PSPDFResetFormActionFlag : ulong {
		IncludeExclude = 1 << (1 - 1)
	}

	[Native]
	public enum PSPDFMediaScreenWindowType : ulong {
		Floating,
		Fullscreen,
		Hidden,
		UseAnnotationRectangle
	}

	[Native]
	public enum PSPDFSignatureAppearanceMode : ulong {
		SignatureAndDescription,
		DescriptionOnly
	}

	[Native]
	public enum PSPDFSignatureInputMethod : ulong {
		None,
		Finger,
		ApplePencil,
		ThirdPartyStylus,
		Mouse,
	}

	[Native]
	public enum PSPDFSignatureStatusSeverity : long {
		None = 0,
		Warning,
		Error
	}

	[Native]
	public enum PSPDFSignerError : ulong {
		None = 0,
		NoFormElementSet = 1,
		CannotNotCreatePKCS7 = 256,
		CannotNotAddSignatureToPKCS7 = 257,
		CannotNotInitPKCS7 = 258,
		CannotGeneratePKCS7Signature = 259,
		CannotWritePKCS7Signature = 260,
		CannotVerifySignature = 261,
		CannotSaveToDestination = 262,
		UnsupportedSubfilterType = 263,
		CannotFindSignature = 264,
		CannotSignAttributes = 265,
		CannotSignFormElement = 272
	}

	public enum PSPDFSoundAnnotationEncoding {
		[Field ("PSPDFSoundAnnotationEncodingRaw", PSPDFKitLibraryPath.LibraryPath)]
		Raw,
		[Field ("PSPDFSoundAnnotationEncodingSigned", PSPDFKitLibraryPath.LibraryPath)]
		Signed,
		[Field ("PSPDFSoundAnnotationEncodingMuLaw", PSPDFKitLibraryPath.LibraryPath)]
		MuLaw,
		[Field ("PSPDFSoundAnnotationEncodingALaw", PSPDFKitLibraryPath.LibraryPath)]
		ALaw,
	}

	[Native]
	public enum PSPDFSoundAnnotationState : long {
		Stopped = 0,
		Recording,
		RecordingPaused,
		Playing,
		PlaybackPaused
	}

	[Native]
	[Flags]
	public enum PSPDFSubmitFormActionFlag : ulong {
		IncludeExclude = 1 << (1 - 1),
		IncludeNoValueFields = 1 << (2 - 1),
		ExportFormat = 1 << (3 - 1),
		GetMethod = 1 << (4 - 1),
		SubmitCoordinates = 1 << (5 - 1),
		Xfdf = 1 << (6 - 1),
		IncludeAppendSaves = 1 << (7 - 1),
		IncludeAnnotations = 1 << (8 - 1),
		SubmitPdf = 1 << (9 - 1),
		CanonicalFormat = 1 << (10 - 1),
		ExclNonUserAnnots = 1 << (11 - 1),
		ExclFKey = 1 << (12 - 1),
		EmbedForm = 1 << (14 - 1)
	}

	[Native]
	[Flags]
	public enum PSPDFTextFieldFlag : ulong {
		Multiline = 1 << (13 - 1),
		Password = 1 << (14 - 1),
		FileSelect = 1 << (21 - 1),
		DoNotSpellCheck = 1 << (23 - 1),
		DoNotScroll = 1 << (24 - 1),
		Comb = 1 << (25 - 1),
		RichText = 1 << (26 - 1)
	}

	[Native]
	public enum PSPDFTextInputFormat : ulong {
		Normal,
		Number,
		Date,
		Time
	}

	[Native]
	public enum PSPDFUndoCoalescing : ulong {
		None,
		Timed,
		All
	}

	[Native]
	public enum PSPDFSignatureIntegrityStatus : long {
		Ok = 0,
		TamperedDocument
	}

	[Native]
	public enum PSPDFRotation : ulong {
		Zero = 0,
		Ninety = 90,
		OneHundredEighty = 180,
		TwoHundredSeventy = 270
	}

	[Native]
	public enum PSPDFSignatureEncryptionAlgorithm : ulong {
		Rsa,
		Dsa,
		Ecdsa,
		Unknown
	}

	[Native]
	public enum PSPDFSignatureHashAlgorithm : ulong {
		Md5,
		Sha160,
		Sha224,
		Sha256,
		Sha386,
		Sha512,
		Unknown
	}
}
