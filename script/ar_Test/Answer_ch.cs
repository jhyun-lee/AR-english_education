using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer_ch : MonoBehaviour
{


    public GameObject[] prefab;// ����� �� ���� ��

    public answer_ch_mode[] answer_ch_mode; // �� ������ �Լ��ϵ� >> 

    private int random_ind = 0;

    public Test_score save_answer;
    
    

    // Start is called before the first frame update
    void Start()
    {
        //Reset();
        //Invoke("setting", 3);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reset()
    {
        for (int i = 0; i < 4; i++)
        {
            prefab[i].SetActive(false);
        }
    }



    public void setting()
    {
        Reset();
        random_ind = Random.Range(0, 4);// ĳ���� ����
        prefab[random_ind].SetActive(true);
        save_answer.answer[0] = prefab[random_ind].name;// ������

        answer_ch_mode[random_ind].setting(); // ������ ��������
    }



   






}

