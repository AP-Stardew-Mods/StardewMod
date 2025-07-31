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

    // Public
    public int bgPosX;
    public int bgPosY;
    public int posX;
    public int posY;
    public int bgWidth;
    public int bgHeight;
    public int customBoxWidth;
    public int customBoxHeight;
    public Texture2D testTexture; 
    
    public Interface_Menu(IMonitor monitor, IModHelper helper, int x, int y, int width, int height, bool showUpperRightCloseButton = false) : base()
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

        // TODO make these percentages not hardcoded values
        
        // Position of Background and Foreground
        this.bgPosX = 10;
        this.bgPosY = 10;
        this.posX = this.bgPosX + 12;
        this.posY = this.bgPosY + 12;

        // Width and Height of Background and Foreground
        this.bgWidth = Game1.viewport.Width - 10;
        this.bgHeight = Game1.viewport.Height - 10;
        this.customBoxWidth = this.bgWidth - 24;
        this.customBoxHeight = this.bgHeight - 24;

        //this.testTexture = Game1.content.Load<Texture2D>("assets/items/BigCraftables/Central Interface.png");
        this.testTexture = helper.ModContent.Load<Texture2D>("assets/Central Interface.png");
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

        // Drawing Stuff //
        // https://learn.microsoft.com/en-us/previous-versions/windows/xna/bb196426(v=xnagamestudio.10) //

        IClickableMenu.drawTextureBox(b, this.bgPosX, this.bgPosY, this.bgWidth, this.bgHeight, Color.White);
        b.Draw(Game1.staminaRect, new Rectangle(this.posX, this.posY, this.customBoxWidth, this.customBoxHeight), Color.Black);

        // Test Texture Draw //
        int test_scale = 4;
        b.Draw(this.testTexture, new Rectangle(100, 100, 16 * test_scale, 32 * test_scale), Color.White);
        
        this.drawMouse(b);

        // Remove this later lul
        string title = "Bruh";

        float maxTitleWidth = 800f;
        float rightPadding = 100f;
        
        float scale = Math.Min(1f, maxTitleWidth / Game1.dialogueFont.MeasureString(title).X);

        Vector2 titlePosition = new Vector2(
            this.posX + this.bgWidth - rightPadding - maxTitleWidth,
            this.posY + 40
        );

        
        Color titleColor = Color.Orange;
        Color titleShadowColor = Color.Brown;
        // ** //
        
        
        // Draw Text Dark Brown Layer
        Game1.spriteBatch.DrawString(
            Game1.dialogueFont,
            title,
            titlePosition + new Vector2(3, 3),
            titleShadowColor,
            0f,
            Vector2.Zero,
            scale,
            SpriteEffects.None,
            0.86f
        );
        // Draw Text Light Brown Layer
        Game1.spriteBatch.DrawString(
            Game1.dialogueFont,
            title,
            titlePosition + new Vector2(0, 0),
            titleColor,
            0f,
            Vector2.Zero,
            scale,
            SpriteEffects.None,
            0.86f
        );
    }

}
