using UnityEngine;
using System.Collections;

public class PlataformaDesaparece : MonoBehaviour
{
    [Header("Temporizador por jugador encima")]
    public float timeToDisappear = 2f;   // Tiempo que el jugador debe estar encima para desaparecer

    [Header("Temporizador después de que se vaya el jugador")]
    public float disappearAfterExit = 5f; // Tiempo después de que el jugador se vaya

    [Header("Temblor antes de desaparecer")]
    public float shakeDuration = 0.3f;
    public float shakeAmount = 0.05f;

    private float playerTimer = 0f;      // Cuenta tiempo mientras el jugador está encima
    private float exitTimer = 0f;        // Cuenta tiempo después de que el jugador se va
    private bool playerOnPlatform = false;
    private bool exitTimerActive = false;
    private bool hasDisappeared = false;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (hasDisappeared) return;

        // Temporizador mientras el jugador está encima
        if (playerOnPlatform)
        {
            playerTimer += Time.deltaTime;
            if (playerTimer >= timeToDisappear)
            {
                StartCoroutine(ShakeAndDisappear());
                hasDisappeared = true;
                return;
            }
        }

        // Temporizador después de que el jugador se haya ido
        if (exitTimerActive)
        {
            exitTimer += Time.deltaTime;
            if (exitTimer >= disappearAfterExit)
            {
                StartCoroutine(ShakeAndDisappear());
                hasDisappeared = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
            exitTimerActive = false; // Si el jugador vuelve, se pausa el temporizador de salida
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = false;
            if (!hasDisappeared)
            {
                exitTimerActive = true; // Activamos el temporizador de desaparición después de salir
                exitTimer = 0f;          // Reiniciamos el contador de salida
            }
        }
    }

    IEnumerator ShakeAndDisappear()
    {
        float elapsed = 0f;

        // Temblor
        while (elapsed < shakeDuration)
        {
            transform.position = originalPosition + (Vector3)Random.insideUnitCircle * shakeAmount;
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;

        // Desaparece la plataforma
        gameObject.SetActive(false);
        // O Destroy(gameObject) si quieres eliminarla completamente
    }
}