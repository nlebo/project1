using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBox : MonoBehaviour
{
    [SerializeField]
    CharacterManager CM;
    public bool RideOn;
    public Transform RideTransform;
    // Start is called before the first frame update
    void Start()
    {
        RideOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Ride")
        {
            RideOn = true;
            RideTransform = other.transform;
            RideTransform.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Ride" && RideTransform == other.transform)
        {
            RideOn = false;
            RideTransform.GetComponent<MeshRenderer>().material.color = Color.white;
            RideTransform = null;
        }
    }
}
