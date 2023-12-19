using UnityEngine;

public class destruirmunicion : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("tocó al jugador");
        if (collision.gameObject.CompareTag("jugador"))
        {
            contadorbalas contarbalas = FindObjectOfType<contadorbalas>();
            if (contarbalas != null)
            {
                contarbalas.Increasecontarbalas(); // Aumenta el contador de monedas.
            }

            Destroy(gameObject); // Destruye la moneda.
        }
    }
}
