using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static PlayerManager;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    [Header("Pop Up")]
    public GameObject popUpObj;
    public TextMeshProUGUI headerTitleTMP;
    public TextMeshProUGUI subTitleTMP;
    public TextMeshProUGUI infoBlockTMP;
    public TextMeshProUGUI subInfoBlockTMP;
    public TextMeshProUGUI notesTMP;
    [Range(0,1)] public float popUpPadding;

    [Header("Portrait")] 
    public TextMeshProUGUI healthText;
    public Image healthBar;
    public TextMeshProUGUI manaText;
    public Image manaBar;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        UpdateHealth();
        UpdateMana();
    }

    void UpdateHealth()
    {
        healthText.text = PlayerManager.instance.currentHealth + "/" + PlayerManager.instance.maxHealth;
        healthBar.fillAmount = PlayerManager.instance.currentHealth / PlayerManager.instance.maxHealth;
    }

    void UpdateMana()
    {
        manaText.text = PlayerManager.instance.currentMana + "/" + PlayerManager.instance.maxMana;
        manaBar.fillAmount = PlayerManager.instance.currentMana / PlayerManager.instance.maxMana;

    }
}
