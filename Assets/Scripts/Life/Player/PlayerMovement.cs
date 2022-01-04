using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class PlayerMovement : health
    {
        public GameObject[] guns;
        public float speed;
        private Vector3 input;
        private Vector3 mousePos;
        private Animator animator;
        private Rigidbody rigidbody;
        private int gunNum;
        public Text gunName;
        private int nameTimer;
        protected override void Start()
        {
          //  animator = GetComponent<Animator>();
            rigidbody = GetComponent<Rigidbody>();
            //guns[0].SetActive(true);
            nameTimer = 0;

            // health
          //  lifeBar = transform.Find("CanvasHealth/Image/hp").GetComponent<Slider>();
          //  damageMessage = transform.Find("CanvasInWorld/damageMessage").GetComponent<Text>();
          //  lifeText = transform.Find("CanvasHealth/Image/hp/Text").GetComponent<Text>();
            base.Start();

        }

        protected override void GetHurt(int x)
        {
            base.GetHurt(x);
          //  CameraController.isshakeCamera = true;

        }


        void Update()
        {
            //  SwitchGun();
            input.y = 0;
            input.x = Input.GetAxisRaw("Horizontal");
            input.z = Input.GetAxisRaw("Vertical");

            rigidbody.velocity = input.normalized * speed;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

          /*  if (mousePos.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                gunName.gameObject.transform.parent.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                gunName.gameObject.transform.parent.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }

            if (input != Vector2.zero)
                animator.SetBool("isMoving", true);
            else
                animator.SetBool("isMoving", false);*/
        }

        void SwitchGun()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                guns[gunNum].SetActive(false);
                if (++gunNum > guns.Length - 1)
                {
                    gunNum = 0;
                }
                guns[gunNum].SetActive(true);
                gunName.gameObject.SetActive(true);
                GetComponent<AudioSource>().Play();
                 gunName.text = guns[gunNum].GetComponent<Weapon>().weaponName.ToString();
                nameTimer++;
                Invoke("CloseGunName", 1f);
               // Debug.Log(guns[gunNum].name);
            }
            /* if (Input.GetKeyDown(KeyCode.E))
             {
                 guns[gunNum].SetActive(false);
                 if (--gunNum <0)
                 {
                     gunNum = guns.Length - 1;
                 }
                 guns[gunNum].SetActive(true);
             }*/
            if (Input.GetKeyDown(KeyCode.E))
            {
                GetHurt(1);
            }
        }
        private void CloseGunName()
        {
            nameTimer--;
            if (nameTimer <= 0)
            {
                nameTimer = 0;
                gunName.gameObject.SetActive(false); }
        }

    }
  