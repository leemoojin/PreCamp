using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //�̱���
    public static GameManager Instance;

    public GameObject normalCat;
    public GameObject fatCat;
    public GameObject pirateCat;

    public GameObject retryBtn;

    public RectTransform levelFront;//����ġ ��

    public Text levelTxt;

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
        InvokeRepeating("MakeCat", 0.0f, 1.5f);
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeCat()
    {
        Instantiate(normalCat);

        //�������� ������ Ȯ��
        int p = Random.Range(0, 9);

        if (level == 1)
        {
            //20%Ȯ���� �߰� ����
            if (p < 2) Instantiate(normalCat);
        }
        else if (level == 2)
        {
            //50% Ȯ���� �߰� ����
            if (p < 5) Instantiate(normalCat);
        }
        else if (level == 3)
        {
            //�׶��� ����� �߰� ���� -> �븻����̿� �ٸ��� ��������
            if (p < 4) Instantiate(fatCat);

        }
        else if (level >= 4)
        {
            if (p < 3 ) Instantiate(pirateCat);

            if (p >= 3 && p < 6) Instantiate(fatCat);
        }
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
        levelTxt.text = level.ToString();

        levelFront.localScale = new Vector3((score - level *5)/5.0f, 1f, 1f);
    }
}
