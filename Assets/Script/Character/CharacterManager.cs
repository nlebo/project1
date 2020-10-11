using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    Animator Anim;
    Rigidbody CRigid;
    Vector3 MoveState;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        CRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        InputManager();
        Move();
        AnimationSet();
        MoveState = Vector3.zero;
    }

    public void InputManager()
    {
        if(Input.GetKey(KeyCode.W)) MoveState.z = 1;
        if(Input.GetKey(KeyCode.S)) MoveState.z = -1;

        MoveState.Normalize();
    }

    public void Move()
    {
        if(MoveState == Vector3.zero)
        {
            return;
        }
        
        transform.Translate(MoveState * Time.deltaTime * 5);
        
    }

    public void AnimationSet()
    {
        if(MoveState == Vector3.zero){
             Anim.SetInteger("State",0);
             Anim.SetLayerWeight(1,0);
        }
        else if(MoveState != Vector3.zero){ 
            Anim.SetInteger("State",1);
            Anim.SetFloat("WalkBlend",-MoveState.z + 0.5f);
            Anim.SetLayerWeight(1,1);
        }
    }

}
