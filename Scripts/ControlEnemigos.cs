using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigos : MonoBehaviour
{


    

    public GameObject ObjetoEnemigo;
    public GameObject enemigo;

    public Transform[] SpawnPoint;
    public static int contarCantidadEnemigos;
    

    //public int InfoCantidadEnemigos;
    // Start is called before the first frame update
    void Start()
    {
        
        SpawnPoint = new Transform[transform.childCount];
        for (int i = 0; i < SpawnPoint.Length; i++)
        {
            SpawnPoint[i] = transform.GetChild(i);
        }

        foreach (var p in SpawnPoint)
        {
            
            for (int i = 0; i < 10; i++)
            {
                
                GameObject posEnemigo = Instantiate(enemigo, p.position, p.rotation) as GameObject;
                Vector3 posplusEnemigo = new Vector3(0, 0, i*5);

                posEnemigo.transform.position += posplusEnemigo;
            }
            
        }

        contarCantidadEnemigos = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
