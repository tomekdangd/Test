using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCanvasList : MonoBehaviour
{
   public List<GameObject> slotList = new List<GameObject>();
   public GameObject pointerObj;
   public int pointer;
   CharacterInventory ci;

   public void Display(CharacterInventory npc, int ptr = 0)
   {
      for(int i = 0; i < slotList.Count; i++)
      {
         slotList[i].GetComponent<Image>().sprite = null;
         slotList[i].transform.Find("Text (TMP)").GetComponent<TMPro.TMP_Text>().text = "";
      }
      if (npc == null)
      {
         return;
      }
      int maxAllowed = slotList.Count;
      pointer = ptr;
      ci = npc;
      pointerObj.transform.SetParent(slotList[pointer].transform.parent);
      pointerObj.transform.localPosition = Vector3.zero;
      if (npc.itemList.Count < maxAllowed)
      {
         maxAllowed = npc.itemList.Count;
      }
      for (int i = 0; i < maxAllowed; i++)
      {
         slotList[i].GetComponent<Image>().sprite = npc.itemList[i].itemIcon;
         slotList[i].transform.Find("Text (TMP)").GetComponent<TMPro.TMP_Text>().text = npc.itemList[i].itemPrice.ToString();
      }
   }

   // Start is called before the first frame update
   void Start()
   {
      
   }

   // Update is called once per frame
   void Update()
   {
      PointerMovementInput();
      BuyInput();
   }

   private void BuyInput()
   {
      if(Input.GetKeyUp(KeyCode.Space))
      {
         if(ci == null)
         {
            return;
         }
         if(pointer < ci.itemList.Count)
         {
            if(GameObject.Find("Character").GetComponent<CharacterInventory>().gold >= ci.itemList[pointer].itemPrice)
            {
               GameObject.Find("Character").GetComponent<CharacterInventory>().gold -= ci.itemList[pointer].itemPrice;
               GameObject.Find("Character").GetComponent<CharacterMovementControl>().BuyItem(pointer);
               Display(ci, pointer);
            }
         }
      }
   }

   private void PointerMovementInput()
   {
      bool moved = false;
      if (Input.GetKeyUp(KeyCode.W))
      {
         pointer -= 3;
         moved = true;
      }
      if (Input.GetKeyUp(KeyCode.S))
      {
         pointer += 3;
         moved = true;
      }
      if (Input.GetKeyUp(KeyCode.A))
      {
         pointer -= 1;
         moved = true;
      }
      if (Input.GetKeyUp(KeyCode.D))
      {
         pointer += 1;
         moved = true;
      }

      if (pointer < 0)
      {
         pointer = 0;
      }
      else if (pointer >= slotList.Count)
      {
         pointer = slotList.Count - 1;
      }
      if (moved)
      {
         pointerObj.transform.SetParent(slotList[pointer].transform.parent);
         pointerObj.transform.localPosition = Vector3.zero;
      }
   }
}
