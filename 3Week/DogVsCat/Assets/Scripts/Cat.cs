using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public GameObject hungryCat;
    public GameObject fullCat;

    public RectTransform front;//체력바

    float full = 5.0f;//총 체력
    float energy = 0.0f;

    // Start is called before the first frame update
    void Start()
    {   
        
        //고양이 위치를 y값 30, x값 -9~9 랜덤 
        float x = Random.Range(-9.0f, 9.0f);
        float y = 30.0f;
        transform.position = new Vector2(x, y);

    }

    // Update is called once per frame
    void Update()
    {
        

        //만약 게임이 실행 중이라면 , 실행중이 아니면 고양이 오브젝트가 멈춘다
        if (Time.timeScale == 1.0f)
        {

            //배고플때
            if (energy < full)
            {
                //고양이 위치를 계속 아래로 내려오게
                transform.position += Vector3.down * 0.05f;

                //고양이의 위치가 y값이 -16보다 작으면 게임 오버를 호출
                if (transform.position.y < -16.0f)
                {
                    GameManager.Instance.GameOver();
                }
            }
            //배부를때
            else
            {
                //중심을 기준(x값이 0)으로 좌우로 보내자
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //푸드 태그 오브젝트와 부딪혔을 때
        if (collision.gameObject.CompareTag("Food"))
        {
            if (energy < full)
            {   
                //체력바 게이지 증가
                energy += 1.0f;
                //스케일의 x 값이 1/5 -> 2/5 -> 3/5 순으로 커진다 
                front.localScale = new Vector3(energy / full, 1.0f, 1.0f);
                //Debug.Log("맛있다");
                Destroy(collision.gameObject);//먹일때만 푸드 오브젝트 파괴

                if (energy == full)
                {
                    //체력이 꽉차면 헝그리캣 -> 풀캣
                    hungryCat.SetActive(false);
                    fullCat.SetActive(true);

                    //체력이 꽉차면 3초후 오브젝트 파괴
                    Destroy(gameObject, 3.0f);

                    //점수증가 함수 호출
                    GameManager.Instance.AddScore();
                }                
                
            }            

        }

    }
}
