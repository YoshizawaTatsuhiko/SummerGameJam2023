using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("壁の生成")]
    [Tooltip("何枚でクリアか"), SerializeField] int _numOfWall;
    [Tooltip("壁の生成位置"), SerializeField] Vector2 _spawnPosition;
    [Tooltip("通常の壁"), SerializeField] GameObject[] _nomalWalls;
    [Tooltip("順に当てる壁"), SerializeField] GameObject[] _orderWalls;
    [Tooltip("順に的が生成される壁"), SerializeField] GameObject[] _spawnWhenHitWalls;
    [Tooltip("最初に通常壁が生成される枚数"), SerializeField] int _numOfTutorialWalls;
    int _currentNumOfWall; // 今何枚目か

    [Header("スピード")]
    [Tooltip("初期スピード"), SerializeField] float _startSpeed;
    [Tooltip("１秒でどの程度加速するか"), SerializeField] float _acceleration;

    [Header("スコア")]
    [Tooltip("1枚突破で加算されるスコア"), SerializeField] int _addScore;

    [Header("リザルト")]
    [Tooltip("リザルトキャンバス"), SerializeField] GameObject _resultCanvas;
    [Tooltip("リザルトテキスト"), SerializeField] Text _resultText;
    [Tooltip("スコアテキスト"), SerializeField] Text _scoreText;

    [Header("Audio")]
    [SerializeField] AudioClip _inGameBGM;
    [SerializeField] AudioClip _clearSound;
    [SerializeField] AudioClip _gameOverSound;
    [SerializeField] AudioClip _breakWallSound;
    [Tooltip("When game overプレイヤーが爆発する音")] AudioClip _playerBoomSound;

    static GameManager _instance;
    public static GameManager Instance => _instance;

    private void Awake()
    {
        if (_instance == null) _instance = this;
    }

    public float Speed { get; private set; }

    private void Start()
    {
        Speed = _startSpeed;
        _resultCanvas.SetActive(false);
        AudioManager.Instance.PlayBGM(_inGameBGM);
        // 1枚目をどうするか
        Instantiate(_nomalWalls[0]).transform.position = _spawnPosition;
    }

    private void Update()
    {
        Speed += Time.deltaTime * _acceleration;
        if (Input.GetMouseButtonDown(1))
        {
            GameOver();
        }
    }

    public void BreakWall()
    {
        _currentNumOfWall++; // 枚数加算
        AudioManager.Instance.PlaySE(_breakWallSound);
        AudioManager.Instance.PlaySE(_playerBoomSound);
        if (_currentNumOfWall >= _numOfWall)
        {
            GameClear();
            return;
        }
        GameObject wall = null;
        if (_currentNumOfWall < _numOfTutorialWalls)
        {
            _currentNumOfWall++;
            wall = _nomalWalls[Random.Range(0, _nomalWalls.Length)];
        }
        else
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    wall = _nomalWalls[Random.Range(0, _nomalWalls.Length)];
                    break;
                case 1:
                    wall = _orderWalls[Random.Range(0, _orderWalls.Length)];
                    break;
                case 2:
                    wall = _spawnWhenHitWalls[Random.Range(0, _spawnWhenHitWalls.Length)];
                    break;
            }
        }

        Instantiate(wall).transform.position = _spawnPosition;
        Debug.Log(_currentNumOfWall + "枚壊した");
    }

    /// <summary>Game Over時の処理</summary>
    public void GameOver()
    {
        _resultText.text = "Game Over"; // image,objectを変える場合は要変更
        GameClear();
        AudioManager.Instance.PlayBGM(_gameOverSound, false);

    }

    /// <summary>ゲームクリア時の処理</summary>
    void GameClear()
    {
        _resultCanvas.SetActive(true);
        _scoreText.text = (_currentNumOfWall * _addScore).ToString("00000");
        AudioManager.Instance.PlayBGM(_clearSound, false);
    }
}