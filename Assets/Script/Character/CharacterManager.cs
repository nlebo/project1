using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    bool isRide;
    bool RideBtn;
    [SerializeField]
    bool RideBtnDwn;

    bool isSprint;
    bool SprintBtn;
    public float SprintSpeed = 2f;

    [SerializeField]
    bool isJump;
    bool JumpBtn;
    public float JumpForce = 5;

    
    public float MoveSpeed = 5f;
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

        SprintBtn = Input.GetKey(KeyCode.LeftShift);

        JumpBtn = !isJump && Input.GetKey(KeyCode.Space);
    }

    void Move()
    {
        float MouseX = Input.GetAxis("Mouse X");
        float RMoveSpeed = MoveSpeed;

        isSprint = false;


        if (!Input.GetKey(KeyCode.LeftAlt)) transform.Rotate(Vector3.up * MouseX);
        
        if (!isJump && JumpBtn)
        {
            isJump = true;
            CRigid.AddForce(Vector3.up * JumpForce,ForceMode.Impulse);
        }
        else if (isJump)
        {
            Jump();
        }

        if (MoveState == Vector3.zero)
        {
            return;
        }

        if (MoveState.z > 0 && SprintBtn)
        {
            isSprint = true;
            RMoveSpeed += SprintSpeed;
        }

        
        
        if(!isJump)
        {
            transform.Translate(MoveState * Time.deltaTime * RMoveSpeed);
        }
        
    }

    public void Jump()
    {
        RaycastHit[] hit = Physics.RaycastAll(transform.position,-transform.up,10);
        Debug.DrawRay(transform.position,-transform.up,Color.green,0.2f);

        for(int i=0; i< hit.Length; i++)
        {
            if (hit[i].transform.gameObject.layer == 9)
            {
                float Dis = Vector3.Distance(transform.position, hit[i].point);
                Debug.Log(Dis);
                if (Anim.GetInteger("JumpState") == 0)
                {
                    if (Dis < 1)
                    {
                        Anim.SetInteger("JumpState", 1);
                    }
                }
                else
                {
                    if (Dis >= 1)
                    {
                        Anim.SetInteger("JumpState", 0);
                    }
                }

                if(Anim.GetCurrentAnimatorStateInfo(3).normalizedTime >= 1f) isJump = false;
            }
        }
    }

    public void AnimationSet()
    {
        Anim.SetLayerWeight(2, 0);
        Anim.SetLayerWeight(2, 0);
        Anim.SetLayerWeight(3,0);

        if (isJump)
        {
            Anim.SetInteger("State", 3);
            Anim.SetLayerWeight(3,1);
        }

        else
        {
            if (MoveState == Vector3.zero)
            {
                Anim.SetInteger("State", 0);
            }
            else if (MoveState != Vector3.zero)
            {
                Anim.SetInteger("State", 1);
                Anim.SetFloat("WalkBlend", -MoveState.z + 0.5f);
                Anim.SetLayerWeight(1, 1);

                if (isSprint)
                {
                    Anim.SetInteger("State", 2);
                    Anim.SetLayerWeight(2, 1);
                }
            }
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

    public void EndJump()
    {
        StartCoroutine(EndJumpCor());
    }

    IEnumerator EndJumpCor()
    {
        yield return new WaitForSeconds(0.5f);
        isJump = false;
    }


}
