using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Menus;
using CentralStorageInterface.Classes.Objects;


namespace CentralStorageInterface;

internal sealed class ModEntry : Mod
{


    /*********
     ** Public methods
     *********/
    /// <summary>The mod entry point, called after the mod is first loaded.</summary>
    /// <param name="helper">Provides simplified APIs for writing mods.</param>
    public override void Entry(IModHelper helper)
    {
        //helper.Events.Content.AssetRequested += this.OnAssetRequested;
        helper.Events.Input.ButtonPressed += this.OnButtonPressed;

        // Helper for object list change. Example placing an object
        helper.Events.World.ObjectListChanged += ObjectListChanged;


        helper.Events.World.FurnitureListChanged += FurnitureListChanged;

        

    }


    private void OnButtonPressed(object? sender, ButtonPressedEventArgs e)
    {
        // Ignore if player hasn't loaded a save yet
        if (!Context.IsWorldReady)
            return;
        // Print button presses to console
        this.Monitor.Log($"{Game1.player.Name} pressed {e.Button}.", LogLevel.Debug);

        if (e.Button.IsActionButton())
        {
            Vector2 tile = e.Cursor.Tile;

            if (IsInterfaceOnTile(tile, out StardewValley.Object interfaceObject))
            {

                this.Monitor.Log("Terminal", LogLevel.Debug);
                Interface.OpenInterface(interfaceObject);

                // Test Menu
                Vector2 center = Utility.getTopLeftPositionForCenteringOnScreen(800 + IClickableMenu.borderWidth * 2, 600 + IClickableMenu.borderWidth * 2);
                Interface_Menu testMenu = new Interface_Menu(this.Monitor, (int)center.X, (int)center.Y, 800 + IClickableMenu.borderWidth * 2, 600 + IClickableMenu.borderWidth * 2, true);
                Game1.activeClickableMenu = testMenu;

            }

        }


    // Credit: UltimateStorage System
    private bool IsInterfaceOnTile(Vector2 tile, out StardewValley.Object interfaceObject)
    {
        return (Game1.currentLocation.objects.TryGetValue(tile, out interfaceObject) && interfaceObject.Name == "Central Interface") ||
              (Game1.currentLocation.objects.TryGetValue(tile + new Vector2(0, 1), out interfaceObject) && interfaceObject.Name == "Central Interface");
    }

    private void FurnitureListChanged(object? sender, FurnitureListChangedEventArgs e)
    {

        Monitor.Log($"Placed furniture at {e.Location}");

        // Loop through every furniture objet that was added this frame
        foreach (var obj in e.Added)
        {
            
            StardewValley.Object furniture = obj;
            string locationName = furniture.Location?.NameOrUniqueName ?? e.Location.NameOrUniqueName;
            Vector2 tile = furniture.TileLocation;
            
            Monitor.Log($"Placed object {furniture.Name}");

        
            if (furniture.Name == "JaWoody.CPCentralStorageInterface_Node")
            {
                Node_Handler.addNode(this.Monitor, tile, locationName);
            }
        }


        foreach (var obj in e.Removed)
        {

            StardewValley.Object furniture = obj;
            string locationName = furniture.Location?.NameOrUniqueName ?? e.Location.NameOrUniqueName;
            Vector2 tile = furniture.TileLocation;

            Monitor.Log($"Removed object {furniture.Name}");

        
            if (furniture.Name == "JaWoody.CPCentralStorageInterface_Node")
            {
                Node_Handler.removeNode(this.Monitor, tile, locationName);
            }
        }
    }

        

         
    private void ObjectListChanged(object? sender, ObjectListChangedEventArgs e)
    {
        Monitor.Log($"Placed object at {e.Location}");

        foreach (var pair in e.Added)
        {
            Vector2 tile = pair.Key;
            StardewValley.Object obj = pair.Value;

            Monitor.Log($"Changed object {obj.Name}");


            

            // THIS DOESNT DO ANYTHING
            if (obj.name == "Central Interface")
            {
                Interface testobj = new Interface(obj.name, tile);
            }


        }

    }

}
