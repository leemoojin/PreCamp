using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject card;//ī�� ������

    // Start is called before the first frame update
    void Start()
    {
        //ī�� ��ȣ�� ��� �迭 ����
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };        

        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray();

        //0������ ����� ���� Ŭ���� -> ����
        GameManager.Instance.cardCount = arr.Length;

        //16���� ī�� ������Ʈ ����
        for (int i = 0; i < 16; i++)
        {   
            GameObject go = Instantiate(card, this.transform);
            float x = (i % 4) * 1.4f - 2.1f; //�ε����� 4�� ������ ���� ������ * 1.4 - ���Ƿ� �̵��� ��
            float y = (i / 4) * 1.4f - 3.0f; //�ε����� 4�� ������ ���� �� * 1.4 - ���Ƿ� �̵��� ��

            go.transform.position = new Vector2(x, y);

            //ī�� ������Ʈ�� ī���� ��ũ��Ʈ ������Ʈ�� �߰��߱� ������ ��������Ʈ�� ã�� �� �ִ�
            go.GetComponent<Card>().Setting(arr[i]);            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
