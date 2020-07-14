using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class controle_jeu : MonoBehaviour {



    public Vector3 apparitionVague;
    
    public GameObject menaceTriangle;
    public GameObject menaceDiamond;
    public GameObject heal;
    

    public Canvas canvasGameOver;
    public Canvas canvasWin;
    public Button boutonRecommencer;
    public Button boutonMenu;
    public Text texteGameOver;

    public Text levelText;

    bool gameOver = false;







    void Start () {
        canvasWin = canvasWin.GetComponent<Canvas>();
        canvasGameOver = canvasGameOver.GetComponent<Canvas>();
        boutonRecommencer = boutonRecommencer.GetComponent<Button>();
        boutonMenu = boutonMenu.GetComponent<Button>();
        texteGameOver = texteGameOver.GetComponent<Text>();
        levelText = levelText.GetComponent<Text>();

        canvasWin.enabled = false;
        canvasGameOver.enabled = false;
        boutonMenu.enabled = false;
        boutonRecommencer.enabled = false;
        texteGameOver.enabled = false;
        levelText.GetComponent<Text>().text = "Level: " + Params.Level;


        StartCoroutine(ApparitionVague ());     //lancement de la génération de projectiles
	}

    public void GameOver()
    {
        gameOver = true;
        StopAllCoroutines();
        canvasGameOver.enabled = true;
        boutonMenu.enabled = true;
        boutonRecommencer.enabled = true;
        texteGameOver.enabled = true;
    }

    public void RecommencerPress()
    {
        canvasGameOver.enabled = false;
        boutonRecommencer.enabled = false;
        boutonMenu.enabled = false;
        texteGameOver.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void LevelSuivant()
    {
        if(Params.Level == Params.NbLevelsMax)
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            Params.SelectLevel(Params.Level + 1);
            canvasWin.enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
            
    }


    public void RetourMenu()
    {
        canvasGameOver.enabled = false;
        boutonRecommencer.enabled = false;
        boutonMenu.enabled = false;
        texteGameOver.enabled = false;
        SceneManager.LoadScene("Menu");


    }


    // Update is called once per frame
    IEnumerator  ApparitionVague () {


        Vector3 apparitionMenace;


        yield return new WaitForSeconds (Params.attenteDuDebut);    //une petite attente au début
		for(int j=0;j<Params.Nombrevagues;j++)                      // On fait spawn x Vagues de projectiles
        {
			for (int i=0; i<Params.nombreObstaclesParVague; i++)    //chaque vague à Y projectiles
            {

                
                switch ((int)Random.Range(0,3)) // on fait spawn un projectile dans une des quatres directions
                {
                    case 0:     //HAUT
                        apparitionMenace = new Vector3(Random.Range(-apparitionVague.x,apparitionVague.x)/2, apparitionVague.y, apparitionVague.z);
                        break;
                    case 1:     //GAUCHE
                        apparitionMenace = new Vector3(-apparitionVague.x, Random.Range(-apparitionVague.y,apparitionVague.y)/2, apparitionVague.z);
                        break;
                    case 2:     //BAS
                        apparitionMenace = new Vector3(Random.Range(-apparitionVague.x, apparitionVague.x)/2, -apparitionVague.y, apparitionVague.z);
                        break;
                    case 3:     //DROITE
                        apparitionMenace = new Vector3(apparitionVague.x, Random.Range(-apparitionVague.y, apparitionVague.y)/2, apparitionVague.z);
                        break;
                    default:
                        apparitionMenace = new Vector3(0, 0, 0);
                        break;
                }

				

				Quaternion rotationVague = Quaternion.identity;

                bool diamond_delay = false;             //les diamonds posent un délai supplémentaire avant le prochain spawn
                float typeProjectile = Random.value;    //on choisit au hasard entre les projectiles disponibles, avec une probabilité pour chacun, proba définie par la classe Params
                if (typeProjectile <= Params.probaHeal)     
                    Instantiate(heal, apparitionMenace, rotationVague);

                else if (typeProjectile <= Params.probaHeal + Params.probaDiamond)
                {
                    Instantiate(menaceDiamond, apparitionMenace, rotationVague);
                    diamond_delay = true;
                }
                    

                else
                    Instantiate(menaceTriangle, apparitionMenace, rotationVague);


                if(diamond_delay)
                {
                    diamond_delay = false;
                    yield return new WaitForSeconds(Params.IntervalleProjectiles + 0.5f);
                }
                    
                else
                    yield return new WaitForSeconds(Params.IntervalleProjectiles);  //on attend Z secondes avant le prochain projectile


            }
			yield return new WaitForSeconds (Params.intervalleVague);           //on attend Q secondes avant la prochaine vague
		

		}
        int k = (int) (4 - Params.vitesseTriangle);
        yield return new WaitForSeconds(Mathf.Clamp(k,0,4));        //une petite attente après la fin du niveau, pour que tous les projectiles aient le temps de rentrer en collision

        if (!gameOver) //evite les arrets de coroutines en retard
        {
            canvasWin.enabled = true; //gagné!
        }

	}
}
