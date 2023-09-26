using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var raycastHit = Physics2D.Raycast(ray.origin, ray.direction);
            Debug.Log(raycastHit.collider.gameObject.name);
            if (raycastHit) 
            {
                if(raycastHit.collider.TryGetComponent(out TargetBase target)) 
                {
                    target.TargetAction();
                    Debug.Log("mato");
                }
            }

        }
    }
}
