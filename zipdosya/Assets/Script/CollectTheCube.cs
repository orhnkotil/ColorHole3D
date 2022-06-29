 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTheCube : MonoBehaviour
{

    [HideInInspector]
    public int numberOfDestroy;
    [HideInInspector]
    public bool enemy;
    // Start is called before the first frame update
    void Start()
    {       
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("GetCube"))
        {
            numberOfDestroy+=1;
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("EnemyCube"))
        {
            Destroy(other.gameObject);
            enemy=true;
        }
        
    }


}
