using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

//플레이어가 쌓은 점수(타격점수, 최고점수, 적 파괴점수)를 저장한다.
//속성 : 각 점수
//목적 2: 점수 ui 표시
//목적3 : 점수 ui text 초기화

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    _instance = obj.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    public int bestScore;

    public TMP_Text destroyScoreText;
    public TMP_Text bextScoreText;
    public EndingScreen endingScreen;

    private static GameManager _instance;


    private int _destroyScore;
    public int destroyScore
    {
        get { return _destroyScore; }
        set
        {
            _destroyScore = value;
            destroyScoreText.text = _destroyScore.ToString();
        }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        _destroyScore = 0;
        destroyScoreText.text = "0";

        bestScore = PlayerPrefs.GetInt("Best Score");
        bextScoreText.text = bestScore.ToString();
        DontDestroyOnLoad(gameObject);

    }

    public void GameEnd()
    {
        //bestScore = destroyScore;
        //bextScoreText.text = bestScore.ToString();
        Time.timeScale = 0f;
        endingScreen.gameObject.SetActive(true);
        endingScreen.scoreText.text = destroyScoreText.text + "Points";
        if(destroyScore > PlayerPrefs.GetInt("Best Score"))
        {
            PlayerPrefs.SetInt("Best Score", destroyScore);
        }
        
    }

    public void Exit()
    {

    }
    public void ReStart()
    {
        Time.timeScale = 1;
        endingScreen.gameObject.SetActive(false);
        PlayerMove playerMove = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        playerMove.hp = 100;
        destroyScore = 0;
        destroyScoreText.text = "0";
        bextScoreText.text = PlayerPrefs.GetInt("Best Score").ToString();
    }

}
