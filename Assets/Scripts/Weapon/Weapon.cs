using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
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


    // 获取鼠标位置得到子弹发射方向
    #region mousePosition
    private Vector3 screenPosition;//将物体从世界坐标转换为屏幕坐标
    private  Vector3 mousePositionOnScreen;//获取到点击屏幕的屏幕坐标
    private   Vector3 mousePositionInWorld;//将点击屏幕的屏幕坐标转换为世界坐标
    private Vector3 MouseFollow()
    {
        //获取鼠标在相机中（世界中）的位置，转换为屏幕坐标；
        screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        //获取鼠标在场景中坐标
        mousePositionOnScreen = Input.mousePosition;
        //让场景中的Z=鼠标坐标的Z
        mousePositionOnScreen.z = screenPosition.z;
        //将相机中的坐标转化为世界坐标
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
        //物体跟随鼠标移动
        //transform.position = mousePositionInWorld;
        //物体跟随鼠标X轴移动
        return new Vector3(mousePositionInWorld.x, mousePositionInWorld.y, mousePositionInWorld.z);
    }
    #endregion
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        aus = GetComponent<AudioSource>();

    }

    protected virtual void Update()
    {
        mousePos = MouseFollow();
       
        Shoot();
    }

    protected virtual void Shoot()
    {
      
        direction = (mousePos - new Vector3(transform.parent. position.x,0, transform.parent .position.z)).normalized;//正对着人物的高度,面朝方向
        direction.y = 0;
        //计时器
        #region interval
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
        #endregion

    }

    protected virtual void Skill()
    {


    }
    protected virtual void Fire()
    {
       // Debug.Log(mousePos);

    }
    protected virtual void PlayAc(AudioClip ac)
    {
        aus.PlayOneShot(ac);
    }
}
