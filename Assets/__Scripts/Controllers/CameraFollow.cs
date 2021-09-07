using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //camera follow player
    private Player player;
    private Vector2 nextPosition;
    
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        //repo the camera using the player position
        nextPosition = new Vector2(player.transform.position.x, player.transform.position.y);
        transform.position = new Vector3(nextPosition.x,
                                         nextPosition.y,
                                         transform.position.z);
    }
}
