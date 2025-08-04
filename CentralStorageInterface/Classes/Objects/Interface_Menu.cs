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

public class Interface_Menu : StardewValley.Menus.IClickableMenu
{

    public ClickableTextureComponent trashCan;
    public InventoryMenu inventory;

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
    }

    public customRectValues l_third_rect;
    public customRectValues mid_third_rect;
    public customRectValues bgClick;
    
    
    // Number of Boxes
    public int tempBoxCount = 20;
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


    public override void draw(SpriteBatch b)
    {
        base.draw(b);

        // Draws every draw count
        // Can be put in Constructor to only calculate on menu creation instead of update every frame
        calculateTextureValues();

        
        // Drawing Stuff //
        // https://learn.microsoft.com/en-us/previous-versions/windows/xna/bb196426(v=xnagamestudio.10) //

        // Stardew Default Clickable Brown Texture with border
        IClickableMenu.drawTextureBox(b, bgClick.x, bgClick.y, bgClick.w, bgClick.h, Color.White);
        // Default XNA Graphics Rectangle Mid
        b.Draw(Game1.staminaRect, new Rectangle(mid_third_rect.x, mid_third_rect.y, mid_third_rect.w, mid_third_rect.h), Color.Black);
        // Default XNA Graphics Rectangle Left
        b.Draw(Game1.staminaRect, new Rectangle(l_third_rect.x, l_third_rect.y, l_third_rect.w, l_third_rect.h), Color.White);
        // Drawing an Item frame to fit the Default rectangle
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
       
        // Draw Mouse
        this.drawMouse(b);

        // Custom Text
        //drawCustomText("This is a super long message to test the scaling", 0f, Color.Red, Color.Pink, 0, 0, l_third_rect, "center");

        // Drawing number of nodes
        drawCustomText($"Number of Nodes {Node_Handler.getNumNodes()}", 0f, Color.Red, Color.Pink, 0, 0, l_third_rect, "center");

        // Draw node info
        drawNodeRows();
    }

    public void drawNodeRows()
    {
        int numNodes = Node_Handler.getNumNodes();

        for (int i = 0; i <= numNodes - 1; i++)
        {
            String title = $"Node {i} ...... {Node_Handler.getNodeInfo()[i].TilePosition}";
            float rightPadding = 0f;
            Color color = Color.Blue;
            Color shadowColor = Color.Blue;
            int offsetX = 0;
            int offsetY = (50 * i) + 50;
            customRectValues customRect = l_third_rect;
            String align = "left_align";
            
            drawCustomText(title, rightPadding, color, shadowColor, offsetX, offsetY, customRect, align);
        }

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
        
        // left_third_rect
        l_third_rect.x = bgText.x;
        l_third_rect.y = bgText.y;
        l_third_rect.w = mid_third_rect.x - bgText.x;
        l_third_rect.h = bgText.h;
        
        // Number of boxes
        horBoxCount = mid_third_rect.w / 64;
        vertBoxCount = (int)Math.Ceiling((double)tempBoxCount / horBoxCount);
    }


}



