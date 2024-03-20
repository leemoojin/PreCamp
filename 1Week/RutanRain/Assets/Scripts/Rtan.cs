using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    float direction = 0.05f;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update 
    //��ũ��Ʈ�� �����Ҷ� �ѹ� ȣ��
    void Start()
    {   
        
        Application.targetFrameRate = 60;
        //������Ʈ�� �������� ���
        spriteRenderer = GetComponent<SpriteRenderer>();
        //Debug.Log("�ȳ�");

    }

    // Update is called once per frame
    //������ ���� �ѹ��� ȣ��
    void Update()
    {

        //���콺 Ŭ�� ���� �� ���� ��ȯ
        //0 ���� ��ư, 1 ������ ��ư
        if (Input.GetMouseButtonDown(0))
        {
            direction *= -1;
            spriteRenderer.flipX = !spriteRenderer.flipX;//�¿� ����
        }
        

        //���� ���޽� �ݴ� �������� �̵�
        //������ �� x �� 2.6, ���ʺ� -2.6

        if (transform.position.x > 2.6)
        {
            //flip x �ڽ��� üũ�Ѵ� = true -> �¿� ����
            spriteRenderer.flipX = true;
            direction = -0.05f;
            
        }

        if (transform.position.x < -2.6)
        {
            spriteRenderer.flipX = false;
            direction = 0.05f;
        }

        //transform ������Ʈ�� position X ���� ���� ĳ���� ������Ʈ�� ��ġ�� ���Ѵ�
        // Vector3(x, y, z); ������ ���� z�� �յ��̱� ������ 2d ���ӿ����� �ǵ帱 ���� ���� 
        //transform.position += new Vector3(1f, 0, 0);

        //���� ������ ���������� �̵�
        transform.position += Vector3.right * direction;
    }
}
