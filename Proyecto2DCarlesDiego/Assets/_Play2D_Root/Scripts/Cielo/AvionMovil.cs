using UnityEngine;

public class AvionMovil : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Vector3 target;

    void Start()
    {
        target = pointB.position;
    }

    void Update()
    {
        // Mover hacia el target
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Flip horizontal según dirección
        if (target == pointB.position)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); // mirar derecha
        else
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); // mirar izquierda

        // Cambiar dirección al llegar al target
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            target = target == pointB.position ? pointA.position : pointB.position;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.transform.parent = transform; // el jugador “viaja” con la plataforma
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.transform.parent = null; // deja de viajar cuando se separa
    }
}