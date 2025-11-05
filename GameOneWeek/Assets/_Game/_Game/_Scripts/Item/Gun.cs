using System;
using UnityEngine;

public class Gun : Item, ICollectable
{
    public bool New = true;
    public int currBullets = 10, currMags = 12;
    

    public void OnCollected(PlayerCollect collector)
    {
        collector.CollectItem(this);
    }
}
