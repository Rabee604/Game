using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EnterGame : MonoBehaviour

{
    [SerializeField] private GameObject gameScreen;
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    public void SetName()
    {
        gameScreen.SetActive(true);
        button1.SetActive(false);
        button2.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        button1 = GameObject.Find("Play");
        button2 = GameObject.Find("Stop game");
    }

    // Update is called once per frame
    public void startGame()
    
    {
        SceneManager.LoadScene(0);    
    }
    
        
    
}
