using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public GameObject food;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeFood", 0f, 0.5f);

    }

    void Update()
    {
        //마우스 위치에서 좌우(x축) 값만 가져와서 강아지 오브젝트에 적용하자
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        float x = mousePos.x;
        //강아지가 게임 화면 밖으로 벗어나지 않도록 수정하자 (범위 -8.5~8.5)
        if (x < -8.5f) x = -8.5f;
        if (x > 8.5f) x = 8.5f; 

        //x축은 마우스 위치, y축은 강아지 오브젝트 위치
        transform.position = new Vector2(x, transform.position.y);

    }

    //반복해서 밥오브젝트 생성
    void MakeFood()
    {
        float x = transform.position.x;
        float y = transform.position.y + 2f;
        
        //프리펩 생성, 생성할때 위치값도 지정할 수 있다
        //Quaternion.identity 는 별도의 회전값을 주지 않겠다는 의미
        //미리 만들어둔 food프리펩 그대로 회전값없이 생성하겠다는 의미
        Instantiate(food, new Vector2(x, y), Quaternion.identity);

        Debug.Log("밥먹어");
    }
}
