using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //ΩÃ±€≈Ê
    public static GameManager Instance;

    public GameObject normalCat;
    public GameObject fatCat;
    public GameObject retryBtn;


    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeCat", 0.0f, 1.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeCat()
    {
        Instantiate(normalCat);
    }

    public void GameOver()
    {
        retryBtn.SetActive(true);
    }
}
