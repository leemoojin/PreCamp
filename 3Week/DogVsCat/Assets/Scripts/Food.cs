using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //food ������Ʈ�� ��� ���� �̵��ϰ� y�ప�� ���Ѵ�
        transform.position += Vector3.up * 0.5f;

        //y�� ���� 27�� �Ѿ�� Ǫ�� ������Ʈ �ı�
        if (transform.position.y > 27f)
        {
            Destroy(gameObject);
        }

    }
}
