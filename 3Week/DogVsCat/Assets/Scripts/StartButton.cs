using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//Scene �̵��� ���� using��

public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        //Scene �̵��� ���� Ű����
        SceneManager.LoadScene("MainScene");
    }
}
