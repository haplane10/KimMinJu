﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChracterController : MonoBehaviour
{
    Animator animator;
    [SerializeField] Slider speedSlider;
    [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] float jumpPower;
    [SerializeField] float speed;
    [SerializeField] GameObject fireballPrefab;
    [SerializeField] Transform fireballSpawner;

    bool isGround = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetTrigger("attack");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("fireball");
       //     Invoke("SpawnFireball", 0.4f);
        }

        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            //rigidbody.velocity
            rigidbody.AddForce(Vector2.up * jumpPower);
        }
        rigidbody.AddRelativeForce(Physics2D.gravity / 1.5f);
    }

    public void SpawnFireball()
    {
        var fireball = GameObject.Instantiate(fireballPrefab, fireballSpawner);
        fireball.transform.SetParent(null);
        Destroy(fireball, 5f);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetInteger("animIdx", 2);
            rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
            return;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetInteger("animIdx", 2);
            rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
            return;
        }

        animator.SetInteger("animIdx", 0);
    }

    public void OnWalkButtonClick(int idx)
    {
        animator.SetInteger("animIdx", idx);
    }

    public void OnAttackButtonClick()
    {
        animator.SetTrigger("attack");
    }

    public void OnChangeSpeed()
    {
        animator.speed = speedSlider.value;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isGround && collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entering " + collision.gameObject.name);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Staying " + collision.gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exiting " + collision.gameObject.name);
    }
}
