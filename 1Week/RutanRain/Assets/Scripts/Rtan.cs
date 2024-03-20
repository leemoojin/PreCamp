using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    float direction = 0.05f;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update 
    //스크립트가 시작할때 한번 호출
    void Start()
    {   
        
        Application.targetFrameRate = 60;
        //컴포넌트를 가져오는 기능
        spriteRenderer = GetComponent<SpriteRenderer>();
        //Debug.Log("안녕");

    }

    // Update is called once per frame
    //프레임 마다 한번씩 호출
    void Update()
    {

        //마우스 클릭 했을 때 방향 전환
        //0 왼쪽 버튼, 1 오른쪽 버튼
        if (Input.GetMouseButtonDown(0))
        {
            direction *= -1;
            spriteRenderer.flipX = !spriteRenderer.flipX;//좌우 반전
        }
        

        //벽에 도달시 반대 방향으로 이동
        //오른쪽 벽 x 값 2.6, 왼쪽벽 -2.6

        if (transform.position.x > 2.6)
        {
            //flip x 박스를 체크한다 = true -> 좌우 반전
            spriteRenderer.flipX = true;
            direction = -0.05f;
            
        }

        if (transform.position.x < -2.6)
        {
            spriteRenderer.flipX = false;
            direction = 0.05f;
        }

        //transform 컴포넌트의 position X 값에 따라 캐릭터 오브잭트의 위치가 변한다
        // Vector3(x, y, z); 삼차원 공간 z는 앞뒤이기 때문에 2d 게임에서는 건드릴 일이 없다 
        //transform.position += new Vector3(1f, 0, 0);

        //게임 시작이 오른쪽으로 이동
        transform.position += Vector3.right * direction;
    }
}
