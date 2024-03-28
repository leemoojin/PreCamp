using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    public GameObject square;
    public GameObject endPanel;

    public Text timeTxt;
    public Text nowScore;
    public Text bestScore;

    public Animator anim;


    float time = 0.0f;
    string key = "bestScore";

    bool isPlay = true;

    public static GameManager instance;
    private void Awake()
    {   
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {   
        //게임 시작
        Time.timeScale = 1f;

        InvokeRepeating("MakeSquare", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {   
        
        if (isPlay ) 
        {
            //타이머
            time += Time.deltaTime;
            timeTxt.text = time.ToString("n2");
            Debug.Log(time);

        }

    }

    void MakeSquare()
    {
        //프리펩을 생성시키는 코드
        Instantiate(square);

        Debug.Log("생성한다");
    }

    public void GameOver() 
    {
        isPlay = false;
        anim.SetBool("isDie", true);


        //게임 정지(종료)
        Invoke("TimeStop", 0.5f);
        
        nowScore.text = time.ToString("N2");

        //최고점수가 있다면  
        if (PlayerPrefs.HasKey(key))
        {
            float best = PlayerPrefs.GetFloat(key);
            //최고점수와 현재점수를 비교, 현재 점수가 더 클때 
            if (time > best)
            {
                //현재 점수를 최고점수로 등록
                PlayerPrefs.SetFloat(key, time);
            }

        }
        //최고점수가 없다면
        else 
        {
            //현재점수를 최고점수로 등록
            PlayerPrefs.SetFloat(key, time);
        }

        //최고점수를 엔드판넬에 적용
        bestScore.text = PlayerPrefs.GetFloat(key).ToString("N2");

        //엔드판넬 표시
        endPanel.SetActive(true);

    }

    void TimeStop()
    {
        //게임 정지(종료)
        Time.timeScale = 0f;
    }

}
