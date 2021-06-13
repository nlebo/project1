using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : IEMove
{
	enum AnimState
	{
		Idle = 0,
		Walk = 1,
		Jump = 3,
	}
	Rigidbody MoveObject;
	Transform TF_Foots;
	Animator Anim;
	bool IsJump = false;
	bool JumpHigh = false;
	bool IsJumping = false;

	private void Start()
	{
		EventManager.Instance.AddFixedUpdateManager(UpdateManager);
	}

	public override void SetSpeed(float _speed)
	{
		speed = _speed;
	}

	public override void SetObject(object obj)
	{
		MoveObject = (Rigidbody)obj;
		TF_Foots = MoveObject.transform.Find("Foots");
		Anim = MoveObject.GetComponent<Animator>();
	}

	void UpdateManager()
	{
		if (MoveObject == null)
			return;

		CheckGround();
		if (IsJump) IsJump = false;

		MoveObject.AddForce(Dic * speed, ForceMode.Impulse);
		

	}

	public override void Move()
	{
		if (IsJump)
			return;

		Dic = GetDirection().normalized;
	}

	public override void Jump()
	{
		if (IsJump || !InputManager.GetKeyDown(KeyCode.Space) || IsJumping)
			return;

		Dic = GetDirection().normalized;
		Dic += Vector3.up;
		Dic.Normalize();

		IsJump = true;
		IsJumping = true;
	}

	Vector3 GetDirection()
	{
		Vector3 _dic = Vector3.zero;

		if (InputManager.GetKeyIn(KeyCode.W))
			_dic.z += 1;
		if (InputManager.GetKeyIn(KeyCode.S))
			_dic.z -= 1;
		if (InputManager.GetKeyIn(KeyCode.A))
			_dic.x -= 1;
		if (InputManager.GetKeyIn(KeyCode.D))
			_dic.x += 1;

		return _dic;
	}

	bool CheckGround()
	{
		RaycastHit[] hit;
		hit = Physics.RaycastAll(TF_Foots.position, -Vector3.up);

		foreach (var value in hit)
		{
			if (value.transform.tag == "Plane")
			{
				if (Vector3.SqrMagnitude(TF_Foots.position - value.point) <= 0.01f)
				{
					IsJumping = false;

					return true;
				}
				else if (Vector3.SqrMagnitude(TF_Foots.position - value.point) <= 0.5f)
				{
					Anim.SetInteger("JumpState", 1);
					IsJumping = true;
				}
				else
				{
					Anim.SetInteger("JumpState", 0);
					IsJumping = true;
				}
			}
		}
		return false;
	}

	public override bool IsMove() 
	{
		if (IsJumping)
			return false;

		return Dic.x != 0 || Dic.z != 0;
	}

	public override void SetAnim()
	{
		int state = GetNowState();

		if (IsJumping || Anim.GetCurrentAnimatorStateInfo(0).normalizedTime == 0)
		{
			Anim.SetBool("ChangeState", false);
		}
		int State = Anim.GetInteger("State");

		switch ((AnimState)state)
		{
			case AnimState.Idle:
				{
					Anim.SetInteger("State", state);

					if (State != 0)
					{
						Anim.Play("Idle", 0);
						Anim.SetBool("ChangeState", true);
					}
				}
				break;
			case AnimState.Walk:
				{
					Anim.SetInteger("State", state);
					Anim.SetFloat("WalkBlend", -Dic.z);
					if (State != 1)
					{
						Anim.Play("Walk", 0);
						Anim.SetBool("ChangeState", true);
					}
				}
				break;
			case AnimState.Jump:
				{
					Anim.SetInteger("State", state);

					if (State!=3)
					{
						Anim.Play("Jump", 0);
						Anim.SetBool("ChangeState", true);
					}
				}
				break;
		}
	}

	int GetNowState()
	{
		if (IsJumping)
			return (int)AnimState.Jump;

		if (IsMove())
			return (int)AnimState.Walk;

		return (int)AnimState.Idle;
	}
}
