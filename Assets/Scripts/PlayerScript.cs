using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    boolean acted;
    boolean blocking;
    // Start is called before the first frame update
    void Start()
    {
        acted = false;
        blocking = false;
    }

    boolean isBlocking() {
        return blocking;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && !acted) {
            acted = true;
            blocking = true;
            StartCoroutine(waiting());
            blocking = false;
        }
    }

    IEnumerator waiting()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
