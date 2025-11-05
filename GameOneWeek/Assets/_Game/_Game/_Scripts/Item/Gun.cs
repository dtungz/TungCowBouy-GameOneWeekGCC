using System;
using UnityEngine;

public class Gun : Item, ICollectable
{
    [SerializeField] GunSO itemData;
    public bool New = true;
    public int currBullets = 10, currMags = 12;
    

    public void OnCollected(PlayerCollect collector)
    {
        collector.CollectItem(this);
    }
}
