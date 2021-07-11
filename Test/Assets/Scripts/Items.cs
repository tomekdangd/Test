using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item", order = 1)]
public class Items : ScriptableObject
{
   public string itemName;
   public int itemPrice;
   public Sprite itemIcon;
   public GameObject prefab;
   public int itemID;
   public Universal.ItemType itemType;
}
