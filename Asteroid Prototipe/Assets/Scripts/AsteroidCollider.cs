using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollider : MonoBehaviour
{
    public GameObject effect;
    public int lifeAsteroid = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        lifeAsteroid -= 1;
        if (lifeAsteroid != 0) return;
        if(other.CompareTag("Player")) other.GetComponent<ShipController>().LoseLife();
        if (other.CompareTag("Bullet")) ScoreController.Instance.AddScore();
        var damage = Instantiate(effect, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
