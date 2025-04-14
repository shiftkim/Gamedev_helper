using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Items/Item")]
public class ItemData : ScriptableObject
{
   public string id;          // Уникальный идентификатор предмета
   public string displayName; // Отображаемое имя
   public Sprite sprite;      // Иконка предмета
   public int maxStackSize = 99;
}
