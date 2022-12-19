using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answer_ch_mode : MonoBehaviour
{
    
    public Material[] mat = new Material[4]; // ��


    public int size_obj;// 0~2 ũ���
    public string[] states = new string[3]; // ����

    MeshRenderer[] chi_matArray;// �����
    public GameObject dog_lion_mat;//������, ����
    public GameObject birds_mat;//��

    SkinnedMeshRenderer[] chi_skinnedMeshArray; // ����, ��
    Animation anim_state;
    Animator anim;

    private string now_State="stand";

    private int random_ind=0;
    public Test_score save_answer;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void anim_mat_save()// anim save , anim
    {
        anim = GetComponent<Animator>();
        if (gameObject.name != "Bird")
        {
            if (gameObject.name == "Cat")
            {
                chi_matArray = gameObject.GetComponentsInChildren<MeshRenderer>();
            }
            else
            {
               
                chi_skinnedMeshArray = dog_lion_mat.GetComponentsInChildren<SkinnedMeshRenderer>();
            }

        }

    }


    void mat_change(Material mat)
    {
       


        save_answer.answer[1] = mat.name;// ������
        if (gameObject.name == "Bird")
        {
            
            birds_mat.GetComponent<SkinnedMeshRenderer>().material = mat;

        }
        else if (gameObject.name == "Cat")
        {
            for (int j = 0; j < chi_matArray.Length; j++)// �ڽ� ���͸��� ����
            {
                chi_matArray[j].material = mat;
            }
        }
        else // ���� �� 
        {
            for (int j = 0; j < chi_skinnedMeshArray.Length; j++)// �ڽ� ���͸��� ����
            {
                chi_skinnedMeshArray[j].material = mat;
            }
        }

        //if (mat.name != "normal")
        //{
        //    sentence.text_all[1] = mat.name;
        //}
    }

    void size_ch(int size) // ������ ���ϱ�
    {
       
        if (size == 0)
        {
            save_answer.answer[2] = "big";// ������
            gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            //sentence.text_all[0] = size;

        }
        else if (size == 1)
        {
            save_answer.answer[2] = "small";// ������
            gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            //sentence.text_all[0] = size;

        }
        else
        {
            save_answer.answer[2] = "normal";// ������
            gameObject.transform.localScale = new Vector3(1, 1, 1);

        }
    }

    void update_state(string state)// �ൿ����
    {
        save_answer.answer[3] = state;// ������
        anim.SetBool(now_State, false);

        anim.SetBool(state, true);
        now_State = state;

    }


    public void setting()
    {
        anim_mat_save();// ��� ����

        random_ind = Random.Range(0, 4); // ���͸��� ����
        mat_change(mat[random_ind]);

        random_ind = Random.Range(0, 3); // ũ�� ����
        size_ch(random_ind);

        random_ind = Random.Range(0, 3); // �ִԺ���

        update_state(states[random_ind]);

    }



}
