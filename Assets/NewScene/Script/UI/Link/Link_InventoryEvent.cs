using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Link_InventoryEvent : SingletonMonoBehavior<Link_InventoryEvent>
{
    public bool m_bLoaded = false;

    public Image[] m_InvenSprites;

	protected override void Awake()
	{
		base.Awake();
	}

	void Start()
    {
        StartCoroutine(StartManager());
    }

    IEnumerator StartManager()
    {
        yield return null;

        {
            InvenManager.Instance.m_InvenSprites = m_InvenSprites;
            m_bLoaded = true;
        }
    }
}
