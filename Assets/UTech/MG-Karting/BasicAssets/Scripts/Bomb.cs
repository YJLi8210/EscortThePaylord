using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Bomb : MonoBehaviour
{
    private HashSet<GameObject> enemies;
    CapsuleCollider explosionRange;
    public GameObject bombPrefab;
    // Start is called before the first frame update
    void Start()
    {
        enemies = new HashSet<GameObject>();
        explosionRange = GetComponent<CapsuleCollider>();
        explosionRange.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Boom()
    {
        foreach(GameObject e in enemies)
        {
            Destroy(e);
        }
        enemies.Clear();
    }

    public void Launch()
    {
        foreach (GameObject e in enemies)
        {
            Vector3 offsetVector = new Vector3(0f, 20f, 0f);
            GameObject bomb = Instantiate(bombPrefab, e.transform.position + offsetVector, e.transform.rotation) as GameObject;
            BombMovement bm = bomb.GetComponent<BombMovement>();
            bm.SetTarget(e);
        }
        enemies.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("PoliceCar(Clone)") && !enemies.Contains(other.gameObject))
        {
            enemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("PoliceCar(Clone)") && enemies.Contains(other.gameObject))
        {
            enemies.Remove(other.gameObject);
        }
    }
}
