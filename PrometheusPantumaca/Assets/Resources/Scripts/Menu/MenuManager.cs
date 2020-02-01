using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject[] opcionesMenu;
    [SerializeField] private Transform puntoSeleccionador;
    [SerializeField] int opcionSeleccionada = 0;

    // Start is called before the first frame update
    void Start()
    {
        puntoSeleccionador.position = new Vector3(opcionesMenu[0].transform.right.x, opcionesMenu[0].transform.position.y, opcionesMenu[0].transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        int auxY = (int) Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.W))
        {
            CambiarOpcion(-1);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            CambiarOpcion(1);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            SeleccionarOpcion(opcionSeleccionada);
        }

            ;
    }

    void CambiarOpcion(int cambio)
    {
        opcionSeleccionada += cambio ;
        if (opcionSeleccionada > 2)
            opcionSeleccionada = 0;
        else if (opcionSeleccionada< 0)
        {
            opcionSeleccionada = 2; 
        }

        if (opcionSeleccionada == 0)
        {
            puntoSeleccionador.position = new Vector3(opcionesMenu[0].transform.right.x, opcionesMenu[0].transform.position.y, opcionesMenu[0].transform.position.z);
        } else if(opcionSeleccionada == 1)
        {
            puntoSeleccionador.position = new Vector3(opcionesMenu[1].transform.right.x, opcionesMenu[1].transform.position.y, opcionesMenu[1].transform.position.z);
        }
        else if(opcionSeleccionada == 2){
            puntoSeleccionador.position = new Vector3(opcionesMenu[2].transform.right.x, opcionesMenu[2].transform.position.y, opcionesMenu[2].transform.position.z);
        }

        
    }

    void SeleccionarOpcion(int seleccion)
    {
        opcionesMenu[0].GetComponent<BotonDeMenu>().BotonSeleccionado(opcionSeleccionada);
    }
}
