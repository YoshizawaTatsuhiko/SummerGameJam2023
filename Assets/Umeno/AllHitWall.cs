using UnityEngine;

public class AllHitWall : WallBase
{
    [SerializeField]int _clearCount = 3;
    int _hitCount = 0;
    public override bool Judge()
    {

        return _clearCount == _hitCount;
    }

    public override void WallAction()
    {
        _hitCount++;
    }

    private void Update()
    {
        if(Judge())
        {
            Debug.Log("�j��");
        }
    }
}