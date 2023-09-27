using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OrderHitWall : WallBase
{
    List<int> _selectNum = new List<int>();
    [SerializeField]string _answer = "12345";
    [SerializeField] float _timer;
    [SerializeField] float _speed;
    [SerializeField] GameObject _gameOver;
    Action _resetAction;
    GameManager _gameManager;
    float _baseTimer;
    float _zPosition;
    public Action ResetAction { get { return _resetAction; }set {_resetAction = value; } }
    public override bool Judge()
    {
        for(int n = 0; n< _selectNum.Count; n++)
        {
            var s = string.Join("", _selectNum);
            if (_answer[n] != s[n])
            {
                Debug.Log("false");

                return false;
            }
        }
        Debug.Log("True");
        return true;
    }

    public override void WallAction(int n)
    {
        //“I‚ÌŽ¯•Ê
        _selectNum.Add(n);
        if (Judge())
        {
            if (_selectNum.Count == _answer.Length)
            {
                Debug.Log("”j‰ó");
                _gameManager.BreakWall();
            }
        }
        else
        {
            _selectNum.Clear();
            _resetAction();
        }
    }
    private void OnEnable()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gameOver.SetActive(false);
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
