using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//Scene 이동을 위한 using문

public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        //Scene 이동을 위한 키워드
        SceneManager.LoadScene("MainScene");
    }
}
