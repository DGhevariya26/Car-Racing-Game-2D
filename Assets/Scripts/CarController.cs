using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public float carSpeed;
    public float minPos = 1.70f;
    Vector3 position;

    public UIManager uiScript;

    bool currentPlatformAndroid = false;

    Rigidbody2D rb;

    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();

        

    #if UNITY_ANDROID
            currentPlatformAndroid = true;
    #else
            currentPlatformAndroid = false;
    #endif
        

    }


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        position = transform.position;

        if(currentPlatformAndroid == true)
        {
            Debug.Log("Android");
        }
        else
        {
            Debug.Log("Windows");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if(currentPlatformAndroid == true)
        {
           
        }

        else
        {
            position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;

            position.x = Mathf.Clamp(position.x, -minPos, minPos);

            transform.position = position;
        }

        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy Car")
        {
            Destroy(gameObject);
            uiScript.GameOverActivated();
           
        }
    }

    public void MoveLeft()
    {
        rb.velocity = new Vector2(-carSpeed, 0);
    }

    public void MoveRight()
    {
        rb.velocity = new Vector2(carSpeed, 0);
    }

    public void SetVelocityZero()
    {
        rb.velocity = Vector2.zero;
    }

}

