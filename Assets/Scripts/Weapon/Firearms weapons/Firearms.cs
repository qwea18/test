using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firearms : Weapon
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public GameObject shellPrefab;
    protected Transform muzzlePos;
    protected Transform shellPos;

    [SerializeField] protected AudioClip ac;//开枪的声音
    protected override  void Start()
    {
        base.Start();
        muzzlePos = transform.Find("Muzzle");//枪械类植物的发射口，枪火光特效
        shellPos = transform.Find("BulletShell");//弹壳位置
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Fire()
    {
        base.Fire();
        /*  animator.SetTrigger("Shoot");

        // GameObject bullet = Instantiate(bulletPrefab, muzzlePos.position, Quaternion.identity);
        GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
        bullet.transform.position = muzzlePos.position;

        float angel = Random.Range(-5f, 5f);
        bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(angel, Vector3.forward) * direction);

        // Instantiate(shellPrefab, shellPos.position, shellPos.rotation);
        GameObject shell = ObjectPool.Instance.GetObject(shellPrefab);
        shell.transform.position = shellPos.position;
        shell.transform.rotation = shellPos.rotation;*/
    }
}
