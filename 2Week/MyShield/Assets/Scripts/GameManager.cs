using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    public GameObject square;
    public Text timeTxt;

    float time = 0.0f;

    public static GameManager instance;
    private void Awake()
    {   
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeSquare", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {   
        //Ÿ�̸�
        time += Time.deltaTime;
        timeTxt.text = time.ToString("n2");
        Debug.Log(time);




    }

    void MakeSquare()
    {
        //�������� ������Ű�� �ڵ�
        Instantiate(square);

        Debug.Log("�����Ѵ�");
    }
}
