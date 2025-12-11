using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionScena : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AnimationClip animacionFinal;
    private int LevelCurrent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        LevelCurrent = PlayerPrefs.GetInt("LevelCurrent", 0);
        Debug.Log("LevelCurrent" + LevelCurrent);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CambiarEscena(LevelCurrent));
    }

    IEnumerator CambiarEscena(int level)
    {
        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(animacionFinal.length + 1f);
        SceneManager.LoadScene(level);
    }
}
