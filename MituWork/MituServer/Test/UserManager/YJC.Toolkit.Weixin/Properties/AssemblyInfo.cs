using System;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin;

// 有关程序集的常规信息通过以下
// 特性集控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("YJC.Toolkit.Weixin")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("YJC.Toolkit.Weixin")]
[assembly: AssemblyCopyright("Copyright ©  2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: NeutralResourcesLanguage("zh-Hans")]
[assembly: CLSCompliant(true)]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("e5e9fd03-71f4-43b9-9020-456132428d7e")]

// 程序集的版本信息由下面四个值组成:
//
//      主版本
//      次版本 
//      生成号
//      修订号
//
// 可以指定所有这些值，也可以使用“生成号”和“修订号”的默认值，
// 方法是按如下所示使用“*”:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("5.0.0.0")]
[assembly: AssemblyFileVersion("5.0.0.0")]

[assembly: InternalsVisibleTo("YJC.Toolkit.Weixin.Data, PublicKey=00240000048000009400000006020000"
+ "00240000525341310004000001000100CFD581E82257611BA519160619FD26B7"
+ "FAB3EE8B69D29E3662F2D0FA16D0CCFF5483F375BE6BA603B06479B3AB4D6FDB"
+ "1D1CF6C3D6195AE980783ACD2267064A4366B9A3CD10DFC29BFF259058D07085"
+ "4807DFE5A9DD79F49F58245DDAB1573D8BC42F18479F224B3525EB104AEE31E9"
+ "973CA69E2285F9F991D65BE62AC07AE8")]
[assembly: InternalsVisibleTo("YJC.Toolkit.Weixin.Web, PublicKey=00240000048000009400000006020000"
+ "00240000525341310004000001000100CFD581E82257611BA519160619FD26B7"
+ "FAB3EE8B69D29E3662F2D0FA16D0CCFF5483F375BE6BA603B06479B3AB4D6FDB"
+ "1D1CF6C3D6195AE980783ACD2267064A4366B9A3CD10DFC29BFF259058D07085"
+ "4807DFE5A9DD79F49F58245DDAB1573D8BC42F18479F224B3525EB104AEE31E9"
+ "973CA69E2285F9F991D65BE62AC07AE8")]
[assembly: InternalsVisibleTo("WeMenuUtil, PublicKey="
+ "0024000004800000940000000602000000240000525341310004000001000100"
+ "6DF60669C3F04404032D4E5122C26F1AAFEEAD7676E0C737FF2208FFDDC7B40A"
+ "E6483FCF520947E4D953121C6F4E759AFAB5E5441E2315FBB6B1975410396EAF"
+ "3F8CFA70C1167AEEE69732055B9A4DDBEB5DC6FBA95D0275A3B85641E9D75F98"
+ "E4F8964C4EE9A4C2BFB848C0C3755BA7A0CF294BEA83A290CB764FDE56009DB9")]
[assembly: InternalsVisibleTo("WeUserTool, PublicKey="
+ "0024000004800000940000000602000000240000525341310004000001000100"
+ "6DF60669C3F04404032D4E5122C26F1AAFEEAD7676E0C737FF2208FFDDC7B40A"
+ "E6483FCF520947E4D953121C6F4E759AFAB5E5441E2315FBB6B1975410396EAF"
+ "3F8CFA70C1167AEEE69732055B9A4DDBEB5DC6FBA95D0275A3B85641E9D75F98"
+ "E4F8964C4EE9A4C2BFB848C0C3755BA7A0CF294BEA83A290CB764FDE56009DB9")]

[assembly: Initialization(typeof(WeixinInitialization))]
//[assembly: AssemblyPlugInFactory(typeof(MatchRuleConfigFactory))]
//[assembly: AssemblyPlugInFactory(typeof(ReplyMessageConfigFactory))]
//[assembly: AssemblyPlugInFactory(typeof(RulePlugInFactory))]
//[assembly: AssemblyPlugInFactory(typeof(ReplyMessagePlugInFactory))]
//[assembly: AssemblyPlugInFactory(typeof())]
//[assembly: AssemblyPlugInFactory(typeof())]
//[assembly: AssemblyPlugInFactory(typeof())]