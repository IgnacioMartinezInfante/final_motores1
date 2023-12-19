using UnityEngine;
using UnityEngine.UI;

public class contadorbalas : MonoBehaviour
{
    public Text balastexto; // Referencia al objeto de texto que mostrar� la cantidad de monedas.
    public int contarbalas = 0; // Inicializamos el contador de monedas a 0.

    // M�todo para aumentar la cantidad de monedas.

    private void Start()
    {
        Updatebalastexto();
    }
    public void Increasecontarbalas()
    {
        contarbalas = contarbalas + 5;
        Updatebalastexto(); // Actualizamos el texto en pantalla.
    }

    public void Decreasecontarbalas()
    {
        contarbalas--;
        Updatebalastexto(); // Actualizamos el texto en pantalla.
    }

    // M�todo para actualizar el texto en pantalla con la cantidad actual de monedas.
    private void Updatebalastexto()
    {
        balastexto.text = "Balas: " + contarbalas.ToString();
    }
}