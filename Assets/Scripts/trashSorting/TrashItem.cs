using UnityEngine;

namespace trashSorting
{
    public class TrashItem : MonoBehaviour
    {
        [SerializeField]
        private string correctBinTag;

        // Use Tooltip attribute for custom name
        [Tooltip("Custom name for display in inventory")]
        [SerializeField]
        private string customItemName = "DefaultName";

        public bool CanBeSorted(string binTag)
        {
            return correctBinTag == binTag;
        }

        public string GetCustomName()
        {
            return customItemName;
        }
    }
}