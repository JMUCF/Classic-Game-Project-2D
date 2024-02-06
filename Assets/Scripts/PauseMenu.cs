using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
	public GameObject menuButton;

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }
	
	public void Pause()
	{
		pauseMenu.SetActive(true);
		menuButton.SetActive(true);
		Time.timeScale = 0;
	}
	
	public void Continue()
	{
		pauseMenu.SetActive(false);
		menuButton.SetActive(false);
		Time.timeScale = 1;
	}
	
	public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
		Time.timeScale = 1;
    }
}
