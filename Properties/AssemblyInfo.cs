using System.Resources;
using System.Reflection;
using System.Runtime.InteropServices;
using MelonLoader;

[assembly: AssemblyTitle(PlayerModels.BuildInfo.Name)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(PlayerModels.BuildInfo.Company)]
[assembly: AssemblyProduct(PlayerModels.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + PlayerModels.BuildInfo.Author)]
[assembly: AssemblyTrademark(PlayerModels.BuildInfo.Company)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
//[assembly: Guid("")]
[assembly: AssemblyVersion(PlayerModels.BuildInfo.Version)]
[assembly: AssemblyFileVersion(PlayerModels.BuildInfo.Version)]
[assembly: NeutralResourcesLanguage("en")]
[assembly: MelonModInfo(typeof(PlayerModels.PlayerModels), PlayerModels.BuildInfo.Name, PlayerModels.BuildInfo.Version, PlayerModels.BuildInfo.Author, PlayerModels.BuildInfo.DownloadLink)]


// Create and Setup a MelonModGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonModGameAttribute is found or any of the Values for any MelonModGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonModGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonModGame("Stress Level Zero", "BONEWORKS")]