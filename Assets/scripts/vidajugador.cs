using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidajugador : MonoBehaviour
{
    public int vidaInicial = 100;
    public int vidaActual;
    public GameObject pantalladerrota;
    public Text vidatexto;
    public int vidaMaxima = 100;

    public Camera camaraJugador;
    public Camera camaraderrota;
    public Camera camaravictoria;

    private void Start()
    {
        camaraderrota.gameObject.SetActive(false); 
        vidaActual = vidaInicial;
        pantalladerrota.SetActive(false);
        vidatextofuncion();
    }

    public void reducirvidachoqueconbot()
    {
        ReducirVida(20);
    }

    public void reducirvidarangobot()
    {
        ReducirVida(5);
    }

    public void aumentarvidabotiquin()
    {
        aumentarVida(25);
    }

    public void ReducirVida(int cantidad)
    {
        vidaActual -= cantidad;
        vidatextofuncion();
        if (vidaActual <= 0)
        {
            pantalladerrota.SetActive(true);
            Time.timeScale = 0f;

            // Desactiva la cámara del jugador y activa la cámara de respaldo
            if (camaraJugador != null)
            {
                camaraJugador.gameObject.SetActive(false);
            }

            if (camaraderrota != null)
            {
                camaraderrota.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }

            Destroy(gameObject);
        }
    }

    public void aumentarVida(int cantidad)
    {
        {
            

            // Calcula cuánta vida le falta para alcanzar el máximo
            int vidaRestante = vidaMaxima - vidaActual;

            // Verifica si la cantidad a agregar es menor o igual a la vida restante
            if (cantidad <= vidaRestante)
            {
                vidaActual += cantidad;
            }
            else
            {
                // Si la cantidad es mayor que la vida restante, solo suma la vida restante
                vidaActual = vidaMaxima;
            }

            vidatextofuncion();
        }
    }

    private void vidatextofuncion()
    {
        int vidaMinima = 0;
        if (vidaActual <= vidaMinima)
        {
            vidatexto.text = "Vida: " + vidaMinima.ToString();
        }
        else
        {
            vidatexto.text = "Vida: " + vidaActual.ToString();
        }
    }

    public void RotarJugador(float rotation)
    {
        transform.localRotation = Quaternion.Euler(0f, rotation, 0f);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        vidaActual = vidaInicial;
        pantalladerrota.SetActive(false);

        // Reactiva la cámara del jugador y desactiva la cámara de respaldo al reiniciar el juego
        if (camaraJugador != null)
        {
            camaraJugador.gameObject.SetActive(true);
        }

        if (camaraderrota != null)
        {
            camaraderrota.gameObject.SetActive(false);
        }
    }
}