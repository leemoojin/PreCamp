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
        
    }
}
