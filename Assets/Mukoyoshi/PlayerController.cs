using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private Sprite _defaultSprite = null;
    [SerializeField] private Sprite _gameOverSprite = null;
    [SerializeField] private AudioClip _shootSound = null;
    [SerializeField] private AudioClip _breakSound = null;

    private SpriteRenderer _renderer = null;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var raycastHit = Physics2D.Raycast(ray.origin, ray.direction);

            if (raycastHit)
            {
                AudioManager.Instance.PlaySE(_shootSound);
                Debug.Log($"Hit object : {raycastHit.collider.gameObject.name}");

                if (raycastHit.collider.TryGetComponent(out TargetBase target))
                {
                    AudioManager.Instance.PlaySE(_breakSound);
                    target.TargetAction();
                    Debug.Log("HIT");
                }
            }
        }
    }

    /// <summary>åªç›ÇÃSpriteÇà¯êîÇ≈éÛÇØéÊÇ¡ÇΩSpriteÇ…ïœçXÇ∑ÇÈ</summary>
    /// <param name="sprite">ç∑Çµë÷Ç¶ÇΩÇ¢Sprite</param>
    public void ChangeSprite()
    {
        if(_gameOverSprite) _renderer.sprite = _gameOverSprite;
    }
}
