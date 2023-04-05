using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float hp;
    public float maxHp = 100; //Essa Linha
    public float moveX;
    public float moveY;
    public float moveSpeed;
    bool isMoving;
    public Animator anim;
    public Rigidbody2D rig2D;
    public Image heart; //Essa Linha
    public int enemiesDefeat = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        hp = maxHp; //Essa Linha
    }
    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        
        if(hp <= 0)
        {
            SceneManager.LoadScene("SceneGameOver");
        }
        else if(enemiesDefeat >= 3)
        {
            SceneManager.LoadScene("SceneGameWin");
        }
        
        Movement();
        Animation();
        Attack();
        UpdateUI();
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

    void UpdateUI()
    {
        heart.fillAmount = hp / maxHp;
    }
}
