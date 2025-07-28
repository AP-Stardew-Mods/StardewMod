using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Menus;
using SObject = StardewValley.Object;


namespace CentralStorageInterface.Classes.Objects;

public class Interface_Menu : StardewValley.Menus.IClickableMenu
{

    public ClickableTextureComponent trashCan;
    public InventoryMenu inventory;

    public float _updateTimer;

    private InventoryMenu playerInventoryMenu; // Player inventory menu
    private int containerWidth = 830; // Width of the main container
    private int containerHeight = 900; // Height of the main container
    private int computerMenuHeight; // Height of the computer menu
    private int inventoryMenuWidth; // Width of the inventory menu
    private int inventoryMenuHeight = 280; // Fixed height for the bottom frame (inventory area)

    //public Interface_Menu(IMonitor monitor) : base()
    //{
    //	monitor.Log("Menu Constructed", LogLevel.Debug);
    //}

    public Interface_Menu(IMonitor monitor, int x, int y, int width, int height, bool showUpperRightCloseButton = false) : base()
    {
        monitor.Log("Better Menu Constructed", LogLevel.Debug);
        inventory = new InventoryMenu(xPositionOnScreen + IClickableMenu.spaceToClearSideBorder + IClickableMenu.borderWidth,
                                      yPositionOnScreen + IClickableMenu.spaceToClearTopBorder + IClickableMenu.borderWidth, playerInventory: true);
        trashCan = new ClickableTextureComponent(
            new Rectangle(
              xPositionOnScreen + width / 3 + 576 + 32,
              yPositionOnScreen + IClickableMenu.borderWidth + IClickableMenu.spaceToClearTopBorder + 192 + 64,
              64,
              104
            ),
            Game1.mouseCursors,
            new Rectangle(564 + Game1.player.trashCanLevel * 18, 102, 18, 26),
            4f
        );

        this.xPositionOnScreen = (Game1.viewport.Width - this.containerWidth) / 2;
        this.yPositionOnScreen = (Game1.viewport.Height - this.containerHeight) / 2;
        // Calculate the height of the computer menu.
        computerMenuHeight = containerHeight - inventoryMenuHeight;

        
    }


    public override void receiveLeftClick(int x, int y, bool playSound = true)
    {

    }


    public override void update(GameTime time)
    {
        _updateTimer -= (float)time.ElapsedGameTime.TotalSeconds;
    }


    public override void draw(SpriteBatch b)
    {
        base.draw(b);


        //IClickableMenu.drawTextureBox(b, this.xPositionOnScreen, this.yPositionOnScreen, containerWidth, computerMenuHeight, Color.White);
        b.Draw(Game1.staminaRect, new Rectangle(this.xPositionOnScreen + 12, this.yPositionOnScreen + 12, containerWidth - 24, computerMenuHeight - 24), Color.Red);
        inventory.draw(b);
        trashCan.draw(b);
    }

}
