using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonDeMenu : MonoBehaviour
{
    public int numBotonUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BotonSeleccionado(int numboton)
    {
        MenuManager manager = FindObjectOfType<MenuManager>();
        numBotonUI = numboton;

        switch(numBotonUI)
        {
            case 0:
                Application.LoadLevel("TutorialLevel");
                break;
            case 1:
                Application.LoadLevel("SampleScene");
                break;
            case 2:
                Application.Quit();
                break;
        }

    }
}
