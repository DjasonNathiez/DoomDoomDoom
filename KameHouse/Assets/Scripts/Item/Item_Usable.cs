using UnityEngine;

[CreateAssetMenu(menuName = "Item/Nouvel Item Consommable", order = 0, fileName = "new conso item")]
public class Item_Usable : Item
{
    [Header("Consommable")]
    public int modAmount;

    public AffectedValue affectedValue;
    public enum AffectedValue
    {
        Health,
        Mana
    }
}
