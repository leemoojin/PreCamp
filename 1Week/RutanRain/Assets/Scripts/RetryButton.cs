using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//���� �ҷ����� ������ �ʿ�


public class RetryButton : MonoBehaviour
{
    //����۹�ư�� ������ ��
    //������ �۾��ǰ� �ִ� ���ν��� �ٽ� �ҷ��ð��̴�
    //���� �ҷ����� ������ �ʿ�

    public void Retry()
    {
        //�� �Ŵ�����Ʈ ���� �� �Ŵ����� Ȱ���ؼ� ���� �ҷ��´�
        //���� �ε��Ѵ�
        SceneManager.LoadScene("MainScene");//MainScene �̶�� �̸��� ���� �ҷ��Ͷ�

    }



}
