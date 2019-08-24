﻿/*
 *  Player item within the inventory, takes one of the 15 slots, can be equiped. interacts with world via invent parent
 */

using UnityEngine;
using UnityEngine.UI;

public class InventItemScript : MonoBehaviour
{
    public Image icon;
    private GameObject thisgameobject;
    private Equipment playerequipment;
    private string itemname;
    public bool taken = false;
    private int count = 0;
    private InventParent inventparent;
    private string description;

    private void Start()
    {
        playerequipment = (Equipment)Object.FindObjectOfType(typeof(Equipment));
    }

    public void SetItem(Sprite incicon, GameObject incthisgameobject, string incitemname,int amount,string itemdesc)
    {
        taken = true;
        icon.sprite = incicon;
        thisgameobject = incthisgameobject;
        icon.enabled = true;
        itemname = incitemname;
        count = amount;
        description = itemdesc;
    }

    public void IncreaseItem(int amount)
    {
        count = count + amount;
    }

    public void EquipItem()
    {
        inventparent.UpateUI(itemname +": " + count, description ,icon.sprite);
        Debug.Log("Equipping "+itemname + " " + count);
        playerequipment.equipitem(thisgameobject,this);
    }

    public bool IsTaken()
    {
        return taken;
    }

    public string GetItemName()
    {
        return itemname;
    }

    public void SetParent(InventParent incscript)
    {
        inventparent = incscript;
    }

    public bool UseItem()
    {
        if (count <= 0)
        {
            return false;
        } else
        {
            count--;
            return true;
        }
    }
}
