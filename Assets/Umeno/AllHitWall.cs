using UnityEngine;

public class AllHitWall : WallBase
{
    [SerializeField]int _clearCount = 3;
    int _hitCount = 0;

    public int HitCount { get => _hitCount; set => _hitCount = value; }
    public override bool Judge()
    {
        return _clearCount == _hitCount;
    }
}
