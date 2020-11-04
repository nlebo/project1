using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBox : MonoBehaviour
{
    [SerializeField]
    CharacterManager CM;
    public bool RideOn;
    public bool BoxOn;
    public bool MotorOn;
    public Transform RideTransform;
    public Transform Hit_Transform;
    public Box _Box;
    public Cart _Cart;


    public bool HandleOn;
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
            Hit_Transform = other.transform;
        }
        else if(other.tag == "CreateBox")
        {
            BoxOn = true;
            _Box = other.GetComponent<Box>();
            _Box.GetComponent<MeshRenderer>().material.color = Color.red;
            Hit_Transform = other.transform;
        }
        else if(other.tag == "Motor")
        {
            MotorOn = true;
            _Cart = other.transform.parent.GetComponent<Cart>();
            other.GetComponent<MeshRenderer>().material.color = Color.red;
            Hit_Transform = other.transform;
        }
        else if(other.tag == "Handle")
        {
            HandleOn = true;
            _Cart = other.transform.parent.GetComponent<Cart>();
            other.GetComponent<MeshRenderer>().material.color = Color.red;
            Hit_Transform = other.transform;
        }
    }

    private void OnTriggerExit(Collider other) {
        Hit_Transform = null;
        if(other.tag == "Ride" && RideTransform == other.transform)
        {
            RideOn = false;
            RideTransform.GetComponent<MeshRenderer>().material.color = Color.white;
            RideTransform = null;
        }
        else if(other.tag == "CreateBox" && _Box.transform == other.transform)
        {
            BoxOn = false;
            _Box.GetComponent<MeshRenderer>().material.color = Color.white;
            _Box = null;
        }
        else if(other.tag == "Motor" && _Cart.transform == other.transform.parent)
        {
            MotorOn = false;
            _Cart = null;
            other.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        else if(other.tag == "Handle" && _Cart.transform == other.transform.parent)
        {
            HandleOn = false;
            _Cart = null;
            other.GetComponent<MeshRenderer>().material.color = Color.white;
        } 
    }
}
