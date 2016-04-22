using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    private float moveSpeed = 5.0f;
    private float jumpSpeed = 4.0f;
    public static Vector3 adjustedLight = new Vector3(0,-0.1f,0);
    public GameObject flashLight;
    GameObject lightClone;
    private bool lightIsOn;
    // Use this for initialization
    void Start () {
        flashLight = Resources.Load("spotlight") as GameObject;
        lightClone= GameObject.Find("spotlight(Clone)");
        lightIsOn = true;
    }
	void FlashLight()
    {
        if (!lightIsOn)
        {
            lightClone = Instantiate(flashLight, transform.position+adjustedLight, Camera.main.transform.rotation) as GameObject;
            lightClone.transform.parent = GameObject.Find("Main Camera").transform;
            lightIsOn = true;
        }
        else
        {
            Destroy(lightClone);
            lightIsOn = false;
        }
    }
	// Update is called once per frame
	void Update () {

        if (!GetComponent<healthsystem>().IsDead()&& !GetComponent<PauseManager>().IsPause())
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                Vector3 playerLocation = transform.position;
                float height = playerLocation.y;
                height = height + jumpSpeed * Time.deltaTime;

                transform.position = new Vector3(playerLocation.x, height, playerLocation.z);
            }
            if(Input.GetKeyDown(KeyCode.F))
            {
                FlashLight();
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("final-main");
            }
            if(Input.GetKeyDown(KeyCode.B))
            {
                SceneManager.LoadScene("menu");
            }
        }
    }
}
