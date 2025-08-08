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
    public static int numBasic { get; set; } = 0; //DEFAULT
    public static int numRare { get; set; } = 0; //DEFAULT
    public static int numLegendary { get; set; } = 0; //DEFAULT

    public static int storageBasic { get; } = 10;
    public static int storageRare { get; } = 25;
    public static int storageLegendary { get; } = 50;

    public static void OpenInterface(SObject interfaceObject, IMonitor monitor, IModHelper helper)
    {
        Vector2 center = Utility.getTopLeftPositionForCenteringOnScreen(800 + IClickableMenu.borderWidth * 2, 600 + IClickableMenu.borderWidth * 2);
        Drive_Bay_Menu testMenu = new Drive_Bay_Menu(monitor, helper, (int)center.X, (int)center.Y, 800 + IClickableMenu.borderWidth * 2, 600 + IClickableMenu.borderWidth * 2, true);
        Game1.activeClickableMenu = testMenu;

        Game1.addHUDMessage(new HUDMessage($"Drive Bay Opened: Storage {storageSpace}"));
    }

    public static void DropInItem(Item dropInItem, bool probe)
    {
        switch (dropInItem.Name)
            {
                case "Basic Hard Drive":
                    storageSpace += storageBasic;
                    numBasic += 1;
                    break;
                case "Rare Hard Drive":
                    storageSpace += storageRare;
                    numRare += 1;
                    break;
                case "Legendary Hard Drive":
                    storageSpace += storageLegendary;
                    numLegendary += 1;
                    break;
                default:
                    break;
            }
    }

}
