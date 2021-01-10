using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    bool EngineOn;
    

    public Transform LeftSide,RightSide;
    public float MoveSpeed;
    public float MaxMoveSpeed;
    public float AddSpeedPerSecond;

    public float MaxDegree;
    public float NowDegree;
    public float DegreeAceleation;
    public float AddDegreePerSecond;

    // Start is called before the first frame update
    void Start()
    {
        LeftSide = transform.Find("LeftSide");
        RightSide = transform.Find("RightSide");
        MoveSpeed = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

        
        if(EngineOn){

            MoveSpeed += AddSpeedPerSecond * Time.deltaTime;
            if(MoveSpeed > MaxMoveSpeed) MoveSpeed = MaxMoveSpeed;
            transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed);
            transform.Rotate(0,NowDegree,0);
        }
    }

    public bool PushEngine()
    {

        EngineOn = !EngineOn;
        if(!EngineOn) MoveSpeed = 0;
        return EngineOn;
    }

    public void Handling(float degree)
    {
        if(degree > 0)
            NowDegree += AddDegreePerSecond * DegreeAceleation * Time.deltaTime;
        else if(degree < 0)
            NowDegree -= AddDegreePerSecond * DegreeAceleation * Time.deltaTime;

        if(NowDegree >= MaxDegree) NowDegree = MaxDegree;
        else if(NowDegree <= -MaxDegree) NowDegree = -MaxDegree;
        

    }

}
