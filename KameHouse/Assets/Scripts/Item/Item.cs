using UnityEngine;

[CreateAssetMenu(menuName = "Item/Nouvel Item Camelotte", order = 1, fileName = "new junk item")]
public class Item : ScriptableObject
{
    [Header("Identity")]
    public string itemName;
    public string description;
    public Sprite icon;
    
    [Header("Selling value")]
    public int goldValue;
    public int silverValue;
    public int cooperValue;
    
    public string sellPrice;
    
    [Range(1, 200)] public int stack;

    
    private void OnValidate()
    {
        sellPrice = goldValue + " gold | " + silverValue + " silver | " + cooperValue + " cooper";
    }
}
