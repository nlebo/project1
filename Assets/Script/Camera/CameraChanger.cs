using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    [SerializeField]
    Camera First,Third;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.AddUpdateManager(UpdateManager);
    }

    // Update is called once per frame
    void UpdateManager()
    {
        if(InputManager.GetKeyDown(KeyCode.T))
        {
            First.enabled = (!First.enabled);
            Third.enabled = (!Third.enabled);
        }
    }
}
