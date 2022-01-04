using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShell : MonoBehaviour
{
    //子弹弹壳的出现到消失
    public float speed;
    public float stopTime = .5f;
    public float fadeSpeed = .01f;
    new private Rigidbody rigidbody;
    private SpriteRenderer sprite;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        sprite = GetComponent<SpriteRenderer>();


    }

    private void OnEnable()
    {
        float angel = Random.Range(-30f, 30f);
        rigidbody.velocity = Quaternion.AngleAxis(angel, Vector3.forward) * Vector3.up * speed;

        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);

        StartCoroutine(Stop());
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(stopTime);
        rigidbody.velocity = Vector2.zero;

        while (sprite.color.a > 0)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.g, sprite.color.a - fadeSpeed);
            yield return new WaitForFixedUpdate();
        }
        // Destroy(gameObject);
        ObjectPool.Instance.PushObject(gameObject);
    }
}
