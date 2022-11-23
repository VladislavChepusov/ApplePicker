using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ApleeTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    // Ўаблон дл€ создани€ €блок
    public GameObject applePrefab;
    //—корость движени€ €блок
    public float speed = 1f;
    // –ассто€ние на котором должно измен€тьс€ направление двежни€ €блони
    public float leftAdnRightEdge = 10f;
    // ¬еро€тность случайного изменени€ направлени€ движени€
    public float chanceToChangeDirections = 0.1f;
    // „асто создани€ экземл€ра €блок
    public float secondBetweenAppleDrops = 1f;

    
    void Start()
    {
        // —брасывать €блоки раз в секунду
        Invoke("DropApple", 2f);// Invoke вызывает функцию через заданное кол-во секунд
    }

    // —оздает €блоко в точке где сейчас дерево
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        
        //Quaternion target = Quaternion.Euler(-85.219f, -84.92f, 0);
        // Dampen towards the target rotation
        //apple.transform.rotation = Quaternion.Slerp(apple.transform.rotation, target, Time.deltaTime );
        apple.transform.Rotate(-85.219f, -84.92f, 0, Space.Self);

        apple.transform.position = transform.position;

        Invoke("DropApple", secondBetweenAppleDrops);
    }

    void Update()
    {
        // ѕеремещение 
        Vector3 pos = transform.position; // ѕолучаем текущую позицию
        pos.x += speed * Time.deltaTime; //deltaTime - кол-во секунд с предыдущего кадра
        transform.position = pos;
        // »зменение направлени€
        if (pos.x < -leftAdnRightEdge)
        {
            speed = Mathf.Abs(speed);// ƒвижение вправо
        }
        else
        if (pos.x > leftAdnRightEdge)
        {
            speed = -Mathf.Abs(speed);// ƒвижение влево
        }
    }
    void FixedUpdate()
        {
        if (Random.value < chanceToChangeDirections)
            {
                speed *= -1; //»зменить на обратное направление
            }
        }

}
