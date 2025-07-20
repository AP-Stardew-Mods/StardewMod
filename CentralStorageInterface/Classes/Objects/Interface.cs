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

    public Interface(String name, Vector2 tile)
    {
	// BIG CRAFTABLEs
	this.bigCraftable.Value = true;
	this.Name = name;
	this.TileLocation = tile;
	Game1.addHUDMessage(new HUDMessage($"Interface Created {this.TileLocation.X}"));
    }
    
       
}
