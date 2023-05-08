using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector3 : MonoBehaviour
{
    public  int banana3 = 0;
    [SerializeField] private Text bananaText;

    [SerializeField] private AudioSource collectionSoundEffect;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);
            collectionSoundEffect.Play();
            banana3++;
            bananaText.text = "Testostrone lvl : " + banana3;
        }
    }
}
