using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Clickable
{
	public GameObject m_Box = null;
	bool IsBoxOn = false;
	public override void OnClick()
	{
		OpenBox();
	}

	public void OpenBox()
	{
		if (m_Box == null)
			m_Box = UIManager.Instance.ViewBox2x2();

		LoadComplate();		
	}

	public void LoadComplate()
	{
		StartCoroutine(StartManager());
	}

	IEnumerator StartManager()
	{
		EventManager.Instance.AddUpdateManager(UpdateManager);
		yield return null;
	}

	void CloseBox()
	{
		UIManager.Instance.CloseUI(m_Box);
		m_Box = null;
		EventManager.Instance.DeleteUpdateManager(UpdateManager);
	}


	void UpdateManager()
	{
		if (m_Box != null &&  InputManager.GetKeyDown(KeyCode.Escape) && UIManager.Instance.m_CurUI == m_Box && !UIManager.Instance.Close)
			CloseBox();
	}
}
