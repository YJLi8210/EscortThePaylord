using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform Object;
    public float speed = 0.1f;
    private Vector3 DirectionOfObject;
    private bool bIsChanllenged = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bIsChanllenged)
        {
            DirectionOfObject = Object.transform.position - transform.position;
            DirectionOfObject = DirectionOfObject.normalized;
            transform.Translate(DirectionOfObject*speed, Space.World);
        }
    }

    void OnTriggered(Collider Other)
    {
        if ( Other.CompareTag("Kart") )
        {
            bIsChanllenged = true;
        }
    }
}
