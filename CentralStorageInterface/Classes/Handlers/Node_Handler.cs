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

    public struct NodeInfo 
    {
        
        private Vector2 Tile;
        private String location;

        public NodeInfo(Vector2 tile, String location)
        {
            Tile = tile;
            this.location = location;
        }

        public Vector2 TilePosition => Tile;
        public string LocationName => location;
    }

    private static List<NodeInfo> nodeInfoList = new List<NodeInfo>();
    public static int numNodes;
    
    public Node_Handler()
    {
        
    }

    public static void addNode(IMonitor monitor, Vector2 tile, String location)
    {
        
        nodeInfoList.Add(new NodeInfo(tile, location));
        monitor.Log($"Added {tile}, {location}, to node list");
        numNodes += 1;
    }

    public static void removeNode(IMonitor monitor, Vector2 tile, string location)
    {
        // Find the node that matches
        var match = nodeInfoList.FirstOrDefault(n => n.TilePosition == tile && n.LocationName == location);

        if (match.TilePosition != default && match.LocationName != null)
        {
            nodeInfoList.Remove(match);
            monitor.Log($"Removed Node at {tile} in {location} from node list.");
            numNodes -= 1;
        }
        else
        {
            monitor.Log($"No matching Node found at {tile} in {location} to remove.", LogLevel.Warn);
        }

        
    }

    
    public static int getNumNodes()
    {
        return numNodes;
    }

    public static List<NodeInfo> getNodeInfo()
    {
        return nodeInfoList;
    }   
    
}
