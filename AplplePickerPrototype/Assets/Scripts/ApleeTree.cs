using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ApleeTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    // ������ ��� �������� �����
    public GameObject applePrefab;
    //�������� �������� �����
    public float speed = 1f;
    // ���������� �� ������� ������ ���������� ����������� ������� ������
    public float leftAdnRightEdge = 10f;
    // ����������� ���������� ��������� ����������� ��������
    public float chanceToChangeDirections = 0.1f;
    // ����� �������� ��������� �����
    public float secondBetweenAppleDrops = 1f;

    
    void Start()
    {
        // ���������� ������ ��� � �������
        Invoke("DropApple", 2f);// Invoke �������� ������� ����� �������� ���-�� ������
    }

    // ������� ������ � ����� ��� ������ ������
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
        // ����������� 
        Vector3 pos = transform.position; // �������� ������� �������
        pos.x += speed * Time.deltaTime; //deltaTime - ���-�� ������ � ����������� �����
        transform.position = pos;
        // ��������� �����������
        if (pos.x < -leftAdnRightEdge)
        {
            speed = Mathf.Abs(speed);// �������� ������
        }
        else
        if (pos.x > leftAdnRightEdge)
        {
            speed = -Mathf.Abs(speed);// �������� �����
        }
    }
    void FixedUpdate()
        {
        if (Random.value < chanceToChangeDirections)
            {
                speed *= -1; //�������� �� �������� �����������
            }
        }

}
