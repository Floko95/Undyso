using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class controle_menu : MonoBehaviour
{

    public Canvas levelCanvas;
    public Canvas menuCanvas;
    public Canvas htpCanvas;
    public void Start()
    {
        levelCanvas = levelCanvas.GetComponent<Canvas>();
        menuCanvas = menuCanvas.GetComponent<Canvas>();
        htpCanvas = htpCanvas.GetComponent<Canvas>();
        levelCanvas.enabled = false;
        htpCanvas.enabled = false;
    }

    public void Jouer()
    {
        
        menuCanvas.enabled = false;
        levelCanvas.enabled = true;

    }

    public void SelectedLevel(int i)
    {
        Params.SelectLevel(i);
        
        SceneManager.LoadScene("Playing Scene");
    }

    public void HowToPlay()
    {
        
        menuCanvas.enabled = false ;
        htpCanvas.enabled = true;
    }

    public void Retour()
    {
        levelCanvas.enabled = false;
        htpCanvas.enabled = false;
        menuCanvas.enabled = true;
    }


    public void Quitter()
    {
        Application.Quit();

    }

}
