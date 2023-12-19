using UnityEngine;
using UnityEngine.UI;

public class meta : MonoBehaviour
{
    public GameObject pantallavictoria;
    public Camera camaraJugador;
    public Camera camaravictoria;
    public GameObject jugador;

    private bool camaraCongelada = false;

    private void Start()
    {
        pantallavictoria.SetActive(false);
        camaravictoria.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (camaraCongelada)
        {
            // Congelar la rotación de la cámara
            camaravictoria.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("jugador"))
        {
            pantallavictoria.SetActive(true);
            Time.timeScale = 0f;

            if (camaraJugador != null)
            {
                camaraJugador.gameObject.SetActive(false);
            }

            if (camaravictoria != null)
            {
                camaravictoria.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                camaraCongelada = true; // Indica que la cámara está congelada
            }

            Destroy(jugador);
        }
    }
}
