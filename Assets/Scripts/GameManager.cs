using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Si usas TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton

    [Header("Valores del jugador")]
    public int lives = 10;
    public int gold = 1000;
    public int score = 0;

    [Header("Referencias UI (opcional por ahora)")]
    public TMP_Text goldText;
    public TMP_Text livesText;
    public TMP_Text scoreText;

    [Header("Referencias UI torres desbloqueadas")]
    public bool[] torres;

    [Header("Referencias precios de torres")]
    public int[] torresPrices;

    [Header("Referencias de mensajes de pantalla")]
    public TMP_Text ordaText;
    public TMP_Text messageAlert;


    private int torreSeleccionada = 0;
    private int numOrda = 0;
    private string message;
    private int LevelCurrent;

    void Awake()
    {
        // Asegurar que solo haya un GameManager
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateUI();
        torres[0] = true;
        LevelCurrent = PlayerPrefs.GetInt("LevelCurrent", 0);
        Debug.Log("ESTE ES EL NIVEEEEEEL" +  LevelCurrent);

    }
    public bool getTower(int i)
    {
        return torres[i];
    }

    public int getTowerPrices(int i)
    { 
        return torresPrices[i]; 
    }

    public void activateTower(int i)
    {
        torres[i] = true;
    }

    public void setSeleccionTorre(int i)
    {
        torreSeleccionada = i;
    }

    public int getSeleccionTorre()
    {
        return torreSeleccionada;
    }


    public int GetGold()
    { 
        return gold; 
    }


    public void AddGold(int amount)
    {
        gold += amount;
        UpdateUI();
    }

    public bool SpendGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            UpdateUI();
            return true;
        }
        return false; // No hay suficiente oro
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    public void LoseLife(int amount)
    {
        lives -= amount;
        UpdateUI();

        if (lives <= 0)
        {
            StartCoroutine(GameOver()); 
        }
    }

    public void setMessage(string message)
    {
        this.message = message;
        UpdateUI();
    }

    public string getMessage()
    {
        return message;
    }

    public void setOrda(int orda)
    {
        this.numOrda = orda;
    }

    public int getOrda()
    {
        return numOrda;
    }

    public void Win()
    {
        StartCoroutine(GameWin());
    }

    IEnumerator GameOver()
    {
        this.message = "GAME OVER";
        UpdateUI();
        yield return new WaitForSeconds(5f);
        this.message = "Volviendo al menú de inicio";
        UpdateUI();
        SceneManager.LoadScene(0);
    }

    IEnumerator GameWin()
    {
        this.message = "GANASTEEE";
        UpdateUI();
        yield return new WaitForSeconds(5f);
        this.message = "Llendo al siguiente nivel";
        UpdateUI();
        PlayerPrefs.SetInt("LevelCurrent", LevelCurrent + 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

    void UpdateUI()
    {
        if (goldText) goldText.text = $"{gold}";
        if (livesText) livesText.text = $"{lives}";
        if (scoreText) scoreText.text = $"{score}";

        if(ordaText) ordaText.text = $"{numOrda}";
        if (messageAlert) messageAlert.text = $"{message}";
    }
}
