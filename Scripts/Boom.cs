//Nombre del Desarrollador: Kevin Lozano Sedeño
//Asignatura: Estructura de Datos
//Descripcion del uso de este codigo:
/*
Este script funcionara para simular la destruccion de un objeto para ser colisionado por otro

*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    //Se nombran las variables a utilizar para que la pared y la vida puedan funcionar
    public float cronometro = 0.0f;

    [SerializeField]
    SpriteRenderer spritePared;

    [SerializeField]
    PlayerControl playerVida;


    private void Start()
    {
        //spritePared =GameObject.Find("pared_0").GetComponent<SpriteRenderer>();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Bloque 1 registra colision y evento al activarse con un objeto Pared
        if (collision.gameObject.tag == "Pared")
        {
            spritePared.material.color = Color.blue; //El color de la pared cambiara a azul cuando la dinamita colisione con ella
            //Destroy(collision.gameObject);
            //Destroy(this.gameObject);
        }
        // Bloque 2 registra colision y evento al activarse con un objeto Player
        if (collision.gameObject.tag == "Player")
        {
            playerVida.vida--; //Presentara reduccion de vida al momento de colisionar con la dinamita

            Debug.Log("Al infinito y mas alla"); //Aparecera en la consola al momento de que la dinamita colisione con el jugador y la pared
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {

        //******************bloque aislado**********
        if (collision.gameObject.tag == "Pared") //Se registra el objeto que va a colisionar
        {

            cronometro = cronometro + 0.5f*Time.deltaTime;
            //+++++Bloque aislado 2++++
            if (cronometro >= 5.0f)
            {
                cronometro = 5.0f;
                if (cronometro == 5.0f)
                {
                    Destroy(collision.gameObject);
                    Destroy(this.gameObject); //Se define que el objeto debera destruirse
                }
            }//El codigo realizara un conteo cuando dos objetos colisionen (la dinamita y la pared) y cuando llegue a los 5s, se destruiran
            

        }
        //+++++++++++++++++++++++++++++++++++++++++++
    }






}
