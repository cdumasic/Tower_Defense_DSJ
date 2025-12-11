using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mainMenu;
    public GameObject selectionLevel;
    private Animator animator;
    [SerializeField] private AnimationClip animacionFinal;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

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
        PlayerPrefs.SetInt("LevelCurrent", level);
        PlayerPrefs.Save();
        StartCoroutine(CambiarEscena());
    }

    IEnumerator CambiarEscena()
    {
        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(animacionFinal.length);
        SceneManager.LoadScene(1);
    }
        

}
