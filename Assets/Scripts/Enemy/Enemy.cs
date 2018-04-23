using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int baseScore = 5;
    public int towerScore = 4;
    public AudioClip deathClip;
    public AudioClip ouchClip;

    //Help scene move on
    public static int zombieEstimate = -1;
    public int killGoal;
    
    //Health Vars
    Animator anim;
    AudioSource enemyAudio;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    //Movement Vars
    GameObject player;
    Transform playerPosition;
    NavMeshAgent nav;
    float slowVal = 1.0f;

    //Attack Vars
    bool playerInRange;
    float timer;
    public float timeBetweenAttacks = 0.5f;
    int attackDamage = 25;

    private void Awake()
    {
        if(zombieEstimate==-1)
        {
            zombieEstimate = killGoal;
        }
        player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.transform;
        nav = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        nav.speed = nav.speed + Random.Range(1.0f, 1.5f);
        anim.Play("walk", -1, Random.Range(0f, .4f));

        currentHealth = startingHealth;
    }

    private void Update()
    {
        if (isSinking)
        {
            nav.enabled = false;
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
            return;
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= timeBetweenAttacks && playerInRange)
            {
                Attack();
            }
            nav.SetDestination(playerPosition.position);
        }
    }

    public void TakeDamage(int amount, bool fromPlayer)
    {
        if (isDead)
            return;
        enemyAudio.clip = ouchClip;
        enemyAudio.Play();

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Death(fromPlayer);
        }
    }

    public void Death(bool fromPlayer)
    {
        zombieEstimate--;
        //Interlocked.Decrement(ref numZombies);

        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger("Dead");
        if(Random.Range(0f, 1f) <= .05f)
        {
            enemyAudio.clip = deathClip;
            enemyAudio.Play();
        }
        PlayerInventory.Instance.Cash += fromPlayer ? baseScore : towerScore;

        StartSinking();
    }

    public void StartSinking()
    {
        anim.Play("fallingback", -1, 0f);
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        Destroy(gameObject, .5f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void Attack()
    {
        timer = 0f;
        enemyAudio.Play();
        anim.Play("attack", -1,0f);
		if(HealthBarUI.health > 0){
			player.SendMessage("TakeDamage",attackDamage);//TakeDamage (attackDamage);
		}
    }

    void MakeSlow()
    {
        nav.speed = slowVal;
    }

    public static void SetNumZombies(int x)
    {
        zombieEstimate = x;
    }
}