using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    bool acted;
    bool blocking;
    SpriteRenderer m_SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        acted = false;
        blocking = false;
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
            Debug.Log("Blocking");
            StartCoroutine(waiting());
            //blocking = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Enemy" && blocking) {
            //Add scenechanger success
            Debug.Log("damage trigger");
        }
    }

    IEnumerator waiting()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        m_SpriteRenderer.color = Color.white;
        blocking = false;
        Debug.Log("Done Blocking: " + blocking);
    }
}
