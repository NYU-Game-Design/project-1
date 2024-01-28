using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
        //include a function that gives the player victory if FireRay() returns true and moves them to the next level, else give them a game over screen otherwise;
    }

    private bool FireRay()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right*range* transform.localScale.x*colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);
        if (hit.collider != null)
            // Check to see if the target hit was the player
        return hit.collider != null;
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(Random.Range(1f, 7f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
