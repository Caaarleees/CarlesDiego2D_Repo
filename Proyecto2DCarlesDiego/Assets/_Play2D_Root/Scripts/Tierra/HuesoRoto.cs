using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HuesoRoto : MonoBehaviour
{
    public Sprite brokenSprite;      // Sprite del hueso roto
    public float destroyTime = 1f;   // Tiempo en segundos antes de desaparecer

    private SpriteRenderer sr;
    private Collider2D col;
    private bool isBroken = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        if (!isBroken)
        {
            // Cambiar el sprite a roto
            if (brokenSprite != null)
                sr.sprite = brokenSprite;

            isBroken = true;

            // Iniciar la “desaparición” después de destroyTime segundos
            Invoke("Disappear", destroyTime);
        }
    }

    void Disappear()
    {
        // Desaparece visualmente
        if (sr != null) sr.enabled = false;

        // Desactivar collider para que ya no se pueda pisar
        if (col != null) col.enabled = false;

        // Opcional: destruir el objeto completamente
        // Destroy(gameObject);
    }
}
