using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class controlenemigo : MonoBehaviour
{
    public controlenemigo enemigoPrefab;
    [SerializeField] public Transform Target;
    private Vector3 posicionInicial; // Nueva variable para almacenar la posici�n inicial
    public int hpinicial = 50;
    private int hpactual;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float findtargetrate;
    [SerializeField] private float initialdelay;
    public float distanciaActivacion = 50f; // Distancia para activar/desactivar el seguimiento
    public float distanciada�o = 15f;
    public AudioSource musica;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("jugador");
        if (player != null)
        {
            Target = player.transform;
        }
    }

    void Start()
    {
        hpactual = hpinicial;
        agent = GetComponent<NavMeshAgent>();
        posicionInicial = transform.position; // Almacena la posici�n inicial
        InvokeRepeating("findtarget", initialdelay, findtargetrate);
    }

    public void recibirDa�o()
    {
        hpactual -= 25;
        if (hpactual <= 0)
        {
            this.desaparecer();
        }
    }

    private void desaparecer()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bala"))
        {
            recibirDa�o();
        }
        if (collision.gameObject.CompareTag("jugador"))
        {
            vidajugador sacarvidaporchoque = GameObject.Find("jugador").GetComponent<vidajugador>();
            sacarvidaporchoque.reducirvidachoqueconbot();
        }
    }

    public void findtarget()
    {
        // Verifica la distancia entre el enemigo y el jugador
        float distanciaAlJugador = Vector3.Distance(transform.position, Target.position);

        if (distanciaAlJugador < distanciaActivacion)
        {
            // Activa el NavMeshAgent para seguir al jugador
            agent.destination = Target.position;

            // Verifica si la m�sica ya est� en reproducci�n
            if (!musica.isPlaying)
            {
                // Reproduce la m�sica solo si no est� en reproducci�n
                musica.Play();
            }
        }
        else
        {
            // Desactiva el NavMeshAgent si el jugador est� fuera de la distancia de activaci�n
            agent.destination = transform.position;

            // Vuelve a la posici�n inicial
            if (Vector3.Distance(transform.position, posicionInicial) > 0.1f)
            {
                agent.SetDestination(posicionInicial);
            }

            // Detiene la reproducci�n de la m�sica cuando el jugador est� fuera del rango
            musica.Stop();
        }

        if (distanciaAlJugador < distanciada�o)
        {
            vidajugador sacarvidaporaproximacion = GameObject.Find("jugador").GetComponent<vidajugador>();
            sacarvidaporaproximacion.reducirvidarangobot();
        }
    }
}
