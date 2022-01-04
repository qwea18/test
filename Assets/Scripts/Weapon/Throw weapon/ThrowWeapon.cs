using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowWeapon : Weapon
{
    //最基本实现的武器
    public GameObject bulletPrefab;
    protected Transform muzzlePos;

    [SerializeField] protected AudioClip ac;    //投掷时的声音 如风声
    protected override void Start()
    {
        base.Start();
        muzzlePos = transform.Find("Muzzle");//投掷处
    }
    protected override void Update()
    {
        base.Update();
    }
    protected override void Fire()
    {
        base.Fire();
       // animator.SetTrigger("Shoot");

        // GameObject bullet = Instantiate(bulletPrefab, muzzlePos.position, Quaternion.identity);
        GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
        bullet.transform.position = muzzlePos.position;

        float angel = Random.Range(-5f, 5f);
        bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(angel, Vector3.forward) * direction);

        // Instantiate(shellPrefab, shellPos.position, shellPos.rotation);
       // GameObject shell = ObjectPool.Instance.GetObject(shellPrefab);
      //  shell.transform.position = shellPos.position;
      //  shell.transform.rotation = shellPos.rotation;
    }
}
