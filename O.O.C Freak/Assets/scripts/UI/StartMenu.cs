using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : PersistentSingleton<StartMenu>
{
    public GameObject StartMenuUI;
    public GameObject OptionMenuUI;
    public GameObject HowToPlay;
    public GameObject BattleUI;
    public GameObject PauseUI;
    public GameObject CreditsUI;
    public static StartMenu Instance;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void PlayButton()
    {
        
        GameManager.Instance.UpdateGameState(GameState.Level1);
        StartMenuUI.SetActive(false);
        BattleUI.SetActive(true);
    }
    void Update()
    {
    }
    public void OptionButton()
    {
        StartMenuUI.SetActive(false);
        OptionMenuUI.SetActive(true);
    }
    public void HowToPlayButton()
    {
        StartMenuUI.SetActive(false);
        HowToPlay.SetActive(true);

    }
    public void HowToPlay2Main()
    {
        HowToPlay.SetActive(false);
        StartMenuUI.SetActive(true);
    }
    public void Options2Main()
    {
        OptionMenuUI.SetActive(false);
        StartMenuUI.SetActive(true);
    }

    public void Pause2Main()
    {
        BattleUI.SetActive(false);
        PauseUI.SetActive(false);
        GameManager.Instance.UpdateGameState(GameState.MainMenu);
        restartCurrentScene();

    }
    public void restartCurrentScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void RestartScene2Main()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Debug.Log("it quit");
        Application.Quit();
    }

    public void CreditsfromMain()
    {
        StartMenuUI.SetActive(false);
        CreditsUI.SetActive(true);
    }

    public void CreditsToMain()
    {
        CreditsUI.SetActive(false);
        StartMenuUI.SetActive(true);
    }


    /* public void HowToPlay2Main()
     {

     }
     public void HowToPlay2Main()
     {

     }*/
}
