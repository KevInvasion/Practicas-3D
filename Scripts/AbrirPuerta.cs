//Nombre del Desarrollador: Kevin Lozano Sedeño
//Asignatura: Estructura de Datos
//Descripcion del uso de este codigo:
/*
Este script se utilizara para generar la vida del personaje, es decir, el chekpoint que le dara una vida mas

*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta : MonoBehaviour
{

    [SerializeField]
    PlayerControl playerVida;

    // Start is called before the first frame update
    void Start()
    {
        playerVida = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }
    //Este codigo buscara que la vida se le agregue al personaje 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            playerVida.vida++;

        }
    }//En este codigo, si el cuadro de vida le sumaba vida al personaje pero permanecia en el juego


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerVida.vida++;

        }
    }//En Este codigo el cuadro de vida sumara solo una vida al personaje, pero cuando este lo toque, desaparecera


}
