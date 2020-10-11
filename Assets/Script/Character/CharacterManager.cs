using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    bool isRide;
    bool RideBtn;
    [SerializeField]
    bool RideBtnDwn;
    float RideBtnPressTime;
    Animator Anim;
    Rigidbody CRigid;
    Vector3 MoveState;
    CapsuleCollider Col;

    [SerializeField]
    SelectBox _SelectBox;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        CRigid = GetComponent<Rigidbody>();
        Col = GetComponent<CapsuleCollider>();
        RideBtn = false;
        isRide = false;
        RideBtnPressTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        InputManager();
        if(!isRide)
            Move();
        Ride();
        AnimationSet();
        MoveState = Vector3.zero;
    }

    void InputManager()
    {
        if(Input.GetKey(KeyCode.W)) MoveState.z = 1;
        if(Input.GetKey(KeyCode.S)) MoveState.z = -1;
        if(Input.GetKey(KeyCode.A)) MoveState.x = -0.5f;
        if(Input.GetKey(KeyCode.D)) MoveState.x = 0.5f;

        MoveState.Normalize();

        RideBtn = Input.GetKey(KeyCode.F);
        RideBtnDwn = Input.GetKeyDown(KeyCode.F);
    }

    void Move()
    {
        float MouseX = Input.GetAxis("Mouse X");

        if(!Input.GetKey(KeyCode.LeftAlt)) transform.Rotate(Vector3.up * MouseX);
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

    void Ride()
    {
        if(!RideBtn)
        { 
            RideBtnPressTime = 0;
            return;
        }
        else if(!_SelectBox.RideOn)
        {
            if(isRide && RideBtnDwn)
            {
                Col.isTrigger = false;
                CRigid.useGravity = true;
                isRide= false;
                transform.parent = null;
                transform.localPosition = new Vector3(transform.localPosition.x,0,transform.localPosition.z);
                return;
            }
            else if(isRide)
            {
                return;
            }
        }

        
        
        RideBtnPressTime += Time.deltaTime;
        
        if(RideBtnPressTime >= 2.2f)
        {
            Col.isTrigger = true;
            CRigid.useGravity = false;
            transform.parent = _SelectBox.RideTransform;
            transform.localPosition = Vector3.zero;
            isRide = true;
        }
    }
}
