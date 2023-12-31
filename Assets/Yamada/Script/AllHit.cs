using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllHit : TargetBase
{
    bool _isHit;

    public override void TargetAction()
    {
        if (!_isHit)
        {
            var wall = GetComponentInParent<WallBase>();
            wall.WallAction(1);
            _isHit = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_isHit)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
