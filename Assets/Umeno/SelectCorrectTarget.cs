using UnityEngine;

public class SelectCorrectTarget : TargetBase
{
    [SerializeField] bool _isCorrectButton;
    bool _isHit;

    public override void TargetAction()
    {
        if (!_isHit)
        {
            var wall = GetComponentInParent<WallBase>();
            Debug.Log($"IsCorrect{_isCorrectButton}");
            if (_isCorrectButton)
            {
                wall.WallAction(1);
            }
            else
            {
                wall.WallAction(0);
            }
            _isHit = true;
        }
    }

    private void Update()
    {
        if(_isHit)
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
