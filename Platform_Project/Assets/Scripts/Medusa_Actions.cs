using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medusa_Actions : MonoBehaviour
{
    [SerializeField] float vMotion = 0.2f;
    [SerializeField] float hMotion = 1f;
    [SerializeField] bool inDungeon = false;
    [SerializeField] float vFreq = 2f;
    [SerializeField] bool faceLeft = true;
    [SerializeField] float hDistance = 10f;

    //Cached references
    Vector3 eTransform;
    Rigidbody2D eBody;
    float timer;
    SpriteRenderer sprite;
    

    // Start is called before the first frame update
    void Start()
    {
        eBody = gameObject.GetComponent<Rigidbody2D>();
        eTransform = gameObject.transform.position;
        timer = Time.time;
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        DistanceCheck();
        MedusaMove(Time.time - timer);
    }

    //Control of motion
    public void MedusaMove (float time)
    {

        //Determine horizontal motion based on direction facing
        float xChange;
        if (!faceLeft)
        {
            xChange = hMotion * Time.deltaTime;

        }

        else
        {
            xChange = -hMotion * Time.deltaTime;

        }
        float yChange = vMotion * Mathf.Sin(vFreq * time) / 10;

        gameObject.transform.position += new Vector3(xChange, yChange, 0f);
    }

    //Check for bounds of motion for Medusa
    public void DistanceCheck()
    {
        float xDist = gameObject.transform.position.x - eTransform.x;
        float yDist = gameObject.transform.position.y - eTransform.y;
        float zDist = gameObject.transform.position.z - eTransform.z;

        float distance = Mathf.Sqrt(Mathf.Pow(xDist, 2f) + Mathf.Pow(yDist, 2f) + Mathf.Pow(zDist, 2f));
        Debug.Log("Distance: " + distance);

        if (distance > hDistance)
        {
            faceLeft = !faceLeft;
            Vector3 tScale = eBody.transform.localScale;
            tScale.x *= -1f;
            eBody.transform.localScale = tScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMotion>())
        {
            Debug.Log("oof");
            PlayerMotion player = collision.GetComponent<PlayerMotion>();
            player.PlayerPerish();
        }
    }
}
