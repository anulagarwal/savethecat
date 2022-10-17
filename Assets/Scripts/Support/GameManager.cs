using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Properties
    public static GameManager Instance = null;

    [Header("Component Reference")]
    [SerializeField] public GameObject confetti;
    [SerializeField] public List<MonoBehaviour> gameObjects;

    [Header("Game Attributes")]
    [SerializeField] private int currentScore;
    [SerializeField] private int currentLevel;
    [SerializeField] public GameState currentState;

    #endregion

    #region MonoBehaviour Functions
    private void Awake()
    {
        Application.targetFrameRate = 100;
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    private void Start()
    {
        //SwitchCamera(CameraType.MatchStickCamera);
        currentLevel = PlayerPrefs.GetInt("level", 1);       
        UIManager.Instance.UpdateLevel(currentLevel);
        currentState = GameState.Main;
        foreach (MonoBehaviour m in gameObjects)
        {
            m.enabled = false;
        }
    }

    #endregion

    
    public void StartLevel()
    {
        UIManager.Instance.SwitchUIPanel(UIPanelState.Gameplay);       
        currentState = GameState.InGame;
       // TinySauce.OnGameStarted(currentLevel + "");
        foreach(MonoBehaviour m in gameObjects)
        {
            m.enabled = true;
        }
    }
 

    public void WinLevel()
    {
        if (currentState == GameState.InGame)
        {
            //confetti.SetActive(true);
            Invoke("ShowWinUI", 2f);
            Controller.Instance.ShowFinal(true);
            currentState = GameState.Win;
//            TinySauce.OnGameFinished(true, 0);
            PlayerPrefs.SetInt("level", currentLevel + 1);
            currentLevel++;
            confetti.SetActive(true);
            foreach(MonoBehaviour m in gameObjects)
            {
                m.enabled = false;
            }
        }
    }

    public void LoseLevel()
    {
        if (currentState == GameState.InGame)
        {
            Invoke("ShowLoseUI", 2f);
            Controller.Instance.ShowFinal(false);
         //   TinySauce.OnGameFinished(false, 0);
            currentState = GameState.Lose;
            foreach (MonoBehaviour m in gameObjects)
            {
                m.enabled = false;
            }
        }
    }

    #region Scene Management



    public void ChangeLevel()
    {
            SceneManager.LoadScene("Core");       
    }

    #endregion


    #region Public Core Functions

    public void AddScore(int value)
    {
        currentScore += value;
        UIManager.Instance.UpdateScore(currentScore);
    }


    #endregion

    #region Invoke Functions

    void ShowWinUI()
    {
        UIManager.Instance.SwitchUIPanel(UIPanelState.GameWin);
    }

    void ShowLoseUI()
    {
        UIManager.Instance.SwitchUIPanel(UIPanelState.GameLose);
    }
    #endregion
}
