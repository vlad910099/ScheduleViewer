; ModuleID = 'obj\Debug\120\android\marshal_methods.x86_64.ll'
source_filename = "obj\Debug\120\android\marshal_methods.x86_64.ll"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 8
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [232 x i64] [
	i64 24362543149721218, ; 0: Xamarin.AndroidX.DynamicAnimation => 0x568d9a9a43a682 => 63
	i64 120698629574877762, ; 1: Mono.Android => 0x1accec39cafe242 => 16
	i64 197751585713159992, ; 2: ICSharpCode.SharpZipLib.dll => 0x2be8e04fc33ff38 => 10
	i64 210515253464952879, ; 3: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 53
	i64 232391251801502327, ; 4: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 85
	i64 295915112840604065, ; 5: Xamarin.AndroidX.SlidingPaneLayout => 0x41b4d3a3088a9a1 => 86
	i64 410314583599927389, ; 6: Enums.NET.dll => 0x5b1baf099a2d05d => 7
	i64 582971200311059670, ; 7: Persistence.dll => 0x8172137ccd2e4d6 => 3
	i64 634308326490598313, ; 8: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x8cd840fee8b6ba9 => 72
	i64 702024105029695270, ; 9: System.Drawing.Common => 0x9be17343c0e7726 => 105
	i64 710500338161506772, ; 10: SixLabors.Fonts.dll => 0x9dc344b0ce959d4 => 22
	i64 720058930071658100, ; 11: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x9fe29c82844de74 => 66
	i64 872800313462103108, ; 12: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 62
	i64 940822596282819491, ; 13: System.Transactions => 0xd0e792aa81923a3 => 103
	i64 964003131647442271, ; 14: HtmlAgilityPack => 0xd60d3bda035bd5f => 9
	i64 990502365984941804, ; 15: MathNet.Numerics => 0xdbef8a769b766ec => 12
	i64 996343623809489702, ; 16: Xamarin.Forms.Platform => 0xdd3b93f3b63db26 => 98
	i64 1000557547492888992, ; 17: Mono.Security.dll => 0xde2b1c9cba651a0 => 115
	i64 1120440138749646132, ; 18: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 100
	i64 1315114680217950157, ; 19: Xamarin.AndroidX.Arch.Core.Common.dll => 0x124039d5794ad7cd => 48
	i64 1425944114962822056, ; 20: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 5
	i64 1624659445732251991, ; 21: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 46
	i64 1628611045998245443, ; 22: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 74
	i64 1636321030536304333, ; 23: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0x16b5614ec39e16cd => 67
	i64 1743969030606105336, ; 24: System.Memory.dll => 0x1833d297e88f2af8 => 30
	i64 1795316252682057001, ; 25: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 47
	i64 1836611346387731153, ; 26: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 85
	i64 1875917498431009007, ; 27: Xamarin.AndroidX.Annotation.dll => 0x1a08990699eb70ef => 44
	i64 1981742497975770890, ; 28: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 73
	i64 2136356949452311481, ; 29: Xamarin.AndroidX.MultiDex.dll => 0x1da5dd539d8acbb9 => 78
	i64 2165725771938924357, ; 30: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 51
	i64 2182323945368236980, ; 31: Domain.dll => 0x1e492c10dc80b3b4 => 2
	i64 2262844636196693701, ; 32: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 62
	i64 2284400282711631002, ; 33: System.Web.Services => 0x1fb3d1f42fd4249a => 108
	i64 2287887973817120656, ; 34: System.ComponentModel.DataAnnotations.dll => 0x1fc035fd8d41f790 => 111
	i64 2329709569556905518, ; 35: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 70
	i64 2337758774805907496, ; 36: System.Runtime.CompilerServices.Unsafe => 0x207163383edbc828 => 33
	i64 2463182746987656754, ; 37: MathNet.Numerics.dll => 0x222efba86b11f632 => 12
	i64 2470498323731680442, ; 38: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 57
	i64 2479423007379663237, ; 39: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x2268ae16b2cba985 => 90
	i64 2497223385847772520, ; 40: System.Runtime => 0x22a7eb7046413568 => 34
	i64 2532580330595909775, ; 41: NPOI.OOXML => 0x232588647a4f808f => 19
	i64 2547086958574651984, ; 42: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 43
	i64 2592350477072141967, ; 43: System.Xml.dll => 0x23f9e10627330e8f => 40
	i64 2624866290265602282, ; 44: mscorlib.dll => 0x246d65fbde2db8ea => 17
	i64 2656907746661064104, ; 45: Microsoft.Extensions.DependencyInjection => 0x24df3b84c8b75da8 => 14
	i64 2694427813909235223, ; 46: Xamarin.AndroidX.Preference.dll => 0x256487d230fe0617 => 82
	i64 2783046991838674048, ; 47: System.Runtime.CompilerServices.Unsafe.dll => 0x269f5e7e6dc37c80 => 33
	i64 2815524396660695947, ; 48: System.Security.AccessControl => 0x2712c0857f68238b => 35
	i64 2851879596360956261, ; 49: System.Configuration.ConfigurationManager => 0x2793e9620b477965 => 25
	i64 2923513799412830535, ; 50: UDUNT-TimeTable => 0x2892684fa5f45147 => 42
	i64 2960931600190307745, ; 51: Xamarin.Forms.Core => 0x2917579a49927da1 => 96
	i64 3017704767998173186, ; 52: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 100
	i64 3289520064315143713, ; 53: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 69
	i64 3303437397778967116, ; 54: Xamarin.AndroidX.Annotation.Experimental => 0x2dd82acf985b2a4c => 45
	i64 3311221304742556517, ; 55: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 32
	i64 3397747728761535915, ; 56: HtmlAgilityPack.dll => 0x2f27398ea938bdab => 9
	i64 3493805808809882663, ; 57: Xamarin.AndroidX.Tracing.Tracing.dll => 0x307c7ddf444f3427 => 88
	i64 3522470458906976663, ; 58: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 87
	i64 3531994851595924923, ; 59: System.Numerics => 0x31042a9aade235bb => 31
	i64 3571415421602489686, ; 60: System.Runtime.dll => 0x319037675df7e556 => 34
	i64 3716579019761409177, ; 61: netstandard.dll => 0x3393f0ed5c8c5c99 => 1
	i64 3727469159507183293, ; 62: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 84
	i64 3772598417116884899, ; 63: Xamarin.AndroidX.DynamicAnimation.dll => 0x345af645b473efa3 => 63
	i64 3966267475168208030, ; 64: System.Memory => 0x370b03412596249e => 30
	i64 4525561845656915374, ; 65: System.ServiceModel.Internals => 0x3ece06856b710dae => 109
	i64 4636684751163556186, ; 66: Xamarin.AndroidX.VersionedParcelable.dll => 0x4058d0370893015a => 92
	i64 4743821336939966868, ; 67: System.ComponentModel.Annotations => 0x41d5705f4239b194 => 110
	i64 4782108999019072045, ; 68: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0x425d76cc43bb0a2d => 50
	i64 4794310189461587505, ; 69: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 43
	i64 4795410492532947900, ; 70: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 87
	i64 4938228816400805549, ; 71: NPOI.OpenXml4Net.dll => 0x44881cf1d52aeead => 20
	i64 5142919913060024034, ; 72: Xamarin.Forms.Platform.Android.dll => 0x475f52699e39bee2 => 97
	i64 5203618020066742981, ; 73: Xamarin.Essentials => 0x4836f704f0e652c5 => 95
	i64 5205316157927637098, ; 74: Xamarin.AndroidX.LocalBroadcastManager => 0x483cff7778e0c06a => 76
	i64 5271320364520602397, ; 75: UDUNT-TimeTable.dll => 0x49277df160887b1d => 42
	i64 5348796042099802469, ; 76: Xamarin.AndroidX.Media => 0x4a3abda9415fc165 => 77
	i64 5376510917114486089, ; 77: Xamarin.AndroidX.VectorDrawable.Animated => 0x4a9d3431719e5d49 => 90
	i64 5408338804355907810, ; 78: Xamarin.AndroidX.Transition => 0x4b0e477cea9840e2 => 89
	i64 5451019430259338467, ; 79: Xamarin.AndroidX.ConstraintLayout.dll => 0x4ba5e94a845c2ce3 => 56
	i64 5507995362134886206, ; 80: System.Core.dll => 0x4c705499688c873e => 26
	i64 5624375662354994915, ; 81: SixLabors.ImageSharp.dll => 0x4e0dcbdd9e0596e3 => 23
	i64 5692067934154308417, ; 82: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 94
	i64 5757522595884336624, ; 83: Xamarin.AndroidX.Concurrent.Futures.dll => 0x4fe6d44bd9f885f0 => 54
	i64 5814345312393086621, ; 84: Xamarin.AndroidX.Preference => 0x50b0b44182a5c69d => 82
	i64 5896680224035167651, ; 85: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x51d5376bfbafdda3 => 71
	i64 5979151488806146654, ; 86: System.Formats.Asn1 => 0x52fa3699a489d25e => 28
	i64 6085203216496545422, ; 87: Xamarin.Forms.Platform.dll => 0x5472fc15a9574e8e => 98
	i64 6086316965293125504, ; 88: FormsViewGroup.dll => 0x5476f10882baef80 => 8
	i64 6319713645133255417, ; 89: Xamarin.AndroidX.Lifecycle.Runtime => 0x57b42213b45b52f9 => 72
	i64 6401687960814735282, ; 90: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 70
	i64 6504860066809920875, ; 91: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 51
	i64 6548213210057960872, ; 92: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 60
	i64 6591024623626361694, ; 93: System.Web.Services.dll => 0x5b7805f9751a1b5e => 108
	i64 6617685658146568858, ; 94: System.Text.Encoding.CodePages => 0x5bd6be0b4905fa9a => 112
	i64 6659513131007730089, ; 95: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0x5c6b57e8b6c3e1a9 => 66
	i64 6876862101832370452, ; 96: System.Xml.Linq => 0x5f6f85a57d108914 => 41
	i64 6894844156784520562, ; 97: System.Numerics.Vectors => 0x5faf683aead1ad72 => 32
	i64 7036436454368433159, ; 98: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x61a671acb33d5407 => 68
	i64 7060448593242414269, ; 99: System.Security.Cryptography.Xml => 0x61fbc096731edcbd => 37
	i64 7103753931438454322, ; 100: Xamarin.AndroidX.Interpolator.dll => 0x62959a90372c7632 => 65
	i64 7105430439328552570, ; 101: System.Security.Cryptography.Pkcs => 0x629b8f56a06d167a => 36
	i64 7488575175965059935, ; 102: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 41
	i64 7607451001358638252, ; 103: Enums.NET => 0x69931861362bdcac => 7
	i64 7635363394907363464, ; 104: Xamarin.Forms.Core.dll => 0x69f6428dc4795888 => 96
	i64 7637365915383206639, ; 105: Xamarin.Essentials.dll => 0x69fd5fd5e61792ef => 95
	i64 7654504624184590948, ; 106: System.Net.Http => 0x6a3a4366801b8264 => 4
	i64 7820441508502274321, ; 107: System.Data => 0x6c87ca1e14ff8111 => 102
	i64 7836164640616011524, ; 108: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 46
	i64 8044118961405839122, ; 109: System.ComponentModel.Composition => 0x6fa2739369944712 => 107
	i64 8054447570592506922, ; 110: NPOI.OpenXmlFormats => 0x6fc72564232ca42a => 21
	i64 8083354569033831015, ; 111: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 69
	i64 8103644804370223335, ; 112: System.Data.DataSetExtensions.dll => 0x7075ee03be6d50e7 => 104
	i64 8167236081217502503, ; 113: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 11
	i64 8167532198187476063, ; 114: NPOI.dll => 0x7158e742c487a45f => 18
	i64 8318905602908530212, ; 115: System.ComponentModel.DataAnnotations => 0x7372b092055ea624 => 111
	i64 8329843434826495442, ; 116: ICSharpCode.SharpZipLib => 0x73998c787773f5d2 => 10
	i64 8398329775253868912, ; 117: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x748cdc6f3097d170 => 55
	i64 8400357532724379117, ; 118: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 81
	i64 8476857680833348370, ; 119: System.Security.Permissions.dll => 0x75a3d925fd9d0312 => 38
	i64 8601935802264776013, ; 120: Xamarin.AndroidX.Transition.dll => 0x7760370982b4ed4d => 89
	i64 8626175481042262068, ; 121: Java.Interop => 0x77b654e585b55834 => 11
	i64 8639588376636138208, ; 122: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 80
	i64 8684531736582871431, ; 123: System.IO.Compression.FileSystem => 0x7885a79a0fa0d987 => 106
	i64 9041985878101337471, ; 124: BouncyCastle.Crypto => 0x7d7b963fe854257f => 6
	i64 9312692141327339315, ; 125: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 94
	i64 9324707631942237306, ; 126: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 47
	i64 9342122023452561803, ; 127: SixLabors.ImageSharp => 0x81a5e27bd03e518b => 23
	i64 9638665373315319928, ; 128: NPOI.OpenXmlFormats.dll => 0x85c36b16d5514878 => 21
	i64 9662334977499516867, ; 129: System.Numerics.dll => 0x8617827802b0cfc3 => 31
	i64 9678050649315576968, ; 130: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 57
	i64 9711637524876806384, ; 131: Xamarin.AndroidX.Media.dll => 0x86c6aadfd9a2c8f0 => 77
	i64 9808709177481450983, ; 132: Mono.Android.dll => 0x881f890734e555e7 => 16
	i64 9825649861376906464, ; 133: Xamarin.AndroidX.Concurrent.Futures => 0x885bb87d8abc94e0 => 54
	i64 9834056768316610435, ; 134: System.Transactions.dll => 0x8879968718899783 => 103
	i64 9998632235833408227, ; 135: Mono.Security => 0x8ac2470b209ebae3 => 115
	i64 10038780035334861115, ; 136: System.Net.Http.dll => 0x8b50e941206af13b => 4
	i64 10229024438826829339, ; 137: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 60
	i64 10376576884623852283, ; 138: Xamarin.AndroidX.Tracing.Tracing => 0x900101b2f888c2fb => 88
	i64 10430153318873392755, ; 139: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 58
	i64 10847732767863316357, ; 140: Xamarin.AndroidX.Arch.Core.Common => 0x968ae37a86db9f85 => 48
	i64 11023048688141570732, ; 141: System.Core => 0x98f9bc61168392ac => 26
	i64 11037814507248023548, ; 142: System.Xml => 0x992e31d0412bf7fc => 40
	i64 11162124722117608902, ; 143: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 93
	i64 11340910727871153756, ; 144: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 59
	i64 11341245327015630248, ; 145: System.Configuration.ConfigurationManager.dll => 0x9d643289535355a8 => 25
	i64 11392833485892708388, ; 146: Xamarin.AndroidX.Print.dll => 0x9e1b79b18fcf6824 => 83
	i64 11529969570048099689, ; 147: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 93
	i64 11578238080964724296, ; 148: Xamarin.AndroidX.Legacy.Support.V4 => 0xa0ae2a30c4cd8648 => 68
	i64 11580057168383206117, ; 149: Xamarin.AndroidX.Annotation => 0xa0b4a0a4103262e5 => 44
	i64 11597940890313164233, ; 150: netstandard => 0xa0f429ca8d1805c9 => 1
	i64 11672361001936329215, ; 151: Xamarin.AndroidX.Interpolator => 0xa1fc8e7d0a8999ff => 65
	i64 12011556116648931059, ; 152: System.Security.Cryptography.ProtectedData => 0xa6b19ea5ec87aef3 => 113
	i64 12063623837170009990, ; 153: System.Security => 0xa76a99f6ce740786 => 114
	i64 12102847907131387746, ; 154: System.Buffers => 0xa7f5f40c43256f62 => 24
	i64 12137774235383566651, ; 155: Xamarin.AndroidX.VectorDrawable => 0xa872095bbfed113b => 91
	i64 12451044538927396471, ; 156: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 64
	i64 12466513435562512481, ; 157: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 75
	i64 12487638416075308985, ; 158: Xamarin.AndroidX.DocumentFile.dll => 0xad4d00fa21b0bfb9 => 61
	i64 12538491095302438457, ; 159: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 52
	i64 12550732019250633519, ; 160: System.IO.Compression => 0xae2d28465e8e1b2f => 29
	i64 12700543734426720211, ; 161: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 53
	i64 12963446364377008305, ; 162: System.Drawing.Common.dll => 0xb3e769c8fd8548b1 => 105
	i64 13081516019875753442, ; 163: BouncyCastle.Crypto.dll => 0xb58ae182e046ade2 => 6
	i64 13109727801987935684, ; 164: SixLabors.Fonts => 0xb5ef1bfa438dadc4 => 22
	i64 13112815015440130302, ; 165: NPOI => 0xb5fa13c828b7a0fe => 18
	i64 13162471042547327635, ; 166: System.Security.Permissions => 0xb6aa7dace9662293 => 38
	i64 13246160281449864914, ; 167: Domain => 0xb7d3d09845b51ed2 => 2
	i64 13370592475155966277, ; 168: System.Runtime.Serialization => 0xb98de304062ea945 => 5
	i64 13401370062847626945, ; 169: Xamarin.AndroidX.VectorDrawable.dll => 0xb9fb3b1193964ec1 => 91
	i64 13404347523447273790, ; 170: Xamarin.AndroidX.ConstraintLayout.Core => 0xba05cf0da4f6393e => 55
	i64 13454009404024712428, ; 171: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 101
	i64 13491513212026656886, ; 172: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0xbb3b7bc905569876 => 49
	i64 13572454107664307259, ; 173: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 84
	i64 13647894001087880694, ; 174: System.Data.dll => 0xbd670f48cb071df6 => 102
	i64 13710614125866346983, ; 175: System.Security.AccessControl.dll => 0xbe45e2e7d0b769e7 => 35
	i64 13959074834287824816, ; 176: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 64
	i64 13967638549803255703, ; 177: Xamarin.Forms.Platform.Android => 0xc1d70541e0134797 => 97
	i64 14124974489674258913, ; 178: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 52
	i64 14172845254133543601, ; 179: Xamarin.AndroidX.MultiDex => 0xc4b00faaed35f2b1 => 78
	i64 14261073672896646636, ; 180: Xamarin.AndroidX.Print => 0xc5e982f274ae0dec => 83
	i64 14486659737292545672, ; 181: Xamarin.AndroidX.Lifecycle.LiveData => 0xc90af44707469e88 => 71
	i64 14644440854989303794, ; 182: Xamarin.AndroidX.LocalBroadcastManager.dll => 0xcb3b815e37daeff2 => 76
	i64 14669215534098758659, ; 183: Microsoft.Extensions.DependencyInjection.dll => 0xcb9385ceb3993c03 => 14
	i64 14792063746108907174, ; 184: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 101
	i64 14852515768018889994, ; 185: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 59
	i64 14858066545377347572, ; 186: NPOI.OOXML.dll => 0xce3274cd365507f4 => 19
	i64 14912225920358050525, ; 187: System.Security.Principal.Windows => 0xcef2de7759506add => 39
	i64 14935719434541007538, ; 188: System.Text.Encoding.CodePages.dll => 0xcf4655b160b702b2 => 112
	i64 14954917835170835695, ; 189: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xcf8a8a895a82ecef => 13
	i64 14987728460634540364, ; 190: System.IO.Compression.dll => 0xcfff1ba06622494c => 29
	i64 14988210264188246988, ; 191: Xamarin.AndroidX.DocumentFile => 0xd000d1d307cddbcc => 61
	i64 15153329530785360422, ; 192: NPOI.OpenXml4Net => 0xd24b70ec26e5ea26 => 20
	i64 15370334346939861994, ; 193: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 58
	i64 15374721689732342189, ; 194: UDUNT-TimeTable.Android => 0xd55dfbeb04fd61ad => 0
	i64 15391712275433856905, ; 195: Microsoft.Extensions.DependencyInjection.Abstractions => 0xd59a58c406411f89 => 13
	i64 15582737692548360875, ; 196: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 74
	i64 15609085926864131306, ; 197: System.dll => 0xd89e9cf3334914ea => 27
	i64 15777549416145007739, ; 198: Xamarin.AndroidX.SlidingPaneLayout.dll => 0xdaf51d99d77eb47b => 86
	i64 15810740023422282496, ; 199: Xamarin.Forms.Xaml => 0xdb6b08484c22eb00 => 99
	i64 16154507427712707110, ; 200: System => 0xe03056ea4e39aa26 => 27
	i64 16337011941688632206, ; 201: System.Security.Principal.Windows.dll => 0xe2b8b9cdc3aa638e => 39
	i64 16565028646146589191, ; 202: System.ComponentModel.Composition.dll => 0xe5e2cdc9d3bcc207 => 107
	i64 16621146507174665210, ; 203: Xamarin.AndroidX.ConstraintLayout => 0xe6aa2caf87dedbfa => 56
	i64 16677317093839702854, ; 204: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 81
	i64 16822611501064131242, ; 205: System.Data.DataSetExtensions => 0xe975ec07bb5412aa => 104
	i64 16833383113903931215, ; 206: mscorlib => 0xe99c30c1484d7f4f => 17
	i64 17024911836938395553, ; 207: Xamarin.AndroidX.Annotation.Experimental.dll => 0xec44a31d250e5fa1 => 45
	i64 17031351772568316411, ; 208: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 79
	i64 17037200463775726619, ; 209: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xec704b8e0a78fc1b => 67
	i64 17187273293601214786, ; 210: System.ComponentModel.Annotations.dll => 0xee8575ff9aa89142 => 110
	i64 17523946658117960076, ; 211: System.Security.Cryptography.ProtectedData.dll => 0xf33190a3c403c18c => 113
	i64 17544493274320527064, ; 212: Xamarin.AndroidX.AsyncLayoutInflater => 0xf37a8fada41aded8 => 50
	i64 17608862831326185980, ; 213: Microsoft.IO.RecyclableMemoryStream.dll => 0xf45f3f7307c6c9fc => 15
	i64 17704177640604968747, ; 214: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 75
	i64 17710060891934109755, ; 215: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 73
	i64 17838668724098252521, ; 216: System.Buffers.dll => 0xf78faeb0f5bf3ee9 => 24
	i64 17882897186074144999, ; 217: FormsViewGroup => 0xf82cd03e3ac830e7 => 8
	i64 17892495832318972303, ; 218: Xamarin.Forms.Xaml.dll => 0xf84eea293687918f => 99
	i64 17928294245072900555, ; 219: System.IO.Compression.FileSystem.dll => 0xf8ce18a0b24011cb => 106
	i64 17958341848870185232, ; 220: Microsoft.IO.RecyclableMemoryStream => 0xf938d8c3a0f06910 => 15
	i64 18116111925905154859, ; 221: Xamarin.AndroidX.Arch.Core.Runtime => 0xfb695bd036cb632b => 49
	i64 18121036031235206392, ; 222: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 79
	i64 18129453464017766560, ; 223: System.ServiceModel.Internals.dll => 0xfb98c1df1ec108a0 => 109
	i64 18146411883821974900, ; 224: System.Formats.Asn1.dll => 0xfbd50176eb22c574 => 28
	i64 18167968008143816341, ; 225: Persistence => 0xfc2196a53812c695 => 3
	i64 18203743254473369877, ; 226: System.Security.Cryptography.Pkcs.dll => 0xfca0b00ad94c6915 => 36
	i64 18305135509493619199, ; 227: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 80
	i64 18318849532986632368, ; 228: System.Security.dll => 0xfe39a097c37fa8b0 => 114
	i64 18356138306718393757, ; 229: UDUNT-TimeTable.Android.dll => 0xfebe1a88f3e3e59d => 0
	i64 18380184030268848184, ; 230: Xamarin.AndroidX.VersionedParcelable => 0xff1387fe3e7b7838 => 92
	i64 18428404840311395189 ; 231: System.Security.Cryptography.Xml.dll => 0xffbed8907bd99375 => 37
], align 16
@assembly_image_cache_indices = local_unnamed_addr constant [232 x i32] [
	i32 63, i32 16, i32 10, i32 53, i32 85, i32 86, i32 7, i32 3, ; 0..7
	i32 72, i32 105, i32 22, i32 66, i32 62, i32 103, i32 9, i32 12, ; 8..15
	i32 98, i32 115, i32 100, i32 48, i32 5, i32 46, i32 74, i32 67, ; 16..23
	i32 30, i32 47, i32 85, i32 44, i32 73, i32 78, i32 51, i32 2, ; 24..31
	i32 62, i32 108, i32 111, i32 70, i32 33, i32 12, i32 57, i32 90, ; 32..39
	i32 34, i32 19, i32 43, i32 40, i32 17, i32 14, i32 82, i32 33, ; 40..47
	i32 35, i32 25, i32 42, i32 96, i32 100, i32 69, i32 45, i32 32, ; 48..55
	i32 9, i32 88, i32 87, i32 31, i32 34, i32 1, i32 84, i32 63, ; 56..63
	i32 30, i32 109, i32 92, i32 110, i32 50, i32 43, i32 87, i32 20, ; 64..71
	i32 97, i32 95, i32 76, i32 42, i32 77, i32 90, i32 89, i32 56, ; 72..79
	i32 26, i32 23, i32 94, i32 54, i32 82, i32 71, i32 28, i32 98, ; 80..87
	i32 8, i32 72, i32 70, i32 51, i32 60, i32 108, i32 112, i32 66, ; 88..95
	i32 41, i32 32, i32 68, i32 37, i32 65, i32 36, i32 41, i32 7, ; 96..103
	i32 96, i32 95, i32 4, i32 102, i32 46, i32 107, i32 21, i32 69, ; 104..111
	i32 104, i32 11, i32 18, i32 111, i32 10, i32 55, i32 81, i32 38, ; 112..119
	i32 89, i32 11, i32 80, i32 106, i32 6, i32 94, i32 47, i32 23, ; 120..127
	i32 21, i32 31, i32 57, i32 77, i32 16, i32 54, i32 103, i32 115, ; 128..135
	i32 4, i32 60, i32 88, i32 58, i32 48, i32 26, i32 40, i32 93, ; 136..143
	i32 59, i32 25, i32 83, i32 93, i32 68, i32 44, i32 1, i32 65, ; 144..151
	i32 113, i32 114, i32 24, i32 91, i32 64, i32 75, i32 61, i32 52, ; 152..159
	i32 29, i32 53, i32 105, i32 6, i32 22, i32 18, i32 38, i32 2, ; 160..167
	i32 5, i32 91, i32 55, i32 101, i32 49, i32 84, i32 102, i32 35, ; 168..175
	i32 64, i32 97, i32 52, i32 78, i32 83, i32 71, i32 76, i32 14, ; 176..183
	i32 101, i32 59, i32 19, i32 39, i32 112, i32 13, i32 29, i32 61, ; 184..191
	i32 20, i32 58, i32 0, i32 13, i32 74, i32 27, i32 86, i32 99, ; 192..199
	i32 27, i32 39, i32 107, i32 56, i32 81, i32 104, i32 17, i32 45, ; 200..207
	i32 79, i32 67, i32 110, i32 113, i32 50, i32 15, i32 75, i32 73, ; 208..215
	i32 24, i32 8, i32 99, i32 106, i32 15, i32 49, i32 79, i32 109, ; 216..223
	i32 28, i32 3, i32 36, i32 80, i32 114, i32 0, i32 92, i32 37 ; 232..231
], align 16

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 8; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 8

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 8
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 8
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 16; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1}
!llvm.ident = !{!2}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{!"Xamarin.Android remotes/origin/d17-5 @ 797e2e13d1706ace607da43703769c5a55c4de60"}
!llvm.linker.options = !{}
