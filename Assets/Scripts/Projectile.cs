using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform projectilePoint;
    public GameObject projectilePrefab;

    private GameObject bulletInst;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(waiter());

        //Load game over screen
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(Random.Range(1f, 7f));
        audioSource.Play();
        bulletInst = Instantiate(projectilePrefab, projectilePoint.position, projectilePoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
