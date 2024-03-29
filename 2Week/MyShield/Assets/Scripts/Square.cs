using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //������ ��ġ���� ����
        float x = Random.Range(-3f, 3f);
        float y = Random.Range(3f, 5f);
        transform.position = new Vector2(x, y);

        //������ ������
        float size = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector2(size, size);


        

    }

    // Update is called once per frame
    void Update()
    {
        //������ ������Ʈ�� ����ȭ�� ������ �Ѿ�� �ı�
        if (transform.position.y <= -6f)
        {
            Destroy(this.gameObject);
        }
    }

    //�浹�ϴ� ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //������ ������Ʈ�� �浹�� ���� ������ collision �Ű������� ����ִ�
        //�ε��� ������Ʈ�� �±��̸��� Player ����?
        if (collision.gameObject.CompareTag("Player"))
        {
            //���ӸŴ����� ���ӿ����Լ� ȣ��
            GameManager.instance.GameOver();
        }


    }
}
