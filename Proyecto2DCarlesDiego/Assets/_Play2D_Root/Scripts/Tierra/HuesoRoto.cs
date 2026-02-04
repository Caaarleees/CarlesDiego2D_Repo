using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HuesoRoto : MonoBehaviour
{
    public Sprite normalSprite;      // Sprite del hueso normal
    public Sprite brokenSprite;      // Sprite del hueso roto

    public float destroyTime = 1f;   // Tiempo antes de desaparecer
    public float respawnTime = 3f;   // Tiempo para reaparecer

    private SpriteRenderer sr;
    private Collider2D col;
    private bool isBroken = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        ResetHueso();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        if (!isBroken)
        {
            isBroken = true;

            // Cambiar sprite a roto
            if (brokenSprite != null)
                sr.sprite = brokenSprite;

            Invoke(nameof(Disappear), destroyTime);
        }
    }

    void Disappear()
    {
        // Desaparece
        sr.enabled = false;
        col.enabled = false;

        // Programar reaparecer
        Invoke(nameof(Respawn), respawnTime);
    }

    void Respawn()
    {
        ResetHueso();
    }

    void ResetHueso()
    {
        isBroken = false;
        sr.sprite = normalSprite;
        sr.enabled = true;
        col.enabled = true;
    }
}
