using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZoneFollower : MonoBehaviour
{
    public Transform cameraTransform; // La cámara que seguimos
    public float yOffset = -5f;       // Distancia debajo de la cámara

    private void Update()
    {
        // Posicionar KillZone debajo de la cámara
        if (cameraTransform != null)
        {
            Vector3 newPos = transform.position;
            newPos.x = cameraTransform.position.x;   // Sigue horizontalmente si quieres
            newPos.y = cameraTransform.position.y + yOffset; // Siempre debajo
            transform.position = newPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Aquí puedes reiniciar la escena o llamar a tu función de muerte
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
