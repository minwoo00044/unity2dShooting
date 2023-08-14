using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

//�÷��̾ ���� ����(Ÿ������, �ְ�����, �� �ı�����)�� �����Ѵ�.
//�Ӽ� : �� ����
//���� 2: ���� ui ǥ��
//����3 : ���� ui text �ʱ�ȭ

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
    //    // ���� �۾� ����

    //    // �̱��� �ν��Ͻ� ����
    //    _instance = null;

    //    // ���� �Ŵ��� ���� ������Ʈ �ı�
    //    Destroy(gameObject);
    //}

    //// ���� ���� �� ȣ��� �޼���
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
    //            // �÷��� ��� ���� �� ���� �۾� ����
    //            GameManager.Instance?.CleanUp();
    //        }
    //    }
    //}
}
