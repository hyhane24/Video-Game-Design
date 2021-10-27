using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof(Animator))]

public class MinionAI : MonoBehaviour
{
    public NavMeshAgent nma;
    public Animator ani;
    public GameObject[] waypoints;
    public int currWaypoint;

    public enum AIState{
        WalkStationary,
        WalkMoving
    };

    public AIState aiState;
    public VelocityReporter rep;
    public float d;

    // Start is called before the first frame update
    void Start()
    {
        aiState = AIState.WalkStationary;
        nma = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        currWaypoint = -1;
        setNextWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (nma.remainingDistance < 0.1 && nma.pathPending != true){
            setNextWaypoint();
        }
        ani.SetFloat("vely", nma.velocity.magnitude / nma.speed);
        
        switch (aiState) {
            
            case AIState.WalkStationary:
                if (currWaypoint == waypoints.Length){
                    aiState = AIState.WalkMoving;
                }
            break;
 
            case AIState.WalkMoving: 
            d = Vector3.Distance(waypoints[currWaypoint].transform.position, nma.transform.position);
            if (Vector3.Distance(((d/nma.speed) * rep.velocity) + waypoints[currWaypoint].transform.position, nma.transform.position) < 0.5){
                aiState = AIState.WalkStationary;
            }
            break;   

            default:
            break;
        }
    }

    private void setNextWaypoint() {
        if (waypoints.Length == 0) {
            Debug.LogError("Zero array length");
        }
        currWaypoint++;
        if (currWaypoint > waypoints.Length) {
            currWaypoint = 0;
        }
        nma.SetDestination(waypoints[currWaypoint].transform.position);
    }
}
