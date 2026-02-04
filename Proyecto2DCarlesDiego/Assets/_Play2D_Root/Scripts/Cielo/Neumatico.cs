using UnityEngine;

public class Neumatico : MonoBehaviour
{
    public float fuerzaSalto = 15f; // Ajusta seg�n quieras que salte m�s
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Aumentamos el salto vertical
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
               
            }
        }
    }
}