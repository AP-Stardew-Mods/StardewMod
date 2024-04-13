using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace CentralStorageInterface;

internal class ModEntry : Mod
{
    /*********
        ** Public methods
        *********/
    /// <summary>The mod entry point, called after the mod is first loaded.</summary>
    /// <param name="helper">Provides simplified APIs for writing mods.</param>
    public override void Entry(IModHelper helper)
    {
        // TODO: Do stuff
        helper.Events.Player.InventoryChanged += this.Test;
    }

    private void Test(object? sender, InventoryChangedEventArgs e)
    {
        if (!Context.IsWorldReady)
            return;

        this.Monitor.Log($"{Game1.player.Name}", LogLevel.Debug);
    }

}
