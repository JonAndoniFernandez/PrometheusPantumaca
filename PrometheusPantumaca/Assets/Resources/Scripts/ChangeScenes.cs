using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class ChangeScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevel1()
    { 
        //Cargar nivel 1, bro
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
