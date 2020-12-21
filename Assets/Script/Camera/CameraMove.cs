using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    [Range(1,300)]
    public float MouseSensitve = 150f;
    float xRotation,YRotation;

    public static bool CanSwing;
    public static bool b_CanSwingCamera;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        b_CanSwingCamera = true;
        CanSwing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!b_CanSwingCamera) return;
        

        float MouseY = Input.GetAxis("Mouse Y") * MouseSensitve * Time.deltaTime;
        float MouseX = 0;
        if (CanSwing)
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
