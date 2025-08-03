using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Menus;
using StardewValley.Locations;
using StardewValley.Tools;
using StardewValley.Objects;

#nullable disable

namespace CentralStorageInterface.Classes.Handlers;

public class Node_Handler
{


    // Struct to Hold All Node Info
    private struct NodeInfo 
    {
        
        private Vector2 Tile;
        private String location;

        public NodeInfo(Vector2 tile, String location)
        {
            Tile = tile;
            this.location = location;
        }

        // Outward facing public getters
        public Vector2 TilePosition => Tile;
        public string LocationName => location;
    }

    // Private declaration for the list of nodes
    // TODO: Figure out how to store this list on save or exit
    private static List<NodeInfo> nodeInfoList = new List<NodeInfo>();
            
    // Empty constructor because its just a helper function
    public Node_Handler()
    {

    }


    // MAIN FUNCTION CALLED FROM Mod_Entry on Furniture Changed Event
    public static void addNode(IMonitor monitor, Vector2 tile, String location)
    {
        
        nodeInfoList.Add(new NodeInfo(tile, location));
        monitor.Log($"Added {tile}, {location}, to node list");
    }


    // MAIN FUNCTION CALLED FROM Mod_Entry on Furniture Changed Event
    public static void removeNode(IMonitor monitor, Vector2 tile, string location)
    {
        // Find the node that matches
        var match = nodeInfoList.FirstOrDefault(n => n.TilePosition == tile && n.LocationName == location);

        if (match.TilePosition != default && match.LocationName != null)
        {
            nodeInfoList.Remove(match);
            monitor.Log($"Removed Node at {tile} in {location} from node list.");
        }
        else
        {
            monitor.Log($"No matching Node found at {tile} in {location} to remove.", LogLevel.Warn);
        }
    }
    


    
}
