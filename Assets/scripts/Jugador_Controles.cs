using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Jugador_Controles : MonoBehaviour
{
    public float rapidezDesplazamiento = 10.0f;
    public Camera camaraprimerapersona;
    public GameObject bala;
    [SerializeField] private float distanciaDesdeCamara;
    public Transform puntaArma;

    public contadorbalas contadorBalas;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MoverJugador();
        CheckInput();
    }

    void MoverJugador()
    {
        float movimientoAdelanteAtras = Input.GetAxis("Vertical") * rapidezDesplazamiento;
        float movimientoCostados = Input.GetAxis("Horizontal") * rapidezDesplazamiento;

        movimientoAdelanteAtras *= Time.deltaTime;
        movimientoCostados *= Time.deltaTime;

        transform.Translate(movimientoCostados, 0, movimientoAdelanteAtras);
    }

    void CheckInput()
    {
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetMouseButtonDown(0))
        {
            DispararRayo();
        }
    }
    void DispararRayo()
    {
        // Verifica si tienes balas antes de disparar.
    if (contadorBalas != null && contadorBalas.contarbalas > 0)
    {
        Vector3 puntoDeDisparo = puntaArma.position;

        Ray ray = new Ray(puntoDeDisparo, camaraprimerapersona.transform.forward);
        RaycastHit hit;

        GameObject pro;
        pro = Instantiate(bala, puntoDeDisparo, bala.transform.rotation); // Utiliza Quaternion.identity para una rotación neutral
        Rigidbody rb = pro.GetComponent<Rigidbody>();
        rb.AddForce(camaraprimerapersona.transform.forward * 100, ForceMode.Impulse);
        Destroy(pro, 1);

        if (Physics.Raycast(ray, out hit) && hit.distance < 5)
        {
            Debug.Log("El rayo tocó al objeto: " + hit.collider.name);
            if (hit.collider.name.Substring(0, 3) == "Bot")
            {
                GameObject objetoTocado = GameObject.Find(hit.transform.name);
                controlenemigo scriptObjetoTocado = objetoTocado.GetComponent<controlenemigo>();
                if (scriptObjetoTocado != null)
                {
                    scriptObjetoTocado.recibirDaño();
                }
            }
        }
            // Reduz la cantidad de balas.
            contadorBalas.Decreasecontarbalas();
        }
    }
}