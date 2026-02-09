using UnityEngine;
using TMPro;

public class GameLoopManager : MonoBehaviour
{
    // ===== STATE MACHINE =====
    public enum GameState
    {
        Menu,
        Playing,
        Paused,
        GameOver,
        Victory
    }

    public GameState currentState = GameState.Menu;

    // ===== PLAYER REFERENCE =====
    public GameObject playerObject;

    // ===== UI REFERENCES =====
    public TextMeshProUGUI statsDisplay;
    public TextMeshProUGUI stateDisplay;
    public TextMeshProUGUI instructionsDisplay;

    // ===== GAME VARIABLES =====
    private int frameCount = 0;
    private float currentFPS = 0f;
    private int score = 0;
    private float gameTime = 0f;

    // ===== WIN CONDITION =====
    public int scoreToWin = 5;

    void Start()
    {
        ResetGame();
        currentState = GameState.Menu;

        if (playerObject != null)
            playerObject.SetActive(false);
    }

    void Update()
    {
        currentFPS = 1.0f / Time.deltaTime;

        switch (currentState)
        {
            case GameState.Menu:
                UpdateMenuState();
                break;

            case GameState.Playing:
                UpdatePlayingState();
                break;

            case GameState.Paused:
                UpdatePausedState();
                break;

            case GameState.GameOver:
                UpdateGameOverState();
                break;

            case GameState.Victory:
                UpdateVictoryState();
                break;
        }

        UpdateDisplay();
    }

    // ===== STATE UPDATES =====
    void UpdateMenuState()
    {
        if (playerObject != null)
            playerObject.SetActive(false);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetGame();
            currentState = GameState.Playing;

            if (playerObject != null)
                playerObject.SetActive(true);
        }
    }

    void UpdatePlayingState()
    {
        frameCount++;
        gameTime += Time.deltaTime;

        // ✅ WIN CHECK
        if (score >= scoreToWin)
        {
            currentState = GameState.Victory;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currentState = GameState.Paused;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            currentState = GameState.GameOver;
        }
    }

    void UpdatePausedState()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currentState = GameState.Playing;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentState = GameState.Menu;

            if (playerObject != null)
                playerObject.SetActive(false);
        }
    }

    void UpdateGameOverState()
    {
        if (playerObject != null)
            playerObject.SetActive(false);

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
            currentState = GameState.Playing;

            if (playerObject != null)
            {
                playerObject.SetActive(true);
                playerObject.GetComponent<PlayerHealth>().ResetHealth();
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            currentState = GameState.Menu;
        }
    }

    void UpdateVictoryState()
    {
        if (playerObject != null)
            playerObject.SetActive(false);

        if (Input.GetKeyDown(KeyCode.M))
        {
            currentState = GameState.Menu;
        }
    }

    // ===== UI DISPLAY =====
    void UpdateDisplay()
{
    if (statsDisplay != null)
    {
        statsDisplay.text =
            "FPS: " + currentFPS.ToString("F0") + "\n" +
            "Frame: " + frameCount + "\n" +
            "Score: " + score + " / " + scoreToWin;
    }

    if (stateDisplay != null)
    {
        stateDisplay.text = "STATE: " + currentState.ToString().ToUpper();
    }

    if (instructionsDisplay != null)
    {
        string instructions = "";

        switch (currentState)
        {
            case GameState.Menu:
                instructions = "Press SPACE to Start";
                break;

            case GameState.Playing:
                instructions =
                    "Arrow Keys: Move | ESC: Pause\n" +
                    "Collect " + scoreToWin + " items to win!";
                break;

            case GameState.Paused:
                instructions = "ESC: Resume | Q: Quit to Menu";
                break;

            case GameState.GameOver:
                instructions = "GAME OVER!\nR: Retry | M: Menu";
                break;

            case GameState.Victory:
                instructions = "VICTORY!\nYou collected all items!\nM: Menu";
                break;
        }

        instructionsDisplay.text = instructions;
    }
}
    // ===== HELPERS =====
    void ResetGame()
    {
        frameCount = 0;
        score = 0;
        gameTime = 0f;
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int n)
    {
        score += n;
    }
}