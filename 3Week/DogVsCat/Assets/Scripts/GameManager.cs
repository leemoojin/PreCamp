using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�̱���
    public static GameManager Instance;

    public GameObject normalCat;
    public GameObject fatCat;
    public GameObject retryBtn;

    int level = 0;
    int score = 0;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        //��� ����� ������ ���� �����ϰ� ���缭 ����ϴ� �󵵵� �Ȱ��� �Ѵ�
        Application.targetFrameRate = 60;
        Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {       
        InvokeRepeating("MakeCat", 0.0f, 1.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeCat()
    {
        Instantiate(normalCat);
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        retryBtn.SetActive(true);
    }

    public void AddScore()
    {
        score++;

        //5���ھ�� 1������ ���� (1~4 = 0 ����, 5~9 = 1����)
        level = score / 5;
    }
}
