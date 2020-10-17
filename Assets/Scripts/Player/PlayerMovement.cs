using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 0;

    [SerializeField]
    bool move = true;

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
        var horizontalAxis = Input.GetAxis("Horizontal");
        movement.x = horizontalAxis * Time.deltaTime * speed;

        if (horizontalAxis < 0) //Maintain current flip, if
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else if (horizontalAxis > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        //movement.y = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        if (move)
        {
            body.MovePosition(transform.position + movement);
        }
    }
}
