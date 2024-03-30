using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public GameObject food;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeFood", 0f, 0.5f);

    }

    void Update()
    {
        //���콺 ��ġ���� �¿�(x��) ���� �����ͼ� ������ ������Ʈ�� ��������
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        float x = mousePos.x;
        //�������� ���� ȭ�� ������ ����� �ʵ��� �������� (���� -8.5~8.5)
        if (x < -8.5f) x = -8.5f;
        if (x > 8.5f) x = 8.5f; 

        //x���� ���콺 ��ġ, y���� ������ ������Ʈ ��ġ
        transform.position = new Vector2(x, transform.position.y);

    }

    //�ݺ��ؼ� �������Ʈ ����
    void MakeFood()
    {
        float x = transform.position.x;
        float y = transform.position.y + 2f;
        
        //������ ����, �����Ҷ� ��ġ���� ������ �� �ִ�
        //Quaternion.identity �� ������ ȸ������ ���� �ʰڴٴ� �ǹ�
        //�̸� ������ food������ �״�� ȸ�������� �����ϰڴٴ� �ǹ�
        Instantiate(food, new Vector2(x, y), Quaternion.identity);

        Debug.Log("��Ծ�");
    }
}
