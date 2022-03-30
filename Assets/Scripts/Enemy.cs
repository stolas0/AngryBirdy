using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject _cloudParticlesPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
            return;

        Bird bird = collision.collider.GetComponent<Bird>();
        if (bird != null)
        {
            Instantiate(_cloudParticlesPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }


        if (collision.GetContact(0).normal.y <= -0.5f)
        {
            Instantiate(_cloudParticlesPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
