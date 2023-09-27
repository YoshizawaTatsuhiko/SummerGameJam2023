using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditButton : MonoBehaviour
{
    public GameObject Credit;
    public GameObject StartButton;

    // Start is called before the first frame update
    void Start()
    {
        Credit.SetActive(false);
        StartButton.SetActive(true);
    }

    public void OnClick()
    {
        if (!Credit.activeInHierarchy)
        {
            Credit.SetActive(true);
            StartButton.SetActive(false);
        }
        else
        {
            Credit.SetActive(false);
            StartButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
