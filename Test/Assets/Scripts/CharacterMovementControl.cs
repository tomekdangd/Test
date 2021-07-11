using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementControl : MonoBehaviour
{
   public GameObject talkCanvas;
   public GameObject buyCanvas;
   public GameObject sellCanvas;
   public GameObject inventoryCanvas;

   public float speed = 10.0f;

   public bool moveAble = true;

   public GameObject interactingNPC;

   // Start is called before the first frame update
   void Start()
   {
   }

   // Update is called once per frame
   void Update()
   {
      if(!moveAble)
      {
         return;
      }
      MovementInput(Time.deltaTime);
      InteractionInput();
   }

   private void MovementInput(float time)
   {
      if (Input.GetKey(KeyCode.W))
      {
         Move(Vector3.forward, time);
      }
      if (Input.GetKey(KeyCode.S))
      {
         Move(Vector3.back, time);
      }
      if (Input.GetKey(KeyCode.A))
      {
         Move(Vector3.left, time);
      }
      if (Input.GetKey(KeyCode.D))
      {
         Move(Vector3.right, time);
      }
   }

   private void Move(Vector3 dir, float time)
   {
      if(!transform.Find("Graphics/body").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Walking"))
      {
         transform.Find("Graphics/body").GetComponent<Animator>().Play("Walking");
      }
      transform.position += dir * speed * time;
   }

   private void InteractionInput()
   {
      if(Input.GetKeyUp(KeyCode.Space))
      {
         GameObject[] npcObjects = GameObject.FindGameObjectsWithTag("NPC");

         for(int i = 0; i < npcObjects.Length; i++)
         {
            if (DistanceBetween(transform.position, npcObjects[i].transform.position) < 2.0f)
            {
               talkCanvas.SetActive(true);
               moveAble = false;
               interactingNPC = npcObjects[i];
            }
         }
      }
      if(Input.GetKeyUp(KeyCode.I))
      {
         inventoryCanvas.SetActive(true);
         moveAble = false;
         inventoryCanvas.GetComponent<InventoryHandler>().Display(gameObject.GetComponent<CharacterInventory>());
      }
   }

   private float DistanceBetween(Vector3 pointA, Vector3 pointB)
   {
      float distance = 0.0f;

      distance = (pointB.x - pointA.x) * (pointB.x - pointA.x) + (pointB.y - pointA.y) * (pointB.y - pointA.y) + (pointB.z - pointA.z) * (pointB.z - pointA.z);

      distance = Mathf.Sqrt(distance);

      return distance;
   }

   public void TalkCanvasClose()
   {
      talkCanvas.SetActive(false);
      moveAble = true;
   }

   public void TalkCanvasTalkOpen()
   {
      talkCanvas.transform.Find("Background").Find("Talk").GetComponent<TMPro.TMP_Text>().text = interactingNPC.GetComponent<NPCMessage>().messages;
      talkCanvas.transform.Find("Background").gameObject.SetActive(true);
      talkCanvas.transform.Find("Interaction").gameObject.SetActive(false);
   }

   public void TalkCanvasTalkClose()
   {
      talkCanvas.transform.Find("Background").gameObject.SetActive(false);
      talkCanvas.transform.Find("Interaction").gameObject.SetActive(true);
      talkCanvas.SetActive(false);
      moveAble = true;
   }

   public void ShowBuyCanvas()
   {
      TalkCanvasTalkClose();
      moveAble = false;
      buyCanvas.SetActive(true);
      buyCanvas.GetComponent<BuyCanvasList>().Display(interactingNPC.GetComponent<CharacterInventory>());
   }

   public void ShowSellCanvas()
   {
      TalkCanvasTalkClose();
      moveAble = false;
      sellCanvas.SetActive(true);
      sellCanvas.GetComponent<SellCanvasList>().Display(interactingNPC.GetComponent<CharacterInventory>());
   }

   public void BuyItem(int idx)
   {
      GetComponent<CharacterInventory>().itemList.Add(interactingNPC.GetComponent<CharacterInventory>().itemList[idx]);
      interactingNPC.GetComponent<CharacterInventory>().itemList.RemoveAt(idx);
   }

   public void CloseBuyCanvas()
   {
      buyCanvas.SetActive(false);
      moveAble = true;
   }

   public void CloseSellCanvas()
   {
      sellCanvas.SetActive(false);
      moveAble = true;
   }

   public void CloseInventoryCanvas()
   {
      inventoryCanvas.SetActive(false);
      moveAble = true;
   }

   public void EquipItem(int idx)
   {
      if(GetComponent<CharacterInventory>().itemList[idx].itemType == Universal.ItemType.EQUIPMENT)
      {
         GetComponent<CharacterEquipment>().EquipItem((Equipment)GetComponent<CharacterInventory>().itemList[idx]);
         GetComponent<CharacterInventory>().itemList.RemoveAt(idx);
      }
   }
}
