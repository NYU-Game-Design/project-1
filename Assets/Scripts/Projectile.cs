using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform projectilePoint;
    public GameObject projectilePrefab;

    private GameObject bulletInst;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());

        //Load game over screen
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(Random.Range(1f, 7f));
        bulletInst = Instantiate(projectilePrefab, projectilePoint.position, projectilePoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
