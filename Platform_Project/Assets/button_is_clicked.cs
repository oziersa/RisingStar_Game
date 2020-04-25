using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_is_clicked : MonoBehaviour
{
    void Start()
    {

    }
    public void Play_Game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void back_To_Menu()
    {
        SceneManager.LoadScene("main_menu");
    }
    public void info()
    {
        SceneManager.LoadScene("info");
    }
    public void volume()
    {
        SceneManager.LoadScene("volume");
    }
    // Update is called once per frame
    void Update()
    {

    }

}
