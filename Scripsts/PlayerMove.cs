using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerMove : MonoBehaviour
{
    bool playerDie = false;
    bool spesialStatu = false;
    [SerializeField] GameObject finishGamePanel;
    [SerializeField] GameObject restartGamePanel;
    GameObject finishObj;
    [SerializeField] AudioSource gunSound;
    [SerializeField] ParticleSystem bullets;
    [SerializeField] GameObject body;
    Rigidbody playerRigidbody;
    Animator playerAnimation;
    [SerializeField] Joystick joyStick;
    [SerializeField] float rotationSpeed = 0;

    float playerPozitionX;
    float playerPozitionZ;

    static public bool enemyTrigger = false;
    float move = 0;
    float moveSpeed = 3f;

    bool finish = false;
    void Start()
    {
        finishObj = GameObject.Find("FinishObject");
        playerAnimation = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        InputAndMove();
        PlayerRotate();
        AnimationControl();
        FinishPosition();
        EnemyTriggerControl();
    }

    //Character - enemy trigger control
    private void EnemyTriggerControl()
    {
        if (enemyTrigger == false)
        {
            bullets.Stop();
            gunSound.Stop();
        }
    }

    //Character Move Finish Position
    private void FinishPosition()
    {
        if (finish)
        {
            transform.position = Vector3.Lerp(transform.position, finishObj.transform.position, 0.05f);
        }
    }

    //Character Rotate
    private void PlayerRotate()
    {
        playerRigidbody.angularVelocity = Vector3.zero;
        if ((joyStick.Horizontal != 0 || joyStick.Vertical != 0) && !enemyTrigger && !playerDie)
        {
            transform.rotation = Quaternion.LookRotation(playerRigidbody.velocity);
        }
        else
        {

        }
    }

    //Animation
    private void AnimationControl()
    {
        if ((joyStick.Horizontal > 0.1f || joyStick.Horizontal < -0.1f) || (joyStick.Vertical > 0.1 || joyStick.Vertical < -0.1f))
        {
            playerAnimation.SetBool("walk", true);
        }

        else
        {
            playerAnimation.SetBool("walk", false);
        }

        if (finish)
        {
            playerAnimation.SetBool("finish", true);
        }
        else
        {
            playerAnimation.SetBool("finish", false);
        }

        if (playerDie)
        {
            playerAnimation.SetBool("die", true);
        }
        else
        {
            playerAnimation.SetBool("die", false);
        }
    }

    //Character Move
    private void InputAndMove()
    {
        playerPozitionX = transform.position.x;
        playerPozitionZ = transform.position.z;
        if (!spesialStatu)
        {
            if ((joyStick.Horizontal == 0 && joyStick.Vertical == 0) || finish || playerDie)
            {
                playerRigidbody.velocity = Vector3.zero;
                transform.position = new Vector3(playerPozitionX, 0f, playerPozitionZ);
            }
            else
            {
                float xValue = joyStick.Horizontal * moveSpeed;
                float zValue = joyStick.Vertical * moveSpeed;
                playerRigidbody.velocity = new Vector3(xValue, 0f, zValue);
            }
        }
    }

    //Character Die
    void Die()
    {
        bullets.Stop();
        gameObject.transform.GetChild(4).gameObject.SetActive(false);
        playerDie = true;
        restartGamePanel.SetActive(true);
    }


    private void Finish()
    {
        finishGamePanel.SetActive(true);
        finish = true;
        spesialStatu = true;
        new WaitForSecondsRealtime(1f);
        spesialStatu = false;
    }

    //Next Level Button
    public void NextLevel()
    {
        spesialStatu = true;
        new WaitForSecondsRealtime(1f);
        transform.position = new Vector3(0, 0, -16);
        new WaitForSecondsRealtime(1f);
        spesialStatu = false;
        finish = false;
    }

    //Character and map reset
    public void RestartGamePlayer()
    {
        enemyTrigger = false;
        transform.position = new Vector3(0, 0, -16);
        playerDie = false;
        gameObject.transform.GetChild(4).gameObject.SetActive(true);
    }

    //Enemy triggered
    private void EnemyTrigger()
    {
        if (enemyTrigger == false || !bullets.isPlaying)
        {
            enemyTrigger = true;
            bullets.Play();
            if (!gunSound.isPlaying)
            {
                gunSound.Play();
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Finish();
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Die();
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            transform.LookAt(other.gameObject.transform, Vector3.up);
            EnemyTrigger();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyTrigger = false;
        }
    }
    
}
