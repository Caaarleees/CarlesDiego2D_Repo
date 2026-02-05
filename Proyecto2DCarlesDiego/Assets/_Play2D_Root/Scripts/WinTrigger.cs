using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    public float timeToWin = 2f;   // Tiempo necesario encima
    private float timer = 0f;
    private bool hasWon = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (hasWon) return;

        if (other.CompareTag("Player"))
        {
            timer += Time.deltaTime;

            if (timer >= timeToWin)
            {
                hasWon = true;
                SceneManager.LoadScene("Win");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            timer = 0f; // Si se baja antes, se reinicia el tiempo
        }
    }
}
