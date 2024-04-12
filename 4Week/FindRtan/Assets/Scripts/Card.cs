using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx = 0;//ī�� ��ȣ

    public GameObject front;
    public GameObject back;

    public Animator anim;

    AudioSource audioSource;
    public AudioClip clip;

    //ī�� �ո�, �̹���
    public SpriteRenderer frontImage;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Setting(int number)
    {
        //���� ���� �Ű������� idx�� �־��ش�
        idx = number;
        //����Ƽ resources ������ ����
        frontImage.sprite = Resources.Load<Sprite>($"rtan{idx}");
    }

    public void OpenCard()
    {           
        if (GameManager.Instance.secondCard != null) return;

        //ī�� ���������� ȿ���� ����
        //PlayOneShot ȿ���� ���� �Ҹ��� ��ġ�� �ʴ´�, �������� ������ѵ� �ѹ��� ����
        audioSource.PlayOneShot(clip);

        //�ִϸ��̼� ����(cardFlip)
        anim.SetBool("isOpen", true);

        //�ո� ������Ʈ�� Ų��
        front.SetActive(true);
        //�޸� ������Ʈ�� ����
        back.SetActive(false);

        //firstCard �� ����ִٸ�
        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        //firstCard �� ��������ʴٸ�        
        else
        {
            GameManager.Instance.secondCard = this;
            //������ ī�尡 ������ �Ǵ��ϴ� �Լ� ȣ��
            GameManager.Instance.Matched();
        }
        
    }

    public void DestroyCard()
    {   
        //�ı��ϱ����� ī�带 Ȯ���ϱ� ���� �����̸� �ش�
        Invoke("DestroyCardInvoke", 1.0f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 1.0f);
    }
    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);

        front.SetActive(false);
        back.SetActive(true);
    }
}
