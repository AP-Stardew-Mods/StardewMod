using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using SObject = StardewValley.Object;

namespace CentralStorageInterface;


public class Interface : StardewValley.Object
{
    // Constants from Chest.cs
    public const int capacity = 100;
    protected bool _farmerNearby;

    public Interface(String name, Vector2 tile)
    {
	// BIG CRAFTABLEs
	this.bigCraftable.Value = true;
	this.Name = name;
	this.TileLocation = tile;
	Game1.addHUDMessage(new HUDMessage($"Interface Created {this.TileLocation.X}"));
    }

    // From Item.cs
    public override int maximumStackSize() => 1;

    public void interact()
    {
	Game1.addHUDMessage(new HUDMessage($"Interact"));
    }

    
       
}
