using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisparoRayo : MonoBehaviour
{
    public float distanciaRayo;
    public LayerMask capaDaño;
    public Image puntero;
    
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
        rayo.origin = Barril.position;
        rayo.direction = Barril.forward;
        rayoInteraccion = Camera.main.ScreenPointToRay(this.centroCamara);

        Debug.DrawRay(rayoInteraccion.origin, rayoInteraccion.direction * distanciaRayo, Color.green);

        if (Physics.Raycast(rayoInteraccion,out hitinfo, distanciaRayo, capaDaño))
        {
            if (hitinfo.collider != null)
            {
                if (hitinfo.collider.tag == "Enemy")
                {
                    puntero.color = Color.green;
                }
            }
        }
        else
        {
            puntero.color = Color.white;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(rayo,out hitinfo, distanciaRayo,capaDaño))
            {
                if (hitinfo.collider != null)
                {
                    if (hitinfo.collider.tag=="Enemy")
                    {
                        Destroy(hitinfo.collider.gameObject);
                    }
                }
            }
        } 
    }
}
