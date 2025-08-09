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
    public struct HardDriveInfo
    {
        public int storageSpace { get; set; }
        public int numBasic { get; set; }
        public int numRare { get; set; }
        public int numLegendary { get; set; }
    }

    public static HardDriveInfo Info = new HardDriveInfo {
        storageSpace = 10,
        numBasic = 0,
        numRare = 0,
        numLegendary = 0
    };

    public static int storageBasic { get; } = 10;
    public static int storageRare { get; } = 25;
    public static int storageLegendary { get; } = 50;

    // Helpers
    public static IMonitor monitor { get; set; }
    public static IModHelper helper { get; set; }

    public static void OpenInterface(SObject interfaceObject)
    {
        Vector2 center = Utility.getTopLeftPositionForCenteringOnScreen(800 + IClickableMenu.borderWidth * 2, 600 + IClickableMenu.borderWidth * 2);
        Drive_Bay_Menu testMenu = new Drive_Bay_Menu(monitor, helper, (int)center.X, (int)center.Y, 800 + IClickableMenu.borderWidth * 2, 600 + IClickableMenu.borderWidth * 2, true);
        Game1.activeClickableMenu = testMenu;

        Game1.addHUDMessage(new HUDMessage($"Drive Bay Opened: Storage {Info.storageSpace}"));
    }

    public static void Interact(StardewValley.Object interfaceObject, IMonitor passMonitor, IModHelper passHelper)
    {
        monitor = passMonitor;
        helper = passHelper;

        if ((Game1.player.ActiveObject != null) && (Game1.player.ActiveObject.Name.Contains("Hard Drive")))
        {
            monitor.Log("Click with Hard Drive");
            Drive_Bay.DropInItem(Game1.player.ActiveObject, true);

            StardewValley.Object heldItem = Game1.player.ActiveObject;

            if (heldItem.Stack > 1)
            {
                Game1.player.ActiveObject.Stack -= 1;
            }
            else
            {

            }
        }
        else
        {
            Drive_Bay.OpenInterface(interfaceObject);
        }
    }

    public static void DropInItem(Item dropInItem, bool probe)
    {
        switch (dropInItem.Name)
            {
                case "Basic Hard Drive":
                    Info.storageSpace += storageBasic;
                    Info.numBasic += 1;
                    break;
                case "Rare Hard Drive":
                    Info.storageSpace += storageRare;
                    Info.numRare += 1;
                    break;
                case "Legendary Hard Drive":
                    Info.storageSpace += storageLegendary;
                    Info.numLegendary += 1;
                    break;
                default:
                    break;
            }
    }

}
