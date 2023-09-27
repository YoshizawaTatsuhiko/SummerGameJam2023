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
    bool _isSuccess;
    public override bool Judge()
    {

        return _clearCount == _hitCount;
    }

    public override void WallAction(int n)
    {
        _hitCount += n;
        if (Judge())
        {
            _isSuccess = true;
            Debug.Log("破壊");
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
        if (!_isSuccess && transform.position.z < 0)
        {
            var player = FindObjectOfType<PlayerController>();
            if (player)
            {
                player.ChangeSprite();
            }
            else
            {
                Debug.LogError("playerスクリプトが存在しません");
            }
            Debug.Log("GameOver");
            _gameManager.GameOver();
        }
    }
}
