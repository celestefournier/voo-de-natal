using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 3;
    public ScoreManager collectablesManager;
    public Timer timer;
    public GameObject itemEffect;
    public GameObject collisionEffect;

    SceneManager sceneManager;

    void Start()
    {
        transform.DOMoveX(-11, 2).From().SetEase(Ease.OutQuint).SetDelay(0.3f);
        sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneManager>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetAxis("Vertical") > 0 && transform.position.y < 3.5f)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.up * Input.GetAxis("Vertical") * speed;
        }
        else if (Input.GetAxis("Vertical") < 0 && transform.position.y > -3.3f)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.up * Input.GetAxis("Vertical") * speed;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Instantiate(collisionEffect, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            sceneManager.Lose(
                timer.time,
                collectablesManager.candyScore,
                collectablesManager.bellScore,
                collectablesManager.ornamentScore,
                collectablesManager.starScore
            );
        }
        else if (other.tag == "Item")
        {
            Instantiate(itemEffect, other.transform.position, Quaternion.identity);
            collectablesManager.PickItem(other.name);
            Destroy(other.gameObject);
        }
    }
}
