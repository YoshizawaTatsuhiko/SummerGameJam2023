using UnityEngine;
using UnityEngine.UIElements;

public class SelectCorrectWall : WallBase
{
    [SerializeField] GameObject _blindfoldPrefab;
    [SerializeField] float _speed = 0.1f;
    [SerializeField] float _timer = 1f;
    GameManager _gameManager;
    float _zPosition;
    bool _isBlindFold;
    bool _isCorrect;
    float _blindTime = 10;
    float _baseTimer;
    bool _isSuccess;


    public override bool Judge()
    {
        return _isCorrect;
    }

    public override void WallAction(int n)
    {
        if(n == 0)
        {
            _isCorrect = false;
            _isBlindFold = true;
        }
        else
        {
            _isCorrect = true;
        }
        if (Judge())
        {
            _isSuccess = true;
            Debug.Log("”j‰ó");
            _gameManager.BreakWall();
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        _zPosition = transform.position.z;
        _gameManager = FindObjectOfType<GameManager>();
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
            _gameManager.GameOver();
        }
        if(_isBlindFold)
        {
            _blindfoldPrefab.SetActive(true);
            _isBlindFold = true;
        }

        if(_isBlindFold && _blindTime > 0)
        {
            _blindTime -= Time.deltaTime;
        }
        else
        {
            _isBlindFold = false;
            _blindTime = 10;
            _blindfoldPrefab.SetActive(false);
        }
    }
}
