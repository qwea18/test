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
    
}
