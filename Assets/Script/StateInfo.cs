using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateInfo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float HP,Stamina;
    void Start()
    {
        
    }

    public float GetHP()
    {
        return HP;
    }

    public float GetStamina()
    {
        return Stamina;
    }

    protected bool UseStamina(float value)
    {
        if(Stamina - value < 0)
            return false;
        Stamina = Stamina - value;
        return true;
    }
}
