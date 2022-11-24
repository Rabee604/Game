using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScore : MonoBehaviour
{ 
    TextMeshProUGUI playerScoreText; 
    TextMeshProUGUI playerlifeText;

    private int playerScore;
   [SerializeField]
    private int playerlife;
    // Start is called before the first frame update
    void Start()
    {
        playerScoreText = gameObject.GetComponent<TextMeshProUGUI>();
        playerlifeText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame

   public void scoreManger()
   {
       playerScore++;
        playerScoreText.text = playerScore.ToString();
      
    }
    
   public void lifeManger()
   {
      
       playerlife--;
       playerlifeText.text = playerlife.ToString();
   }
    
   
}
