using System;
using UnityEngine;

public class Gun : Item, ICollectable, IShootable
{
    [SerializeField] GunSO itemData;

    private int currBullets, currMags;

    private void Start()
    {
        currBullets = itemData.bulletCount;
        currMags = itemData.magCount;
    }

    public void OnCollected(PlayerCollect collector)
    {
        collector.CollectItem(this);
    }

    public void Shoot()
    {
        
    }

    public void Reload()
    {
        
    }
}
