using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{

    public GameObject[] obj=new GameObject[11];
    public int state = 0;// ���� ���� >>>>>> 0~2;
    public bool change = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (change)
        {
            statechange();
            change = !change;
        }
    }


    void statechange() // ������--------------------------------------
    {

        for (int i = 0; i < 12; i++)// �������
        {
            obj[i].SetActive(false);
        }


        if (state == 0)// ��
        {
            for(int i = 0; i < 4; i++)// ���̰�
            {
                obj[i].SetActive(true);
            }
        }
        else if (state == 1) // ũ��
        {
            for (int i = 4; i < 7; i++)// ���̰�
            {
                obj[i].SetActive(true);
            }
        }
        else// ����
        {
            for (int i = 7; i < 12; i++)// ���̰�
            {
                obj[i].SetActive(true);
            }
        }
        

    }
}
