using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Params
{
    //classe recueillant les détails du niveau actuel, ainsi que les données des paramètres des 20 niveaux du jeu
    public static int NbLevelsMax = 20;
    public static int Level = 0;

    public static int Nombrevagues = 1;


    public static int nombreObstaclesParVague = 10;

    public static float attenteDuDebut = 2;

    public static float IntervalleProjectiles = 0.5f;
    public static float intervalleVague = 1;
    public static float vitesseTriangle = 3;

    public static float probaHeal = 0.1f;
    public static float probaDiamond = 0.2f;

    public static int startingHP = 3;

    public static void LoadLevel(int level, int NombreVagues, int nombreObstaclesparVague, float attentedudebut, float intervalleProj, float intervallevague, float vitessetriangle, float probaheal, float probadiamond)
    {
        Params.Level = level;
        Params.Nombrevagues = NombreVagues;
        Params.nombreObstaclesParVague = nombreObstaclesparVague;
        Params.attenteDuDebut = attentedudebut;
        Params.IntervalleProjectiles = intervalleProj;
        Params.intervalleVague = intervallevague;
        Params.vitesseTriangle = vitessetriangle;
        Params.probaHeal = probaheal;
        Params.probaDiamond = probadiamond;
    }
    public static void SelectLevel(int i)
    {
        switch (i)
        {
            case 1:
                Params.LoadLevel(1, 2, 3, 3, 2, 0, 1,0,0); //très lent, tuto
                break;
            case 2:
                Params.LoadLevel(2, 3, 5, 2, 0.8f, 1, 3,0,0);   //classique
                break;
            case 3:
                Params.LoadLevel(3, 5, 10, 2, 0.5f, 1, 3,0,0);  //moins de repos
                break;
            case 4:
                Params.LoadLevel(4, 5, 3, 2, 1, 2, 6,0,0);  //rapide mais court
                break;
            case 5:
                Params.LoadLevel(5, 2, 3, 3, 2, 0, 6, 0.5f, 0); //très lent, tuto pour heal
                break;
            case 6:
                Params.LoadLevel(6, 5, 10, 2, 0.5f, 1, 4, 0.2f, 0);  //moins de repos mais du heal
                break;
            case 7:
                Params.LoadLevel(7, 5, 10, 2, 0.5f, 1.5f, 5, 0.1f, 0);  //moins de heal et dur
                break;
            case 8:
                Params.LoadLevel(8, 5, 10, 2, 0.4f, 1, 5, 0.1f, 0);
                break;
            case 9:
                Params.LoadLevel(9, 3, 3, 3, 2, 0, 3, 0, 1); //tuto diamond
                break;
            case 10:
                Params.LoadLevel(10, 3, 5, 2, 0.8f, 1, 4, 0.1f, 0.3f);
                break;
            case 11:
                Params.LoadLevel(11, 5, 4, 2, 1, 1, 5, 0.1f, 0.2f);
                break;
            case 12:
                Params.LoadLevel(12, 5, 4, 2, 0.8f, 0, 1, 0.1f, 0.2f); //bcp plus lent
                break;
            case 13:
                Params.LoadLevel(13, 7, 4, 2, 0.5f, 1, 4, 0.1f, 0.4f);
                break;
            case 14:
                Params.LoadLevel(14, 5, 4, 2, 1, 1, 6, 0.1f, 0.2f);
                break;
            case 15:
                Params.LoadLevel(15, 5, 4, 2, 0.8f, 0.8f, 6, 0.1f, 0.2f);
                break;
            case 16:
                Params.LoadLevel(16, 5, 4, 2, 0.5f, 0.5f, 4, 0.1f, 0.8f);
                break;
            case 17:
                Params.LoadLevel(17, 5, 5, 2, 0.5f, 0.8f, 6, 0.1f, 0.3f); //bcp plus leeeeeent
                break;
            case 18:
                Params.LoadLevel(18, 5, 5, 2, 0.5f, 0.8f, 7, 0.1f, 0.3f);
                break;
            case 19:
                Params.LoadLevel(19, 5, 5, 2, 0.5f, 0, 7, 0.1f, 0);
                break;
            case 20:
                Params.LoadLevel(20, 10, 5, 2, 0.6f, 2, 8, 0.1f, 0.3f);
                break;

        }
    }
}

