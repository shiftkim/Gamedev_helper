using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
   [SerializeField] private PlayerInventory inventory;
    
   // References to UI elements
   [SerializeField] private TextMeshProUGUI keysCountText;
   [SerializeField] private TextMeshProUGUI coinsCountText;
   [SerializeField] private TextMeshProUGUI potionsCountText;
    
   // IDs of items to track
   [SerializeField] private string keyId = "2";
   [SerializeField] private string coinId = "1";
   [SerializeField] private string potionId = "3";
    
   private void OnEnable()
   {
      // Subscribe to inventory changes
      if (inventory != null)
      {
         inventory.OnInventoryChanged += UpdateUI;
      }
   }
    
   private void OnDisable()
   {
      // Unsubscribe
      if (inventory != null)
      {
         inventory.OnInventoryChanged -= UpdateUI;
      }
   }
    
   private void Start()
   {
      UpdateUI();
   }
    
   public void UpdateUI()
   {
      // Update each text element with the current count
      if (keysCountText != null)
         keysCountText.text = inventory.GetItemCount(keyId).ToString();
            
      if (coinsCountText != null)
         coinsCountText.text = inventory.GetItemCount(coinId).ToString();
            
      if (potionsCountText != null)
         potionsCountText.text = inventory.GetItemCount(potionId).ToString();
   }
}