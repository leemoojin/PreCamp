using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //싱글톤
    public static GameManager Instance;

    public GameObject normalCat;
    public GameObject fatCat;
    public GameObject pirateCat;

    public GameObject retryBtn;

    public RectTransform levelFront;//경험치 바

    public Text levelTxt;

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
        InvokeRepeating("MakeCat", 0.0f, 1.5f);
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeCat()
    {
        Instantiate(normalCat);

        //랜덤으로 등장할 확률
        int p = Random.Range(0, 9);

        if (level == 1)
        {
            //20%확률로 추가 생성
            if (p < 2) Instantiate(normalCat);
        }
        else if (level == 2)
        {
            //50% 확률로 추가 생성
            if (p < 5) Instantiate(normalCat);
        }
        else if (level == 3)
        {
            //뚱뚱한 고양이 추가 생성 -> 노말고양이와 다르게 생성하자
            if (p < 4) Instantiate(fatCat);

        }
        else if (level >= 4)
        {
            if (p < 3 ) Instantiate(pirateCat);

            if (p >= 3 && p < 6) Instantiate(fatCat);
        }
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
        levelTxt.text = level.ToString();

        levelFront.localScale = new Vector3((score - level *5)/5.0f, 1f, 1f);
    }
}
