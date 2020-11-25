﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


// FSM States for the enemy
public enum EnemyState { CHASE, MOVING, DEFAULT};

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    public float chaseDistance = 20.0f;
    public float stoppingDistance = 5.0f;

    protected EnemyState state = EnemyState.DEFAULT;
    protected Vector3 destination = new Vector3(0, 0, 0);

    AudioSource myaudio;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = this.GetComponent<NavMeshAgent>();
        myaudio = GetComponent<AudioSource>();

    }

    private Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-50.0f, 50.0f), 0, Random.Range(-50.0f, 50.0f));
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case EnemyState.DEFAULT:
                destination = transform.position + RandomPosition();
                if (Vector3.Distance(transform.position, player.transform.position) < chaseDistance
                )
                {
                    state = EnemyState.CHASE;
                }
                else
                {
                    state = EnemyState.MOVING;
                    agent.SetDestination(destination);
                }
                break;
            case EnemyState.MOVING:
                Debug.Log("Dest = " + destination);
                if (Vector3.Distance(transform.position, destination) < 5)
                {
                    state = EnemyState.DEFAULT;
                }
                if (Vector3.Distance(transform.position, player.transform.position) < chaseDistance
                )
                {
                    state = EnemyState.CHASE;
                }
                break;

            case EnemyState.CHASE:
                if (Vector3.Distance(transform.position, player.transform.position) > chaseDistance
                )
                {
                    state = EnemyState.DEFAULT;
                    
                }
                agent.SetDestination(player.transform.position);
                break;
            default:
                break;
        }

    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.CompareTag("Bullet"))
        {
            // Disable all Renderers and Colliders
            Renderer[] allRenderers = gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer c in allRenderers) c.enabled = false;
            Collider[] allColliders = gameObject.GetComponentsInChildren<Collider>();
            foreach (Collider c in allColliders) c.enabled = false;
            StartCoroutine(PlayAndDestroy(myaudio.clip.length));
        }

    }
    private IEnumerator PlayAndDestroy(float waitTime)
    {
        myaudio.Play();
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }


}
