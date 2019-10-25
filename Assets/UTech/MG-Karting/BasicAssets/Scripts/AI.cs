using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent agent;    //宣告NavMeshAgent
    public GameObject target_obj;    //目標物件

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //接收NavMeshAgent
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target_obj.transform.position); //讓方塊往目標物的座標移動
    }
}
