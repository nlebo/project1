using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonMonoBehavior<UIManager>
{
    public GameObject UICanvas;
    public GameObject Inventory;
    public GameObject Box2x2;


    GameObject m_Inventory;
    GameObject m_Box2x2;
    public GameObject m_CurUI;

    public bool Close = false;

    List<GameObject> m_CurUIs = new List<GameObject>();

	protected override void Awake()
	{
		base.Awake();
        EventManager.Instance.AddUpdateManager(UpdateManager);
	}

	public void AddUI(GameObject obj)
    {
        Instantiate(obj, UICanvas.transform,false);
    }

    public GameObject ViewInven()
    {
        if (m_Inventory != null)
		{
			if (m_CurUIs.Contains(m_Inventory))
				m_CurUIs.Remove(m_Inventory);
			DestroyImmediate(m_Inventory);
        }
        m_Inventory = Instantiate(Inventory, UICanvas.transform, false);
        m_CurUIs.Add(m_Inventory);
        m_CurUI = m_Inventory;

        return m_Inventory;
    }
    public GameObject ViewBox2x2()
    {
        if (m_Box2x2 != null)
        {
            if (m_CurUIs.Contains(m_Box2x2))
                m_CurUIs.Remove(m_Box2x2);
            DestroyImmediate(m_Box2x2);
        }
        m_Box2x2 = Instantiate(Box2x2, UICanvas.transform, false);
        m_CurUIs.Add(m_Box2x2);
        m_CurUI = m_Box2x2;

        return m_Box2x2;
    }

    public bool IsOpen(GameObject Ui)
    {
        return m_CurUIs.Contains(Ui);
    }

    public void CloseUI(GameObject obj)
    {
        if (!m_CurUIs.Contains(obj))
            return;

        m_CurUIs.Remove(obj);
        DestroyImmediate(obj);

        if (m_CurUI == null && m_CurUIs.Count > 0)
            m_CurUI = m_CurUIs[0];
        Close = true;
    }

    void UpdateManager()
    {
        Close = false;
    }
}
