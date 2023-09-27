using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private AudioClip _shootSound = null;

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
                    target.TargetAction();
                    Debug.Log("HIT");
                }
            }
        }
    }
}
