using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    bool EngineOn;


    public float MoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EngineOn)
            transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed);
        
    }

    public bool PushEngine()
    {

        EngineOn = !EngineOn;
        return EngineOn;
    }
}
