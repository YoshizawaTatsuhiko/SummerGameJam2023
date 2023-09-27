using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllHit : TargetBase
{
    [SerializeField] AudioClip _playSe;
    bool _isHit;

    public override void TargetAction()
    {
        if (!_isHit)
        {
            AudioManager.Instance.PlaySE(_playSe);
            var wall = GetComponentInParent<WallBase>();
            wall.WallAction(1);
            _isHit = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
