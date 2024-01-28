using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private SceneChanger detectNext;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
        if (FireRay()){
            detectNext.LoadScene();
        }
        //Load game over screen
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(Random.Range(1f, 7f));
    }

    private bool FireRay()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right*range* transform.localScale.x*colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);
            // MAY NEED TO CHANGE THIS SO THAT IT CAN FIRE FROM A SPECIFIC LOCATION


        if (hit.collider != null)
            // Check to see if the target hit was the player
        return hit.collider != null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
