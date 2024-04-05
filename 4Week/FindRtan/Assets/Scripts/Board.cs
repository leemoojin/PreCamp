using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject card;//카드 프리펩

    // Start is called before the first frame update
    void Start()
    {
        //16장의 카드 오브젝트 생성
        for (int i = 0; i < 16; i++)
        {
            GameObject gO = Instantiate(card, this.transform);
            float x = (i % 4) * 1.4f - 2.1f; //인덱스를 4로 나눴을 때의 나머지 * 1.4 - 임의로 이동한 값
            float y = (i / 4) * 1.4f - 3.0f; //인덱스를 4로 나눴을 때의 몫 * 1.4 - 임의로 이동한 값

            gO.transform.position = new Vector2(x, y);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
