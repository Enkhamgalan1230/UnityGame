using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public static int bananas;
    [SerializeField] private Text bananaText;

    [SerializeField] private AudioSource collectionSoundEffect;

    void Start()
    {
        bananas = 0;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);
            collectionSoundEffect.Play();
            bananas++;
            bananaText.text = "Testostrone lvl : " + bananas;
        }
    }

}
