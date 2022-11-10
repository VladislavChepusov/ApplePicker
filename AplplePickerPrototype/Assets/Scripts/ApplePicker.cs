using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    // Список корзин
    public List<GameObject> basketList;
    void Start()
    {
        basketList = new List<GameObject>();
        // Функция создания корзин на сцене
        for (int i = 0; i < numBackets; i++)
        {
            GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGo.transform.position = pos; 
            basketList.Add(tBasketGo);
        }
    }

    public void AppleDestroyed()
    {
        // Удалить все упавшие яблоки
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject tApple in tAppleArray)
        {
            Destroy(tApple);
        }
        int basketIndex = basketList.Count - 1;
        GameObject tBasketGo = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGo);

        if (basketList.Count == 0)
            SceneManager.LoadScene(0);
    }



}
