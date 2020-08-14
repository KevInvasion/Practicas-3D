//Nombre del Desarrollador: Kevin Lozano Sedeño
//Asignatura: Estructura de Datos
//Descripcion del uso de este codigo:
/*
Este script se utilizara para generar disparo del arma

*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisparoPlayer : MonoBehaviour
{
    //Son las variables a utilizar en el script
    [SerializeField] Rigidbody[] proyectil;
    [SerializeField] int tipoMunicion = 0;
    [SerializeField] Transform mano;
    [SerializeField] float fuerzadisparo;
    [SerializeField] KeyCode tecladisparo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    tipoMunicion++;
        //}

        //if (tipoMunicion == proyectil.Length)
        //{
        //    tipoMunicion = 0;
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    tipoMunicion--;
        //}

        //if (tipoMunicion <= 0)
        //{
        //    tipoMunicion = proyectil.Length-1;
        //}

        //Se declaro una variable para elegir la tecla en el inspector, asi como definir el tipo de proyectil que se va a disparar
        //Tambien se agrego una variable fuerza, esta se puede cambiar en el inspector al gusto del programador

        if (Input.GetKeyDown(tecladisparo))
        {
            var proyectilPos = Instantiate(proyectil[tipoMunicion]) as Rigidbody;

            proyectilPos.transform.position = mano.position;

            proyectilPos.AddForce(mano.forward * fuerzadisparo);
        }
    }
}
