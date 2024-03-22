using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//ui�� �ؽ�Ʈ Ÿ���� �������� ����

public class GameManager : MonoBehaviour
{
    //�̱����� ���� �ϳ��ۿ� ���ٴ� �ǹ�
    //->������Ʈ�� ���� �Ŵ������ ��ü�� ���� �����ϴ�
    //���� ��ũ��Ʈ���� ������ �����ϰ��ϴ� ���
    public static GameManager Instance;
    //�ν��Ͻ��� �� �ڽ��� �־�����Ѵ�
    private void Awake()
    {
        //Instance ���� �ȿ� �� �ڽ��� �����͸� �־���� �Ѵ�
        Instance = this;
        //������ ����� �Ǿ��� �� ������ �ð��� �۵��Ѵ�
        Time.timeScale = 1.0f;
    }

    int totalScore;

    float totalTime = 15.0f;

    //ui text
    public Text totalScoreTxt;
    public Text timeTxt;


    //prefabȭ�� Rain ������Ʈ�� �ҷ��;��Ѵ� > �̰��� �ڷ����� ���ӿ�����Ʈ�̴�
    public GameObject rain;
    //->����Ƽ �ν����� â���� ������ ������ rain ������
    //Prefab Rain ������Ʈ�� ��Ƶ� �����̱⶧���� �����Ͱ� ����ִ�

    public GameObject endPanel;

    // Start is called before the first frame update
    void Start()
    {
        //�Լ��� �ݺ������� �����ϴ� �Լ� InvokeRepeating(�Լ��� �̸�, ���� ���Ŀ� ��������, �ݺ� �ֱ�)
        //0f -> 0�� ���� float ���̱� ������ �ڿ� f�� ���δ�, �ݺ��ֱ� -> ���ʸ��� ���� ���� 1f�� 1�ʸ��� ����
        InvokeRepeating("MakeRain", 0f, 1f);
        //->"MakeRain" �̶�� �Լ��� 0�ʺ���(�ٷ�) 1�ʸ��� �ݺ������� ȣ���Ѵٴ� �ǹ�

    }

    // Update is called once per frame
    void Update()
    {

        if (totalTime > 0f)
        {
            //��ŻŸ�ӿ� �귯�� �ð��� ������
            //time Ű���带 ����ϸ� �ð��� ����� �����ͼ� ��밡���ϴ�
            //������ ���� ���� �������� ���⶧���� ��⸶�� ���̰� �߻��Ѵ�
            //�ð��� ������ִ� ������ �������� ������ ���� ���ȴ�
            //������ deltaTime�� ����ϸ�
            //��� ������ ���� �ð����� ���� �� �ֵ��� ������ ��� �������ش�
            totalTime -= Time.deltaTime;
            //N2 �� �Ҽ��� 2°�ڸ������� ǥ���ش޶�� ����̴�

        }
        //��ŻŸ���� 0 ���ϰ��Ǹ� ���� ����
        else
        {
            //������ �����Ҷ� ��Ȯ�� 0�ʿ��� ���ߴ°� �ƴ϶� �̼��� ������ �߻��� �� �ִ�
            //������ 0�ʷ� ���� �������ش�
            totalTime = 0f;

            //SetActive(bool); �ش� ���ӿ�����Ʈ�� Ȱ��ȭ ���θ� �����ϴ� �Լ� 
            endPanel.SetActive(true);


            //������ ���ߴ� Ű����� time���� �����Ѵ�
            //time�� ũ�⸦ 0���� ����� 
            //ù��° �����Ӱ� ���� �����ӱ����� �ð��� ���̰� �������Եȴ�
            //-> ������ �ð��� ���߰ԵǴ� ȿ���� ����           
            Time.timeScale = 0f;

        }

        timeTxt.text = totalTime.ToString("N2");
        Debug.Log(totalTime);





    }

    //������� �����ϴ� �Լ��� ������
    void MakeRain()
    {
        //���ӿ�����Ʈ�� �����ϴ� �Լ� Instantiate()
        Instantiate(rain);
    
    }

    //������ �÷��ִ� ��� (int score) �Ű�����
    //public �� �� ��ũ��Ʈ�� �ƴ� �ܺ��� ��ũ��Ʈ���� ���� �����ϰ� ����ϴ� Ű����
    public void AddScore(int score)
    {
        totalScore += score;

        if (totalScore < 0) totalScore = 0;
        
        totalScoreTxt.text = totalScore.ToString();
        //Debug.Log(totalScore);
    }
}
