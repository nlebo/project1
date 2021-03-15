using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inven_Manager : MonoBehaviour
{
    static public Inven_Manager m_Inven_Manager;
    Item_Manager LeftH,RightH,Head,Body,Foot;
    int[] EquipItems = new int[5];
    int[,] Inven_Grid;
    bool SetGrid;

    Item_Manager[,] HaveItems;

    UI_Manager UIM;
    
    // Start is called before the first frame update
    void Start()
    {
        SetGrid = false;
        UIM = UI_Manager.m_UI_Manager;
        m_Inven_Manager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Set_Grid(int x,int y)
    {
        if(SetGrid) return false;

        Inven_Grid = new int[y,x];
        HaveItems = new Item_Manager[y,x];

        Inven_Grid.Initialize();
        SetGrid = true;
        UpdateGridUI();
        return true;
    }

    public bool InsertItem(Item_Manager value)
    {
        if(!SetGrid) return false;

        int EmptyNum = -1;
        int x = 0, y = 0;

        for(y = 0 ; y < Inven_Grid.GetLength(0); y++)
        {
            for(x = 0 ; x< Inven_Grid.GetLength(1); x++ )
            {
                if(Inven_Grid[y,x] == 0 ) 
                {
                    EmptyNum = x + (y * Inven_Grid.GetLength(1));
                    break;
                }
            }

            if(EmptyNum != -1) break;
        }

        if(EmptyNum == -1) return false;


        HaveItems[y,x] = value;
        Inven_Grid[y,x] = 1;
        UpdateGridUI();

        return true;
    }

    public bool Equip(int x,int y)
    {
        Item_Manager value = HaveItems[y,x];
        if(value.equipable[0])
        {
            if(LeftH == null){ 
                LeftH = value;
                HaveItems[y,x]= null;
                Inven_Grid[y,x] = 0;
                
            }

            else{
                Item_Manager temp = LeftH;
                LeftH = value;
                HaveItems[y,x]= null;
                Inven_Grid[y,x] = 0;
                InsertItem(temp);
            }
            EquipItems[0] = value.ItemCode;
        }

        else if(value.equipable[1])
        {
            if(RightH == null){ 
                RightH = value;
                HaveItems[y,x]= null;
                Inven_Grid[y,x] = 0;
            }

            else{
                Item_Manager temp = RightH;
                RightH = value;
                HaveItems[y,x]= null;
                Inven_Grid[y,x] = 0;
                InsertItem(temp);
            }
            EquipItems[1] = value.ItemCode;
        }

        else if(value.equipable[2])
        {
            if(Head == null){ 
                Head = value;
                HaveItems[y,x]= null;
                Inven_Grid[y,x] = 0;
            }

            else{
                Item_Manager temp = Head;
                Head = value;
                HaveItems[y,x]= null;
                Inven_Grid[y,x] = 0;
                InsertItem(temp);
            }
            EquipItems[2] = value.ItemCode;
        }

        else if(value.equipable[3])
        {
            if(Body == null){ 
                Body = value;
                HaveItems[y,x]= null;
                Inven_Grid[y,x] = 0;
            }

            else{
                Item_Manager temp = Body;
                Body = value;
                HaveItems[y,x]= null;
                Inven_Grid[y,x] = 0;
                InsertItem(temp);
            }
            EquipItems[3] = value.ItemCode;
        }

        else if(value.equipable[4])
        {
            if(Foot == null){ 
                Foot = value;
                HaveItems[y,x]= null;
                Inven_Grid[y,x] = 0;
            }

            else{
                Item_Manager temp = Foot;
                Foot = value;
                HaveItems[y,x]= null;
                Inven_Grid[y,x] = 0;
                InsertItem(temp);
            }
            EquipItems[4] = value.ItemCode;
        }

        else return false;

        UpdateGridUI();

        return true;
    }

    public bool UpdateGridUI()
    {
        if(!SetGrid) return false;

        for(int x = 0 ; x < Inven_Grid.GetLength(1); x++)
        {
            for(int y = 0 ; y< Inven_Grid.GetLength(0); y++ )
            {
                if(Inven_Grid[y,x] == 1 ) 
                {
                   UIM.ChangeUI(UIM.UserInven_Grids[x + (y * Inven_Grid.GetLength(1))],HaveItems[y,x].UISprite);
                }
                else
                {
                    UIM.ChangeUI(UIM.UserInven_Grids[x + (y * Inven_Grid.GetLength(1))],null);
                }
            }
        }

        return true;
    }
    public int Get_Inven_Grid_Length(int value)
    {
        return Inven_Grid.GetLength(value);
        
    }
    
    public bool IsEquip(int itemCode)
    {
        for(int i = 0 ; i< EquipItems.Length;i++)
        {
            if(EquipItems[i] == itemCode) return true;
        }
        return false;
    }
}
