using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    float bulletSpeed = 5500;
    public GameObject bullet;

    public int MaxAmmo = 10;
    private int CurrentAmmo;
    public float ReloadTime = 5.0f;
    private bool isReloading = false;

    AudioSource bulletAudio;

    // Start is called before the first frame update
    void Start()
    {
        CurrentAmmo = MaxAmmo;

        bulletAudio = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        isReloading = false;
    }

    public void Fire()
    {
        CurrentAmmo--;

        GameObject tempBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
        tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);
        Destroy(tempBullet, 1.0f);

        bulletAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
            return;
        
        if (CurrentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Fire();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(ReloadTime);

        CurrentAmmo = MaxAmmo;
        isReloading = false;
    }
}
