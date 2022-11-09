using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")] //��������� ������ � ���������
    // ������ �������
    public GameObject basketPrefab;
    // ���������� ������(������)
    public int numBackets = 3;
    // ��������� ������� ������
    public float basketBottomY = -14f;
    // ���������� ����� ���������
    public float basketSpacingY = -2f;
    void Start()
    {
        // ������� �������� ������ �� �����
        for (int i = 0; i < numBackets; i++)
        {
            GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGo.transform.position = pos; 
        }
    }

    
}
