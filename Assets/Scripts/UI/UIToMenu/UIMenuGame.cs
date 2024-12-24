using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuGame : MonoBehaviour
{
    public GameObject FonMenu;
    public void ContinueGame()
    {
        FonMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void PauseGame()
    {
        FonMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void ExitToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
