using UnityEngine;
using TMPro; // Si usas TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton

    [Header("Valores del jugador")]
    public int lives = 10;
    public int gold = 100;
    public int score = 0;

    [Header("Referencias UI (opcional por ahora)")]
    public TMP_Text goldText;
    public TMP_Text livesText;
    public TMP_Text scoreText;

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
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("GAME OVER 🟥");
        // Aquí podrías pausar el juego o mostrar un menú
        Time.timeScale = 0;
    }

    void UpdateUI()
    {
        if (goldText) goldText.text = $"{gold}";
        if (livesText) livesText.text = $"{lives}";
        if (scoreText) scoreText.text = $"{score}";
    }
}
