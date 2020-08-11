using System.Resources;
using System.Reflection;
using System.Runtime.InteropServices;
using MelonLoader;

[assembly: AssemblyTitle(PlayerSkins.BuildInfo.Name)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(PlayerSkins.BuildInfo.Company)]
[assembly: AssemblyProduct(PlayerSkins.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + PlayerSkins.BuildInfo.Author)]
[assembly: AssemblyTrademark(PlayerSkins.BuildInfo.Company)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
//[assembly: Guid("")]
[assembly: AssemblyVersion(PlayerSkins.BuildInfo.Version)]
[assembly: AssemblyFileVersion(PlayerSkins.BuildInfo.Version)]
[assembly: NeutralResourcesLanguage("en")]
[assembly: MelonModInfo(typeof(PlayerSkins.PlayerSkins), PlayerSkins.BuildInfo.Name, PlayerSkins.BuildInfo.Version, PlayerSkins.BuildInfo.Author, PlayerSkins.BuildInfo.DownloadLink)]


// Create and Setup a MelonModGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonModGameAttribute is found or any of the Values for any MelonModGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonModGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonModGame("Stress Level Zero", "BONEWORKS")]