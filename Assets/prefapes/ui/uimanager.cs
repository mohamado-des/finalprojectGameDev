using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class uimanager : MonoBehaviour
{
    [SerializeField]private GameObject GameOverScreen;
    [SerializeField] AudioClip gameoversound;
    [SerializeField] private GameObject pauseScreen;
    private void Awake()
   {
        GameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {


            if (pauseScreen.activeInHierarchy)
            {
                PauseGame(false);
            }
            else
                PauseGame(true);
        }
    }
    #region gameover

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
        soundmanager.instance.playsound(gameoversound);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Resume()
    {
            PauseGame(false );
    }
    public void MENU()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    { 
        Application.Quit();
        
    }
    #endregion 
    #region pause
    private void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);
        if(status)
        {
            Time.timeScale= 0;
        }
        else
        {
            Time.timeScale= 1;
        }
    }
    #endregion
    
}

