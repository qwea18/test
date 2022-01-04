using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class health : MonoBehaviour
{

    public int Hp;
    public int water;
    public int growth;

    protected Slider lifeBar;
    protected Slider waterBar;
    protected Slider growthBar;

    public AudioClip hurt;
    protected Text lifeText;
    protected Text damageMessage;
    
    protected virtual void Start() {
       /* lifeBar.maxValue = Hp;
        lifeBar.value = Hp;*/
    }

    protected virtual void GetHurt( int x )
    {
        GetComponent<AudioSource>().PlayOneShot(hurt);
        Hp -= x;
        lifeBar.value = Hp;
        if (Hp < 0)
        {
            Hp = 0;
        }
        damageMessage.gameObject.SetActive(true);
        damageMessage.text = "- " + x.ToString();
        lifeText.text = Hp.ToString() + "  /  " + lifeBar.maxValue.ToString();
        Invoke("CloseTheDamageMessage", 0.5f);

    }
    protected virtual void GetCure()
    {

    }

    protected virtual void CloseTheDamageMessage()
    {
        damageMessage.gameObject.SetActive(false);
    }
}
