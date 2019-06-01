using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    // The layer on which you can click, in this case it's the floor
    public LayerMask ClickableLayer;

    // The player nav mesh agent
    private NavMeshAgent myAgent;



    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
        if (myAgent == null)
        {
            Debug.LogError(" There's no agent in the player, added one, please have a look for the dimension");
            gameObject.AddComponent<NavMeshAgent>();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        ///For Input Always make sure you're doing in Update(), to not miss out on any input in any of the frames.
        if (Input.GetMouseButtonDown(0))
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit HitInfo;

            if (Physics.Raycast(camRay, out HitInfo, 100f, ClickableLayer))
            {
                myAgent.SetDestination(HitInfo.point);
            }
        }
    }
}
