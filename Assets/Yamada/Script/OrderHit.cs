using UnityEngine;

public class OrderHit : TargetBase
{
    bool _isHit;
    [SerializeField] int _id = 1;
    OrderHitWall _orderHitWall;
    //[SerializeField] private List<int> _selectNum;

    private void Awake()
    {
        _orderHitWall = GetComponent<OrderHitWall>();
    }
    private void OnEnable()
    {
        _orderHitWall.ResetAction += ResetAction;
    }
    private void OnDisable()
    {
        _orderHitWall.ResetAction -= ResetAction;
    }
    public override void TargetAction()
    {
        if (!_isHit)
        {
            var wall = GetComponentInParent<WallBase>();
            wall.WallAction(_id);
            _isHit = true;
        }
    }
    public void ResetAction()
    {
        _isHit = false;
    }
}
