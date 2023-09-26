using UnityEngine;

public class SelectCorrectWall : WallBase
{
    [SerializeField] GameObject _blindfoldPrefab;
    bool _isBlindFold;
    bool _isCorrect;
    float _blindTime = 10;


    public override bool Judge()
    {
        return _isCorrect;
    }

    public override void WallAction(int n)
    {
        if(n == 0)
        {
            _isCorrect = false;
            _isBlindFold = true;
        }
        else
        {
            _isCorrect = true;
        }
    }

    private void Update()
    {
        if (Judge())
        {
            Debug.Log("”j‰ó");
            Destroy(gameObject);
        }
        if(_isBlindFold)
        {
            _blindfoldPrefab.SetActive(true);
            _isBlindFold = true;
        }

        if(_isBlindFold && _blindTime > 0)
        {
            _blindTime -= Time.deltaTime;
        }
        else
        {
            _isBlindFold = false;
            _blindTime = 10;
            _blindfoldPrefab.SetActive(false);
        }
    }
}
