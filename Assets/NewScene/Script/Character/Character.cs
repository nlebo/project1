using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : UnitStat
{
    static Character _Instance;
    public static Character Instance
    { get { return _Instance == null ? new Character() : _Instance; } }

	private void Awake()
	{
        if (_Instance == null)
            _Instance = this;
	}

	IEMove m_Move;
    Animator Anim;
    Rigidbody m_rigid;

    void Start()
    {
        m_rigid = GetComponent<Rigidbody>();
        m_Move = GetComponent<IEMove>();
        Anim = GetComponent<Animator>();
        
        if (m_Move != null)
        {
            m_Move.SetSpeed(m_MoveSpeed);
            m_Move.SetObject((object)m_rigid);
        }

        EventManager.Instance.AddUpdateManager(UpdateManager);
    }

    void UpdateManager()
    {
        if (m_Move == null)
            return;

        m_Move.Move();
        m_Move.Jump();
        m_Move.SetAnim();

        if (InputManager.GetKeyDown(KeyCode.I) && InvenManager.Instance.m_Inventory == null)
        {
            InvenManager.Instance.OpenInven();
        }

        
    }
}
