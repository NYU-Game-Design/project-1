using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    bool acted;
    bool blocking;
    bool perfect;
    SpriteRenderer m_SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        acted = false;
        blocking = false;
        perfect = false;
    }

    bool isBlocking() {
        return blocking;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && !acted) {
            acted = true;
            blocking = true;
            perfect = true;
            Debug.Log("Blocking");
            StartCoroutine(waiting());
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Enemy" && blocking && perfect) {
            //score increase by 10
            Debug.Log("damage trigger");
        }
        else if (other.tag == "Enemy" && blocking) {
            //score increase by 5
            Debug.Log("damage trigger");
        }
        else if (other.tag == "Enemy" && !blocking) {
            //game over
        }
        StartCoroutine(resetBlocking());
    }

    IEnumerator waiting()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        perfect = false;
        m_SpriteRenderer.color = Color.magenta;
        yield return new WaitForSeconds(0.25f);
        m_SpriteRenderer.color = Color.grey;
        blocking = false;
        Debug.Log("Done Blocking: " + blocking);
    }

    IEnumerator resetBlocking()
    {
        yield return new WaitForSeconds(0.5f);
        blocking = true;
        m_SpriteRenderer.color = Color.white;
        Debug.Log("Reset Blocking: " + blocking);
    }
}
