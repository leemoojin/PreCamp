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

    float time = 0.0f;

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
        //게임 정지(종료)
        Time.timeScale = 0f;
        nowScore.text = time.ToString("N2");
        //엔드판넬 표시
        endPanel.SetActive(true);

    }

}
