using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace CentralStorageInterface;

public class ModEntry : Mod
{

    internal static IMonitor ModMonitor { get; set; }
    internal new static IModHelper Helper { get; set; }

    internal static ModConfig Config;
    /*********
    ** Public methods
    *********/
    /// <summary>The mod entry point, called after the mod is first loaded.</summary>
    /// <param name="helper">Provides simplified APIs for writing mods.</param>
    public override void Entry(IModHelper helper)
    {


        //helper.Events.Content.AssetRequested += this.OnAssetRequested;
        helper.Events.Input.ButtonPressed += this.OnButtonPressed;
        helper.Events.GameLoop.SaveLoaded += this.OnSaveLoaded;

        CentralInterface.Initialize(this);

    }

    // Private methods
    private void OnAssetRequested()
    {

    }

    private void OnButtonPressed(object? sender, ButtonPressedEventArgs e) 
    {
        // Ignore if player hasn't loaded a save yet
        if (!Context.IsWorldReady)
            return;

        // Print button presses to console
        this.Monitor.Log($"{Game1.player.Name} pressed {e.Button}.", LogLevel.Debug);
    }

    private void OnSaveLoaded(object? sender, EventArgs e)
    {
        foreach(IContentPack contentPack in this.Helper.ContentPacks.GetOwned())
        {
            this.Monitor.Log($"Reading content pack: {contentPack.Manifest.Name} {contentPack.Manifest.Version} from {contentPack.DirectoryPath}");
        }
    }
 

}
