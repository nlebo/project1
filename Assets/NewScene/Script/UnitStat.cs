using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStat : MonoBehaviour
{
	[SerializeField]
	int Hp;
	public int m_Hp { get { return Hp; } }
	public int m_SetHp {set{ Hp = value; } }

	[SerializeField]
	int stamina;
	public int m_Stamina { get { return stamina; } }
	public int m_SetStamina { set { stamina = value; } }

	[SerializeField]
	float movespeed;
	public float m_MoveSpeed { get { return movespeed; } }
	public float m_SetMoveSpeed { set { movespeed = value; } }

}
