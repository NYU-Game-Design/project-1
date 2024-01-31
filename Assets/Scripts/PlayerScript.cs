using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    bool acted;
    bool blocking;
    bool perfect;
    bool parried;
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
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.color = Color.white;
        if (other.tag == "Enemy" && blocking && perfect) {
            m_SpriteRenderer.color = Color.magenta;
            ScoreManager.Instance.IncreaseScore(50);
            Debug.Log("damage trigger");
        }
        else if (other.tag == "Enemy" && blocking) {
            m_SpriteRenderer.color = Color.magenta;
            ScoreManager.Instance.IncreaseScore(20);
            Debug.Log("damage trigger");
        }
        else if (other.tag == "Enemy" && !blocking) {
            //game over
        }
        acted = false;
        m_SpriteRenderer.color = Color.white;
        Debug.Log("Reset Blocking: " + blocking);
    }

    IEnumerator waiting()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        perfect = false;
        
        yield return new WaitForSeconds(0.25f);
        m_SpriteRenderer.color = Color.grey;
        blocking = false;
        Debug.Log("Done Blocking: " + blocking);
    }

}
