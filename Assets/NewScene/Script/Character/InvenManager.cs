using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenManager : SingletonMonoBehavior<InvenManager>
{

	public GameObject m_Inventory = null;
	public Image[] m_InvenSprites { get; set; }

	[SerializeField]
	int Count;

	public int MAX_INVEN_COUNT = 6;


	protected override void Awake()
	{
        base.Awake();
	}

	public void OpenInven()
	{
		if (m_Inventory == null)
			m_Inventory = UIManager.Instance.ViewInven();

		LoadComplate();
	}

	public void LoadComplate()
	{
		StartCoroutine(StartManager());
	}

	IEnumerator StartManager()
	{
		while (Link_InventoryEvent.Instance != null && Link_InventoryEvent.Instance.m_bLoaded == false)
		{
			yield return null;
		}
		SetInven();

		EventManager.Instance.AddUpdateManager(UpdateManager);
	}

	void UpdateManager()
	{
		if (m_Inventory != null && UIManager.Instance.IsOpen(m_Inventory))
		{
			if (InputManager.GetKeyDown(KeyCode.I))
			{
				CloseInven();
			}
			else if (InputManager.GetKeyDown(KeyCode.Escape) && UIManager.Instance.m_CurUI == m_Inventory && !UIManager.Instance.Close)
				CloseInven();
		}
	}

	public void CloseInven()
	{
		UIManager.Instance.CloseUI(m_Inventory);
		m_Inventory = null;
		EventManager.Instance.DeleteUpdateManager(UpdateManager);
	}

	void SetInven()
	{
		List<ClientDataManager.Inven_Info> Inven = ClientDataManager.Instance.Character_Inven;
		if (Inven == null)
			return;


		for (int i = 0; i < m_InvenSprites.Length; i++)
		{
			if (i >= Inven.Count)
			{
				m_InvenSprites[i].gameObject.SetActive(false);
				continue;
			}

			m_InvenSprites[i].sprite = Inven[i].IconSp;
			m_InvenSprites[i].gameObject.SetActive(true);
		}
	}

	
}
