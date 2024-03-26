using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    public GameObject square;
    public GameObject endPanel;

    public Text timeTxt;
    public Text nowScore;

    float time = 0.0f;

    bool isPlay = true;

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
        //���� ����
        Time.timeScale = 1f;

        InvokeRepeating("MakeSquare", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {   
        
        if (isPlay ) 
        {
            //Ÿ�̸�
            time += Time.deltaTime;
            timeTxt.text = time.ToString("n2");
            Debug.Log(time);

        }

    }

    void MakeSquare()
    {
        //�������� ������Ű�� �ڵ�
        Instantiate(square);

        Debug.Log("�����Ѵ�");
    }

    public void GameOver() 
    {
        isPlay = false;
        //���� ����(����)
        Time.timeScale = 0f;
        nowScore.text = time.ToString("N2");
        //�����ǳ� ǥ��
        endPanel.SetActive(true);

    }

}
