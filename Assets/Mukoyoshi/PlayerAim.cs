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
            var aim = Camera.main.ScreenPointToRay(Input.mousePosition);
            var ray = Physics2D.Raycast(aim.origin, aim.direction);
            Debug.Log(ray.collider.gameObject.name);

        }
    }
}
