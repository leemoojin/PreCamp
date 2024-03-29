using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //랜덤한 위치에서 생성
        float x = Random.Range(-3f, 3f);
        float y = Random.Range(3f, 5f);
        transform.position = new Vector2(x, y);

        //랜덤한 사이즈
        float size = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector2(size, size);


        

    }

    // Update is called once per frame
    void Update()
    {
        //스퀘어 오브젝트가 게임화면 밖으로 넘어가면 파괴
        if (transform.position.y <= -6f)
        {
            Destroy(this.gameObject);
        }
    }

    //충돌하는 로직
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //스퀘어 오브젝트와 충돌된 것의 정보는 collision 매개변수에 들어있다
        //부딪힌 오브젝트의 태그이름이 Player 인지?
        if (collision.gameObject.CompareTag("Player"))
        {
            //게임매니저의 게임오버함수 호출
            GameManager.instance.GameOver();
        }


    }
}
