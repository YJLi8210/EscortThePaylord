using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonOnClicks : MonoBehaviour
{
    public GameObject myBulletHolder;

    public int MaxAmmo = 3;
    public int CurrentAmmo;
    public float ReloadTime = 5.0f;
    private bool isReloading = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentAmmo = MaxAmmo;
    }

    void OnEnable()
    {
        isReloading = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FireOnClick()
    {
        if (isReloading)
            return;

        if (CurrentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        CurrentAmmo--;

        if (myBulletHolder == null)
            return;

        Shooting shootScript = myBulletHolder.GetComponent<Shooting>();

        if(shootScript == null)
            return;

        shootScript.Fire();
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(ReloadTime);

        CurrentAmmo = MaxAmmo;
        isReloading = false;
    }
}
