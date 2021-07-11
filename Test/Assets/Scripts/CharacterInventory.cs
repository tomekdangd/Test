using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
   public int gold;
   public List<Items> itemList = new List<Items>();

   // Start is called before the first frame update
   void Start()
   {
      
   }

   // Update is called once per frame
   void Update()
   {
      
   }

   public void AddItem(Items item)
   {
      itemList.Add(item);
   }

   public void RemoveItem(Items item)
   {
      itemList.Remove(item);
   }
}
