using UnityEngine;

[CreateAssetMenu(menuName = "Item/Nouvel Item Consommable", order = 0, fileName = "new conso item")]
public class Item_Usable : Item, IConsommableItem
{
    [Header("Consommable")]
    public int modAmount;

    public AffectedValue affectedValue;
    public enum AffectedValue
    {
        Health,
        Mana
    }
    
    public void Consume()
    {
        switch (affectedValue)
        {
            case AffectedValue.Health:
                PlayerManager.instance.currentHealth += modAmount;
                break;
            
            case AffectedValue.Mana:
                PlayerManager.instance.currentMana += modAmount;
                break;
        }
    }
}
