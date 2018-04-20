using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBorder : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if(ball != null)
        {       
            string wallName = transform.name;
            GameManager.Score(wallName);
            collision.gameObject.SendMessage("RestartGame", 1, SendMessageOptions.RequireReceiver);
        }
    }
}
