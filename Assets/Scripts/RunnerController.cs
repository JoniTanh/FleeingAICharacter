using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunnerController : MonoBehaviour
{
    private NavMeshAgent _agent;

    public GameObject Player;

    public float EnemyDistanceRun = 5.0f;
    public float AlertSituationRun = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        if (distance < AlertSituationRun)
        {
            _agent.SetDestination(RandomNavmeshLocation());
        }

        else if (distance < EnemyDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;

            Vector3 newPos = transform.position + dirToPlayer;

            _agent.SetDestination(newPos);
        }

    }

    public Vector3 RandomNavmeshLocation()
    {
        float xPoint = Random.Range(-25, 25);
        float zPoint = Random.Range(-25, 25);
        Vector3 targetPos = new Vector3(xPoint, 0, zPoint);
        
        return targetPos;
    }

}
