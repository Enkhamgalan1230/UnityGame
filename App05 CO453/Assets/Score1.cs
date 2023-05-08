using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score1 : MonoBehaviour
{
    [SerializeField] private Text ScoreText;


    public  int score1 = ItemCollector.bananas;
    public  int score2 = ItemCollector2.banana2;
    public  int score3 = ItemCollector3.banana3;

    public void Run()
    {
        ScoreText.text = "Level 1 =  " + score1 + "Level 2 = " + score2 + "Level 3 = " + score3;
    }


}



