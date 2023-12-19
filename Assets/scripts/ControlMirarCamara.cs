using UnityEngine;
using UnityEngine.AI;

public class ControlMirarCamara : MonoBehaviour
{
    Vector2 mouseMirar;
    Vector2 suavidadV;
    public float sensibilidad = 5.0f;
    public float suavizado = 2.0f;
    private vidajugador jugadorScript; // Nueva referencia al script vidajugador

    void Start()
    {
        // Obtén la referencia al script vidajugador
        jugadorScript = GetComponentInParent<vidajugador>();
    }

    void Update()
    {
       

        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensibilidad * suavizado, sensibilidad * suavizado));

        suavidadV.x = Mathf.Lerp(suavidadV.x, md.x, 1f / suavizado);
        suavidadV.y = Mathf.Lerp(suavidadV.y, md.y, 1f / suavizado);

        mouseMirar += suavidadV;
        mouseMirar.y = Mathf.Clamp(mouseMirar.y, -90f, 90f);
        transform.localRotation = Quaternion.AngleAxis(-mouseMirar.y, Vector3.right);

        // Utiliza el script vidajugador para obtener la rotación del jugador
        if (jugadorScript != null)
        {
            jugadorScript.RotarJugador(mouseMirar.x);
        }
    }
}