90c8ff2 (HEAD -> feature/interface-custom-object, origin/feature/interface-custom-object) Merge pull request #15 from AP-Stardew-Mods/node
dd8fc0e Merge branch 'feature/interface-custom-object' into node
50c6187 Node handler to make a list of all the nodes on the map
d2ba980 changed bounding box to 1 1
a439262 Furniture for Node to walk over it. Added via Data/Furnitutre in [CP]
b5f09bf Merge pull request #14 from AP-Stardew-Mods/Draw-Menu
ea4c2ae Merge pull request #13 from AP-Stardew-Mods/revert-12-Draw-Menu
c704897 (origin/revert-12-Draw-Menu) Revert "Draw menu"
97b9587 (origin/Draw-Menu, Draw-Menu) Item Handler Class
16ea4c6 Merge pull request #12 from AP-Stardew-Mods/Draw-Menu
7aea469 updated frame sprites
6653367 Added Item Handler Class to start getting locations and later chest contents from location
b76a8e1 algorimth to draw boxes up until the edge of the rect and then start on the next row
53603d4 floor mid rect to be multiple of 64 to draw a perfect amount of frames
d88e14e item frame drawn 32x32 at the edge of the middle rect
a4ac843 structs for components x,y,w,h relative to intitial drawn component
aeaa9cd Loading in custom 2D Textures with Smapis helper.ModContent.Load
3c2d424 Moved menu creation to Open Interface Handler
0582f53 Updated textures for Central and Crafting Vanilla Items
512aa0f text title
ac07a03 Custom values for Black box and background
d1d9783 Draw red square with SpriteBatch b.draw()
1120412 one more formatting thing for Interface_Menu
9c82cfa formatting
39f6540 re-re-reformatted
e8fb2b7 Re-reformat
2adfcfe Formatting change
694e343 Interface Menu Handler Object
b3abcd4 Changed tabs to spaces
9b433d9 Merge pull request #11 from AP-Stardew-Mods/Draw-Menu
18e3d34 drew a trashcan to learn b.Draw and Sprite Batch
9ac7d14 Merge pull request #10 from AP-Stardew-Mods/open-menu-on-interact
d653a22 (open-menu-on-interact) Extended IClickableMenu which Game1 is set to upon interaction with the Interface
e49b649 Merge pull request #9 from AP-Stardew-Mods/terminal-open
f15d2f8 (terminal-open) Changed Interface to a helper class not an object class because SMAPI defaults CP objects to vanilla objects
bf7abad open terminal functionality
1430414 created a method to detect when some clicks 'action click' on the the same tile as the terminal object it will produce an output
fabc5b8 Interface Class with just a constructor
15247ea Created object 'Interface' which when created will display a message
f9e800f (feature/content-patcher-item) Merge pull request #6 from AP-Stardew-Mods/practice-event-hook
fd76bb8 (practice-event-hook) printed to console item placed and location using event hook
97963b2 removed files for clean slate
c4c2eaf removed extra manifest
f2115b1 changed manifests to not have spaces
5517a92 added Content patcher files
65844c9 moved [CP] file dir to parent dir to keep them seperate
b42458a (origin/dev, origin/HEAD, dev) Merge pull request #5 from AP-Stardew-Mods/feature/big-craftable-jsons
1d5495c Update CentralStorageInterface Objects.json
4de58a3 Update CentralStorageInterface content.json and Objects.json
d72f1ef Update CentralStorageInterface content.json
1e44c5d Update UniqueID in manifest.json
77cf95f created instances for Node and Crafting interface and updated content.json
d7cd88e Merge pull request #3 from AP-Stardew-Mods/CI-Interface
e1ecec0 Update CentralStorageInterface.csproj
c75ab62 Delete CentralStorageInterface/APIs.cs
48b77fa Delete CentralStorageInterface/IContentPatcherApi.cs
e29faf0 updated [CP]manifest
bb8ed20 folder structure. One folder for assests/items/png
26825bd merge changes
b3745f6 Merge branch 'dev' into CI-Interface
e3dbf07 Merge branch 'main' into dev
10b47ec (origin/main) Merge pull request #4 from AP-Stardew-Mods/feature/interface-item
10eb81c Added item files and set up folder structure to run both mods
ae4de2a Moved assests and object to CP folder, created api, central interface, Icontent classes
4714736 added a content.json for future
b3e16ba Merge branch 'feature/interface-item' into CI-Interface
54f4580 updated test textures from 32x32 -> 16x16
b78ed04 Added new manifest to CP folder. Updated folder structure
23a6670 added more test sprites for CI Interface node and crafting interface
eeadac0 Added asset folder
4c9f786 Merge pull request #2 from AP-Stardew-Mods/dev
bf89764 Merge pull request #1 from AP-Stardew-Mods/feature/base-code-cleanup
f830199 Removed test code from ModEntry
836518c Merge branch 'dev' into feature/base-code-cleanup
2f7b07f Cleaned up base project code
2590cc0 Added concepts folder and started scope diagram
9c2ec77 Scope.drawio
e319506 Test.drawio
5fdfaf9 Added base project files
6c1f2c2 Made some initial updates to manifest.json
e7ec4d3 Added manifest.json
db2f578 Initial commit
