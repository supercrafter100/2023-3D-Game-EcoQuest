using UnityEngine;

namespace trashSorting
{
    public class Inventory : MonoBehaviour
    {
    
        private GameObject _itemInInventory;
        private bool _isInventoryFull = false;

        // Custom name for display in inventory
        private string _customItemName = "DefaultName";

        public bool IsInventoryFull()
        {
            return _isInventoryFull;
        }

        public void AddItemToInventory(GameObject item)
        {
            if (!_isInventoryFull)
            {
                _itemInInventory = item;
                _isInventoryFull = true;

                // Get custom name from TrashItem component
                TrashItem trashItem = item.GetComponent<TrashItem>();
                if (trashItem != null)
                {
                    _customItemName = trashItem.GetCustomName();
                }

                item.SetActive(false);

                // Debug statement for adding an item to the inventory
                Debug.Log("Added item to the inventory: " + _customItemName);
            }
            else
            {
                // Debug statement for attempting to add an item to a full inventory
                Debug.Log("Inventory is full. Cannot add another item.");
            }
        }

        public GameObject GetItemInInventory()
        {
            return _itemInInventory;
        }

        public void RemoveItemFromInventory()
        {
            if (_itemInInventory != null)
            {
                _isInventoryFull = false; // Inventory is now empty
                Destroy(_itemInInventory); // Destroy the item from the scene

                // Debug statement for removing an item from the inventory
                Debug.Log("Removed item from the inventory: " + _customItemName);

                _itemInInventory = null;
            }
            else
            {
                // Debug statement for attempting to remove an item from an empty inventory
                Debug.Log("Inventory is already empty. Cannot remove an item.");
            }
        }
    }
}