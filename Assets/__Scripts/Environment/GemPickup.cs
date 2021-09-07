using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickup : MonoBehaviour
{
    [SerializeField] private AudioClip gemPickUpFX;
    [SerializeField] private int scoreToAdd = 500;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if collision happened
        if (collision.GetType().Equals(typeof(CapsuleCollider2D)))
        {
            //check if collision happpend
            FindObjectOfType<GameSession>().AddScore(scoreToAdd);
            //audio source
            AudioSource.PlayClipAtPoint(gemPickUpFX, Camera.main.transform.position);
            Destroy(this.gameObject);
        }
        else
        {
            //intro level
            AudioSource.PlayClipAtPoint(gemPickUpFX, Camera.main.transform.position);
            Destroy(this.gameObject);
        }
    }


}
