using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Menus;
using SObject = StardewValley.Object;
using CentralStorageInterface.Classes.Handlers;

namespace CentralStorageInterface.Classes.Objects;

public class Drive_Bay_Menu : StardewValley.Menus.IClickableMenu
{

    public ClickableTextureComponent trashCan;
    public InventoryMenu inventory;
    private ClickableTextureComponent upArrow;
    private ClickableTextureComponent downArrow;

    private ClickableTextureComponent basicUpArrow;
    private ClickableTextureComponent basicDownArrow;
    
    public float _updateTimer;

    //private InventoryMenu? playerInventoryMenu; 

    // Public
    public int bgPosX;
    public int bgPosY;
    public int posX;
    public int posY;
    public int bgWidth;
    public int bgHeight;
    public int customBoxWidth;
    public int customBoxHeight;
    public Texture2D itemFrame;

    // Alias
    public int vX;
    public int vY;
    public int vW;
    public int vH;
    

    // BG Texture //
    public struct customTextureValues {
        public int x, y, w, h;
        public Texture2D texture; 
    }

    public customTextureValues bgText;

    public struct customRectValues {
        public int x, y, w, h;
        public String textTitle;
    }

    public customRectValues basic_third_rect;
    public customRectValues rare_third_rect;
    public customRectValues legendary_third_rect;
    public customRectValues bgClick;
    
    
    // Number of Boxes
    public int tempBoxCount = 20;
    public int horBoxCount;
    public int vertBoxCount;


    
    public Drive_Bay_Menu(IMonitor monitor, IModHelper helper, int x, int y, int width, int height, bool showUpperRightCloseButton = false) : base()
    {

        // On Creation Default Values
        basic_third_rect.textTitle = $"Basic Drive Bays: {Drive_Bay.Info.numBasic}";
        rare_third_rect.textTitle = $"Rare Drive Bays: {Drive_Bay.Info.numRare}";
        legendary_third_rect.textTitle = $"Legendary Drive Bays: {Drive_Bay.Info.numLegendary}";


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

        // Draws every draw count
        // Can be put in Constructor to only calculate on menu creation instead of update every frame
        calculateTextureValues();

        
        // Item Frame Init
        this.itemFrame = helper.ModContent.Load<Texture2D>("assets/menu/item_frame.png");

        basicUpArrow = new ClickableTextureComponent(new Rectangle(this.xPositionOnScreen, this.yPositionOnScreen, 44, 48), Game1.mouseCursors, new Rectangle(421, 459, 11, 12), 4f);
        basicDownArrow = new ClickableTextureComponent(new Rectangle(this.xPositionOnScreen + width + 16, this.yPositionOnScreen + height - 64, 44, 48), Game1.mouseCursors, new Rectangle(421, 472, 11, 12), 4f);
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

        // Stardew Default Clickable Brown Texture with border
        IClickableMenu.drawTextureBox(b, bgClick.x, bgClick.y, bgClick.w, bgClick.h, Color.White);
        // Default XNA Graphics Rectangle Basic
        b.Draw(Game1.staminaRect, new Rectangle(basic_third_rect.x, basic_third_rect.y, basic_third_rect.w, basic_third_rect.h), Color.Black);
        // Default XNA Graphics Rectangle Rare
        b.Draw(Game1.staminaRect, new Rectangle(rare_third_rect.x, rare_third_rect.y, rare_third_rect.w, rare_third_rect.h), Color.White);

        b.Draw(Game1.staminaRect, new Rectangle(legendary_third_rect.x, legendary_third_rect.y, legendary_third_rect.w, legendary_third_rect.h), Color.Red);
        // Drawing an Item frame to fit the Default rectangle
        int hor_scale = 0;
        int vert_scale = 0;

        //basicUpArrow.draw(b);
        //basicDownArrow.draw(b);

        // Custom text in boxes
        // Text for Basic Hard Drives
        drawCustomText(basic_third_rect.textTitle, 0f, Color.Blue, Color.Blue, 0, 0, basic_third_rect, "left_align");
        // Text for Rare Hard Drives
        drawCustomText(rare_third_rect.textTitle, 0f, Color.Blue, Color.Blue, 0, 0, rare_third_rect, "left_align");
        // Text for Legendary Hard Drives
        drawCustomText(legendary_third_rect.textTitle, 0f, Color.Blue, Color.Blue, 0, 0, legendary_third_rect, "left_align");

        // Draw Mouse
        this.drawMouse(b);

    }


    public void drawCustomText(String title, float rightPadding, Color titleColor, Color titleShadowColor, int offsetX, int offsetY, customRectValues customRect, String align)
    {

        float rawLength = Game1.dialogueFont.MeasureString(title).X;
        //float scale = customRect.w / titleLength;
        float scale = Math.Min(1f, customRect.w / rawLength);
        float alignX = 0f;
        float titleLength = rawLength * scale;
        
        switch (align)
        {
            case "left_align":
                alignX = 0;
                break;
            case "center":
                alignX = (customRect.w / 2f) - (titleLength / 2f);
                break;
            case "right_align":
                alignX = (customRect.w * .9f) - (titleLength / 2f);
                break;
            default:
                alignX = customRect.w * .1f;
                break;
        }
        
        Vector2 titlePosition = new Vector2(
            customRect.x + alignX,
            customRect.y);
        
        Game1.spriteBatch.DrawString(
            Game1.dialogueFont,
            title,
            titlePosition + new Vector2(offsetX, offsetY),
            titleColor,
            0f,
            Vector2.Zero,
            scale,
            SpriteEffects.None,
            0.86f
        );

    }

    //** Function to calculate the relative sizes of all the boxes **//
    public void calculateTextureValues()
    {
        // Alias
        vX = Game1.viewport.X;
        vY = Game1.viewport.Y;
        vW = Game1.viewport.Width;
        vH = Game1.viewport.Height;

        // bgClick
        bgClick.x = (int)(vW * .3);
        bgClick.y = (int)(vH * .3);
        bgClick.w = (int)(vW * .3);
        bgClick.h = (int)(vH * .3);

        // bgText
        bgText.x = bgClick.x + 12;
        bgText.y = bgClick.y + 12;
        bgText.w = bgClick.w - 24;
        bgText.h = bgClick.h - 24;
        
        // basic_third_rect
        basic_third_rect.x = bgText.x;
        basic_third_rect.y = bgText.y;
        basic_third_rect.w = bgText.w;
        basic_third_rect.h = (int)(bgText.h * .3);

        // basic up arrow
        
        
        // rare_third_rect
        rare_third_rect.x = bgText.x;
        rare_third_rect.y = basic_third_rect.y + basic_third_rect.h;
        rare_third_rect.w = bgText.w;
        rare_third_rect.h = basic_third_rect.h;
                
        // legendary_third_rect
        legendary_third_rect.x = bgText.x;
        legendary_third_rect.y = rare_third_rect.y + rare_third_rect.h;
        legendary_third_rect.w = bgText.w;
        legendary_third_rect.h = basic_third_rect.h;
    }


}



