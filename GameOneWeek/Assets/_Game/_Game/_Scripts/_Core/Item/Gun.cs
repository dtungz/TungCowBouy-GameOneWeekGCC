using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour, IShootable
{
    public void Shoot(Vector2 direction)
    {
        direction = direction - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        BulletPlayer bullet = PoolManager.Spawn<BulletPlayer>(PoolType.Bullet, transform.position, Quaternion.Euler(0, 0, angle));
        if(ChoiceGun.currGun == GunStatic.Shotgun)
        {
            BulletPlayer bullet1 = PoolManager.Spawn<BulletPlayer>(PoolType.Bullet, transform.position, Quaternion.Euler(0, 0, angle - 20));
            BulletPlayer bullet2 = PoolManager.Spawn<BulletPlayer>(PoolType.Bullet, transform.position, Quaternion.Euler(0, 0, angle + 20));
        }
    }
}
