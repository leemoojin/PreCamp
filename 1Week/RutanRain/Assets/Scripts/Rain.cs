using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    float size = 1.0f;
    int score = 1;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //���� �����ϱ����� SpriteRenderer�� �������� ���� GetComponent<>(); Ű���带 ����Ѵ�
        spriteRenderer = GetComponent<SpriteRenderer>();

        //������ ��ġ
        // Random.Range(�ּҰ�, �ִ밪);
        float x = Random.Range(0.0f, 1.0f);
        float y = Random.Range(3.0f, 5.0f);

        //�����ϰ� ����� ���� �����ǿ� �ִ´�
        transform.position = new Vector3(x, y, 0);

        //������ ũ��
        //���߼� (Ÿ��1~3)
        //�������� �ִ밪�� ������ �ʴ´�
        //Random.Range(1, 4); �϶� �ִ밪 4�� ������ 1,2,3 �� �������� ����
        int type = Random.Range(1, 4);
        //Ÿ�Կ� ���� ũ��, ����, ���� �ٸ��� ��������
        if (type == 1)
        {
            size = 0.8f;
            score = 1;
            //�÷� ���� �Է��Ҷ��� �ִ밪�� 255���� ������ ���� �Է��ؾ��Ѵ�
            //150�� �Է� �ϰ�������� 150/255�� �Է� �ϸ�ȴ�
            //������ ������ float
            spriteRenderer.color = new Color(100 / 255f, 100 / 255f, 1f, 1f);
        }
        else if (type == 2) 
        {
            size = 1.0f;
            score = 2;
            spriteRenderer.color = new Color(130 / 255f, 130 / 255f, 1f, 1f);

        }
        else if (type == 3) 
        {
            size = 1.2f;
            score = 3;
            spriteRenderer.color = new Color(150 / 255f, 150 / 255f, 1f, 1f);

        }
        //����Ƽ Ʈ������ ������Ʈ�� �����ؼ� ������ ����
        transform.localScale = new Vector3(size, size, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //������Ʈ �浹������ �����ϱ� ���� �Լ�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Collision2D collision �̶�� ���޹��� ���ڿ�
        //������ �׶��� ������Ʈ�� �ε������� �׶��� ���õ� ���� ������Ʈ �������� ����ִ�

        //Debug.Log("�浹");

        //�׶��� ������Ʈ�� �ε������� ����� ������Ʈ�� ����
        //collision.gameObject.name == "Ground" �浹�� ���� ������Ʈ�� �̸��� �׶����϶�
        //collision.gameObject.CompareTag("Ground") �浹�� ���� ������Ʈ�� �±װ� �׶��� �϶�
        if (collision.gameObject.CompareTag("Ground"))
        {   
            //this �� Rain �ڱ� �ڽ�
            Destroy(this.gameObject);

        }

    }

}
