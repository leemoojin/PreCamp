using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//ui의 텍스트 타입을 가져오기 위해

public class GameManager : MonoBehaviour
{
    //싱글톤은 나는 하나밖에 없다는 의미
    //->프로젝트에 게임 매니저라는 객체는 내가 유일하다
    //여러 스크립트에서 접근이 가능하게하는 기능
    public static GameManager Instance;
    //인스턴스에 나 자신을 넣어줘야한다
    private void Awake()
    {
        //Instance 변수 안에 나 자신의 데이터를 넣어줘야 한다
        Instance = this;
        //게임이 재시작 되었을 때 빗방울과 시간이 작동한다
        Time.timeScale = 1.0f;
    }

    int totalScore;

    float totalTime = 15.0f;

    //ui text
    public Text totalScoreTxt;
    public Text timeTxt;


    //prefab화된 Rain 오브젝트를 불러와야한다 > 이것의 자료형은 게임오브젝트이다
    public GameObject rain;
    //->유니티 인스펙터 창에서 위에서 선언한 rain 변수에
    //Prefab Rain 오브젝트를 담아둔 상태이기때문에 데이터가 들어있다

    public GameObject endPanel;

    // Start is called before the first frame update
    void Start()
    {
        //함수를 반복적으로 실행하는 함수 InvokeRepeating(함수의 이름, 몇초 이후에 생성할지, 반복 주기)
        //0f -> 0초 이후 float 값이기 때문에 뒤에 f를 붙인다, 반복주기 -> 몇초마다 생성 할지 1f는 1초마다 생성
        InvokeRepeating("MakeRain", 0f, 1f);
        //->"MakeRain" 이라는 함수를 0초부터(바로) 1초마다 반복적으로 호출한다는 의미

    }

    // Update is called once per frame
    void Update()
    {

        if (totalTime > 0f)
        {
            //토탈타임에 흘러간 시간을 빼주자
            //time 키워드를 사용하면 시간의 기능을 가져와서 사용가능하다
            //성능이 좋은 기기느 프레임이 높기때문에 기기마다 차이가 발생한다
            //시간을 계산해주는 연산이 프레임이 높으면 많이 계산된다
            //하지만 deltaTime을 사용하면
            //모든 기기들이 같은 시간값을 가질 수 있도록 프레임 대비 조정해준다
            totalTime -= Time.deltaTime;
            //N2 는 소수점 2째자리까지만 표시해달라는 명령이다

        }
        //토탈타임이 0 이하가되면 게임 종료
        else
        {
            //게임을 정지할때 정확히 0초에서 멈추는게 아니라 미세한 오차가 발생할 수 있다
            //때문에 0초로 직접 수정해준다
            totalTime = 0f;

            //SetActive(bool); 해당 게임오브젝트를 활성화 여부를 설정하는 함수 
            endPanel.SetActive(true);


            //게임을 멈추는 키워드는 time으로 접근한다
            //time의 크기를 0으로 만든다 
            //첫번째 프레임과 다음 프레임까지의 시간의 차이가 없어지게된다
            //-> 게임의 시간이 멈추게되는 효과를 연출           
            Time.timeScale = 0f;

        }

        timeTxt.text = totalTime.ToString("N2");
        Debug.Log(totalTime);





    }

    //빗방울을 생성하는 함수을 만들자
    void MakeRain()
    {
        //게임오브젝트를 생성하는 함수 Instantiate()
        Instantiate(rain);
    
    }

    //점수를 올려주는 기능 (int score) 매개변수
    //public 은 내 스크립트가 아닌 외부의 스크립트에서 접근 가능하게 허용하는 키워드
    public void AddScore(int score)
    {
        totalScore += score;

        if (totalScore < 0) totalScore = 0;
        
        totalScoreTxt.text = totalScore.ToString();
        //Debug.Log(totalScore);
    }
}
