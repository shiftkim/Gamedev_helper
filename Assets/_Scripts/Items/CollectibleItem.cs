using UnityEngine;
using System; 

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    public static Action<ItemData> OnItemPickedUp;

    private SpriteRenderer _spriteRenderer;
    
    public void SetItemData(ItemData newItemData)
    {
        itemData = newItemData;
    
        // Update sprite
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = newItemData.sprite;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        OnItemPickedUp?.Invoke(itemData); 
        Destroy(gameObject);
    }
}