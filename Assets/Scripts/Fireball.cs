using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = (transform.localScale.x > 0 ? Vector2.right : Vector2.left) * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 enterPoint = collision.GetContact(0).point;
        Instantiate(explosionPrefab, enterPoint, Quaternion.identity);
        Destroy(gameObject);
    }
}
