using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{

    public Image[] hearts;
    public int health = 20;
    public int maxHealth = 20;
    private bool flashActive;
    [SerializeField] private float flashLenght = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer playerSprite;
    private PnlControl control;


    private void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        control =  GameObject.FindGameObjectWithTag("PnlControl").GetComponent<PnlControl>();
    }

    private void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        HurtFlash();

         if (health <= 0)
         {
             gameObject.SetActive(false);
             control.kaybettin();
             Time.timeScale = 0.0f;
         }
        
    }

    public void TakeDamage(int amount)
    {
        hearts[health - 1].enabled = false;
        health -= amount;
        flashActive = true;
        flashCounter = flashLenght;
    }

    private void HurtFlash()
    {
        if (flashActive)
        {
            if (flashCounter > flashLenght * .99f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLenght * .82f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLenght * .66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLenght * .49f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLenght * .33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLenght * .16f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }
}