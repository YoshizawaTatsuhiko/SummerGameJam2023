using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("�ǂ̐���")]
    [Tooltip("�ǂ̐����ʒu"), SerializeField] Vector2 _spawnPosition;
    [Tooltip("�ʏ�̕�"), SerializeField] GameObject[] _nomalWalls;
    [Tooltip("���ɓ��Ă��"), SerializeField] GameObject[] _orderWalls;
    [Tooltip("���ɓI������������"), SerializeField] GameObject[] _spawnWhenHitWalls;
    [Tooltip("�ŏ��ɒʏ�ǂ���������閇��"), SerializeField] int _numOfTutorialWalls;
    int _numOfWall; // �`���[�g���A���p�ϐ�

    [Header("�X�s�[�h")]
    [Tooltip("�����X�s�[�h"), SerializeField] float _startSpeed;
    [Tooltip("�P�b�łǂ̒��x�������邩"), SerializeField] float _acceleration;

    [Header("�X�R�A")]
    [Tooltip("1���˔j�ŉ��Z�����X�R�A"), SerializeField] int _addScore;
    int _score;

    public static GameManager _instance;

    private void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(gameObject);
    }

    public float Speed { get; private set; }

    private void Start()
    {
        Speed = _startSpeed;
        // 1���ڂ��ǂ����邩
    }

    private void Update()
    {
        Speed += Time.deltaTime * _acceleration;
    }

    public void BreakWall()
    {
        _score += _addScore; // �X�R�A���Z
        if (_numOfWall < _numOfTutorialWalls)
        {
            _numOfWall++;
            SpawnWall(_nomalWalls[Random.Range(0, _nomalWalls.Length)]);
        }
        else
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    SpawnWall(_nomalWalls[Random.Range(0, _nomalWalls.Length)]);
                    break;
                case 1:
                    SpawnWall(_orderWalls[Random.Range(0, _orderWalls.Length)]);
                    break;
                case 2:
                    SpawnWall(_spawnWhenHitWalls[Random.Range(0, _spawnWhenHitWalls.Length)]);
                    break;
            }
        }
    }

    void SpawnWall(GameObject wall)
    {
        Instantiate(wall).transform.position = _spawnPosition;
    }

    public void GameOver()
    {

    }
}
