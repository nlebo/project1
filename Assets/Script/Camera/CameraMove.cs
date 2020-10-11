using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public float MouseSensitve = 100f;
    float xRotation,YRotation;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float MouseY = Input.GetAxis("Mouse Y") * MouseSensitve * Time.deltaTime;
        float MouseX = 0;
        if (Input.GetKey(KeyCode.LeftAlt))
            MouseX = Input.GetAxis("Mouse X") * MouseSensitve * Time.deltaTime;
        else
            YRotation = 0;
        YRotation += MouseX;
        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -70, 70);
        YRotation = Mathf.Clamp(YRotation, -40, 40);
        
        transform.localRotation = Quaternion.Euler(xRotation, YRotation, 0);

    }
}
