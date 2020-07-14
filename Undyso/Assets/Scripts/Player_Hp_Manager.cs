using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player_Hp_Manager : MonoBehaviour
{

    
    public ParticleSystem Particule_contact_joueur;
    public ParticleSystem Particule_Heal;
    Canvas displayHP; 
    public GameObject textHp;
    public controle_jeu controller_jeu;

    private int Hps = Params.startingHP;


    // Start is called before the first frame update
    void Start()
    {
        

        
        displayHps(Hps);
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Projectile")
        {
            Destroy(collision.gameObject);
            Instantiate(Particule_contact_joueur, this.transform.position, this.transform.rotation);
           
            Hps--;
           
            displayHps(Hps);
            if (Hps <= 0)       //si plus d'hps, game over
            {
                Destroy(gameObject);
                controller_jeu.GameOver();
            }
       
        }
        else if (collision.tag == "Heal")   //Si le joueur se prend un heal, augmente ses Hps
        {
            Destroy(collision.gameObject);
            Instantiate(Particule_Heal, this.transform.position, this.transform.rotation);
            if(Hps < Params.startingHP)
                Hps++;
            displayHps(Hps);
        }

         
    }

   

    void displayHps(int value)      //affiche les Hps du joueur
    {
        
        textHp.GetComponent<Text>().text = "" + value;
        

    }
}
