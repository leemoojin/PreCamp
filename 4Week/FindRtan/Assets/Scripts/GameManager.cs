using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //���� ������ ī��
    public Card firstCard;
    public Card secondCard;

    public Text timeTxt;
    public GameObject endTxt;
    
    //0������ ����� ���� Ŭ���� -> ����
    public int cardCount = 0;

    float time = 0.00f;

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Ÿ�̸��� �ð��� �帣�� ����
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        //30�ʰ� �Ǹ� ���� ����
        if (time >= 30f)
        {
            //���� ����
            timeTxt.text = "30.00";
            Time.timeScale = 0.0f;
            endTxt.SetActive(true);
        }

    }

    public void Matched()
    {
        Debug.Log("�Ǵ�����");
        //������ ī�尡 ���ٸ� �ı��ض�
        if (firstCard.idx == secondCard.idx)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();

            cardCount -= 2;
            if (cardCount == 0)
            {
                //���� ����
                Time.timeScale = 0.0f;
                endTxt.SetActive(true);
            }
        }
        //�ٸ��ٸ� �ٽ� �������
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        //�Ǵ��� �����ڿ� ������ ���� ����� ���� ������ ���ؼ�
        firstCard = null;
        secondCard = null;

    }
}
