using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx = 0;//카드 번호

    public GameObject front;
    public GameObject back;

    public Animator anim;

    AudioSource audioSource;
    public AudioClip clip;

    //카드 앞면, 이미지
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
        //전달 받은 매개변수를 idx에 넣어준다
        idx = number;
        //유니티 resources 폴더에 접근
        frontImage.sprite = Resources.Load<Sprite>($"rtan{idx}");
    }

    public void OpenCard()
    {           
        if (GameManager.Instance.secondCard != null) return;

        //카드 오픈했을때 효과음 실행
        //PlayOneShot 효과음 끼리 소리가 겹치지 않는다, 연속으로 재생시켜도 한번만 실행
        audioSource.PlayOneShot(clip);

        //애니메이션 실행(cardFlip)
        anim.SetBool("isOpen", true);

        //앞면 오브젝트를 킨다
        front.SetActive(true);
        //뒷면 오브젝트를 끈다
        back.SetActive(false);

        //firstCard 가 비어있다면
        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        //firstCard 가 비어있지않다면        
        else
        {
            GameManager.Instance.secondCard = this;
            //두장이 카드가 같은지 판단하는 함수 호출
            GameManager.Instance.Matched();
        }
        
    }

    public void DestroyCard()
    {   
        //파괴하기전에 카드를 확인하기 위해 딜레이를 준다
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
