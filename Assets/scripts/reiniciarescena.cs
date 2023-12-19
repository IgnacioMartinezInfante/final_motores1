using UnityEngine;
using UnityEngine.SceneManagement;

public class reiniciarescena : MonoBehaviour
{
    public void Reiniciar()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
