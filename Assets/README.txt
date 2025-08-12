Instructions:
-----------------
Create items:

-----------------
Setup Inventory and items Categories:
- Modify Script "InventoryCategory" in Assets/InventorySystem/SystemScripting

-----------------
Create inventories:

- Access Create Assets Menu (right click on Project panel)
- Navigate: Create/Inventories/GeneralInventory
- (Impirtant) Assign Unique name to the file and in the inspector field
- (Important) Assign corresponding OnInventoryChangedEvent (Void Event) this will be assigned in all references to this inventory to update its changes.
- Fill all other options as desired


-----------------
(Optional) Create collections:

-----------------
Create Events (I.e. To add new player inventory):


-----------------
Setup Collectible Objects:
   (This allows items to be collected by player)

- Create an object
- Add component "CollectibleItem"(Script)
- Assign the corresponding Item (ScriptableObject)
- Add and adjust a Collider2D component
- Add a SpriteRenderer component (ideally assign your reference sprite here too)


---------------------------------------------------
---------------------------------------------------
Setup Inventory Manager and UI

-----------------
Setup ItemCollector:
- Create an object child of your player (Or child of a Shared Inventory, for shared inventories create a collector per each player)
- Add a Collider2D component
- Add ItemCollector (Script) component
- (Optional) Assign your player's Collider to use it instead (Even if you assign your player's collider you should add a Collider2D component to this object)
- Add a child object with a sprite and assign as InteractionSign
- Add a PlayerInput component to manage interactions
- Assign corresponding ListOfCollectibleGameObject Event
- If you check Collect On Contact the items will be collected (and removed from scene) as soon as your player makes contact, otherwise when an item is in range the interaction sign will appear and all items in ragne will be collected when you press the interaction button (Keyboard key "e" by default)


-----------------
Setup Inventory Manager:

- Add Inventory Manager prefab from "InventoryPrefabs" folder
- Assign in inspector the inventories you want it to manage
- Check that they match with the player or UI display you desire
++
- Add as child an ItemEventListener prefab (If you used the InventoryManager prefab there's no need to add objects, just assign the correct references in the inspectos)
- Assign the GameEvent (Item Event) that will manage the inventories in this Manager. 
   --- Each Manager should have a different GameEvent
- Create a Unity Event Response in the inspector
   -- Assign your corresponding Inventory Manager
   -- Choose InventoryManager/AddItemToCorrectInventory
++
- Add as child a ListOfCollectibleObjectListener prefab ((If you used the InventoryManager prefab there's no need to add objects, just assign the correct references in the inspectos)
- Assign the GameEvent (ListOfCollectibleObjects Event) that will manage the inventories in this Manager. 
   --- Each Manager should have a different GameEvent
- Create a Unity Event Response in the inspector
   -- Assign your corresponding Inventory Manager
   -- Choose InventoryManager/AddItemFromList


-----------------
Setup Inventory UI:

- Add Inventory Canvas prefab
  -- In each iventory (I.E: General, Album, Stamps) assign the corresponding inventory that matches your InventoryManager
++
- If you didn't use InventoryCanvas prefab:
   --- Create a UI Panel, add a Grid Component to it
   --- Create an object for your inventory and add the component InventoryUIManager (Script)
- Assign the InvSlot prefab and the panel created to the correspondint Inventory
++
- On the prefab "OnInventoryChangedListener": Assign corresponding OnInventoryChangedEvent (Void Event)
- Configure your Open and Close buttons to activate and deactivate corresponding UI objects
- Add to the Open button your "InventoryUIPanel" that holds the component "InventoryUIManager"
- Set its action to InventoryUIManager.UpdateInventoryUI
++
Repeat Steps for each inventory

-----------------
Create Shared Inventories:
- Add a SharedInventory prefab or create an empty object an setup all the above steps for an Inventory UI
- Add the following objects per each Player you want to update here:
  -- ItemCollector
  -- 
- The OnInventoryChangedEventListener debe usar el Event que está asignado al Scriptable Object de Inventario ???????
