using StardewModdingAPI;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CentralStorageInterface
{
    internal class CentralInterface
    {
        

        static IModHelper Helper;
        static IMonitor Monitor;

        internal static void Initialize(IMod ModInstance)
        {
            Helper = ModInstance.Helper;
            Monitor = ModInstance.Monitor;

            Game1.player.addItemByMenuIfNecessary(new StardewValley.Object(StardewValley.Object.);
            
        }

        public static void spawnItem()
        {
            //Item item = new Machine();
            //Game1.player.addItemToInventory(item);
        }
    }
}
