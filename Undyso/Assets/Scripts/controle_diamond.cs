using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controle_diamond : MonoBehaviour
{


    
    public float posTriggerRotate;
    public ParticleSystem Particule_contact_shield;
    Rigidbody2D rigidbodyDiamond;
    


    float rotatedone = 0;
    bool rotateEnCours = false;
    bool once = false;




    // Start is called before the first frame update
    void Start()
    {

        rigidbodyDiamond = GetComponent<Rigidbody2D>();
        rigidbodyDiamond.AddForce(new Vector2(-this.transform.position.x, -this.transform.position.y) * Params.vitesseTriangle);//de base le diamant va vers le joueur en 0,0
        
    }
    private void FixedUpdate()
    {
        if ((Mathf.Abs(rigidbodyDiamond.position.x) <= posTriggerRotate-1 && Mathf.Abs(rigidbodyDiamond.position.y) <= posTriggerRotate) || rotateEnCours == true) //dès qu'on franchis le seuil
        {
            if (rotatedone == 0)    //on stoppe le mouvement
            {
                rigidbodyDiamond.velocity = new Vector2(0, 0);
                rotateEnCours = true;
            }
                
            if (rotatedone < 180)  //tant qu'on a pas tourné sur 180 degrés,on tourne autour de 0,0
            {
                
                transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 0, 1), 180 * Time.deltaTime);
                rotatedone += Time.deltaTime * 180;
               
            }
            else if (rotatedone >= 180 && once == false)    //dès qu'on a tourné sur 180 degrés, on remet la vélocité pour répartir vers le joueur
            {
                
                once = true;
                rotateEnCours = false;
                
                
                rigidbodyDiamond.velocity = new Vector2(-this.transform.position.x,-transform.position.y) * (Params.vitesseTriangle /2);
                
            }
        }
            

    }

    private void OnTriggerEnter2D(Collider2D other)
    {



        if (other.tag == "GameController")
        {
            Instantiate(Particule_contact_shield, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }
        else if (other.tag == "Player")//géré par le HP_manager
        {




            Destroy(gameObject);


        }
        


    }

}
