using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButton(0))
        {
            rb.AddForce(-MouseScript.mouseDelta * speed);
        }
        
    }
}
