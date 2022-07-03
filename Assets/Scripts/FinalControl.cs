using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinalControl : MonoBehaviour
{
    public void MenuDonBtn()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitBtn()
    {
        Application.Quit();
    }
}
