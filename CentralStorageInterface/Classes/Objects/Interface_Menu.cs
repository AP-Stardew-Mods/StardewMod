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
    public Texture2D itemFrame;

    // Alias
    public int vX;
    public int vY;
    public int vW;
    public int vH;
    
    // Relative Values //


    // BG IClickableMenu //
    public struct bgClickable {
        public int x, y, w, h;
    }

    public bgClickable bgClick;

    // BG Texture //
    public struct bgTexture {
        public int x, y, w, h;
        public Texture2D texture; 
    }

    public bgTexture bgText;
    
    // Middle Third Rectangle 
    public struct middle_third_rect {
        public int x, y, w, h;
    }

    public middle_third_rect mid_third_rect;

    // Number of Boxes
    public int tempBoxCount = 75;
    public int horBoxCount;
    public int vertBoxCount;

    
    
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
        
        

        //this.testTexture = Game1.content.Load<Texture2D>("assets/items/BigCraftables/Central Interface.png");
        //this.testTexture = helper.ModContent.Load<Texture2D>("assets/cat.png");

        calculateTextureValues();

        monitor.Log($"{mid_third_rect.w}", LogLevel.Debug);
 
        
        // Item Frame Init
        this.itemFrame = helper.ModContent.Load<Texture2D>("assets/menu/item_frame.png");
    }


    public override void receiveLeftClick(int x, int y, bool playSound = true)
    {

    }


    public override void update(GameTime time)
    {
        _updateTimer -= (float)time.ElapsedGameTime.TotalSeconds;
    }

    public void calculateTextureValues()
    {
        // Alias
        vX = Game1.viewport.X;
        vY = Game1.viewport.Y;
        vW = Game1.viewport.Width;
        vH = Game1.viewport.Height;

        // bgClick
        bgClick.x = 0;
        bgClick.y = 0;
        bgClick.w = vW;
        bgClick.h = vH;

        // bgText
        bgText.x = bgClick.x + 12;
        bgText.y = bgClick.y + 12;
        bgText.w = bgClick.w - 24;
        bgText.h = bgClick.h - 24;

        // mid_third_rect
        mid_third_rect.x = (bgText.w - ((bgText.w / 2 / 64) * 64)) / 2;
        mid_third_rect.y = bgText.y;
        mid_third_rect.w = (bgText.w / 2 / 64) * 64;;
        mid_third_rect.h = bgText.h;

        // Number of boxes
        horBoxCount = mid_third_rect.w / 64;
        vertBoxCount = (int)Math.Ceiling((double)tempBoxCount / horBoxCount);
    }

    public override void draw(SpriteBatch b)
    {
        base.draw(b);

        // Drawing Stuff //
        // https://learn.microsoft.com/en-us/previous-versions/windows/xna/bb196426(v=xnagamestudio.10) //

        IClickableMenu.drawTextureBox(b, bgClick.x, bgClick.y, bgClick.w, bgClick.h, Color.White);
        b.Draw(Game1.staminaRect, new Rectangle(mid_third_rect.x, mid_third_rect.y, mid_third_rect.w, mid_third_rect.h), Color.Red);

        
        int hor_scale = 0;
        int vert_scale = 0;
        
        for (int frame = 0; frame < tempBoxCount; frame ++)
        {
            
            if ((frame % horBoxCount == 0) && (frame != 0))
            {
                hor_scale = 0;
                vert_scale += 1;
            }
            
            // Draw Item Frame //
            b.Draw(this.itemFrame, new Rectangle(mid_third_rect.x + (64 * hor_scale), mid_third_rect.y + (64 * vert_scale), 64, 64), Color.White);

            hor_scale += 1;
        }
       
        
        // Test Texture Draw //
        //int test_scale = 4;
        //b.Draw(this.testTexture, new Rectangle(this.posX, this.posY, this.customBoxWidth, this.customBoxHeight), Color.White);
        
        this.drawMouse(b);

        // Remove this later lul
        string title = "Bruh";

        float maxTitleWidth = 800f;
        float rightPadding = 100f;
        
        float scale = Math.Min(1f, maxTitleWidth / Game1.dialogueFont.MeasureString(title).X);

        Vector2 titlePosition = new Vector2(
            0 + 0 - rightPadding - maxTitleWidth,
            0 + 40
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
