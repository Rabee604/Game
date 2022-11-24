using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Gameover : MonoBehaviour
{
    [SerializeField] 
    private GameObject gameOver;
    [SerializeField] 
    TextMeshProUGUI playerScoreText;
    [SerializeField] 
    private TextMeshProUGUI gameOverScore;

    public void gameOverPage()
    {
        // ativate gameobjet 
        gameOver.SetActive(true);
        Debug.Log(playerScoreText);
        gameOverScore = playerScoreText;

    }

    public void startGame()
    {
        SceneManager.LoadScene("DemoScene");
        
    }
    
    public void QuitGame()
    {
        SceneManager.LoadScene(0);
        
    }
    
   
        
    
}
