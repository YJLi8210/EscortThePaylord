using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float delay = 2.0f;
    float countdown;

    bool hasExploded = false;
    public GameObject explosopnEffect;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.transform.tag.Equals("Enemy") || other.gameObject.name.Equals("sherman(Clone)")) && !hasExploded)
        {
            //Debug.Log("Collision");
            Explode();
            hasExploded = true;

            Destroy(other.gameObject);

            gameObject.SetActive(false);
        }
    }

    void Explode()
    {
        Debug.Log("Explode");
        Instantiate(explosopnEffect, transform.position, transform.rotation);
    }
}
