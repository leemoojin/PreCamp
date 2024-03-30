using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //food 오브젝트가 계속 위로 이동하게 y축값에 더한다
        transform.position += Vector3.up * 0.5f;

        //y축 값이 27을 넘어가면 푸드 오브젝트 파괴
        if (transform.position.y > 27f)
        {
            Destroy(gameObject);
        }

    }
}
