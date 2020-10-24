using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    bool EngineOn;
    


    public float MoveSpeed;
    public float MaxMoveSpeed;
    public float AddSpeedPerSecond;
    // Start is called before the first frame update
    void Start()
    {
        MoveSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(EngineOn){

            MoveSpeed += AddSpeedPerSecond * Time.deltaTime;
            if(MoveSpeed > MaxMoveSpeed) MoveSpeed = MaxMoveSpeed;
            transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed);
        }
    }

    public bool PushEngine()
    {

        EngineOn = !EngineOn;
        if(!EngineOn) MoveSpeed = 0;
        return EngineOn;
    }
}
