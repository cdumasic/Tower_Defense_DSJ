using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mainMenu;
    public GameObject selectionLevel;

    public void OpenOptionsPanel()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        selectionLevel.SetActive(false);
    }

    public void OpenMainMenuPanel()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        selectionLevel.SetActive(false);
    }

    public void OpenSelectionLevelPanel()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        selectionLevel.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Se salio del juego");
        Application.Quit();
    }

    public void Starlevel(int level)
    {
        SceneManager.LoadScene(level);
    }

}
