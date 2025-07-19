using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace CentralStorageInterface;

internal sealed class ModEntry : Mod
{

       /*********
    ** Public methods
    *********/
    /// <summary>The mod entry point, called after the mod is first loaded.</summary>
    /// <param name="helper">Provides simplified APIs for writing mods.</param>
    public override void Entry(IModHelper helper)
    {


        //helper.Events.Content.AssetRequested += this.OnAssetRequested;
        helper.Events.Input.ButtonPressed += this.OnButtonPressed;

    }


    private void OnButtonPressed(object? sender, ButtonPressedEventArgs e) 
    {
        // Ignore if player hasn't loaded a save yet
        if (!Context.IsWorldReady)
            return;

        // Print button presses to console
        this.Monitor.Log($"{Game1.player.Name} pressed {e.Button}.", LogLevel.Debug);
    }

 

}
