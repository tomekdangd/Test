using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
   public Equipment equipedHead;
   public Equipment equiptedHand;
   public Equipment equiptedBody;

   public GameObject headHolder;
   public GameObject handHolder;
   public GameObject bodyHolder;

   public void EquipItem(Equipment item)
   {
      if(item.equipmentType == Universal.EquipmentType.HEAD)
      {
         if(equipedHead == null)
         {
            equipedHead = item;
         }
         else
         {
            GetComponent<CharacterInventory>().itemList.Add((Items)equipedHead);
            equipedHead = item;
            GameObject.Destroy(headHolder.transform.GetChild(0).gameObject);
         }
         GameObject obj = GameObject.Instantiate<GameObject>(item.prefab);
         obj.transform.SetParent(headHolder.transform);
         obj.transform.localPosition = Vector3.zero;
         obj.transform.localRotation = Quaternion.identity;
      }
      else if (item.equipmentType == Universal.EquipmentType.BODY)
      {
         if (equiptedBody == null)
         {
            equiptedBody = item;
         }
         else
         {
            GetComponent<CharacterInventory>().itemList.Add((Items)equiptedBody);
            equiptedBody = item;
            GameObject.Destroy(bodyHolder.transform.GetChild(0).gameObject);
         }
         GameObject obj = GameObject.Instantiate<GameObject>(item.prefab);
         obj.transform.SetParent(bodyHolder.transform);
         obj.transform.localPosition = Vector3.zero;
         obj.transform.localRotation = Quaternion.identity;
      }
      else if (item.equipmentType == Universal.EquipmentType.WEAPON)
      {
         if (equiptedHand == null)
         {
            equiptedHand = item;
         }
         else
         {
            GetComponent<CharacterInventory>().itemList.Add((Items)equiptedHand);
            equiptedHand = item;
            GameObject.Destroy(handHolder.transform.GetChild(0).gameObject);
         }
         GameObject obj = GameObject.Instantiate<GameObject>(item.prefab);
         obj.transform.SetParent(handHolder.transform);
         obj.transform.localPosition = Vector3.zero;
         obj.transform.localRotation = Quaternion.identity;
      }
   }

   // Start is called before the first frame update
   void Start()
   {
       
   }

   // Update is called once per frame
   void Update()
   {
       
   }
}
