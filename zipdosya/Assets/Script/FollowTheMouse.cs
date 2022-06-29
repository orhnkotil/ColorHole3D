using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTheMouse : MonoBehaviour
{
    private NavMeshAgent blackHole;
    // int layerMask = 1 << 8;
    private Ray rayPoint;
  

    // Start is called before the first frame update
    void Start()
    {
        blackHole=GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        denemeMetot();
    }


    private void denemeMetot()
    {
        rayPoint=Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit raycast;

        if(Physics.Raycast(rayPoint,out raycast,100,64))
        {
            transform.position=raycast.point;
            // blackHole.SetDestination(raycast.point);
            // Debug.Log(raycast.point);      
        }
    }

    

}
