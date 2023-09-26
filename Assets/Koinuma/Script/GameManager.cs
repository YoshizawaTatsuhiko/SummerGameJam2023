using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("壁の生成")]
    [Tooltip("壁の生成位置"), SerializeField] Vector2 _spawnPosition;
    [Tooltip("通常の壁"), SerializeField] GameObject[] _nomalWalls;
    [Tooltip("順に当てる壁"), SerializeField] GameObject[] _orderWalls;
    [Tooltip("順に的が生成される壁"), SerializeField] GameObject[] _spawnWhenHitWalls;
    [Tooltip("最初に通常壁が生成される枚数"), SerializeField] int _numOfTutorialWalls;
    int _numOfWall; // チュートリアル用変数

    [Header("スピード")]
    [Tooltip("初期スピード"), SerializeField] float _startSpeed;
    [Tooltip("１秒でどの程度加速するか"), SerializeField] float _acceleration;

    [Header("スコア")]
    [Tooltip("1枚突破で加算されるスコア"), SerializeField] int _addScore;
    int _score;

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
        // 1枚目をどうするか
    }

    private void Update()
    {
        Speed += Time.deltaTime * _acceleration;
    }

    public void BreakWall()
    {
        _score += _addScore; // スコア加算
        GameObject wall = null;
        if (_numOfWall < _numOfTutorialWalls)
        {
            _numOfWall++;
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
    }

    public void GameOver()
    {

    }
}