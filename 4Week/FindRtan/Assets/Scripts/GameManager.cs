using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //비교할 두장의 카드
    public Card firstCard;
    public Card secondCard;

    public Text timeTxt;
    public GameObject endTxt;
    
    //0장으로 만들면 게임 클리어 -> 종료
    public int cardCount = 0;

    float time = 0.00f;

    AudioSource audioSource;
    public AudioClip clip;

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //타이머의 시간이 흐르게 구현
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        //30초가 되면 게임 종료
        if (time >= 30f)
        {
            //게임 종료
            timeTxt.text = "30.00";
            GameOver();
        }

    }

    public void Matched()
    {
        Debug.Log("판단하자");
        //두장의 카드가 같다면 파괴해라
        if (firstCard.idx == secondCard.idx)
        {
            audioSource.PlayOneShot(clip);//파괴 효과음

            firstCard.DestroyCard();
            secondCard.DestroyCard();

            cardCount -= 2;
            if (cardCount == 0)
            {
                //게임 종료
                GameOver();
            }
        }
        //다르다면 다시 뒤집어라
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        //판단의 끝난뒤에 변수의 값을 비우자 다음 선택을 위해서
        firstCard = null;
        secondCard = null;
    }

    void GameOver() 
    {
        //게임 종료
        Time.timeScale = 0.0f;
        endTxt.SetActive(true);
    }
}
