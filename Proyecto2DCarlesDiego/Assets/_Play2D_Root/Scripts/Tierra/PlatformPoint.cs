using UnityEngine;

public class PlatformPoint : MonoBehaviour
{
    private bool pointAdded = false; // Para que cada plataforma sume solo 1 punto

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!pointAdded && collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.AddPoint(1);
            pointAdded = true;
        }
    }
}
