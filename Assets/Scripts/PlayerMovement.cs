using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 0;

    Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 movement = new Vector3();
        movement.x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        //movement.y = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        body.MovePosition(transform.position + movement);
    }
}
