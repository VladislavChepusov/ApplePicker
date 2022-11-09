using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")] //Добавляет раздел в инспектор
    // шаблон корзины
    public GameObject basketPrefab;
    // количетсво корзин(жизней)
    public int numBackets = 3;
    // Начальная позиция корзин
    public float basketBottomY = -14f;
    // Расстояние между корзинами
    public float basketSpacingY = -2f;
    void Start()
    {
        // Функция создания корзин на сцене
        for (int i = 0; i < numBackets; i++)
        {
            GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGo.transform.position = pos; 
        }
    }

    
}
