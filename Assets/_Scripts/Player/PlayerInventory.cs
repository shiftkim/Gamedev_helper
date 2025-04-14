using UnityEngine;
using System;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    private Dictionary<string, int> _items = new Dictionary<string, int>();
    public Action OnInventoryChanged;
    
    private void OnEnable()
    {
        CollectibleItem.OnItemPickedUp += HandleItemPickedUp;
    }
    
    private void OnDisable()
    {
        CollectibleItem.OnItemPickedUp -= HandleItemPickedUp;
    }
    
    private void HandleItemPickedUp(ItemData item)
    {
        string itemId = item.id;
    
        if (_items.TryGetValue(itemId, out int currentAmount) && currentAmount >= item.maxStackSize)
        {
            Debug.Log($"Невозможно подобрать: {item.displayName} (стак полный - {currentAmount}/{item.maxStackSize})");
            return; // Выходим, предмет не добавляется
        }
    
        // Если проверки пройдены, добавляем предмет
        AddItem(item);
        Debug.Log($"Подобран предмет: {item.displayName}");
    }

    private void AddItem(ItemData item, int amount = 1)
    {
        if (item == null) return;
    
        string itemId = item.id;
    
        if (_items.TryGetValue(itemId, out int currentAmount))
        {
            // Предмет уже есть, увеличиваем количество
            int newAmount = Mathf.Min(currentAmount + amount, item.maxStackSize);
            _items[itemId] = newAmount;
        }
        else
        {
            // Добавляем новый предмет, не больше максимального размера стака
            int newAmount = Mathf.Min(amount, item.maxStackSize);
            _items.Add(itemId, newAmount);
        }
    
        OnInventoryChanged?.Invoke();
    }
    
    public int GetItemCount(string itemId)
    {
        if (_items.TryGetValue(itemId, out int count))
            return count;
        return 0;
    }
}