using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���� ī�޶� ����
        //��ũ���� ��ġ�� ���� ������� ��ġ�� ��ȯ�ϴ� �Լ� ScreenToWorldPoint(transform.position);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //���� ������Ʈ�� ��ġ = ���콺�� ��ġ 
        transform.position = mousePos;
    }
}
