using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    static InputManager _Instance;
    static public InputManager Instance
    { get { return _Instance == null ? new InputManager() : _Instance; } }

    static Dictionary<KeyCode, bool> KeyIn = new Dictionary<KeyCode, bool>();
    static Dictionary<KeyCode, bool> KeyDown = new Dictionary<KeyCode, bool>();
    static List<KeyCode> CheckKey = new List<KeyCode>();

	private void Awake()
	{
        if (_Instance == null)
            _Instance = this;
	}

	// Start is called before the first frame update
	void Start()
    {
        EventManager.Instance.AddUpdateManager(UpdateManager);
    }

    // Update is called once per frame
    void UpdateManager()
    {
        foreach (var data in CheckKey)
        {
            SetKeyIn(data, Input.GetKey(data));
            SetKeyDown(data, Input.GetKeyDown(data));
        }
    }
   

    void SetKeyIn(KeyCode key,bool value)
    {
        if (!KeyIn.ContainsKey(key))
            KeyIn.Add(key, value);

        KeyIn[key] = value;
    }

    void SetKeyDown(KeyCode key, bool value)
    {
        if (!KeyDown.ContainsKey(key))
            KeyDown.Add(key, value);

        KeyDown[key] = value;
    }

    public static bool GetKeyDown(KeyCode key)
    {
        if (!KeyDown.ContainsKey(key))
        {
            if (!CheckKey.Contains(key))
                CheckKey.Add(key);
            KeyDown.Add(key, Input.GetKeyDown(key));
        }

        return KeyDown[key];
    }

    public static bool GetKeyIn(KeyCode key)
    {
        if (!KeyIn.ContainsKey(key))
		{
			if (!CheckKey.Contains(key))
				CheckKey.Add(key);
            KeyIn.Add(key, Input.GetKey(key));
        }

        return KeyIn[key];
    }
}
