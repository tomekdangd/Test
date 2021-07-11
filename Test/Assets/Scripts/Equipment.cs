using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Equipment", order = 1)]
public class Equipment : Items
{
   public Universal.EquipmentType equipmentType;
}
