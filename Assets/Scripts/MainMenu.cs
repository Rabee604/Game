
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private EnterGame enterGame;
    [SerializeField] private Button button1;

    public void Exit()
    {
       enterGame.SetName();
       button1.enabled = false;


    }


    public void playGame()
    {
        SceneManager.LoadScene("DemoScene");
    }
}
