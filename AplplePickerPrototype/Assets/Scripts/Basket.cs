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
        // �������� ������� ���������� ��������� ���� �� ������ �� INput
        Vector3 mousePos2D = Input.mousePosition;

        // ���������� Z ������ ���������� ��� ������ � ���������� ������������
        // ��������� ��������� ����
        mousePos2D.z = -Camera.main.transform.position.z;

        // ScreenToWorldPoint - ����������� �������� ���������� � ���������� �����������
        // ��������������� ����� �� ��������� ��������� ������ � ���������� ���������� ����
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // ����������� ������� ����� ��� � � ���������� � ��������� ����
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    // ����� ���������� ������ ��� ����� ������ ������ ������������ � ���������(��������)
    private void OnCollisionEnter(Collision collision)
    {
        // �������� ������ �������� � �������
        GameObject collideWith = collision.gameObject;
        if (collideWith.tag == "Apple")
        {
            Destroy(collideWith);
            // ������ ������� ����� � int 
            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text =score.ToString();
            if (score > HightScore.score)
                HightScore.score = score;
        }
    }


    void Start()
    {
        // ���� �� ����� ������� ������ � ������ � ���������� ������ �� ����
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //�������� ��������� TextMeshProUGUI (������ Text �������)
        scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
        scoreGT.text = "0";
    }   
}
