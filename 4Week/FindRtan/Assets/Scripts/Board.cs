using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject card;//ī�� ������

    // Start is called before the first frame update
    void Start()
    {
        //16���� ī�� ������Ʈ ����
        for (int i = 0; i < 16; i++)
        {
            GameObject gO = Instantiate(card, this.transform);
            float x = (i % 4) * 1.4f - 2.1f; //�ε����� 4�� ������ ���� ������ * 1.4 - ���Ƿ� �̵��� ��
            float y = (i / 4) * 1.4f - 3.0f; //�ε����� 4�� ������ ���� �� * 1.4 - ���Ƿ� �̵��� ��

            gO.transform.position = new Vector2(x, y);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
