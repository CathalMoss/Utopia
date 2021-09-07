using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    [SerializeField] private AudioClip coinPickUpFX;
    [SerializeField] private int pointsForCoin = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if collision has happened and add coins if correct
        if (collision.GetType().Equals(typeof(CapsuleCollider2D)))
        {
            // add to coin count
            FindObjectOfType<GameSession>().AddCoins(pointsForCoin);
            // audio source for coin
            AudioSource.PlayClipAtPoint(coinPickUpFX, Camera.main.transform.position);
            Destroy(this.gameObject);
        }
        else
        {
            // does not count towards coin total
            // made for intro level
            AudioSource.PlayClipAtPoint(coinPickUpFX, Camera.main.transform.position);
            Destroy(this.gameObject);
        }
    }
}
