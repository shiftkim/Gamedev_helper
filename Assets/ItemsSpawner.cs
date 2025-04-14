using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject collectiblePrefab;
    [SerializeField] private ItemData[] itemsToSpawn;
    [SerializeField] private BoxCollider2D spawnArea; 
    
    public GameObject SpawnItem(ItemData itemData, Vector2 position)
    {
        if (itemData == null || collectiblePrefab == null) return null;
        
        GameObject item = Instantiate(collectiblePrefab, position, Quaternion.identity);
        CollectibleItem collectible = item.GetComponent<CollectibleItem>();
        SpriteRenderer spriteRenderer = item.GetComponent<SpriteRenderer>();
        
        if (collectible != null)
        {
            collectible.SetItemData(itemData);
        }
        
        if (spriteRenderer != null && itemData.sprite != null)
        {
            spriteRenderer.sprite = itemData.sprite;
        }
        
        return item;
    }
    
    public void SpawnRandomItemInArea()
    {
        if (itemsToSpawn == null || itemsToSpawn.Length == 0 || spawnArea == null)
        {
            Debug.LogWarning("No items to spawn or area is undefined");
        }
        
        ItemData randomItem = itemsToSpawn[Random.Range(0, itemsToSpawn.Length)];
        
        Vector2 randomPosition = GetRandomPositionInArea();
        
        SpawnItem(randomItem, randomPosition);
    }
    
    private Vector2 GetRandomPositionInArea()
    {
        Vector2 center = spawnArea.bounds.center;
        Vector2 size = spawnArea.bounds.size;
        
        float x = Random.Range(-size.x / 2, size.x / 2);
        float y = Random.Range(-size.y / 2, size.y / 2);
        
        return center + new Vector2(x, y);
    }
    
   
}