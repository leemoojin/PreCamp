using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public GameObject hungryCat;
    public GameObject fullCat;

    public RectTransform front;//ü�¹�

    float full = 5.0f;//�� ü��
    float energy = 0.0f;

    // Start is called before the first frame update
    void Start()
    {   
        //��� ����� ������ ���� �����ϰ� ���缭 ����ϴ� �󵵵� �Ȱ��� �Ѵ�
        Application.targetFrameRate = 60;
        //����� ��ġ�� y�� 30, x�� -9~9 ���� 
        float x = Random.Range(-9.0f, 9.0f);
        float y = 30.0f;
        transform.position = new Vector2(x, y);

    }

    // Update is called once per frame
    void Update()
    {
        //����ö�
        if (energy < full)
        {
            //����� ��ġ�� ��� �Ʒ��� ��������
            transform.position += Vector3.down * 0.05f;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Ǫ�� �±� ������Ʈ�� �ε����� ��
        if (collision.gameObject.CompareTag("Food"))
        {
            if (energy < full)
            {   
                //ü�¹� ������ ����
                energy += 1.0f;
                //�������� x ���� 1/5 -> 2/5 -> 3/5 ������ Ŀ���� 
                front.localScale = new Vector3(energy / full, 1.0f, 1.0f);

                if (energy == full)
                {
                    //ü���� ������ ��׸�Ĺ -> ǮĹ
                    hungryCat.SetActive(false);
                    fullCat.SetActive(true);
                }

                //Debug.Log("���ִ�");
                Destroy(collision.gameObject);//���϶��� Ǫ�� ������Ʈ �ı�
                
            }            

        }

    }
}
