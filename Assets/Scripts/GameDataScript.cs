using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Game Data", order = 51)]
public class GameDataScript : ScriptableObject
{
    public bool resetOnStart;
    public int level = 1;
    public int balls = 6;
    public int points = 0;
    public bool music = true;
    public bool sound = true;
    public int pointsToBall = 0;

    public void Reset()
    {
        level = 1;
        balls = 6;
        points = 0;
        pointsToBall = 0;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("balls", balls);
        PlayerPrefs.SetInt("points", points);
        PlayerPrefs.SetInt("pointsToBall", pointsToBall);
        PlayerPrefs.SetInt("music", music ? 1 : 0);
        PlayerPrefs.SetInt("sound", sound ? 1 : 0);
    }

    public void Load()
    {
        level = PlayerPrefs.GetInt("level", 1);
        balls = PlayerPrefs.GetInt("balls", 6);
        points = PlayerPrefs.GetInt("points", 0);
        pointsToBall = PlayerPrefs.GetInt("pointsToBall", 0);
        music = PlayerPrefs.GetInt("music", 1) == 1;
        sound = PlayerPrefs.GetInt("sound", 1) == 1;
    }

    public int[] getProbab()
    {
        int[] probab = new int[3];
        probab[0] = 40; // Fire
        probab[1] = 40; // Steel
        probab[2] = 20; // Norm

        int[] probsum = new int[3];
        probsum[0] = probab[0];
        for (int i = 1; i < 3; i++)
            probsum[i] = probsum[i - 1] + probab[i];

        return probsum;
    }

}
