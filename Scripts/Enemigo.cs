//Nombre del Desarrollador: Kevin Lozano Sedeño
//Asignatura: Estructura de Datos
//Descripcion del uso de este codigo:
/*
Este script se utilizara para generar el control del enemigo, asi como su movimiento hacia el jugador

*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Transform target;
    public Transform ojitos;
    public float velocidadEnemigo;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //e declara que el enemigo debera caminar hacia el player
        //ojitos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ojitos.LookAt(this.target.position);


        //float enemigoPosicion = transform.position.z;
        
        Vector3 posicionTotaldeljugador = target.position;
        Vector3 posicionTotaldelenemigo = this.transform.position;

        float distanciaEntreobjetos = Vector3.Distance(posicionTotaldeljugador, posicionTotaldelenemigo);

        Debug.DrawLine(posicionTotaldelenemigo,posicionTotaldeljugador,Color.green); // Se dibujara una linea entre el jugadir y el enemigo color verde.

        if (distanciaEntreobjetos > 3)
        {
            posicionTotaldelenemigo = Vector3.MoveTowards(this.transform.position, target.position, velocidadEnemigo * Time.deltaTime);
        }
        if (distanciaEntreobjetos <= 3)
        {
            Destroy(this.gameObject, 2f);
            posicionTotaldeljugador = posicionTotaldeljugador - new Vector3(0, 0, 5);
            //posicionTotaldeljugador = posicionTotaldeljugador - new Vector3(posicionTotaldeljugador.x, posicionTotaldeljugador.y);
            //transform.position = Vector3.MoveTowards(this.transform.position, target.position, 10 * Time.deltaTime);
        }

    }
}
