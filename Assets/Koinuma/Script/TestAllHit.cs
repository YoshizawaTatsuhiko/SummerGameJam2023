using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAllHit : TargetBase
{
    bool _isHit;

    public override void TargetAction()
    {
        if (!_isHit)
        {
            var wall = GetComponentInParent<WallBase>();
            wall.WallAction();
            _isHit = true;
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}