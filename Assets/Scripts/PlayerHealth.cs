using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour

{   [SerializeField] 
    private PlayerScore playerScore;
    [SerializeField] private int maxHeath;
    private Animator animator;
    [SerializeField] private Gameover gameover;
    private int currentHeath;

    [SerializeField] private Enmey enmey;

    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        currentHeath = maxHeath;
        animator = GetComponent<Animator>();
    }

    
    
    
    public void TakeDamage(int damage)
    {
        currentHeath -= damage;
        
        
       
        if (currentHeath>= 0)
        {
            animator.SetTrigger("hit");
            Debug.Log("Live" + currentHeath);
            playerScore.lifeManger();


        }
        else
        {
            
            //Destroy(gameObject);
            //enmey.disable();
            gameover.gameOverPage();
            
            //SceneManager.LoadScene("DemoScene");
            
           
            
            
        }

    }

    public int getHealth()
    {
        
        return currentHeath;
    }

    
}
