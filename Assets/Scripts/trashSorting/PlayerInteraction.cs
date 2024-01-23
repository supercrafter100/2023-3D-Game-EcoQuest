using UnityEngine;
using UnityEngine.UI;

namespace trashSorting
{
    public class PlayerInteraction : MonoBehaviour
    {
        public Text interactionText;
        public Text inventoryText;
        public GameManager gameManager;
        public float interactionDistance = 3f;

        private GameObject _currentItem;
        private GameObject _currentBin;
        private Animator _binController;
        private ParticleSystem _goodParticles;
        private ParticleSystem _badParticles;
        private AudioSource _goodAudioSource;
        private AudioSource _badAudioSource;

        // When colliding with other items, a text pop-up appears with instructions
        void OnTriggerEnter(Collider other)
        {
            Inventory inventory = GetComponent<Inventory>();
        
            if (other.CompareTag("TrashItem") && inventory.GetItemInInventory() == null)
            {
                _currentItem = other.gameObject;
                interactionText.text = "Druk op F om het afval op te rapen";
            }
            else if (other.CompareTag("RecyclingBin") && inventory.GetItemInInventory() != null)
            {
                // If we are standing next to a trash can and we have something in our inventory, we first open the lid before showing the text
                _currentBin = other.gameObject;
                _binController = _currentBin.GetComponent<Animator>();
            
            
                if (_binController != null)
                {
                    _binController.SetTrigger("OpenLid");
                }
            
                interactionText.text = "Druk op F om het afval in deze vuilbak te steken";
            }
            else if (other.CompareTag("RecyclingBin"))
            {
                _currentBin = other.gameObject;
                interactionText.text = "Raap afval op van de grond en breng het naar de correcte vuilbak";
            }
        }
    
        // When exiting the collider of items/trash cans, the text pop-up will disappear
        void OnTriggerExit(Collider other)
        {
            if (other.gameObject == _currentItem)
            {
                interactionText.text = "";
                _currentItem = null;
            }
            else if (other.gameObject == _currentBin)
            {
                _binController = other.GetComponent<Animator>();
                if (_binController != null)
                {
                    // Closing the lid if there is an animation
                    _binController.SetTrigger("CloseLid");
                }
            
                // Remove text pop-up
                interactionText.text = "";
                _currentBin = null;
            
            }
            // Sometimes bug with 2 trash cans, where only 1 closes. This resolves that issue
            if (other.CompareTag("RecyclingBin") && !_currentBin)
            {
                _binController = other.GetComponent<Animator>();
                if (_binController != null)
                {
                    _binController.SetTrigger("CloseLid");

                }
            }
            gameManager.InfoMessage(0);
        }

        void Update()
        {
            // Check for player input
            if (Input.GetKeyDown(KeyCode.F))
            {
                Inventory inventory = GetComponent<Inventory>();

                // When the inventory is empty
                if (inventory.GetItemInInventory() == null)
                {
                    // When we are standing next to an item, but not next to a bin
                    if (_currentItem != null && _currentBin == null)
                    {
                        PickUpItem();
                    }
                }
                // When we are standing next to a trash can, 
                else if (_currentBin != null)
                {
                    _goodParticles = _currentBin.transform.Find("GoodParticles")?.GetComponent<ParticleSystem>();
                    _badParticles = _currentBin.transform.Find("BadParticles")?.GetComponent<ParticleSystem>();
                    _goodAudioSource = _currentBin.transform.Find("GoodParticles")?.GetComponent<AudioSource>();
                    _badAudioSource = _currentBin.transform.Find("BadParticles")?.GetComponent<AudioSource>();
                    TryInteracting();
                }
            }

            // Update the inventory display
            UpdateInventoryDisplay();
        }

        void PickUpItem()
        {
            if (_currentItem != null)
            {
                Inventory inventory = GetComponent<Inventory>();
                inventory.AddItemToInventory(_currentItem);
                _currentItem.SetActive(false); // Disable the object temporarily

                // Debug statement for picking up an item
                Debug.Log("Picked up item: " + _currentItem.name);

                // Debug statement for current inventory
                Debug.Log("Current Inventory: " + (inventory.GetItemInInventory() != null ? inventory.GetItemInInventory().name : "Empty"));
                interactionText.text = "";
            }
        }

        void TryInteracting()
        {
            Debug.Log("Trying to interact");

            Inventory inventory = GetComponent<Inventory>();
            GameObject itemInInventory = inventory.GetItemInInventory();

            // Check if we have something in our inventory
            if (itemInInventory != null && _currentBin != null)
            {
                RecyclingBin recyclingBin = _currentBin.GetComponent<RecyclingBin>();
            
                // Make sure the var. recyclingBin is correctly assigned
                if (recyclingBin != null)
                {
                    TrashItem trashItem = itemInInventory.GetComponent<TrashItem>();
                
                    // Make sure the var. trashItem is correctly assigned
                    if (trashItem != null)
                    {
                        // sorting logic
                        if (trashItem.CanBeSorted(recyclingBin.GetBinTag()))
                        {
                            PlayParticles(true);
                        
                            gameManager.IncrementScore(); // Increment the score in GameManager
                            gameManager.InfoMessage(1);
                            Debug.Log("Correctly interacted with item: " + itemInInventory.name + " at bin: " + _currentBin.name);
                        }
                        else
                        {
                            PlayParticles(false);
                            gameManager.DecrementScore(); // Decrement the score in GameManager
                        
                            gameManager.InfoMessage(2);
                            Debug.Log("Incorrectly interacted with item: " + itemInInventory.name + " at bin: " + _currentBin.name);
                        }

                        // Remove and destroy item from inventory
                        inventory.RemoveItemFromInventory();
                    }
                }
            }
        
            // Set everything back to empty
            interactionText.text = "";
            _currentItem = null;
            _currentBin = null;
        }

        void UpdateInventoryDisplay()
        {
            Inventory inventory = GetComponent<Inventory>();
            GameObject itemInInventory = inventory.GetItemInInventory();

            if (itemInInventory != null)
            {
                TrashItem trashItem = itemInInventory.GetComponent<TrashItem>();

                if (trashItem != null)
                {
                    // Display the custom name of the item in the inventory
                    inventoryText.text = "Inventaris: " + trashItem.GetCustomName();
                }
                else
                {
                    // Fallback to default display if no custom name is set
                    inventoryText.text = "Inventaris: " + itemInInventory.name;
                }
            }
            else
            {
                // Display an empty inventory message
                inventoryText.text = "Inventaris: Leeg";
            }
        }

        // We display some particles and play a sound based on good or bad sorting
        void PlayParticles(bool isSuccess)
        {
            if (isSuccess)
            {
                _goodParticles.Play();
                _goodAudioSource.Play();
            }
            else
            {
                _badParticles.Play();
                _badAudioSource.Play();
            }
        }
    }
}