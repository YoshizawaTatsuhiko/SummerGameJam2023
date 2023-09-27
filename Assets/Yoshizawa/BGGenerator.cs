using System.Collections.Generic;
using UnityEngine;

// 日本語対応
public class BGGenerator : MonoBehaviour
{
    [SerializeField] private float _interval = 1.0f;
    [SerializeField] private BGMove _path = null;
    [SerializeField] private float _scroolSpeed = 10.0f;
    [SerializeField] private float _bgLifeTime = 5.0f;

    private List<BGMove> _backGrounds = new List<BGMove>();

    private float _timer = 0.0f;

    private void Start()
    {
        BackGroundGenerate();
    }

    private void FixedUpdate()
    {
        if (CalcInterval())
        {
            BackGroundGenerate();
        }
    }

    private bool CalcInterval()
    {
        float dist = Vector3.Distance(transform.position, _backGrounds[_backGrounds.Count - 1].transform.position);

        if (dist >= _interval) return true;
        return false;
    }

    private void BackGroundGenerate()
    {
        var bg = Instantiate(_path, transform);
        bg.MoveSpeed = _scroolSpeed;
        bg.LifeTime = _bgLifeTime;
        _backGrounds.Add(bg);
    }
}
