using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    [SerializeField] private List<Item> Inventory = new List<Item>(6);  
    [SerializeField] private int currBullet, currMegs;
    
    
    public void CollectItem(Item item)
    {
        for (int i = 0; i < Inventory.Count; i++)
        {
            if(Inventory[i] == null)
            {
                Inventory[i] = item;
                Gun gun = item.GetComponent<Gun>();
                if (gun != null)
                {
                    currBullet = gun.currBullets;
                    currMegs = gun.currMags;
                }
                break;
            }
        }
    }
    
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        ICollectable item = other.GetComponent<ICollectable>();
        if (item != null)
        {
            Debug.Log(other.name + " collected");
            item.OnCollected(this);
            
        }
    }
}
