using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    [SerializeField]
    GameObject First,Third;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            First.SetActive(!First.activeInHierarchy);
            Third.SetActive(!Third.activeInHierarchy);
        }
    }
}
