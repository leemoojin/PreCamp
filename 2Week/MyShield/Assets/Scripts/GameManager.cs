using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    public GameObject square;
    public Text timeTxt;

    float time = 0.0f;

    public static GameManager instance;
    private void Awake()
    {   
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeSquare", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {   
        //타이머
        time += Time.deltaTime;
        timeTxt.text = time.ToString("n2");
        Debug.Log(time);




    }

    void MakeSquare()
    {
        //프리펩을 생성시키는 코드
        Instantiate(square);

        Debug.Log("생성한다");
    }
}
