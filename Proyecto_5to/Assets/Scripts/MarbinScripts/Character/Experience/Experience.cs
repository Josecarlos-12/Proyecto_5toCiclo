using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Experience : MonoBehaviour
{
    public WaveExpansiveProta waveProta;
    public SwordPunch sworPunch;
    public Sword sword;
    public Bullet bullet,laser;
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
    public int count, count2, count3, count4, count5, count6, count7;


    public GameObject level1, level2, level3, level4, level5, level6, level7;

    public bool one, two, three, four, five, choroLife;

    public string expePref = "EXP";

    public bool options;

    public float bulletD;
    public float meleD;
    public float bulletSpeed;
    public float moveSped;

    [Header("Enemigo")]
    public ExperienceFollow robotin;

    [Header("Guardar Datos")]
    public string sMaxExperience = "MaxExperience";


    public string sBulletD = "BD";
    public float fBulletD;

    public string sBulletSpeed = "BulletSpeed";
    public float fBulletSpeed;

    public string sLaserSpeed = "LaserSpeed";
    public float fLaserSpeed;

    public string sBulletAlcanec = "BulletAlcance";
    public float fBulletAlcance;

    public string sLaserAlcance = "LaserAlcance";
    public float fLaserAlcance;

    public string sSwordD = "SD";
    public float fSwordD;

    public string SLaserD = "LD";
    public float fLaserD;

    public string sLifeEnergy = "LE";
    public float fLifeEnergy;

    public string sSpeedProta = "SpeedProta";
    public float fSpeedProta;

    public string sRegenerationLife = "ReLife";
    public float fReLife;

    public string roboLife = "RoboLife";
    public float fRoboLi;

    public string sLessDash = "LessDash";
    public float fLessDa;

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
        NormalExperiecie();
        OPTIONS();
        TextExperience();
        MoreExperience();
        imageExperience.fillAmount = experience / maxExperience;
    }

    public void NormalExperiecie()
    {
        if (Input.GetKeyDown(KeyCode.F9))
        {
            text.text = "Experiencia";
            Debug.Log("SA");
            experience = 0;
            maxExperience = 300;
            PlayerPrefs.SetFloat("OP1", 0);
            PlayerPrefs.SetFloat("OP2", 0);
            PlayerPrefs.SetFloat("EXP", 0);
            PlayerPrefs.SetFloat("OPTION1", 0);
            PlayerPrefs.SetFloat("OPTION2", 0);
            PlayerPrefs.SetFloat("OPTION3", 0);
            PlayerPrefs.SetFloat("OPTION4", 0);
            //Onda Explosiva
            waveProta.canExplotion = false;
            //Robar Vida con cuchillo
            sworPunch.stealLife = false;
            sworPunch.choro = 25;
            //Daño Espada
            sword.damage = 50;
            //Daño bala
            bullet.damageB = 20;
            //Daño laser
            laser.damageB = 50;
            //Vida
            life.life= 1000;
            life.maxLife = 1000;
            //Energia
            energy.energy = 1000;
            energy.energyMax = 1000;
            // Velocidad de movimiento prota
            move.speed = 13;
            //Escudo
            shield.canShild = false;
            //Tipos de disparo
            weapon.typeBullet = false;
            weapon.bDoubleBullet = false;
        }
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
                experience += robotin.experience;
                
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

    public void TextExperience()
    {
        if (PlayerPrefs.GetFloat("OP1") == 1)
        {
            text.text = "Nivel 1";
        }
        if (PlayerPrefs.GetFloat("OP1") == 2)
        {
            text.text = "Nivel 2";
        }
        if (PlayerPrefs.GetFloat("OP1") == 3)
        {
            text.text = "Nivel 3";
        }
        if (PlayerPrefs.GetFloat("OP1") == 4)
        {
            text.text = "Nivel 4";
        }
        if (PlayerPrefs.GetFloat("OP1") == 5)
        {
            text.text = "Nivel 5";
        }
        if (PlayerPrefs.GetFloat("OP1") == 6)
        {
            text.text = "Nivel 6";
        }
        if (PlayerPrefs.GetFloat("OP1") == 7)
        {
            text.text = "Nivel 7";
        }
    }

    public void MoreExperience()
    {
        if (experience >= 300 && PlayerPrefs.GetFloat("OP1")==0)
        {            
            if(count<3)
            count ++;

            if (count == 1)
            {
                
                // ESpara que salga el canvas
                PlayerPrefs.SetFloat("OP1", 1);
                StopOculMose();
                level1.SetActive(true);
            }
        }

        if (experience >= 650 && PlayerPrefs.GetFloat("OP1") == 1)
        {                        
            if (count2 < 3)
                count2++;

            if (count2 == 1)
            {
                
                PlayerPrefs.SetFloat("OP1", 2);
                StopOculMose();
                level2.SetActive(true);
            }
        }

        if (experience >= 1200 && PlayerPrefs.GetFloat("OP1") == 2)
        {
            if (count3 < 3)
                count3++;

            if (count3 == 1)
            {
                
                PlayerPrefs.SetFloat("OP1", 3);
                StopOculMose();
                level3.SetActive(true);
            }
        }

        if (experience >= 1850 && PlayerPrefs.GetFloat("OP1") == 3)
        {
            if (count4 < 3)
                count4++;

            if (count4 == 1)
            {
                PlayerPrefs.SetFloat("OP1", 4);
                StopOculMose();
                level4.SetActive(true);
            }
        }
    }

    public void StopOculMose()
    {
        options = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    #region Option1
    public void DamageShoot()
    {
        maxExperience = 650;
        OculMouse();
        fBulletD = bullet.damageB += 10;
        fLaserD = laser.damageB + 10;
        level1.SetActive(false);

        // elegir primera opcion
        PlayerPrefs.SetFloat("OPTION1", 1);
    }

    public void MeleSword()
    {
        maxExperience = 650;
        OculMouse();
        fSwordD = sword.damage + 10;
        level1.SetActive(false);
        PlayerPrefs.SetFloat("OPTION1", 2);
    }

    public void Resistence()
    {
        maxExperience = 650;
        OculMouse();
        level1.SetActive(false);
        fLifeEnergy= life.maxLife += 100;
        life.life = life.maxLife;
        fLifeEnergy = energy.energyMax + 100;
        energy.energy=energy.energyMax;
        PlayerPrefs.SetFloat("OPTION1", 3);
    }
    #endregion

    #region Option2
    public void SpeedShoot()
    {
        maxExperience = 1200;
        OculMouse();
        fBulletSpeed= bullet.speedBullet + 2000;
        fLaserSpeed = laser.speedBullet + 2000;
        level2.SetActive(false);

        PlayerPrefs.SetFloat("OPTION2", 1);
    }

    public void speedMove()
    {
        maxExperience = 1200;
        OculMouse();
        fSpeedProta = move.speed + 7;
        level2.SetActive(false);
        PlayerPrefs.SetFloat("OPTION2", 2);
    }

    public void Shield()
    {
        maxExperience = 1200;
        OculMouse();
        level2.SetActive(false);
        shield.canShild = true;
        PlayerPrefs.SetFloat("OPTION2", 3);
    }
    #endregion

    #region Option3
    public void Alcance()
    {
        bullet.destructtion = fBulletAlcance;
        laser.destructtion = fLaserAlcance;
        maxExperience = 1850;
        OculMouse();
        level3.SetActive(false);
        PlayerPrefs.SetFloat("OPTION3", 1);
    }

    public void MeleSwordV2()
    {
        fSwordD = sword.damage + 10;
        maxExperience = 1850;
        OculMouse();
        level3.SetActive(false);
        PlayerPrefs.SetFloat("OPTION3", 2);
    }


    public void RegenerationLife()
    {
        maxExperience = 1850;
        OculMouse();
        level3.SetActive(false);
        PlayerPrefs.SetFloat("OPTION3", 3);
    }
    #endregion

    #region Option4
    public void BulletThunder()
    {
        maxExperience = 2200;
        OculMouse();
        level4.SetActive(false);
        PlayerPrefs.SetFloat("OPTION4", 1);
    }
    public void ChoroLife()
    {
        choroLife = true;
        maxExperience = 2200;
        OculMouse();
        level4.SetActive(false);
        PlayerPrefs.SetFloat("OPTION4", 2);
    }
    public void RegenerationEXP()
    {
        maxExperience = 2200;
        OculMouse();
        level4.SetActive(false);
        PlayerPrefs.SetFloat("OPTION4", 3);
    }

    #endregion


    #region Option5
    public void SpeedShootV2()
    {
        maxExperience = 2650;
        OculMouse();
        fBulletSpeed = bullet.speedBullet + 2000;
        fLaserSpeed = laser.speedBullet + 2000;
        level5.SetActive(false);
        PlayerPrefs.SetFloat("OPTION5", 1);
    }
    public void speedMoveV2()
    {
        maxExperience = 2650;
        fSpeedProta = move.speed + 7;
        OculMouse();
        level5.SetActive(false);
        PlayerPrefs.SetFloat("OPTION5", 2);
    }
    public void RegenerationLifeV2()
    {
        fReLife = life.fReLife + 30;
        maxExperience = 2650;
        OculMouse();
        level5.SetActive(false);
        PlayerPrefs.SetFloat("OPTION5", 3);
    }

    #endregion


    #region Option6
    public void DamageShootV2()
    {
        maxExperience = 3100;
        OculMouse();
        fBulletD = bullet.damageB += 10;
        fLaserD = laser.damageB + 10;
        level6.SetActive(false);
        PlayerPrefs.SetFloat("OPTION6", 1);
    }
    public void MeleSwordV3()
    {
        maxExperience = 3100;
        fSwordD = sword.damage + 10;
        OculMouse();
        level6.SetActive(false);
        PlayerPrefs.SetFloat("OPTION6", 2);
    }
    public void ResistenceV2()
    {
        fLifeEnergy = life.maxLife += 100;
        life.life = life.maxLife;
        fLifeEnergy = energy.energyMax += 100;
        energy.energy = energy.energyMax;
        maxExperience = 3100;
        OculMouse();
        level6.SetActive(false);
        PlayerPrefs.SetFloat("OPTION6", 3);
    }

    #endregion

    #region Option7
    public void DoubleBullet()
    {
        OculMouse();
        level7.SetActive(false);
        PlayerPrefs.SetFloat("OPTION7", 1);
    }
    public void ChoroLifeMore()
    {
        if (!choroLife)
        {
           fRoboLi = 25;
        }
        else if (choroLife)
        {
            fRoboLi = sworPunch.choro += 25;
        }

        OculMouse();
        level7.SetActive(false);
        PlayerPrefs.SetFloat("OPTION7", 2);
    }
    public void LessDash()
    {
        fLessDa= energy.lessDash - 50;
        OculMouse();
        level7.SetActive(false);
        PlayerPrefs.SetFloat("OPTION7", 3);
    }

    #endregion

    public void OculMouse()
    {
        experience = 0;
        options = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }
    public void SaveEsperience()
    {
        //Experienci Maxima
        PlayerPrefs.SetFloat(sMaxExperience, maxExperience);

        //Experiencia
        PlayerPrefs.SetFloat(expePref, experience);

        //Daño Bala
        PlayerPrefs.SetFloat(sBulletD, fBulletD);

        //Daño Laser
        PlayerPrefs.SetFloat(SLaserD, fLaserD);

        //Daño Espada
        PlayerPrefs.SetFloat(sSwordD, fSwordD);

        //Vida - Energia
        PlayerPrefs.SetFloat(sLifeEnergy, fLifeEnergy);

        //Velocidad Bala
        PlayerPrefs.SetFloat(sBulletSpeed, fBulletSpeed);

        //Velocidad Laser
        PlayerPrefs.SetFloat(sLaserSpeed, fLaserSpeed);

        //Velocidad Personaje
        PlayerPrefs.SetFloat(sSpeedProta, fSpeedProta);

        //Alcance Bala
        PlayerPrefs.SetFloat(sBulletAlcanec, fBulletAlcance);

        //Alcance Laser
        PlayerPrefs.SetFloat(sLaserAlcance, fLaserAlcance);

        //Regenerar vida
        PlayerPrefs.SetFloat(sLaserAlcance, fLaserAlcance);

        //Robo Vida - Espada
        PlayerPrefs.SetFloat(roboLife, fRoboLi);

        //menos cantidad para el dash
        PlayerPrefs.SetFloat(sLessDash, fLessDa);
    }

    public void LoadData()
    {
        //Experiencia Maxima
        maxExperience = PlayerPrefs.GetFloat(sMaxExperience, 0);

        //Experiencia
        experience = PlayerPrefs.GetFloat(expePref, 0);

        //Daño Bala
        fBulletD = PlayerPrefs.GetFloat(sBulletD, 0);

        //Daño Laser
        fLaserD = PlayerPrefs.GetFloat(SLaserD, 0);

        //Daño Espada
        fSwordD = PlayerPrefs.GetFloat(sSwordD, 0);

        //Vida - Energia
        fLifeEnergy = PlayerPrefs.GetFloat(sLifeEnergy, 0);

        //Velocidad Bala
        fBulletSpeed=PlayerPrefs.GetFloat(sBulletSpeed,0);

        //Velocidad laser
        fLaserSpeed = PlayerPrefs.GetFloat(sLaserSpeed, 0);

        //Velocidad Prota
        fSpeedProta =PlayerPrefs.GetFloat(sSpeedProta,0);

        //Regenerar Vida
        fReLife = PlayerPrefs.GetFloat(sRegenerationLife, 0);

        //Robar vida - Espada
        fRoboLi = PlayerPrefs.GetFloat(roboLife, 0);

        //menos cantidad para el dash
        fLessDa = PlayerPrefs.GetFloat(sLessDash, 0);
    }


    private void OnDestroy()
    {
        SaveEsperience();
    }


    public void OPTIONS()
    {
       if( PlayerPrefs.GetFloat("OPTION1") == 1)
        {
            bullet.damageB = fBulletD;
            laser.damageB = fLaserD;
        }
        if (PlayerPrefs.GetFloat("OPTION1") == 2)
        {
            sword.damage = fSwordD;
        }
        if (PlayerPrefs.GetFloat("OPTION1") == 3)
        {
            life.maxLife = fLifeEnergy;
            energy.energyMax = fLifeEnergy;
        }


        if (PlayerPrefs.GetFloat("OPTION2") == 1)
        {
            bullet.speedBullet = fBulletSpeed;
            laser.speedBullet = fLaserSpeed;
        }
        if (PlayerPrefs.GetFloat("OPTION2") == 2)
        {
            move.speed = fSpeedProta;
        }
        if (PlayerPrefs.GetFloat("OPTION2") == 3)
        {
            shield.canShild = true;
        }


        if (PlayerPrefs.GetFloat("OPTION3") == 1)
        {
            bullet.destructtion = fBulletAlcance;
            //laser.destructtion = fLaserAlcance;            
        }
        if (PlayerPrefs.GetFloat("OPTION3") == 2)
        {
            sword.damage = fSwordD;
            //No le pongo condicion porque el resultado se guarda en Option1=1
        }
        if (PlayerPrefs.GetFloat("OPTION3") == 3)
        {
            life.regeneration = true;
        }


        if (PlayerPrefs.GetFloat("OPTION4") == 1)
        {
            weapon.typeBullet = true;
        }
        if (PlayerPrefs.GetFloat("OPTION4") == 2)
        {
            sworPunch.stealLife = true;
        }
        if (PlayerPrefs.GetFloat("OPTION4") == 3)
        {
            waveProta.canExplotion = true;
        }


        if(PlayerPrefs.GetFloat("OPTION5") == 1)
        {
            bullet.speedBullet = fBulletSpeed;
            laser.speedBullet = fLaserSpeed;
        }
        if (PlayerPrefs.GetFloat("OPTION5") == 2)
        {
            move.speed = fSpeedProta;
        }
        if (PlayerPrefs.GetFloat("OPTION5") == 3)
        {
            life.regeneration = true;
            life.fReLife = fReLife;
        }


        if (PlayerPrefs.GetFloat("OPTION6") == 1)
        {
            bullet.damageB = fBulletD;
            laser.damageB = fLaserD;
        }
        if (PlayerPrefs.GetFloat("OPTION6") == 2)
        {
            sword.damage = fSwordD;
        }
        if (PlayerPrefs.GetFloat("OPTION6") == 3)
        {
            life.maxLife = fLifeEnergy;
            energy.energyMax = fLifeEnergy;
        }


        if (PlayerPrefs.GetFloat("OPTION7") == 1)
        {
            weapon.bDoubleBullet = true;
        }
        if (PlayerPrefs.GetFloat("OPTION7") == 2)
        {
            sworPunch.stealLife = true;
            sworPunch.choro = fRoboLi;
        }
        if (PlayerPrefs.GetFloat("OPTION7") == 3)
        {
            energy.lessDash = fLessDa;
        }
    }

}
