using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunWeapon : Weapon
{
    // Start is called before the first frame update
    protected bool isShooting;

    [SerializeField] protected AudioClip ac;//持续攻击播放声音
    protected override  void Start()
    {
        base.Start();
    }

    // Update is called once per frame
  protected override  void Update()
    {
        base.Update(); 
    }

    protected override void Shoot()//持续攻击单独实现，不需要使用interval
    {
        // base.Shoot();
        if (Input.GetButtonDown("Fire1"))
        {

            isShooting = true;

        }
        if (Input.GetButtonUp("Fire1"))
        {
            isShooting = false;
        }
        animator.SetBool("Shoot", isShooting);

        if (isShooting)
        {
            Fire();
        }
        else
        {
            aus.Stop();
        }
    }

    protected override void PlayAc(AudioClip ac)
    {
        // base.PlayAc();
        aus.Play();
    }
}
