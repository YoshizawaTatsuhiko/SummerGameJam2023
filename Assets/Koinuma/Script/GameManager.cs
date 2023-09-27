using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("�ǂ̐���")]
    [Tooltip("�����ŃN���A��"), SerializeField] int _numOfWall;
    [Tooltip("�ǂ̐����ʒu"), SerializeField] Vector2 _spawnPosition;
    [Tooltip("�ʏ�̕�"), SerializeField] GameObject[] _nomalWalls;
    [Tooltip("���ɓ��Ă��"), SerializeField] GameObject[] _orderWalls;
    [Tooltip("���ɓI������������"), SerializeField] GameObject[] _spawnWhenHitWalls;
    [Tooltip("�ŏ��ɒʏ�ǂ���������閇��"), SerializeField] int _numOfTutorialWalls;
    int _currentNumOfWall; // �������ڂ�

    [Header("�X�s�[�h")]
    [Tooltip("�����X�s�[�h"), SerializeField] float _startSpeed;
    [Tooltip("�P�b�łǂ̒��x�������邩"), SerializeField] float _acceleration;

    [Header("�X�R�A")]
    [Tooltip("1���˔j�ŉ��Z�����X�R�A"), SerializeField] int _addScore;

    [Header("���U���g")]
    [Tooltip("���U���g�L�����o�X"), SerializeField] GameObject _resultCanvas;
    [Tooltip("���U���g�e�L�X�g"), SerializeField] Text _resultText;
    [Tooltip("�X�R�A�e�L�X�g"), SerializeField] Text _scoreText;

    [Header("Audio")]
    [SerializeField] AudioClip _inGameBGM;
    [SerializeField] AudioClip _clearSound;
    [SerializeField] AudioClip _gameOverSound;
    [SerializeField] AudioClip _breakWallSound;
    [Tooltip("When game over�v���C���[���������鉹")] AudioClip _playerBoomSound;

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
        // 1���ڂ��ǂ����邩
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
        _currentNumOfWall++; // �������Z
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
        Debug.Log(_currentNumOfWall + "���󂵂�");
    }

    /// <summary>Game Over���̏���</summary>
    public void GameOver()
    {
        _resultText.text = "Game Over"; // image,object��ς���ꍇ�͗v�ύX
        GameClear();
        AudioManager.Instance.PlayBGM(_gameOverSound, false);

    }

    /// <summary>�Q�[���N���A���̏���</summary>
    void GameClear()
    {
        _resultCanvas.SetActive(true);
        _scoreText.text = (_currentNumOfWall * _addScore).ToString("00000");
        AudioManager.Instance.PlayBGM(_clearSound, false);
    }
}