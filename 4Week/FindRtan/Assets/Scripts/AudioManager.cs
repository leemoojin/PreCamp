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
            //신을 이동해도 오디오매니저 게임오브젝트가 파괴되지 않음
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            //혹시라도 다른 씬에 AudioManager 가 있을 수 있다
            //처음 만들어진 싱글톤을 제외하곤 파괴해 주는 코드추가
            Destroy(gameObject);
            Debug.Log("중복 오디오 매니저 파괴");
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
