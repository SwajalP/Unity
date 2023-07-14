using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoMovement : MonoBehaviour
{
    public float speed = 10f;
    public Vector2 maxVelocity = new Vector2(3, 5);
    private Rigidbody2D rb;
    public bool standing;
    public float jetSpeed = 15f;
    public float airSpeedMultiplier = .3f;
    private DinoController controller;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D> ();
        controller = GetComponent<DinoController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var forceX = 0f;
        var forceY = 0f;

        var absVelX = Mathf.Abs(rb.velocity.x);
        var absVelY = Mathf.Abs(rb.velocity.y);

        if(absVelY < .2f)
        {
            standing = true;
        }
        else
        {
            standing = false;
        }
        if(controller.dinoMoving.x != 0)
        {
            if(absVelX < maxVelocity.x)
            {
                forceX = standing ? (speed/2) * controller.dinoMoving.x : ((speed/ 2) * controller.dinoMoving.x * airSpeedMultiplier);
                transform.localScale = new Vector3(forceX > 0 ? 1 : -1, 1, 1);
            }

            animator.SetInteger("AnimState", 1);
        }
        else
        {
            animator.SetInteger("AnimState", 0);
        }
        if (controller.dinoMoving.y != 0)
        {
            if (absVelY < maxVelocity.y)
            {
                forceY = jetSpeed * controller.dinoMoving.y;

            }
            animator.SetInteger("AnimState", 2);
        }else if(absVelY > 0){
            animator.SetInteger("AnimState", 3);
        }

        if (Input.GetKey("up"))
        {
            if(absVelY< maxVelocity.y)
            {
                forceY = jetSpeed/1.5f;
            }
        }
        rb.AddForce(new Vector2(forceX, forceY));
    }
}
