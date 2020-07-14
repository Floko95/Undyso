using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    private Vector3 fp;
    private Vector3 lp;
    private float dragDistance;
    public float rotationSpeed;
    
    Quaternion wantedRotation;  

    void Start()
    {
        dragDistance = Screen.height * 5 / 100; //distance de drag = 5% de l'écran
     
        wantedRotation = Quaternion.Euler(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1) // un seul doigt touche l'écran
        {
            Touch touch = Input.GetTouch(0); 
            if (touch.phase == TouchPhase.Began) 
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // mettre à jour la denrière position
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //si on retire le doigt
            {
                lp = touch.position;  

                //Si la distance dépasse 5%
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {
                 //Check si horizontal ou vertical
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //Si horinzontal
                        if ((lp.x > fp.x))  
                        {   //DROITE

                            wantedRotation = Quaternion.Euler(0, 0, -90);
                        }
                        else
                        {   //GAUCHE
                            wantedRotation = Quaternion.Euler(0, 0, 90);
                        }
                    }
                    else
                    {   //Si vertical
                        if (lp.y > fp.y)  
                        {   //HAUT
                            wantedRotation = Quaternion.Euler(0, 0, 0);
                        }
                        else
                        {   //BAS
                            wantedRotation = Quaternion.Euler(0, 0, 180);
                        }
                    }
                }
                else
                {   //tap, car la distance est de moins de 5%
                    
                }
            }
        }

        this.GetComponent<Rigidbody2D>().MoveRotation(Quaternion.Slerp(this.transform.rotation, wantedRotation, rotationSpeed));

        /*        Debugage PC
        if (Input.GetKeyDown(KeyCode.Z))
        {
            wantedRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            wantedRotation = Quaternion.Euler(0, 0, 90);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            wantedRotation = Quaternion.Euler(0, 0, 180);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            wantedRotation = Quaternion.Euler(0, 0, -90);
        }
        this.GetComponent<Rigidbody2D>().MoveRotation(Quaternion.Slerp(this.transform.rotation, wantedRotation, rotationSpeed));*/
    }
}
