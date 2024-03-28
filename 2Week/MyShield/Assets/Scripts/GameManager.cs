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
    public Text bestScore;

    public Animator anim;


    float time = 0.0f;
    string key = "bestScore";

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
        anim.SetBool("isDie", true);


        //���� ����(����)
        Invoke("TimeStop", 0.5f);
        
        nowScore.text = time.ToString("N2");

        //�ְ������� �ִٸ�  
        if (PlayerPrefs.HasKey(key))
        {
            float best = PlayerPrefs.GetFloat(key);
            //�ְ������� ���������� ��, ���� ������ �� Ŭ�� 
            if (time > best)
            {
                //���� ������ �ְ������� ���
                PlayerPrefs.SetFloat(key, time);
            }

        }
        //�ְ������� ���ٸ�
        else 
        {
            //���������� �ְ������� ���
            PlayerPrefs.SetFloat(key, time);
        }

        //�ְ������� �����ǳڿ� ����
        bestScore.text = PlayerPrefs.GetFloat(key).ToString("N2");

        //�����ǳ� ǥ��
        endPanel.SetActive(true);

    }

    void TimeStop()
    {
        //���� ����(����)
        Time.timeScale = 0f;
    }

}
