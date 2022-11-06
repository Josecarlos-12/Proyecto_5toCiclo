using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Experience : MonoBehaviour
{
    public Sword sword;
    public Bullet bullet;
    public Life life;
    public Energy energy;
    public MoveRGB move;
    public Shield shield;
    public Weapon weapon;

    public Image imageExperience;
    public GameObject ObjecExperience;
    public float experience;
    public float EXP;
    public float maxExperience;


    public TextMeshProUGUI text;
    public int count, count2, count3, count4;


    public GameObject level1, level2, level3, level4;

    public bool one, two, three, four, five;

    public string expePref = "EXP";

    public bool options;

    public float bulletD;
    public float meleD;
    public float bulletSpeed;
    public float moveSped;
    private void Awake()
    {
       LoadData();
    }

    void Start()
    {
        //PlayerPrefs.SetFloat("OP1", 0);
        //PlayerPrefs.SetFloat("OP2", 0);
        //PlayerPrefs.SetFloat("EXP", 0);
        //PlayerPrefs.SetFloat("OPTION1", 0);
        //PlayerPrefs.SetFloat("OPTION2", 0);
        //PlayerPrefs.SetFloat("OPTION3", 0);
        //PlayerPrefs.SetFloat("OPTION4", 0);

        ObjecExperience.SetActive(false);
        imageExperience.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        OPTIONS();
        MoreExperience();
        imageExperience.fillAmount = experience / maxExperience;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Experience"))
        {
            Destroy(other.gameObject);
            if (experience <= maxExperience)
            {
                ObjecExperience.SetActive(true);
                imageExperience.enabled = true;
                experience += 50;
                
                StartCoroutine(Experi());
            }
        }
    }

    public IEnumerator Experi()
    {
        yield return new WaitForSeconds(3);
        imageExperience.enabled = false;
        ObjecExperience.SetActive(false);
    }

    public void MoreExperience()
    {
        if (experience >= 300 && PlayerPrefs.GetFloat("OP1")==0)
        {            
            text.text = "Nivel 1";

            if(count<3)
            count ++;

            if (count == 1)
            {
                // ESpara que salga el canvas
                PlayerPrefs.SetFloat("OP1", 1);
                options = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
                level1.SetActive(true);
            }
        }

        if (experience >= 550 && PlayerPrefs.GetFloat("OP1") == 1)
        {
            
            text.text = "Nivel 2";

            if (count2 < 3)
                count2++;


            if (count2 == 1)
            {
                PlayerPrefs.SetFloat("OP1", 2);
                options = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
                level2.SetActive(true);
            }
        }

        if (experience >= 850 && PlayerPrefs.GetFloat("OP1") == 2)
        {
            text.text = "Nivel 3";
            count3++;
            if (count3 == 1)
            {
                PlayerPrefs.SetFloat("OP1", 3);
                options = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
                level3.SetActive(true);
            }
        }

        if (experience >= 1100 && PlayerPrefs.GetFloat("OP1") == 3)
        {
            text.text = "Nivel 4";
            count4++;
            if (count4 == 1)
            {
                PlayerPrefs.SetFloat("OP1", 4);
                options = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
                level4.SetActive(true);
            }
        }
    }


    #region Option1
    public void DamageShoot()
    {
        OculMouse();
        bullet.damageB += 10;
        level1.SetActive(false);

        // elegir primera opcion
        PlayerPrefs.SetFloat("OPTION1", 1);
    }

    public void MeleSword()
    {
        OculMouse();
        sword.damage += 10;
        level1.SetActive(false);
        PlayerPrefs.SetFloat("OPTION1", 2);
    }

    public void Resistence()
    {
        OculMouse();
        level1.SetActive(false);
        life.maxLife += 100;
        life.life = life.maxLife;
        energy.energyMax += 100;
        energy.energy=energy.energyMax;
        PlayerPrefs.SetFloat("OPTION1", 3);
    }
    #endregion

    #region Option2
    public void SpeedShoot()
    {
        OculMouse();
        bullet.speedBullet += 2000;
        level2.SetActive(false);

        PlayerPrefs.SetFloat("OPTION2", 1);
    }

    public void speedMove()
    {
        OculMouse();
        move.speed += 7;
        level2.SetActive(false);
        PlayerPrefs.SetFloat("OPTION2", 2);
    }

    public void Shield()
    {
        OculMouse();
        level2.SetActive(false);
        shield.canShild = true;
        PlayerPrefs.SetFloat("OPTION2", 3);
    }
    #endregion

    #region Option3
    public void Alcance()
    {
        OculMouse();
        level3.SetActive(false);
        PlayerPrefs.SetFloat("OPTION3", 1);
    }

    public void VelMove()
    {
        OculMouse();
        level3.SetActive(false);
        PlayerPrefs.SetFloat("OPTION3", 2);
    }


    public void RegenerationLife()
    {
        OculMouse();
        level3.SetActive(false);
        PlayerPrefs.SetFloat("OPTION3", 3);
    }
    #endregion

    #region Option4
    public void BulletThunder()
    {
        OculMouse();
        level4.SetActive(false);
        PlayerPrefs.SetFloat("OPTION4", 1);
    }
    public void ChoroLife()
    {
        OculMouse();
        level4.SetActive(false);
        PlayerPrefs.SetFloat("OPTION4", 2);
    }
    public void RegenerationEXP()
    {
        OculMouse();
        level4.SetActive(false);
        PlayerPrefs.SetFloat("OPTION4", 3);
    }

    #endregion

    public void OculMouse()
    {
        options = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }
    public void SaveEsperience()
    {
        PlayerPrefs.SetFloat(expePref, experience);
    }

    public void LoadData()
    {
        experience = PlayerPrefs.GetFloat(expePref, 0);
    }


    private void OnDestroy()
    {
        SaveEsperience();
    }


    public void OPTIONS()
    {
       if( PlayerPrefs.GetFloat("OPTION1") == 1)
        {
            bullet.damageB = 30;
        }
        if (PlayerPrefs.GetFloat("OPTION1") == 2)
        {
            sword.damage = 60;
        }
        if (PlayerPrefs.GetFloat("OPTION1") == 3)
        {
            life.maxLife = 1100;
            energy.energy = 1100;
        }


        if (PlayerPrefs.GetFloat("OPTION2") == 1)
        {
            bullet.speedBullet = 5000;
        }
        if (PlayerPrefs.GetFloat("OPTION2") == 2)
        {
            move.speed = 15;
        }
        if (PlayerPrefs.GetFloat("OPTION2") == 3)
        {
            shield.canShild = true;
        }


        if (PlayerPrefs.GetFloat("OPTION3") == 1)
        {
        }
        if (PlayerPrefs.GetFloat("OPTION3") == 2)
        {
        }
        if (PlayerPrefs.GetFloat("OPTION3") == 3)
        {
        }


        if (PlayerPrefs.GetFloat("OPTION4") == 1)
        {
            weapon.typeBullet = true;
        }
        if (PlayerPrefs.GetFloat("OPTION4") == 2)
        {
        }
        if (PlayerPrefs.GetFloat("OPTION4") == 3)
        {
        }
    }

}
