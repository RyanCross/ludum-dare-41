﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int baseScore = 10;
    public AudioClip deathClip;

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
    int attackDamage = 1;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.transform;
        nav = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        capsuleCollider = GetComponent<CapsuleCollider>();

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

        enemyAudio.Play();

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Death(fromPlayer);
        }
    }

    public void Death(bool fromPlayer)
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play();
        //ScoreManager.score += scoreValue;

        StartSinking();
    }

    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        Destroy(gameObject, 2f);
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
        //player.TakeDamage(attackDamage);
    }

    void MakeSlow()
    {
        nav.speed = slowVal;
    }
}