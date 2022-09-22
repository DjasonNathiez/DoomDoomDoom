using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Nouvel Item Equipement", order = 0, fileName = "new gear item")]
public class Item_Gear : Item, IGearItem
{
    [Header("Equipement")]
    public GearSlot gearSlot;
    public enum GearSlot { Head, Chest, Legs, Feet }

    public DataElements dataElements;

    public List<SecondaryDataElements> secondariesData;
    public void Equip()
    {
        Debug.Log("Equip");
        switch (gearSlot)
        {
            case GearSlot.Head:
                PlayerManager.instance.playerGear.head = this;
                break;
            
            case GearSlot.Feet:
                PlayerManager.instance.playerGear.feet = this;
                break;
            
            case GearSlot.Chest:
                PlayerManager.instance.playerGear.chest = this;
                break;
            
            case GearSlot.Legs:
                PlayerManager.instance.playerGear.legs = this;
                break;
        }
        
    }
}
