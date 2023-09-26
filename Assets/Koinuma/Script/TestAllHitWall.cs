using UnityEngine;

public class TestAllHitWall : WallBase
{
    [SerializeField] int _clearCount = 3;
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
        if (Judge())
        {
            GameManager.Instance.BreakWall();
            Destroy(gameObject);
        }
    }
}
