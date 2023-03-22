using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveX;
    public float moveY;
    public float moveSpeed;
    bool isMoving;
    public Animator anim;
    public Rigidbody2D rig2D;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        Movement();
        Animation();
        Attack();
    }
    
    void Movement()
    {
        rig2D.MovePosition(transform.position + new Vector3(moveX, moveY, 0) * moveSpeed * Time.deltaTime);
    }

    void Animation()
    {
        if(moveX == 0 && moveY == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

        anim.SetBool("isMoving", isMoving);
        anim.SetFloat("Horizontal", moveX);
        anim.SetFloat("Vertical", moveY);
    }

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("isAttack");
        }
    }

}
