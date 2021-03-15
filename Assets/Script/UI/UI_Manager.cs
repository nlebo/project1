using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager m_UI_Manager;

    public Image UserInven;
    public Image[] UserInven_Grids;
    public Image HpBar;
    public Image StaminaBar;
    public Image Box_2X2;
    public Image Dig_Bar;

    public float STime, DTime=0.2f;
    public bool Click;
    // Start is called before the first frame update
    void Start()
    {
        m_UI_Manager = this;
        STime = 0;
        Click = false;
    }

    void Update()
    {
        if(Click)
        {
            STime += Time.deltaTime;
            if(STime >= DTime)
            {
                Click = false;
                STime = 0;
            }
        }
    }

    // Update is called once per frame
    
    public bool ChangeUI(Image _image ,Sprite _sprite)
    {
        if(_sprite == null)
            _image.gameObject.SetActive(false);

        else
            _image.gameObject.SetActive(true);

        _image.sprite = _sprite;

        return true;
    }

    public void SelectUserInven(string where)
    {
        if(!Click)
        {
            Click = true;
            return;
        }

        int _where = int.Parse(where);
        Inven_Manager IN = Inven_Manager.m_Inven_Manager;
        IN.Equip(_where % IN.Get_Inven_Grid_Length(1), _where / IN.Get_Inven_Grid_Length(1));

    }

    public void ChangeBarValue(string what,float value)
    {
        switch(what)
        {
            case "HP" :
            HpBar.fillAmount = value;
            break;
            case "Stamina" :
            StaminaBar.fillAmount = value;
            break;

            case "Dig" :
            Dig_Bar.fillAmount = value;
            break;

        }
    }
}
