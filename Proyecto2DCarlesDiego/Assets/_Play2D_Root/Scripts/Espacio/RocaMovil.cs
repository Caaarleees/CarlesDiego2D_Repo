using UnityEngine;

public class RocaMovil : MonoBehaviour
{
    public Transform pointA;   // Punto inicial
    public Transform pointB;   // Punto final
    public float speed = 2f;   // Velocidad de movimiento

    private Vector3 target;

    void Start()
    {
        target = pointB.position; // Comenzamos yendo hacia B
    }

    void Update()
    {
        // Mover la plataforma hacia el target
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Cambiar de dirección al llegar al target
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            target = target == pointB.position ? pointA.position : pointB.position;
        }
    }

    // Opcional: hacer que el jugador viaje con la plataforma
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.transform.parent = transform;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.transform.parent = null;
    }
}