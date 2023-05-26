; ModuleID = 'obj\Debug\120\android\marshal_methods.x86.ll'
source_filename = "obj\Debug\120\android\marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android"


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
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [232 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 72
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 101
	i32 52239042, ; 2: HtmlAgilityPack => 0x31d1ac2 => 9
	i32 57263871, ; 3: Xamarin.Forms.Core.dll => 0x369c6ff => 96
	i32 65901613, ; 4: MathNet.Numerics => 0x3ed942d => 12
	i32 101534019, ; 5: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 86
	i32 120558881, ; 6: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 86
	i32 127363243, ; 7: ICSharpCode.SharpZipLib => 0x79768ab => 10
	i32 159306688, ; 8: System.ComponentModel.Annotations => 0x97ed3c0 => 110
	i32 165246403, ; 9: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 53
	i32 182336117, ; 10: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 87
	i32 209399409, ; 11: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 51
	i32 230216969, ; 12: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 67
	i32 232815796, ; 13: System.Web.Services => 0xde07cb4 => 108
	i32 242077508, ; 14: NPOI.OpenXml4Net => 0xe6dcf44 => 20
	i32 252843578, ; 15: NPOI.OOXML.dll => 0xf12163a => 19
	i32 261689757, ; 16: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 56
	i32 278686392, ; 17: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 71
	i32 280482487, ; 18: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 65
	i32 318968648, ; 19: Xamarin.AndroidX.Activity.dll => 0x13031348 => 43
	i32 321597661, ; 20: System.Numerics => 0x132b30dd => 31
	i32 331603304, ; 21: SixLabors.Fonts => 0x13c3dd68 => 22
	i32 342366114, ; 22: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 69
	i32 385762202, ; 23: System.Memory.dll => 0x16fe439a => 30
	i32 441335492, ; 24: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 55
	i32 442521989, ; 25: Xamarin.Essentials => 0x1a605985 => 95
	i32 450948140, ; 26: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 64
	i32 465846621, ; 27: mscorlib => 0x1bc4415d => 17
	i32 469710990, ; 28: System.dll => 0x1bff388e => 27
	i32 470165088, ; 29: NPOI.OpenXmlFormats => 0x1c062660 => 21
	i32 476646585, ; 30: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 65
	i32 486930444, ; 31: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 76
	i32 526420162, ; 32: System.Transactions.dll => 0x1f6088c2 => 103
	i32 605376203, ; 33: System.IO.Compression.FileSystem => 0x24154ecb => 106
	i32 627609679, ; 34: Xamarin.AndroidX.CustomView => 0x2568904f => 60
	i32 663517072, ; 35: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 92
	i32 666292255, ; 36: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 48
	i32 690569205, ; 37: System.Xml.Linq.dll => 0x29293ff5 => 41
	i32 709152836, ; 38: System.Security.Cryptography.Pkcs.dll => 0x2a44d044 => 36
	i32 775507847, ; 39: System.IO.Compression => 0x2e394f87 => 29
	i32 803616222, ; 40: UDUNT-TimeTable.Android => 0x2fe635de => 0
	i32 809851609, ; 41: System.Drawing.Common.dll => 0x30455ad9 => 105
	i32 843511501, ; 42: Xamarin.AndroidX.Print => 0x3246f6cd => 83
	i32 928116545, ; 43: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 101
	i32 967690846, ; 44: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 69
	i32 974778368, ; 45: FormsViewGroup.dll => 0x3a19f000 => 8
	i32 1012816738, ; 46: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 85
	i32 1028951442, ; 47: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 13
	i32 1035644815, ; 48: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 47
	i32 1042160112, ; 49: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 98
	i32 1046434417, ; 50: Domain.dll => 0x3e5f5271 => 2
	i32 1052210849, ; 51: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 73
	i32 1098259244, ; 52: System => 0x41761b2c => 27
	i32 1175144683, ; 53: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 90
	i32 1178241025, ; 54: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 80
	i32 1203951334, ; 55: Enums.NET.dll => 0x47c2d6e6 => 7
	i32 1204270330, ; 56: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 48
	i32 1267360935, ; 57: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 91
	i32 1269851834, ; 58: BouncyCastle.Crypto => 0x4bb066ba => 6
	i32 1293217323, ; 59: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 62
	i32 1365406463, ; 60: System.ServiceModel.Internals.dll => 0x516272ff => 109
	i32 1376866003, ; 61: Xamarin.AndroidX.SavedState => 0x52114ed3 => 85
	i32 1395857551, ; 62: Xamarin.AndroidX.Media.dll => 0x5333188f => 77
	i32 1406073936, ; 63: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 57
	i32 1411638395, ; 64: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 33
	i32 1436672683, ; 65: UDUNT-TimeTable.Android.dll => 0x55a1e2ab => 0
	i32 1452070440, ; 66: System.Formats.Asn1.dll => 0x568cd628 => 28
	i32 1460219004, ; 67: Xamarin.Forms.Xaml => 0x57092c7c => 99
	i32 1462112819, ; 68: System.IO.Compression.dll => 0x57261233 => 29
	i32 1469204771, ; 69: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 46
	i32 1488290336, ; 70: SixLabors.ImageSharp.dll => 0x58b58220 => 23
	i32 1542894362, ; 71: Persistence => 0x5bf6b31a => 3
	i32 1551954004, ; 72: Microsoft.IO.RecyclableMemoryStream.dll => 0x5c80f054 => 15
	i32 1560059367, ; 73: Persistence.dll => 0x5cfc9de7 => 3
	i32 1582372066, ; 74: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 61
	i32 1592978981, ; 75: System.Runtime.Serialization.dll => 0x5ef2ee25 => 5
	i32 1596753216, ; 76: BouncyCastle.Crypto.dll => 0x5f2c8540 => 6
	i32 1622152042, ; 77: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 75
	i32 1624863272, ; 78: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 94
	i32 1636350590, ; 79: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 59
	i32 1639515021, ; 80: System.Net.Http.dll => 0x61b9038d => 4
	i32 1657153582, ; 81: System.Runtime => 0x62c6282e => 34
	i32 1658241508, ; 82: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 88
	i32 1658251792, ; 83: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 100
	i32 1670060433, ; 84: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 56
	i32 1729485958, ; 85: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 52
	i32 1766324549, ; 86: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 87
	i32 1773845564, ; 87: UDUNT-TimeTable.dll => 0x69babc3c => 42
	i32 1776026572, ; 88: System.Core.dll => 0x69dc03cc => 26
	i32 1788241197, ; 89: Xamarin.AndroidX.Fragment => 0x6a96652d => 64
	i32 1808609942, ; 90: Xamarin.AndroidX.Loader => 0x6bcd3296 => 75
	i32 1813201214, ; 91: Xamarin.Google.Android.Material => 0x6c13413e => 100
	i32 1818569960, ; 92: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 81
	i32 1867746548, ; 93: Xamarin.Essentials.dll => 0x6f538cf4 => 95
	i32 1878053835, ; 94: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 99
	i32 1885316902, ; 95: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 49
	i32 1919157823, ; 96: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 78
	i32 2011961780, ; 97: System.Buffers.dll => 0x77ec19b4 => 24
	i32 2019465201, ; 98: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 73
	i32 2055257422, ; 99: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 70
	i32 2079903147, ; 100: System.Runtime.dll => 0x7bf8cdab => 34
	i32 2085039813, ; 101: System.Security.Cryptography.Xml.dll => 0x7c472ec5 => 37
	i32 2090596640, ; 102: System.Numerics.Vectors => 0x7c9bf920 => 32
	i32 2097448633, ; 103: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 66
	i32 2126786730, ; 104: Xamarin.Forms.Platform.Android => 0x7ec430aa => 97
	i32 2143465592, ; 105: Microsoft.IO.RecyclableMemoryStream => 0x7fc2b078 => 15
	i32 2198219022, ; 106: MathNet.Numerics.dll => 0x8306290e => 12
	i32 2201231467, ; 107: System.Net.Http => 0x8334206b => 4
	i32 2217644978, ; 108: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 90
	i32 2244775296, ; 109: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 76
	i32 2256548716, ; 110: Xamarin.AndroidX.MultiDex => 0x8680336c => 78
	i32 2261435625, ; 111: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 68
	i32 2265110946, ; 112: System.Security.AccessControl.dll => 0x8702d9a2 => 35
	i32 2279755925, ; 113: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 84
	i32 2315684594, ; 114: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 44
	i32 2383496789, ; 115: System.Security.Principal.Windows.dll => 0x8e114655 => 39
	i32 2400516001, ; 116: Domain => 0x8f14f7a1 => 2
	i32 2409053734, ; 117: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 82
	i32 2435904999, ; 118: System.ComponentModel.DataAnnotations.dll => 0x9130f5e7 => 111
	i32 2465532216, ; 119: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 55
	i32 2471841756, ; 120: netstandard.dll => 0x93554fdc => 1
	i32 2475788418, ; 121: Java.Interop.dll => 0x93918882 => 11
	i32 2501346920, ; 122: System.Data.DataSetExtensions => 0x95178668 => 104
	i32 2505896520, ; 123: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 72
	i32 2544667144, ; 124: Enums.NET => 0x97ac8a08 => 7
	i32 2581819634, ; 125: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 91
	i32 2620871830, ; 126: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 59
	i32 2624644809, ; 127: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 63
	i32 2633051222, ; 128: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 71
	i32 2660759594, ; 129: System.Security.Cryptography.ProtectedData.dll => 0x9e97f82a => 113
	i32 2701096212, ; 130: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 88
	i32 2732626843, ; 131: Xamarin.AndroidX.Activity => 0xa2e0939b => 43
	i32 2737747696, ; 132: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 46
	i32 2765824710, ; 133: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 112
	i32 2766581644, ; 134: Xamarin.Forms.Core => 0xa4e6af8c => 96
	i32 2778768386, ; 135: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 93
	i32 2810250172, ; 136: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 57
	i32 2819470561, ; 137: System.Xml.dll => 0xa80db4e1 => 40
	i32 2841355853, ; 138: System.Security.Permissions => 0xa95ba64d => 38
	i32 2853208004, ; 139: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 93
	i32 2855708567, ; 140: Xamarin.AndroidX.Transition => 0xaa36a797 => 89
	i32 2867946736, ; 141: System.Security.Cryptography.ProtectedData => 0xaaf164f0 => 113
	i32 2903344695, ; 142: System.ComponentModel.Composition => 0xad0d8637 => 107
	i32 2905242038, ; 143: mscorlib.dll => 0xad2a79b6 => 17
	i32 2907560873, ; 144: NPOI.OpenXmlFormats.dll => 0xad4ddba9 => 21
	i32 2916838712, ; 145: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 94
	i32 2919462931, ; 146: System.Numerics.Vectors.dll => 0xae037813 => 32
	i32 2921128767, ; 147: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 45
	i32 2921417940, ; 148: System.Security.Cryptography.Xml => 0xae214cd4 => 37
	i32 2944313911, ; 149: System.Configuration.ConfigurationManager.dll => 0xaf7eaa37 => 25
	i32 2968338931, ; 150: System.Security.Principal.Windows => 0xb0ed41f3 => 39
	i32 2978675010, ; 151: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 62
	i32 3012788804, ; 152: System.Configuration.ConfigurationManager => 0xb3938244 => 25
	i32 3024354802, ; 153: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 67
	i32 3044182254, ; 154: FormsViewGroup => 0xb57288ee => 8
	i32 3057625584, ; 155: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 79
	i32 3103600923, ; 156: System.Formats.Asn1 => 0xb8fd311b => 28
	i32 3111772706, ; 157: System.Runtime.Serialization => 0xb979e222 => 5
	i32 3132293585, ; 158: System.Security.AccessControl => 0xbab301d1 => 35
	i32 3135029042, ; 159: ICSharpCode.SharpZipLib.dll => 0xbadcbf32 => 10
	i32 3178908327, ; 160: SixLabors.Fonts.dll => 0xbd7a4aa7 => 22
	i32 3204380047, ; 161: System.Data.dll => 0xbefef58f => 102
	i32 3211777861, ; 162: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 61
	i32 3213246214, ; 163: System.Security.Permissions.dll => 0xbf863f06 => 38
	i32 3247949154, ; 164: Mono.Security => 0xc197c562 => 115
	i32 3258312781, ; 165: Xamarin.AndroidX.CardView => 0xc235e84d => 52
	i32 3267021929, ; 166: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 50
	i32 3280506390, ; 167: System.ComponentModel.Annotations.dll => 0xc3888e16 => 110
	i32 3284441313, ; 168: SixLabors.ImageSharp => 0xc3c498e1 => 23
	i32 3308639592, ; 169: NPOI.OOXML => 0xc535d568 => 19
	i32 3317135071, ; 170: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 60
	i32 3317144872, ; 171: System.Data => 0xc5b79d28 => 102
	i32 3340431453, ; 172: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 49
	i32 3346324047, ; 173: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 80
	i32 3353484488, ; 174: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 66
	i32 3362522851, ; 175: Xamarin.AndroidX.Core => 0xc86c06e3 => 58
	i32 3366347497, ; 176: Java.Interop => 0xc8a662e9 => 11
	i32 3374999561, ; 177: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 84
	i32 3395150330, ; 178: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 33
	i32 3404865022, ; 179: System.ServiceModel.Internals => 0xcaf21dfe => 109
	i32 3428513518, ; 180: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 14
	i32 3429136800, ; 181: System.Xml => 0xcc6479a0 => 40
	i32 3430777524, ; 182: netstandard => 0xcc7d82b4 => 1
	i32 3441283291, ; 183: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 63
	i32 3476120550, ; 184: Mono.Android => 0xcf3163e6 => 16
	i32 3486566296, ; 185: System.Transactions => 0xcfd0c798 => 103
	i32 3493954962, ; 186: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 54
	i32 3501239056, ; 187: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 50
	i32 3509114376, ; 188: System.Xml.Linq => 0xd128d608 => 41
	i32 3515174580, ; 189: System.Security.dll => 0xd1854eb4 => 114
	i32 3536029504, ; 190: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 97
	i32 3553742135, ; 191: NPOI.dll => 0xd3d1cd37 => 18
	i32 3567349600, ; 192: System.ComponentModel.Composition.dll => 0xd4a16f60 => 107
	i32 3618140916, ; 193: Xamarin.AndroidX.Preference => 0xd7a872f4 => 82
	i32 3627220390, ; 194: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 83
	i32 3632359727, ; 195: Xamarin.Forms.Platform => 0xd881692f => 98
	i32 3633644679, ; 196: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 45
	i32 3641597786, ; 197: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 70
	i32 3645089577, ; 198: System.ComponentModel.DataAnnotations => 0xd943a729 => 111
	i32 3672681054, ; 199: Mono.Android.dll => 0xdae8aa5e => 16
	i32 3676310014, ; 200: System.Web.Services.dll => 0xdb2009fe => 108
	i32 3682565725, ; 201: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 51
	i32 3684561358, ; 202: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 54
	i32 3685196866, ; 203: NPOI.OpenXml4Net.dll => 0xdba7a442 => 20
	i32 3689375977, ; 204: System.Drawing.Common => 0xdbe768e9 => 105
	i32 3718780102, ; 205: Xamarin.AndroidX.Annotation => 0xdda814c6 => 44
	i32 3724971120, ; 206: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 79
	i32 3758932259, ; 207: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 68
	i32 3786282454, ; 208: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 53
	i32 3807198597, ; 209: System.Security.Cryptography.Pkcs => 0xe2ed3d85 => 36
	i32 3810220126, ; 210: HtmlAgilityPack.dll => 0xe31b585e => 9
	i32 3822602673, ; 211: Xamarin.AndroidX.Media => 0xe3d849b1 => 77
	i32 3829621856, ; 212: System.Numerics.dll => 0xe4436460 => 31
	i32 3841636137, ; 213: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 13
	i32 3885922214, ; 214: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 89
	i32 3896760992, ; 215: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 58
	i32 3920810846, ; 216: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 106
	i32 3921031405, ; 217: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 92
	i32 3929912290, ; 218: UDUNT-TimeTable => 0xea3db3e2 => 42
	i32 3931092270, ; 219: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 81
	i32 3945713374, ; 220: System.Data.DataSetExtensions.dll => 0xeb2ecede => 104
	i32 3953953790, ; 221: System.Text.Encoding.CodePages => 0xebac8bfe => 112
	i32 3955647286, ; 222: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 47
	i32 4025784931, ; 223: System.Memory => 0xeff49a63 => 30
	i32 4105002889, ; 224: Mono.Security.dll => 0xf4ad5f89 => 115
	i32 4126470640, ; 225: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 14
	i32 4151237749, ; 226: System.Core => 0xf76edc75 => 26
	i32 4182413190, ; 227: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 74
	i32 4184478168, ; 228: NPOI => 0xf96a11d8 => 18
	i32 4185676441, ; 229: System.Security => 0xf97c5a99 => 114
	i32 4260525087, ; 230: System.Buffers => 0xfdf2741f => 24
	i32 4292120959 ; 231: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 74
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [232 x i32] [
	i32 72, i32 101, i32 9, i32 96, i32 12, i32 86, i32 86, i32 10, ; 0..7
	i32 110, i32 53, i32 87, i32 51, i32 67, i32 108, i32 20, i32 19, ; 8..15
	i32 56, i32 71, i32 65, i32 43, i32 31, i32 22, i32 69, i32 30, ; 16..23
	i32 55, i32 95, i32 64, i32 17, i32 27, i32 21, i32 65, i32 76, ; 24..31
	i32 103, i32 106, i32 60, i32 92, i32 48, i32 41, i32 36, i32 29, ; 32..39
	i32 0, i32 105, i32 83, i32 101, i32 69, i32 8, i32 85, i32 13, ; 40..47
	i32 47, i32 98, i32 2, i32 73, i32 27, i32 90, i32 80, i32 7, ; 48..55
	i32 48, i32 91, i32 6, i32 62, i32 109, i32 85, i32 77, i32 57, ; 56..63
	i32 33, i32 0, i32 28, i32 99, i32 29, i32 46, i32 23, i32 3, ; 64..71
	i32 15, i32 3, i32 61, i32 5, i32 6, i32 75, i32 94, i32 59, ; 72..79
	i32 4, i32 34, i32 88, i32 100, i32 56, i32 52, i32 87, i32 42, ; 80..87
	i32 26, i32 64, i32 75, i32 100, i32 81, i32 95, i32 99, i32 49, ; 88..95
	i32 78, i32 24, i32 73, i32 70, i32 34, i32 37, i32 32, i32 66, ; 96..103
	i32 97, i32 15, i32 12, i32 4, i32 90, i32 76, i32 78, i32 68, ; 104..111
	i32 35, i32 84, i32 44, i32 39, i32 2, i32 82, i32 111, i32 55, ; 112..119
	i32 1, i32 11, i32 104, i32 72, i32 7, i32 91, i32 59, i32 63, ; 120..127
	i32 71, i32 113, i32 88, i32 43, i32 46, i32 112, i32 96, i32 93, ; 128..135
	i32 57, i32 40, i32 38, i32 93, i32 89, i32 113, i32 107, i32 17, ; 136..143
	i32 21, i32 94, i32 32, i32 45, i32 37, i32 25, i32 39, i32 62, ; 144..151
	i32 25, i32 67, i32 8, i32 79, i32 28, i32 5, i32 35, i32 10, ; 152..159
	i32 22, i32 102, i32 61, i32 38, i32 115, i32 52, i32 50, i32 110, ; 160..167
	i32 23, i32 19, i32 60, i32 102, i32 49, i32 80, i32 66, i32 58, ; 168..175
	i32 11, i32 84, i32 33, i32 109, i32 14, i32 40, i32 1, i32 63, ; 176..183
	i32 16, i32 103, i32 54, i32 50, i32 41, i32 114, i32 97, i32 18, ; 184..191
	i32 107, i32 82, i32 83, i32 98, i32 45, i32 70, i32 111, i32 16, ; 192..199
	i32 108, i32 51, i32 54, i32 20, i32 105, i32 44, i32 79, i32 68, ; 200..207
	i32 53, i32 36, i32 9, i32 77, i32 31, i32 13, i32 89, i32 58, ; 208..215
	i32 106, i32 92, i32 42, i32 81, i32 104, i32 112, i32 47, i32 30, ; 216..223
	i32 115, i32 14, i32 26, i32 74, i32 18, i32 114, i32 24, i32 74 ; 232..231
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"NumRegisterParameters", i32 0}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 797e2e13d1706ace607da43703769c5a55c4de60"}
!llvm.linker.options = !{}
