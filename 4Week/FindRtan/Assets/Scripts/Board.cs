using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject card;//카드 프리펩

    // Start is called before the first frame update
    void Start()
    {
        //카드 번호가 담긴 배열 생성
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };        

        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray();

        //0장으로 만들면 게임 클리어 -> 종료
        GameManager.Instance.cardCount = arr.Length;

        //16장의 카드 오브젝트 생성
        for (int i = 0; i < 16; i++)
        {   
            GameObject go = Instantiate(card, this.transform);
            float x = (i % 4) * 1.4f - 2.1f; //인덱스를 4로 나눴을 때의 나머지 * 1.4 - 임의로 이동한 값
            float y = (i / 4) * 1.4f - 3.0f; //인덱스를 4로 나눴을 때의 몫 * 1.4 - 임의로 이동한 값

            go.transform.position = new Vector2(x, y);

            //카드 오브젝트에 카드라는 스크립트 컴포넌트를 추가했기 때문에 겟컴포넌트로 찾을 수 있다
            go.GetComponent<Card>().Setting(arr[i]);            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
