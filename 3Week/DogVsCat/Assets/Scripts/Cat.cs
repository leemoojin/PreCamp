using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public GameObject hungryCat;
    public GameObject fullCat;

    public RectTransform front;//ü�¹�
    
    //�׶��� �����, �Ϲ� ����� ���п�
    public int type;

    float full = 5.0f;//�� ü��
    float energy = 0.0f;
    float speed = 0.05f;//����̰� �������� �ӵ�

    //bool isFull = false;

    // Start is called before the first frame update
    void Start()
    {   
        
        //����� ��ġ�� y�� 30, x�� -9~9 ���� 
        float x = Random.Range(-9.0f, 9.0f);
        float y = 30.0f;
        transform.position = new Vector2(x, y);

        //�븻�����
        if (type == 1)
        {
            speed = 0.05f;
            full = 5f;
        }
        //�׶װ����
        else if (type == 2)
        {
            speed = 0.02f;
            full = 10f;
        }
        //���������
        else if (type == 3)
        {
            speed = 0.1f;
            full = 5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        //���� ������ ���� ���̶�� , �������� �ƴϸ� ����� ������Ʈ�� �����
        if (Time.timeScale == 1.0f)
        {

            //����ö�
            if (energy < full)
            {
                //����� ��ġ�� ��� �Ʒ��� ��������
                transform.position += Vector3.down * speed;

                //������� ��ġ�� y���� -16���� ������ ���� ������ ȣ��
                if (transform.position.y < -16.0f)
                {
                    GameManager.Instance.GameOver();
                }
            }
            //��θ���
            else
            {
                //�߽��� ����(x���� 0)���� �¿�� ������
                if (transform.position.x > 0)
                {
                    transform.position += Vector3.right * 0.05f;
                }
                else
                {
                    transform.position += Vector3.left * 0.05f;
                }


            }

        }                       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Ǫ�� �±� ������Ʈ�� �ε����� ��
        if (collision.gameObject.CompareTag("Food"))
        {   
            //����� �������� �� ���� �ʾ��� ��
            if (energy < full)
            {   
                //ü�¹� ������ ����
                energy += 1.0f;
                //�������� x ���� 1/5 -> 2/5 -> 3/5 ������ Ŀ���� 
                front.localScale = new Vector3(energy / full, 1.0f, 1.0f);
                //Debug.Log("���ִ�");
                Destroy(collision.gameObject);//���϶��� Ǫ�� ������Ʈ �ı�

                //�������� �� á�� ��
                if (energy == full)
                {
                    //Debug.Log("������ ����");
                    //ü���� ������ ��׸�Ĺ -> ǮĹ
                    hungryCat.SetActive(false);
                    fullCat.SetActive(true);

                    //ü���� ������ 3���� ������Ʈ �ı�
                    Destroy(gameObject, 3.0f);

                    //�������� �Լ� ȣ��
                    GameManager.Instance.AddScore();

                }                
                
            }            

        }

    }
}
