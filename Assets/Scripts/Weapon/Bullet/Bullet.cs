using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float speed;//子弹飞行速度
    public GameObject explosionPrefab; //击中效果
    new private Rigidbody rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void SetSpeed(Vector3 direction)
    {
        rigidbody.velocity = direction * speed;
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster" || other.tag == "Wall")
        {
            GameObject exp = ObjectPool.Instance.GetObject(explosionPrefab);
            exp.transform.position = transform.position;

            // Destroy(gameObject);
            ObjectPool.Instance.PushObject(gameObject);
        }
    }

}
