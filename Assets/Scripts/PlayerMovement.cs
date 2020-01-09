using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator anim;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        
        if (!DialogueManager.isInteracting)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        
            if (movement.sqrMagnitude != 0)
            {
                anim.SetFloat("Horizontal", movement.x);
                anim.SetFloat("Vertical", movement.y);
            }
            anim.SetFloat("Speed", movement.sqrMagnitude);
        }
        else
        {
            anim.SetFloat("Speed", 0);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            anim.SetTrigger("Attack");
        }
    }

    void FixedUpdate()
    {
        if (DialogueManager.isInteracting) { return; }

        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
