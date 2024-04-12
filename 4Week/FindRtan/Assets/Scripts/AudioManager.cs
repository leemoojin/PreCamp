using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{   
    public static AudioManager Instance;

    AudioSource audioSource;
    public AudioClip clip;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //���� �̵��ص� ������Ŵ��� ���ӿ�����Ʈ�� �ı����� ����
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            //Ȥ�ö� �ٸ� ���� AudioManager �� ���� �� �ִ�
            //ó�� ������� �̱����� �����ϰ� �ı��� �ִ� �ڵ��߰�
            Destroy(gameObject);
            Debug.Log("�ߺ� ����� �Ŵ��� �ı�");
        }
    
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = this.clip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
