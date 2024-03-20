using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    float size = 1.0f;
    int score = 1;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //색을 변경하기위해 SpriteRenderer를 가져오기 위해 GetComponent<>(); 키워드를 사용한다
        spriteRenderer = GetComponent<SpriteRenderer>();

        //랜덤한 위치
        // Random.Range(최소값, 최대값);
        float x = Random.Range(0.0f, 1.0f);
        float y = Random.Range(3.0f, 5.0f);

        //랜덤하게 추출된 값을 포지션에 넣는다
        transform.position = new Vector3(x, y, 0);

        //랜덤한 크기
        //대중소 (타입1~3)
        //범위에서 최대값은 나오지 않는다
        //Random.Range(1, 4); 일때 최대값 4을 제외한 1,2,3 만 랜덤으로 등장
        int type = Random.Range(1, 4);
        //타입에 따라 크기, 점수, 색을 다르게 세팅하자
        if (type == 1)
        {
            size = 0.8f;
            score = 1;
            //컬러 값을 입력할때는 최대값인 255으로 나눠준 값을 입력해야한다
            //150을 입력 하고싶을때는 150/255를 입력 하면된다
            //데이터 형식은 float
            spriteRenderer.color = new Color(100 / 255f, 100 / 255f, 1f, 1f);
        }
        else if (type == 2) 
        {
            size = 1.0f;
            score = 2;
            spriteRenderer.color = new Color(130 / 255f, 130 / 255f, 1f, 1f);

        }
        else if (type == 3) 
        {
            size = 1.2f;
            score = 3;
            spriteRenderer.color = new Color(150 / 255f, 150 / 255f, 1f, 1f);

        }
        //유니티 트랜스폼 컴포넌트에 접근해서 스케일 변경
        transform.localScale = new Vector3(size, size, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //오브젝트 충돌관련을 구현하기 위한 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Collision2D collision 이라는 전달받은 인자에
        //빗방울과 그라운드 오브젝트가 부딪혔을때 그라운와 관련된 게임 오브젝트 정보들이 들어있다

        //Debug.Log("충돌");

        //그라운드 오브젝트에 부딪혔을때 빗방울 오브젝트를 제거
        //collision.gameObject.name == "Ground" 충돌한 게임 오브젝트의 이름이 그라운드일때
        //collision.gameObject.CompareTag("Ground") 충돌한 게임 오브젝트의 태그가 그라운드 일때
        if (collision.gameObject.CompareTag("Ground"))
        {   
            //this 는 Rain 자기 자신
            Destroy(this.gameObject);

        }

    }

}
