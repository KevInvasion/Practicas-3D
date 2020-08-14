//Nombre del Desarrollador: Kevin Lozano Sedeño
//Asignatura: Estructura de Datos
//Descripcion del uso de este codigo:
/*
Este script se utilizara para generar el control del avatar Jugador

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{// Inicio del Cuerpo de la Clase

    //++++++ Area para declarar variables+++++

    //El tipo de dato   Nombre de la variable
    Rigidbody fisicasRB;
    public Transform cabeza;
    //Al declarar una variable publica, esta se puede visualizar en el inspector
    public float FuerzaSaltoPersonaje;

    //Esta variable podra hacer que nuestro personaje cuente con un numero de vidas
    public int vida;

    //Serialized Field cumple con el muestreo de variables en el inspector pero con su acceso privado
    [SerializeField]
    float VelocidadPersonaje;
    [SerializeField]
    float velocidadRotacionX;
    [SerializeField] 
    float velocidadRotacionY;

    float ejeZ;
    float rotacionX;
    float rotacionY;





    //+++++++++++++++++++++++++++++++++++++++++

    // Start sirve para inicializar datos, componentes y variables
    // Carga todos mis GameObjects, Acciones, Valores o Eventos al Juego 
    void Start()
    {
        //lee el componente de cierto tipo
        Cursor.visible = false;
        
        fisicasRB = GetComponent<Rigidbody>();
        FuerzaSaltoPersonaje = 5.0f;
        VelocidadPersonaje = 1.0f;
        vida = 3;
        //En esta seccion logramos hacer que el personaje tenga una fuerza de salto y de movimienti, y ademas, declarar el numero de vidas
        //que el personaje tiene como limite
      
    }

    // Update sirve para utilizar los datos, componentes y variables
    void Update()
    {
        //region variables
        #region Variables
        ejeZ = Input.GetAxis("Vertical") * VelocidadPersonaje*Time.deltaTime;
        var ejeX = Input.GetAxis("Horizontal") * VelocidadPersonaje*Time.deltaTime;
        rotacionX = Input.GetAxis("Mouse X") * velocidadRotacionX;
        rotacionY = Input.mousePosition.x * velocidadRotacionX;
        #endregion
        //Region guarda codigo de salto
        #region Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fisicasRB.AddForce(Vector2.up * FuerzaSaltoPersonaje, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fisicasRB.AddForce(Vector2.up * FuerzaSaltoPersonaje, ForceMode.Impulse);
        }
        #endregion
        //Guarda movimiento por fisicas
        #region Movimientos Fisicas


        //if (Input.GetKey(KeyCode.D))
        //{           
        //    fisicasRB.velocity = new Vector2(VelocidadPersonaje, fisicasRB.velocity.y);
        //}
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    fisicasRB.velocity = new Vector2(-VelocidadPersonaje, fisicasRB.velocity.y);
        //}

        //fisicasRB.velocity = new Vector3(fisicasRB.velocity.x, fisicasRB.velocity.y, ejeZ);
        #endregion
        //Guarda movimiento por transform
        #region Movimiento por transform

        transform.Translate(new Vector3(ejeX, 0, ejeZ));

        #endregion

        #region Rotacion

        rotacionY = Mathf.Clamp(rotacionY, -90, 90); //limita el rango de campo visual del jugador

        transform.localEulerAngles = new Vector3(Input.mousePosition.y * -velocidadRotacionY, rotacionY, 0);
        #endregion
        if (vida<=0)
        {
        
        }
         

    }

}// Fin del Cuerpo de la Clase
