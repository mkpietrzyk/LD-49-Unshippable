using System.Collections;
using System.Runtime.InteropServices;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private IntVariable containersOn;
    [SerializeField] private FloatVariable shipAngle;
    [SerializeField] private FloatVariable timeLeft;
    [SerializeField] private IntVariable containersGoal;

    public BoolVariable gameStarted;
    public BoolVariable gamePaused;
    public BoolVariable gameEnded;
    public StringVariable uiState;

    void Update()
    {
        if (!gamePaused.Value && gameStarted.Value && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        if (!gameEnded && (timeLeft.Value < 0 || shipAngle.Value > 30))
        {
            gameEnded.Value = true;
            Time.timeScale = 0;
            uiState.Value = "EndMenu";
        }

        if (!gameEnded && containersOn.Value == containersGoal.Value && shipAngle.Value < 30 && timeLeft.Value > 0)
        {
            gameEnded.Value = true;
            Time.timeScale = 0;
            uiState.Value = "EndMenu";
        }

        if (gameStarted)
        {
            if (timeLeft.Value > 0)
            {
                float newTime = timeLeft.Value - Time.deltaTime;
                timeLeft.Value = newTime;    
            }
        }
    }

    public void SelectLevel()
    {
        uiState.Value = "LevelSelectMenu";
    }

    public void StartGame(int index)
    {
        int[] containerGoals = {5, 10, 15, 20};
        int[] timeLeftGoals = {180, 180, 240, 240};

        gameStarted.Value = true;
        uiState.Value = "Game";
        timeLeft.Value = timeLeftGoals[index - 1];
        containersGoal.Value = containerGoals[index - 1];
        SceneManager.LoadScene(index);
    }
    
    public void EnterSandbox()
    {
        uiState.Value = "HTPMenu";
    }

    public void EnterSettings()
    {
        uiState.Value = "SettingsMenu";
    }

    public void PauseGame()
    {
        gamePaused.Value = true;
        Time.timeScale = 0;
        uiState.Value = "PauseMenu";
    }

    public void ResumeGame()
    {
        gamePaused.Value = false;
        Time.timeScale = 1;
        uiState.Value = "Game";
    }


    public void ReturnToMenu()
    {
        gameStarted.Value = false;
        gameEnded.Value = false;
        gamePaused.Value = false;
        uiState.Value = "MainMenu";
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}