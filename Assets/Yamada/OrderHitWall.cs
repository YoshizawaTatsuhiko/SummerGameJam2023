using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderHitWall : WallBase
{
    List<int> _selectNum = new List<int>();
    [SerializeField]string _answer = "12345";
    Action _resetAction;
    public Action ResetAction { get { return _resetAction; }set {_resetAction = value; } }
    public override bool Judge()
    {
        for(int n = 0; n< _selectNum.Count; n++)
        {
            var s = string.Join("", _selectNum);
            if (_answer[n] != s[n])
            {
                Debug.Log("false");

                return false;
            }
        }
        Debug.Log("True");
        return true;
    }

    public override void WallAction(int n)
    {
        //“I‚ÌŽ¯•Ê
        _selectNum.Add(n);
        if (Judge())
        {
            if (_selectNum.Count == _answer.Length)
            {
                Debug.Log("”j‰ó");
            }
        }
        else
        {
            _selectNum.Clear();
            _resetAction();
        }
    }
    //private void Update()
    //{
    //    if (Judge())
    //    {
    //        if (_selectNum.Count == _answer.Length)
    //        {
    //            Debug.Log("”j‰ó");
    //        }
    //    }
    //}
}
