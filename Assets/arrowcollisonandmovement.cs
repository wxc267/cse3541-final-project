using UnityEngine;
using System.Collections;

public class arrowcollisonandmovement : MonoBehaviour {
    float damping = 0.99f;
    //float dampingWall = 0.003f;

    float speed;
    
    // Use this for initialization
    void Start () {
        speed = 20f;

    }
    public float GetSpeed()
    {
        return speed;
    }
	void OnCollisionStay(Collision col)
    {
        if (col.gameObject.layer == 8)
        {
            speed = 0;
        }
        
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 13)
        {
            speed =0;
            

        }
    }
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        speed *= damping;
        if (speed < 1)
        {
            speed = 0;
        }
        
    }
}
