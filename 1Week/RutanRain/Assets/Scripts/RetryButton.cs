using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//신을 불러오는 로직에 필요


public class RetryButton : MonoBehaviour
{
    //재시작버튼을 눌렀을 때
    //게임이 작업되고 있는 메인신을 다시 불러올것이다
    //신을 불러오는 로직이 필요

    public void Retry()
    {
        //신 매니지먼트 안의 신 매니저를 활용해서 신을 불러온다
        //신을 로드한다
        SceneManager.LoadScene("MainScene");//MainScene 이라는 이름의 씬을 불러와라

    }



}
