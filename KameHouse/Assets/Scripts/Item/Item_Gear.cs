using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Nouvel Item Equipement", order = 0, fileName = "new gear item")]
public class Item_Gear : Item
{
    [Header("Equipement")]
    public GearSlot gearSlot;
    public enum GearSlot { Head, Chest, Legs, Feet }

    public DataElements dataElements;

    public List<SecondaryDataElements> secondariesData;
}