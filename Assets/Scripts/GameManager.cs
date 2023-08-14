using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

//플레이어가 쌓은 점수(타격점수, 최고점수, 적 파괴점수)를 저장한다.
//속성 : 각 점수
//목적 2: 점수 ui 표시
//목적3 : 점수 ui text 초기화

public class GameManager : MonoBehaviour
{

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
    public int bestScore;

    public TMP_Text destroyScoreText;
    public TMP_Text bextScoreText;

    private static GameManager _instance;

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
        bestScore = destroyScore;
        bextScoreText.text = bestScore.ToString();
        Time.timeScale = 0f;
        PlayerPrefs.SetInt("Best Score", bestScore);
    }

    //public void CleanUp()
    //{
    //    // 정리 작업 수행

    //    // 싱글톤 인스턴스 해제
    //    _instance = null;

    //    // 게임 매니저 게임 오브젝트 파괴
    //    Destroy(gameObject);
    //}

    //// 게임 종료 시 호출될 메서드
    //private void OnApplicationQuit()
    //{
    //    CleanUp();
    //}

    //[InitializeOnLoad]
    //public class PlayModeStateListener
    //{
    //    static PlayModeStateListener()
    //    {
    //        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    //    }

    //    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    //    {
    //        if (state == PlayModeStateChange.ExitingPlayMode)
    //        {
    //            // 플레이 모드 종료 시 정리 작업 수행
    //            GameManager.Instance?.CleanUp();
    //        }
    //    }
    //}
}
