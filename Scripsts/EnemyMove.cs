using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    Animator enemyAnimator;
    Rigidbody EnemyRb;
    Canvas healthCanvas;
    Slider enemyHealthSlider;
    float enemyHealt;
    GameObject mainCamera;

    BoxCollider enemyBoxCollider;

    bool followTarget = false;
    Transform target;
    NavMeshAgent nMA;

    GameObject wound;

    ParticleSystem[] particles;
    void Start()
    {
        enemyBoxCollider = GetComponentInChildren<BoxCollider>();
        EnemyRb = GetComponentInChildren<Rigidbody>();
        particles = GetComponentsInChildren<ParticleSystem>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        enemyHealthSlider = GetComponentInChildren<Slider>();
        mainCamera = GameObject.Find("Main Camera");
        healthCanvas = GetComponentInChildren<Canvas>();
        healthCanvas.enabled = false;
        enemyAnimator = GetComponent<Animator>();
        nMA = GetComponent<NavMeshAgent>();
        enemyHealt = enemyHealthSlider.value;
    }

    void Update()
    {
        FollowTarget();
        EnemyAnimatorControl();
        HealthBar();
    }

    //Enemy Healthbar Control
    private void HealthBar()
    {
        if (healthCanvas.enabled)
        {
            healthCanvas.transform.LookAt(mainCamera.transform.position);
        }
        enemyHealthSlider.value = enemyHealt;
    }

    //Enemy character chasing us
    private void FollowTarget()
    {
        EnemyRb.angularVelocity = Vector3.zero;
        EnemyRb.velocity = Vector3.zero;
        if (followTarget)
        {
            nMA.SetDestination(target.position);
        }
        else
        {
            EnemyRb.velocity = Vector3.zero;
        }
    }

    //Animator Control
    private void EnemyAnimatorControl()
    {
        if ((Vector3.Distance(this.transform.position, target.position) < 0.45f) && followTarget)
        {
            enemyAnimator.SetBool("walk", false);
        }
        else if ((Vector3.Distance(this.transform.position, target.position) > 0.45f) && followTarget)
        {
            enemyAnimator.SetBool("walk", true);
        }
    }

    //Enemy hit
    void Hit()
    {
        if (!healthCanvas.enabled) { healthCanvas.enabled = true; }
        particles[0].Play();
        enemyHealt -= 100f;
        if (enemyHealt <= 0f)
        {
            Destroy(gameObject.transform.GetChild(0).gameObject);
            Destroy(gameObject.transform.GetChild(1).gameObject);
            Destroy(gameObject.transform.GetChild(2).gameObject);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            enemyBoxCollider.enabled = false;
            followTarget = false;
            particles[1].Play();
            Invoke("Die", 0.5f);
        }
    }

    //Enemy Die
    private void Die()
    {
        PlayerMove.enemyTrigger = false;
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemyAnimator.SetBool("walk", true);
            followTarget = true;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Hit();
    }




}
