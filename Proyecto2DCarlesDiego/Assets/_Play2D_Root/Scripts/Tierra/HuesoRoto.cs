using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class HuesoRoto : MonoBehaviour
{
    public Sprite normalSprite;      // Sprite del hueso normal
    public Sprite brokenSprite;      // Sprite del hueso roto
    public float destroyTime = 1f;   // Tiempo antes de desaparecer

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

            // Desaparece para siempre después de destroyTime
            Invoke(nameof(DisappearPermanently), destroyTime);
        }
    }

    void DisappearPermanently()
    {
        // Desactiva el sprite y el collider para "desaparecer"
        sr.enabled = false;
        col.enabled = false;

        // Destruir el objeto para que nunca vuelva
        Destroy(gameObject);
    }

    void ResetHueso()
    {
        isBroken = false;
        sr.sprite = normalSprite;
        sr.enabled = true;
        col.enabled = true;
    }
}