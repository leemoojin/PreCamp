using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RetryBtn : MonoBehaviour
{

    public void Retry()
    {
        //메인신을 다시 로드
        SceneManager.LoadScene("MainScene");
    
    }

}
