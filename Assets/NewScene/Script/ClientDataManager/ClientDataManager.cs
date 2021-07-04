using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientDataManager : SingletonMonoBehavior<ClientDataManager>
{
	public struct Inven_Info
	{
		public int ntype;
		public int nID;
		public int nCount;

		public Sprite IconSp;
	}

	private List<Inven_Info> m_Char_Inven;
	public List<Inven_Info> Character_Inven
	{ get { return m_Char_Inven; } set { m_Char_Inven = value; } }



	protected override void Awake()
	{
		base.Awake();
	}
}
