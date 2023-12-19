using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botiquinvida : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("tocó al jugador");
        if (collision.gameObject.CompareTag("jugador"))
        {
            vidajugador vidaActual = FindObjectOfType<vidajugador>();
            if (vidaActual != null && vidaActual.vidaActual < 100)
            {
                vidaActual.aumentarvidabotiquin(); // Aumenta el contador de monedas.
                Destroy(gameObject); // Destruye la moneda.
            }
        }
    }
}
