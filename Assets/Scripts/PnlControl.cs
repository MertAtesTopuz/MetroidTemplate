using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PnlControl : MonoBehaviour
{
    public GameObject kaybettin_pnl;
    public GameObject durdur_pnl;
    // public GameObject levelup_pnl;

    private void Start()
    {

    }

    private void Update()
    {

    }

    public void tekrar_oyna_btn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }

    public void menu_don_btn()
    {

        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }

    public void level_btn()
    {

        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void kaybettin()
    {
        Time.timeScale = 0.0f;
        kaybettin_pnl.SetActive(true);

    }

    /* public void levelup()

     {
         Time.timeScale = 0.0f;
         levelup_pnl.SetActive(true);

     }
    */
    public void devam_et_btn()
    {

        Time.timeScale = 1.0f;
        durdur_pnl.SetActive(false);
    }

    public void durdur_btn()
    {

        Time.timeScale = 0.0f;
        durdur_pnl.SetActive(true);
    }
}
