using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public virtual void OnClick() { }
    public virtual void OnMouseOn() 
    {
        Material material = GetComponent<MeshRenderer>().material;
        material.color = Color.red;
    }
    public virtual void OnMouseExit()
    {
        Material material = GetComponent<MeshRenderer>().material;
        material.color = Color.white;
    }
}
