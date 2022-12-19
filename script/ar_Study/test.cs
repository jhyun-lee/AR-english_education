using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using UnityEditor.Presets;
using UnityEngine;

public class test : MonoBehaviour
{

    private string obj="";
    private Vector3 randomPos;
    private int num = 0;


    public game_con game_con;
    public GameObject[] word = new GameObject[11]; ///������Ʈ��
    public GameObject[] target = new GameObject[11]; ///������ġ���͵�

    List<Vector3> save_target = new List<Vector3>(); // ��ǥ�� ����

    List<GameObject> spawn_obj = new List<GameObject>(); // ������ ���͵�
    private Quaternion rota;


    // Start is called before the first frame update
    void Start()
    {
        rota = target[0].transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        game_con.text_all[2] = obj;
    }



    private void OnTriggerEnter(Collider other) // ĳ���� �̸�
    {
        if (other.gameObject.tag == "zoo")
        {
            obj = other.gameObject.name;
            if (game_con.text_all[2]!= other.gameObject.name)
            {
                for(int i = 0; i < 4; i++)
                {
                    game_con.text_all[i] = "";
                }

                game_con.reset_all();// ���ĳ�� �ѹ�����
            }
            

        }
       
    }


    public void random_for(int n) // ���� ��ǥ�̱��Լ�
    {
        save_target.Clear();
        

        for (int i = 0; i < n; i++)
        {
            num = Random.Range(0, 10);
            while (true)
            {
                if (save_target.Contains(target[num].transform.position))
                {
                    num = Random.Range(0, 10);
                }
                else
                {

                    save_target.Add(target[num].transform.position);
                    break;
                }
            }


        }

        
    }

    public void delay_spawn()
    {
        Invoke("spawn_prefeb", 2.0f);
    }
    


    public void word_destroy()
    {
        for (int i = 0; i < spawn_obj.Count; i++) // ��ü ����
        {
            Destroy(spawn_obj[i]);
        }
        spawn_obj.Clear();
    }


    public void spawn_prefeb() // ����
    {

        word_destroy();

        if (game_con.state == 0) // �� 4��
        {
            random_for(4);

            for (int i = 0; i < 4; i++) // ����
            {
                Debug.Log("������");
                GameObject temp = Instantiate(word[i], save_target[i], rota);
                temp.transform.parent = this.transform;
                spawn_obj.Add(temp);
            }

        }
        else if (game_con.state == 1) // ũ�� 3��
        {
            random_for(3);

            for (int i = 0; i < 3; i++) // ����
            {
                GameObject temp = Instantiate(word[i + 4], save_target[i], rota);
                temp.transform.parent = this.transform;
                spawn_obj.Add(temp);
            }
        }
        else if (game_con.state == 2)// ���� 4�� 
        {
            random_for(4);

            for (int i = 0; i < 4; i++) // ����
            {
                GameObject temp = Instantiate(word[i + 7], save_target[i], rota);
                temp.transform.parent = this.transform;
                spawn_obj.Add(temp);
            }
        }
        else // ���ܾ� �о��ְ� �ٽ� 0���� ���ư��ºκ�
        {
            game_con.sound();// �Ҹ�����
        }

        
        
    }
}
