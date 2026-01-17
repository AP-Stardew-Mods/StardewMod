using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Menus;
using StardewValley.Locations;
using StardewValley.Tools;
using StardewValley.Objects;

#nullable disable

namespace CentralStorageInterface.Classes.Handlers;

public class Item_Handler
{

    //private readonly List<Chest> chests;

    // Temp Location need to pass this in later
    private GameLocation location = Game1.currentLocation;
    
    public Item_Handler (IMonitor monitor)
    {
        monitor.Log("Item Handler Init", LogLevel.Debug);
        monitor.Log($"Current Location: {location.Name}", LogLevel.Debug);
    }

    
}

    

    


    
