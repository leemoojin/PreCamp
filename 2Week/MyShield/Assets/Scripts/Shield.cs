using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //메인 카메라에 접근
        //스크린의 위치를 게임 월드상의 위치로 변환하는 함수 ScreenToWorldPoint(transform.position);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //쉴드 오브젝트의 위치 = 마우스의 위치 
        transform.position = mousePos;
    }
}
