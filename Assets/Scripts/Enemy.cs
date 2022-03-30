using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
            return;

        Bird bird = collision.collider.GetComponent<Bird>();
        if (bird != null)
        {
            Destroy(gameObject);
            return;
        }


        if (collision.GetContact(0).normal.y <= -0.5f)
        {
            Destroy(gameObject);
            return;
        }
    }
}
