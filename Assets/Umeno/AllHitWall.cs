using UnityEngine;

public class AllHitWall : WallBase
{
    [SerializeField]int _clearCount = 3;
    [SerializeField] float _timer;
    [SerializeField] float _speed;
    GameManager _gameManager;
    float _zPosition;
    float _baseTimer;
    int _hitCount = 0;
    public override bool Judge()
    {

        return _clearCount == _hitCount;
    }

    public override void WallAction(int n)
    {
        _hitCount += n;
        if (Judge())
        {
            Debug.Log("”j‰ó");
            _gameManager.BreakWall();
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _zPosition = transform.position.z;
        _speed = _gameManager.Speed;
        _baseTimer = _timer;
    }
    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            _speed = _gameManager.Speed;
            _timer = _baseTimer;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, _zPosition -= _speed);
        if (transform.position.z > 0)
        {
            Debug.Log("GameOver");
            _gameManager.GameOver();
        }
    }
}
