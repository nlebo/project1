using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    static EventManager _Instance;
    static public EventManager Instance
    { get { return _Instance == null ? new EventManager() : _Instance; } }

    public delegate void updatemanager();
	updatemanager UpdateManager;
	updatemanager FixedUpdateManager;

	private void Awake()
	{
		if (_Instance == null)
			_Instance = this;
	}

	private void Update()
	{
		UpdateManager();
	}

	private void FixedUpdate()
	{
		FixedUpdateManager();
	}

	public void AddUpdateManager(updatemanager value)
	{
		if (UpdateManager == value)
			UpdateManager -= value;
		UpdateManager += value;
	}

	public void AddFixedUpdateManager(updatemanager value)
	{
		if (FixedUpdateManager == value)
			FixedUpdateManager -= value;
		FixedUpdateManager += value;
	}

	public void DeleteUpdateManager(updatemanager value)
	{
	    UpdateManager -= value;
	}

}
