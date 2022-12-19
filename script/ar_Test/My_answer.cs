using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_answer : MonoBehaviour
{
    public Material[] mat = new Material[4]; // ��


    public int size_obj;// 0~2 ũ���
    public string[] states = new string[3]; // ����

    public MeshRenderer[] chi_matArray;// �����
    public GameObject dog_lion_mat;//������, ����
    public GameObject birds_mat;//��

    SkinnedMeshRenderer[] chi_skinnedMeshArray; // ����, ��
    Animation anim_state;
    Animator anim;

    private string now_State = "stand";

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


    public void findcol(string col)
    {
        
        
        for (int i = 0; i < mat.Length; i++)
        {
            if (mat[i].name == col)
            {
                anim_mat_save();
                mat_change(mat[i]);
                return;
            }
        }

    }


    void mat_change(Material mat)
    {

        Debug.Log("__1___" + gameObject.name);

        if (gameObject.name == "Bird")
        {
            Debug.Log("__111___" + mat.name);
            //GameObject obj = GameObject.Find("Condor_col"); // ����..... ����
            birds_mat.GetComponent<SkinnedMeshRenderer>().material = mat;

        }
        else if (gameObject.name == "Cat")
        {
            Debug.Log("__222___" + mat.name);
            for (int j = 0; j < chi_matArray.Length; j++)// �ڽ� ���͸��� ����
            {
                chi_matArray[j].material = mat;
            }
        }
        else // ���� �� 
        {
            Debug.Log("�����ϰ� ��");
            Debug.Log("__333___" + mat.name);
            for (int j = 0; j < chi_skinnedMeshArray.Length; j++)// �ڽ� ���͸��� ����
            {
                chi_skinnedMeshArray[j].material = mat;
            }
        }


    }


    public void size_ch(string size) // ������ ���ϱ�
    {

        if (size == "big")
        {

            gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);


        }
        else if (size == "small")
        {

            gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);


        }
        else
        {

            gameObject.transform.localScale = new Vector3(1, 1, 1);

        }
    }


    public void update_state(string state)// �ൿ����
    {

        anim.SetBool(now_State, false);
        anim.SetBool(state, true);
        now_State = state;
    }


    public void Reset_zoo()// ����
    {
        findcol("normal");
        size_ch("normal");
        update_state("stand");
    }

}
