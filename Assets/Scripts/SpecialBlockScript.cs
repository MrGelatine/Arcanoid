using System.IO;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // using TMPro;

public class SpecialBlockScript : MonoBehaviour
{

    GameObject playerObj;
    float deltaX;

    float maxSpeed = 3.0f;

    public Vector2 blockInitialForce;
    Rigidbody2D rb;

    PlayerScript playerScript;
    public GameObject textObject;
    Text textComponent;
    public int hitsToDestroy;
    public int points;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        //rb.AddForce(blockInitialForce);
        /*var v = rb.velocity;
        if (Random.Range(0, 2) == 0)
            v.Set(1.0f, 0);
        else
            v.Set(-1.0f, 0);
        rb.velocity = v;*/


        if (textObject != null)
        {
            textComponent = textObject.GetComponent<Text>();
            textComponent.text = hitsToDestroy.ToString();
        }
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        {
            if (collision.gameObject.tag == "Ball")
            {
                hitsToDestroy -= playerScript.force;
                if (hitsToDestroy <= 0)
                {
                    print(points);
                    Destroy(gameObject);
                    playerScript.BlockDestroyed(points, this.gameObject.name, this.gameObject.transform.position);
                }
                else if (textComponent != null)
                    textComponent.text = hitsToDestroy.ToString();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        var v = rb.velocity;
        if (Random.Range(0, 2) == 0)
            v.Set(v.x - 0.05f, v.y);
        else
        {
            if (v.x < maxSpeed)
                v.Set(v.x + 0.05f, v.y);
        }
        rb.velocity = v;
    }
}
