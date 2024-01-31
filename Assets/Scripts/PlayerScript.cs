using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    bool acted;
    bool blocking;
    bool perfect;
    bool parried;
    SpriteRenderer m_SpriteRenderer;
    // sound effects
    public AudioSource audioSource;
    public AudioClip parry;
    public AudioClip damage1;
    public AudioClip damage2;
    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        acted = false;
        blocking = false;
        perfect = false;
        parried = false;
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
        parried = true;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        if (other.tag == "Enemy" && blocking && perfect) {
            m_SpriteRenderer.color = Color.magenta;
            Debug.Log("damage trigger");
            audioSource.PlayOneShot(parry);
            ScoreManager.Instance.IncreaseScore(50);
        }
        else if (other.tag == "Enemy" && blocking) {
            m_SpriteRenderer.color = Color.magenta;
            Debug.Log("damage trigger");
            audioSource.PlayOneShot(parry);
            ScoreManager.Instance.IncreaseScore(20);
        }
        else if (other.tag == "Enemy" && !blocking) {
            //game over
            // 50% chance of playing damage1 or damage2
            if (Random.Range(0, 2) == 0)
            {
                audioSource.PlayOneShot(damage1);
            }
            else
            {
                audioSource.PlayOneShot(damage2);
            }
            if (ScoreManager.Instance.score < 0f) {
                SceneManager.LoadScene("YouLose", LoadSceneMode.Single);
            }
            if (ScoreManager.Instance.score >= 100f) {
                ScoreManager.Instance.DecreaseScore(ScoreManager.Instance.score);
            }
            else {
                ScoreManager.Instance.DecreaseScore(100);
            }
        }
    }

    IEnumerator waiting()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        perfect = false;
        
        yield return new WaitForSeconds(0.25f);
        m_SpriteRenderer.color = Color.grey;
        blocking = false;
        Debug.Log("Done Blocking: " + blocking);

        if (parried) {
            acted = false;
            m_SpriteRenderer.color = Color.white;
            parried = false;
            Debug.Log("Reset Blocking: " + blocking);
        }
    }

}
