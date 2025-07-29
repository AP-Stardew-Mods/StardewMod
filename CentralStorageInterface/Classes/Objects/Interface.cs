using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using SObject = StardewValley.Object;

namespace CentralStorageInterface.Classes.Objects;


public class Interface
{

    public Interface(String name, Vector2 tile)
    {

    }

    public static void OpenInterface(SObject interfaceObject)
    {
        Game1.addHUDMessage(new HUDMessage("Interface Opened"));
    }

    

}
