using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controle_triangle : MonoBehaviour
{



    
    public ParticleSystem Particule_contact_shield;
    Rigidbody2D rigidbodyTriangle;
    







    // Start is called before the first frame update
    void Start()
    {
        
        rigidbodyTriangle = GetComponent<Rigidbody2D>();
        rigidbodyTriangle.AddForce(new Vector2(-this.transform.position.x, -this.transform.position.y) * Params.vitesseTriangle);  //le traingle se dirige en 0,0 vers le joueur
        rigidbodyTriangle.angularVelocity = Random.Range(0, 360);   //le triangle tourne aléatoirement
    }


    private void OnTriggerEnter2D(Collider2D other)
    {


        
        if (other.tag == "GameController")      
        {
            Instantiate(Particule_contact_shield,this.transform.position,this.transform.rotation);
            Destroy(gameObject);
        }
        else if(other.tag == "Player")  //la collision avec le joueur est gérée par le Hp Manager
        {
           
               

            
            Destroy(gameObject);
             
           
        }
       
        
    }
   
}
