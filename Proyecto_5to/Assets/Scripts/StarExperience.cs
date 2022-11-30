using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.SocialPlatforms.Impl;
using System.Xml.Linq;

public class StarExperience : MonoBehaviour
{
    public int count;
    public Experience exp;


    private void Update()
    {
        if (count < 3)
        {
            count++;
        }

        if (count == 1)
        {
            //Enemies
            PlayerPrefs.SetInt("BossDeath", 0);

            PlayerPrefs.SetInt("DoubleJump", 0);
            PlayerPrefs.SetInt("Dash", 0);

            exp.text.text = "0";
            Debug.Log("SA");
            exp.experience = 0;
            exp.maxExperience = 300;
            PlayerPrefs.SetFloat("OP1", 0);
            PlayerPrefs.SetFloat("OP2", 0);
            PlayerPrefs.SetFloat("EXP", 0);
            PlayerPrefs.SetFloat("OPTION1", 0);
            PlayerPrefs.SetFloat("OPTION2", 0);
            PlayerPrefs.SetFloat("OPTION3", 0);
            PlayerPrefs.SetFloat("OPTION4", 0);
            //Onda Explosiva
            exp.waveProta.canExplotion = false;
            //Robar Vida con cuchillo
            exp.sworPunch.stealLife = false;
            exp.sworPunch.choro = 25;
            //Daño Espada
            exp.sword.damage = 50;
            //Daño bala
            exp.bullet.damageB = 20;
            //Daño laser
            exp.laser.damageB = 50;
            //Vida
            exp.life.life = 1000;
            exp.life.maxLife = 1000;
            //Energia
            exp.energy.energy = 1000;
            exp.energy.energyMax = 1000;
            // Velocidad de movimiento prota
            exp.move.speed = 13;
            //Escudo
            exp.shield.canShild = false;
            //Tipos de disparo
            exp.weapon.typeBullet = false;
            exp.weapon.bDoubleBullet = false;
            //Alcance
            exp.laser.destructtion = 0.5f;
            exp.bullet.destructtion = 0.5f;
        }
    }
}
