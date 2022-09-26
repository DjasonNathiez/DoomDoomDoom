using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemListener 
{
    void GetItem(Item item)
    {
        if (item.GetType() == typeof(Item_Gear))
        {
            Debug.Log("GEAR");
            Equip((Item_Gear)item);
        }

        if (item.GetType() == typeof(Item_Usable))
        {
            Debug.Log("USABLE");
            Consume((Item_Usable)item);
        }
    }

    private void Consume(Item_Usable consumable)
    {
        switch (consumable.affectedValue)
        {
            case Item_Usable.AffectedValue.Health:
                PlayerManager.instance.currentHealth += consumable.modAmount;
                break;
            
            case Item_Usable.AffectedValue.Mana:
                PlayerManager.instance.currentMana += consumable.modAmount;
                break;
        }
    }

    private void Equip(Item_Gear gear)
    {
        switch (gear.gearSlot)
        {
            case Item_Gear.GearSlot.Head:
                PlayerManager.instance.playerGear.head = gear;
                break;
            
            case Item_Gear.GearSlot.Feet:
                PlayerManager.instance.playerGear.feet = gear;
                break;
            
            case Item_Gear.GearSlot.Chest:
                PlayerManager.instance.playerGear.chest = gear;
                break;
            
            case Item_Gear.GearSlot.Legs:
                PlayerManager.instance.playerGear.legs = gear;
                break;
        }
    }
}
