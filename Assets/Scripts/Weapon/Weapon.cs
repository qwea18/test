using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float interval1;//攻击间隔
    public float interval2;//特殊技能间隔 比如冲刺等
    protected float timer1;
    protected float timer2;
    protected Vector3 mousePos;
    protected Vector3 direction;
    
    protected Animator animator;//动画
    public string weaponName;
    protected AudioSource aus;
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        aus = GetComponent<AudioSource>();

    }

    protected virtual void Update()
    {
       
        Shoot();
    }

    protected virtual void Shoot()
    {
        direction = (mousePos - new Vector3(transform.position.x,0.5f, transform.position.z)).normalized;//正对着人物的高度,面朝方向
        transform.right = direction;

        if (timer1 != 0)
        {
            timer1 -= Time.deltaTime;
            if (timer1 <= 0)
                timer1 = 0;
        }
        if (timer2 != 0)
        {
            timer2 -= Time.deltaTime;
            if (timer2 <= 0)
                timer2 = 0;
        }

        if (Input.GetButton("Fire1"))
        {
            if (timer1 == 0)
            {
                timer1 = interval1;
                Fire();

            }
        }
        if (Input.GetButton("Fire2"))
        {
            if (timer2 == 0)
            {
                timer2 = interval2;
                Skill();

            }
        }

    }

    protected virtual void Skill()
    {


    }
    protected virtual void Fire()
    {
      
    }
    protected virtual void PlayAc(AudioClip ac)
    {
        aus.PlayOneShot(ac);
    }
}
