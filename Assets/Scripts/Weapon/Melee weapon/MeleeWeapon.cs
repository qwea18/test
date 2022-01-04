using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] protected AudioClip acATK;//近战攻击声音
    [SerializeField] protected AudioClip acSKL;//技能声音
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
    }
    protected override void Fire()
    {
        base.Fire();
    }
    protected override void Skill()//近战武器搭载冲刺，加速，格挡等功能
    {
        base.Skill();
    }
}
