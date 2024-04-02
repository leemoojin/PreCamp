using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //싱글톤
    public static GameManager Instance;

    public GameObject normalCat;
    public GameObject fatCat;
    public GameObject retryBtn;

    int level = 0;
    int score = 0;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        //모든 기기의 프레임 값을 일정하게 맞춰서 계산하는 빈도도 똑같게 한다
        Application.targetFrameRate = 60;
        Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {       
        InvokeRepeating("MakeCat", 0.0f, 1.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeCat()
    {
        Instantiate(normalCat);
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        retryBtn.SetActive(true);
    }

    public void AddScore()
    {
        score++;

        //5스코어마다 1레벨이 증가 (1~4 = 0 레벨, 5~9 = 1레벨)
        level = score / 5;
    }
}
