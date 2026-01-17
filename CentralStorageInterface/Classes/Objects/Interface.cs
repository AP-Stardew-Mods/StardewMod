using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using SObject = StardewValley.Object;
using StardewValley.Menus;

namespace CentralStorageInterface.Classes.Objects;


public class Interface
{

    public Interface(String name, Vector2 tile)
    {

    }

    public static void OpenInterface(SObject interfaceObject, IMonitor monitor, IModHelper helper)
    {
        Vector2 center = Utility.getTopLeftPositionForCenteringOnScreen(800 + IClickableMenu.borderWidth * 2, 600 + IClickableMenu.borderWidth * 2);
        Interface_Menu testMenu = new Interface_Menu(monitor, helper, (int)center.X, (int)center.Y, 800 + IClickableMenu.borderWidth * 2, 600 + IClickableMenu.borderWidth * 2, true);
        Game1.activeClickableMenu = testMenu;

    }
    

}
