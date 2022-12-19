using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class game_con : MonoBehaviour
{
    // Start is called before the first frame update


    public string[] text_all = new string[4]; // ���� ����
    public TextMeshProUGUI text;// �ؽ�Ʈ
    public control[] ch_list;// ĳ���͵�

    public AudioSource myaudio;//��¿����
    public AudioClip[] Audios = new AudioClip[16];// ������  16���� ��Ҹ�
   
    public int state = 0;// ���� ���� >>>>>> 0~2;
    public bool change = false; // �ٲ��~

    public test stage;

    public int allscore = 100; // �ʿ��


    void Start()
    {

        //stage.spawn_prefeb(); // ����
    }

    // Update is called once per frame
    void Update()
    {
        text.text = text_all[0] + " " + text_all[1] + " " + text_all[2] + " " + text_all[3];
        

        if (change)// ��ȭ �߻��� 
        {
            stage.word_destroy();
            stage.delay_spawn();
            change = false;
        }


        if (index == 4)
        {
            CancelInvoke("playsound");
            index = 0;
            delay_reset();
        }
    }




    public void delay_reset() // 3�ʵ� ���� ����
    {
        Invoke("reset_all", 2);

    }



    public void reset_all() // ���ĳ����
    {
        for (int i = 0; i < ch_list.Length; i++)
        {
            ch_list[i].reset();
        }

        state = 0;
        change=true; // �ٽ� ����
    }




    /// <summary>
    /// --------------------------------------�Ҹ�
    /// </summary>
    private int index = 0;



    public void sound()
    {
        InvokeRepeating("playsound", 0.5f, 1.3f);// 2�ʸ��� �ϳ���
    }


    public void playsound() // �������
    {
        if (index == 4)
        {
            Debug.Log("------------");
            return;
        }

        if (text_all[index] != "")
        {
            Debug.Log("������� " + index);
            for (int i = 0; i < 15; i++) 
            {
                if (Audios[i].name == text_all[index])
                {
                    Debug.Log("------------------------------------------");
                    myaudio.clip = Audios[i];
                    break;
                }

            }
            myaudio.Play();
        }
        index += 1;
    }


    public void gamequit()
    {
        Application.Quit();
    }
}


