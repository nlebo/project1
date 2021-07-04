using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBox : MonoBehaviour
{
    [SerializeField]
    CharacterManager CM;
    public bool RideOn;
    public bool BoxOn;
    public bool MotorOn;
    public bool ItemOn;
    public bool PlaneOn;
    public Transform RideTransform;
    public Transform Hit_Transform;
    public Box _Box;
    public Cart _Cart;
    public Item_Manager _Item;

    public Clickable SelectedItem;




    public bool HandleOn;
    // Start is called before the first frame update
    void Start()
    {
        RideOn = false;
        EventManager.Instance.AddUpdateManager(UpdateManager);
    }

    // Update is called once per frame

    void UpdateManager()
    {
        if (SelectedItem != null && InputManager.GetKeyDown(KeyCode.F))
        {
            SelectedItem.OnClick();
        }
    }

    public void ResetAll()
    {

    }

    private void OnTriggerEnter(Collider other) {
        SelectedItem = other.GetComponent<Clickable>();

        if (SelectedItem == null)
            return;

        SelectedItem.OnMouseOn();
    }

    private void OnTriggerExit(Collider other) {
        SelectedItem = other.GetComponent<Clickable>();

        if (SelectedItem == null)
            return;

        SelectedItem.OnMouseExit();
    }
}
