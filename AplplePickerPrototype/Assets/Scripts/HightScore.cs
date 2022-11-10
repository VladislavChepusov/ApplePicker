using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class HightScore : MonoBehaviour
{
    static public int score = 1000;

    void Update()
    {
        TextMeshProUGUI gt = this.GetComponent<TextMeshProUGUI>();
        gt.text = "¬аш рекорд:  " + score;
        //ќбновить HightScore в ’ранилище 
        if (score > PlayerPrefs.GetInt("HightScore"))
            PlayerPrefs.SetInt("HightScore", score);
    }
    //  awake вызываетс€ при создании экземпл€ра класса HightScore(перед start)
    private void Awake()
    {
        //
        if (PlayerPrefs.HasKey("HightScore"))
            score = PlayerPrefs.GetInt("HightScore");
        PlayerPrefs.SetInt("HightScore", score);// —охран€ем очки в хранилище игрока
        
    }
}
