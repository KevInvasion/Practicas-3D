//Nombre del Desarrollador: Kevin Lozano Sedeño
//Asignatura: Estructura de Datos
//Descripcion del uso de este codigo:
/*
Este script se utilizara para generar un rayo, ademas de crear un puntero que cambie de color cuando este encuentre un enemigo

*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisparoRayo : MonoBehaviour
{
    public float distanciaRayo;
    public LayerMask capaDaño;
    public Image puntero; //Esta variable identificara la imagen png que funcionara como puntero.
    
    //Las variables siguentes guardaran la informacion y posicion del rayo.
    private Ray rayo;
    private Ray rayoInteraccion;
    private Vector2 centroCamara;

    private RaycastHit hitinfo;

    public Transform Barril;


    // Start is called before the first frame update
    void Start()
    {
        this.centroCamara.x = Screen.width / 2;
        this.centroCamara.y = Screen.height / 2;


        Cursor.lockState = CursorLockMode.Confined; //delimita el cursor en la pantalla game
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //El rayo sera producido desde el barril de la pistola y se dirigira al centro de la camara.
        rayo.origin = Barril.position;
        rayo.direction = Barril.forward;
        rayoInteraccion = Camera.main.ScreenPointToRay(this.centroCamara);

        Debug.DrawRay(rayoInteraccion.origin, rayoInteraccion.direction * distanciaRayo, Color.green); //Coloreara de color verde el rayo, se visualiza solo en la ventana Scene

        if (Physics.Raycast(rayoInteraccion,out hitinfo, distanciaRayo, capaDaño))
        {
            if (hitinfo.collider != null)
            {
                if (hitinfo.collider.tag == "Enemy")
                {
                    puntero.color = Color.green; //El puntero se colorea de verde cuando encuentra un enemigo.
                }
            }
        }
        else
        {
            puntero.color = Color.white; //El puntero se pintara de blanco cuando el arma no identifique un enemigo.
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(rayo,out hitinfo, distanciaRayo,capaDaño))
            {
                if (hitinfo.collider != null)
                {
                    if (hitinfo.collider.tag=="Enemy")
                    {
                        Destroy(hitinfo.collider.gameObject); //Destruira el objeto enemigo cuando el rayo golpee a un enemigo.
                    }
                }
            }
        } 
    }
}
