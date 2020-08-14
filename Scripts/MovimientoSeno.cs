using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoSeno : MonoBehaviour
{
            //Array    ID
    public string[] nombreJugadores;

    public float velocidad;
    public float extension;

    [SerializeField]
    Transform[] sierra;

    [SerializeField]
    Vector3[] posicionInicial;

        //posiciona o modifica un objeto escala o posicion



    // Start is called before the first frame update
    void Start()
    {
        nombreJugadores = new string[6] { "El Benny", "El Brian", "El Chucho", "El Emi", "El Hani", "Pancho" };

        posicionInicial = new Vector3[sierra.Length];
        //posicionInicial[0] = sierra[0].position;
        //posicionInicial[1] = sierra[1].position;
        //posicionInicial[2] = sierra[2].position;
        for (int i = 0; i < sierra.Length; i++)
        {
            posicionInicial[i]= sierra[i].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 senoPos = new Vector3(Mathf.Sin(Time.time * velocidad) * extension, 0, 0);
        for (int i = 0; i < sierra.Length; i++)
        {
            sierra[i].position = posicionInicial[i] + senoPos;

            sierra[i].Rotate(Vector3.forward * 90);
        }
    }
}
