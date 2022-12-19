using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class control : MonoBehaviour
{

    Animation anim_state;
    Animator anim;
    
    public string[] states=new string[4];
    public Material[] mat = new Material[4];

    public GameObject size_obj;

    


    private string state = "stand";//ã�°�
    private string now_state= "stand";//���簪


    MeshRenderer[] chi_matArray;
    SkinnedMeshRenderer[] chi_skinnedMeshArray;

    
    public game_con sentence;



    




    // Start is called before the first frame update
    void Start()
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
                GameObject obj = GameObject.Find(this.name + "_skel");
                chi_skinnedMeshArray = obj.GetComponentsInChildren<SkinnedMeshRenderer>();
            }
            
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    void change_ing()
    {
        if (state == "run")
        {
            sentence.text_all[3] = "is running";
        }
        else if (state == "fly")
        {
            sentence.text_all[3] = "is flying";
        }
        else if (state == "stand")
        {
            sentence.text_all[3] = "is standing";
        }
        else
        {
            sentence.text_all[3] = "is jumping";
        }
    }


    void update_state()// �ൿ����
    {
        Debug.Log("����!");
        for (int i=0; i < states.Length; i++)
        {
            if(states[i]== state)//�ִ��� Ȯ��
            {
                anim.SetBool(now_state, false);
                anim.SetBool(state, true);
                now_state = state;


                change_ing();

                /////////// �����̸� �ְ� �ٽ� �����ؾߵ�
                sentence.state = 3;
                sentence.change = true;

                /// �ܾ� �� �ٽý���
                break;
            }
        }
        if(now_state != state)
        {
            anim.SetBool(now_state, false);
            now_state = "negative";
            anim.SetBool(now_state, true);
        }
    }

    void color(Material mat)// ������
    {
        if (gameObject.name == "Bird")
        {
            GameObject obj = GameObject.Find("Condor_col");
            obj.GetComponent<SkinnedMeshRenderer>().material = mat;

        }
        else if (gameObject.name == "Cat")
        {
            for (int j = 0; j < chi_matArray.Length; j++)// �ڽ� ���͸��� ����
            {
                chi_matArray[j].material = mat;
            }
        }
        else
        {
            for (int j = 0; j < chi_skinnedMeshArray.Length; j++)// �ڽ� ���͸��� ����
            {
                chi_skinnedMeshArray[j].material = mat;
            }
        }

        if (mat.name != "normal")
        {
            sentence.text_all[1] = mat.name;
        }
        
    }


    void size_ch(string size)
    {
        if (size == "big")
        {

            size_obj.transform.localScale = new Vector3(1.2f, 1.2f , 1.2f );
            sentence.text_all[0] = size;

        }
        else if(size == "small")
        {
            size_obj.transform.localScale = new Vector3(0.8f , 0.8f , 0.8f );
            sentence.text_all[0] = size;

        }
        else
        {
            size_obj.transform.localScale = new Vector3(1 , 1 , 1 );

        }
        
        

    }

    void reset_text()
    {
        


    }

    private void OnTriggerEnter(Collider other) // �ߵ���
    {

        string memo = other.gameObject.name;
        int index = 0;

        for(int i=0;i< memo.Length; i++) // ���ڿ� ��
        {
            if(memo[i] == '(')
            {
                index = i;
                break;
            }
        }

        memo = memo.Substring(0, index);


        Debug.Log(memo);


        if (other.gameObject.tag == "move")//������ ��ü // 0
        {
            if (state != memo) 
            {
                state = memo;// �ִԺ���
                update_state();
            }


        }
        else if (other.gameObject.tag == "color") // 1 
        {
            for (int i = 0; i < mat.Length; i++)//��ã��
            {
                if (mat[i].name == memo)
                {
                    color(mat[i]);
                    break;
                }
            }
            sentence.state += 1;
            sentence.change = true;

        }
        else if (other.gameObject.tag == "Alphabets") // 2
        {
            size_ch(memo);


            sentence.state +=1;
            sentence.change = true;
        }
    }



    public void reset() // ĳ���� Ư¡ + �ؽ�Ʈ
    {

        for (int i = 0; i < 4; i++)
        {
            sentence.text_all[i] = "";
        }
        sentence.text_all[2] = gameObject.name;


        size_ch("normal");

        anim.SetBool(now_state, false);
        anim.SetBool("stand", true);
        state = "none";

        color(mat[4]);

    }

}

