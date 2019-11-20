using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BombMovement : MonoBehaviour
{
    private GameObject target;
    public GameObject expEffect;
    private void Start()
    {
        //target = null;
    }
    // Update is called once per frame
    void Update()
    {
        HandleTranslation();
        HandleRotation();

    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    void HandleTranslation()
    {
        if(target == null)
        {
            return;
        }
        Vector3 x = target.transform.position - transform.position;
        x = x * 0.03f;
        transform.position += x;
    }

    void HandleRotation()
    {
        if (target == null)
        {
            return;
        }
        this.transform.LookAt(target.transform.position - new Vector3(0f,160f,0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("PoliceCar(Clone)"))
        {
            Destroy(other.gameObject);
            Explode();
            Destroy(gameObject);
        }
    }


    void Explode()
    {
        if(expEffect == null)
        {
            return;
        }
        Instantiate(expEffect, transform.position, transform.rotation);
    }
}
