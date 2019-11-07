using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEdibleItem : MonoBehaviour
{

    private Vector3 startPosition;
    float timeCounter = 0f;
    GameObject bomb;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        MovementControl();

    }

    private void MovementControl()
    {
        // rotate around local y axis
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
        // move upward and downward
        timeCounter += Time.deltaTime;
        Vector3 updatedPosition = startPosition + new Vector3(0f, .6f * Mathf.Sin(timeCounter), 0f);
        transform.position = updatedPosition;

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);

        if (other.gameObject.tag.Equals("Player") || other.gameObject.name.Equals("Kart"))
        {
            bomb = GameObject.Find("Bomb");
            if(bomb != null)
            {
                bomb.GetComponent<Bomb>().Boom();
            }
            this.gameObject.SetActive(false);
            Destroy(gameObject);

        }
    }

}
