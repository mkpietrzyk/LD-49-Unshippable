using System.Collections;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private IntVariable containersOn;
    [SerializeField] private FloatVariable shipAngle;
    [SerializeField] private FloatVariable timeLeft;

    public BoolVariable gameStarted;
    public BoolVariable gamePaused;
    public BoolVariable gameEnded;
    public StringVariable uiState;
    public SetStringVariableValue setUIVisibility;

    void Start()
    {
        containersOn.Value = 0;
        shipAngle.Value = 0;
        timeLeft.Value = 0;
    }
    void Update()
    {
        if (!gamePaused.Value && gameStarted.Value && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        // if (!gameEnded.Value && (cash.Value < 0 || householdsCount.Value == 30))
        // {
        //     gameEnded.Value = true;
        //     uiState.Value = "EndMenu";
        // }
    }

    private IEnumerator UpdateScore()
    {
        while (gameStarted.Value)
        {
            yield return new WaitForSeconds(5);
            // int cowsHappiness = (int) (cowsCount.Value * 1.5f);
            // int cowsUnhapiness = (householdsCount.Value - cowsCount.Value) * 10;
            // int cowsUnhapinessValue = cowsUnhapiness < 0 ? 0 : cowsUnhapiness;
            // int currentBalance = householdsCount.Value * 20 + cowsCount.Value * cowsHappiness - cowsCount.Value * 5 - (int) connectionDistance.Value - cowsUnhapinessValue;
            // balance.Value = currentBalance;
            // cash.Value += currentBalance;
        }
    }

    public void StartGame()
    {
        gameStarted.Value = true;
        uiState.Value = "PlayerUI";
        SceneManager.LoadScene("Game");
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
        uiState.Value = "PlayerUI";
    }


    public void ReturnToMenu()
    {
        gameStarted.Value = false;
        gameEnded.Value = false;
        uiState.Value = "MainMenu";
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}