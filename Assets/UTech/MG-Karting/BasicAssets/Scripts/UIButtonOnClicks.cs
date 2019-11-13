using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonOnClicks : MonoBehaviour
{
    public GameObject myBulletHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireOnClick()
    {
        if(myBulletHolder == null)
        {
            return;
        }
        Shooting shootScript = myBulletHolder.GetComponent<Shooting>();
        if(shootScript == null)
        {
            return;
        }
        shootScript.Fire();
    }
}
