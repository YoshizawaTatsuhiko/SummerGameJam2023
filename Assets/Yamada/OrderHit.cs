using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderHit : TargetBase
{
    bool _isHit;
    [SerializeField] int _id = 1;
    //[SerializeField] private List<int> _selectNum;

    private void OnEnable()
    {
        GetComponentInParent<OrderHitWall>().ResetAction += ResetAction;
    }
    private void OnDisable()
    {
        GetComponentInParent<OrderHitWall>().ResetAction -= ResetAction;
    }
    public override void TargetAction()
    {
        if (!_isHit)
        {
            Debug.Log(_id);
            var wall = GetComponentInParent<WallBase>();
            wall.WallAction(_id);
            Debug.Log(_id);
            _isHit = true;
        }
    }
    public void ResetAction()
    {
        _isHit = false;
    }
}