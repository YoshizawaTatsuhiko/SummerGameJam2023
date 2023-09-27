using UnityEngine;

public class OrderHit : TargetBase
{
    [SerializeField] AudioClip _playSe;
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
            AudioManager.Instance.PlaySE(_playSe);
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
