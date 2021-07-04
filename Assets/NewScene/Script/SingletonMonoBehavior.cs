using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehavior<T> : MonoBehaviour where T : SingletonMonoBehavior<T>
{
	private static T _Instance;
	public static T Instance
	{ get { return _Instance == null ? null : _Instance; } }

	protected virtual void Awake()
	{
		_Instance = (T)this;
	}
}
