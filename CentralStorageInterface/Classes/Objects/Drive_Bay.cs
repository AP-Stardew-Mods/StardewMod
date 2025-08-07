using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using SObject = StardewValley.Object;
using StardewValley.Menus;

namespace CentralStorageInterface.Classes.Objects;


public class Drive_Bay
{

    public static int storageSpace { get; set; } = 10; //DEFAULT

   
    public static void OpenInterface(SObject interfaceObject, IMonitor monitor, IModHelper helper)
    {
        Vector2 center = Utility.getTopLeftPositionForCenteringOnScreen(800 + IClickableMenu.borderWidth * 2, 600 + IClickableMenu.borderWidth * 2);
        Drive_Bay_Menu testMenu = new Drive_Bay_Menu(monitor, helper, (int)center.X, (int)center.Y, 800 + IClickableMenu.borderWidth * 2, 600 + IClickableMenu.borderWidth * 2, true);
        Game1.activeClickableMenu = testMenu;

        Game1.addHUDMessage(new HUDMessage($"Drive Bay Opened: Storage {storageSpace}"));
    }
    

}
