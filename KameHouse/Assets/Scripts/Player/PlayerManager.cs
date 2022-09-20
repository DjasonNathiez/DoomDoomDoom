using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Identity")] 
    public string pseudo;
    public int currentLevel;
    public Classes playerClass;
    public PlayerGear playerGear;
}

[Serializable] public class PlayerGear
{
    public Item head;
    public Item chest;
    public Item legs;
    public Item feet;
    public Item weaponLeft;
    public Item weaponRight;
}


/*private Dictionary<string, uint> scores;

private void Start()
{
    scores = new Dictionary<string, uint>();
        
    scores.Add("Jaina", 234125123);
    scores.Add("Aegon", 1234521334);
        
    Debug.Log(scores["Jaina"]);
    Debug.Log(scores["Aegon"]);

    foreach (var VARIABLE in scores)
    {
        if (VARIABLE.Value < 1234521334)
        {
            Debug.Log(VARIABLE.Key);
        }
    }
}*/