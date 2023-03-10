using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Momo;
public class GameManager : MonoBehaviour
{
    #region Properties
    public static GameManager Instance = null;

    [Header("Component Reference")]
    [SerializeField] public GameObject confetti;
    [SerializeField] public List<MonoBehaviour> gameObjects;
    [SerializeField] public AudioSource win;


    [Header("Game Attributes")]
    [SerializeField] private int currentScore;
    [SerializeField] private int currentLevel;
    [SerializeField] public GameState currentState;

    [Header ("Ad 1=Appodeal, 2=GD")]
    [SerializeField] public int adType=1;


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
        adType = 1;
        //SwitchCamera(CameraType.MatchStickCamera);
        currentLevel = PlayerPrefs.GetInt("level", 1);       
        UIManager.Instance.UpdateLevel(currentLevel);
        currentState = GameState.Main;
        foreach (MonoBehaviour m in gameObjects)
        {
            m.enabled = false;
        }

        //Appodeal
        if (adType == 1)
        {
            GetComponent<AdManager>().ShowBanner();
            GetComponent<AdManager>().LoadAd();
        }
        else if(adType == 2)
        {
            GetComponent<AdManager>().PreloadRewardedAd();
        }

        StartLevel();
    }

    #endregion
    public void EnableObjects()
    {
        foreach (MonoBehaviour m in gameObjects)
        {
            m.enabled = true;
        }

    }

    public void DisableObjects()
    {
        foreach (MonoBehaviour m in gameObjects)
        {
            m.enabled = false;
        }
    }

    public void StartLevel()
    {
        UIManager.Instance.SwitchUIPanel(UIPanelState.Gameplay);       
        currentState = GameState.InGame;
        // TinySauce.OnGameStarted(currentLevel + "");
        foreach(MonoBehaviour m in gameObjects)
        {
            m.enabled = true;
        }

        if (adType == 1)
        {
            GetComponent<AdManager>().ShowBanner();
        }
        else if (adType == 2)
        {
            GetComponent<AdManager>().ShowAd();
        }
        Analytics.Instance.StartLevel(currentLevel);

    }


    public void WinLevel()
    {
        if (currentState == GameState.InGame)
        {
            //confetti.SetActive(true);
            Invoke("ShowWinUI", 3f);
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


           


            if (adType == 1)
            {
                if (currentLevel > 1)
                {
                    GetComponent<AdManager>().ShowInterstitial();
                }
            }
            else if (adType == 2)
            {
                GetComponent<AdManager>().ShowAd();
            }


            Analytics.Instance.WinLevel();

        }
    }

    public void LoseLevel()
    {
        if (currentState == GameState.InGame)
        {
            Invoke("ShowLoseUI", 3f);
            Controller.Instance.ShowFinal(false);
            currentState = GameState.Lose;
            foreach (MonoBehaviour m in gameObjects)
            {
                m.enabled = false;
            }

            if (adType == 1)
            {
                if (currentLevel > 1)
                {
                    GetComponent<AdManager>().ShowInterstitial();
                }
            }
            else if (adType == 2)
            {
                GetComponent<AdManager>().ShowAd();
            }

            Analytics.Instance.LoseLevel();
        }

    }

    #region Scene Management


    public void AddInk()
    {
        GetComponent<AdManager>().ShowRewardedAd();

    }

    public void AddFinalInk()
    {

        GetComponentInChildren<DrawingManager>().lenghLimit += 5;
        win.Play();
    }
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
