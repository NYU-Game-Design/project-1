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

    }

    IEnumerator waiter()
    {
        while (true) {
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            audioSource.Play();
            bulletInst = Instantiate(projectilePrefab, projectilePoint.position, projectilePoint.rotation);
            yield return new WaitForSeconds(1f);
        }
        
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
