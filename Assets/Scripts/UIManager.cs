using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private BossHealth healthMan;
    public Slider healthBar;
    public TextMeshProUGUI hpText;

    void Start()
    {
        healthMan = FindObjectOfType<BossHealth>();
    }


    void Update()
    {
        healthBar.maxValue = healthMan.maxHealth;
        healthBar.value = healthMan.currentHealth;
        hpText.text = "Hp: " + healthMan.currentHealth + "/" + healthMan.maxHealth;
    }
}
