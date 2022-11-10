using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public TextMeshProUGUI scoreGT;

    void Update()
    {
        // Получить текущие координаты указателя мыши на экране из INput
        Vector3 mousePos2D = Input.mousePosition;

        // Координата Z камеры определяет как далеко в техмерного пространтсве
        // Находится указатель мыши
        mousePos2D.z = -Camera.main.transform.position.z;

        // ScreenToWorldPoint - преобразует экранные коорлинаты в координаты трезмерного
        // Преобразовываем точку на двумерную плоскость экрана в трехмерные координаты игры
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Переместить корзину вдоль оси Х в координату Х указателя мыши
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    // Метод вызывается всякий раз когда другой обьект сталкивается с корзиныой(коллизия)
    private void OnCollisionEnter(Collision collision)
    {
        // Получить яблоко попавшее в корзину
        GameObject collideWith = collision.gameObject;
        if (collideWith.tag == "Apple")
        {
            Destroy(collideWith);
            // Парсим строчку очков в int 
            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text =score.ToString();
            if (score > HightScore.score)
                HightScore.score = score;
        }
    }


    void Start()
    {
        // Ищем на сцене игровой объект с именем и возвращаем ссылку на него
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //Получаем компонент TextMeshProUGUI (просто Text устарел)
        scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
        scoreGT.text = "0";
    }   
}
