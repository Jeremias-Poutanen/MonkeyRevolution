using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public GameObject GameOverScreen;

    public void GameOver()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("moi");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
