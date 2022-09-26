using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable, IHealable<int>
{
    public static PlayerManager instance;
    
    [Header("Identity")] 
    public string pseudo;
    public int currentLevel;
    public Classes playerClass;
    public PlayerGear playerGear;

    [Header("Data")] 
    public float currentHealth;
    public float maxHealth;
    public float currentMana;
    public float maxMana;
    
    private void Awake()
    {
        #region Singleton

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        #endregion
    }
    
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        
        if (currentHealth <= 0) Debug.Log("Dead");
    }
    public void Heal(int amount)
    {
        currentHealth += amount;
    }
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