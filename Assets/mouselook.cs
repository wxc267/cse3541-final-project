using UnityEngine;
using System.Collections;

public class mouselook : MonoBehaviour {
    private enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    private RotationAxes axes = RotationAxes.MouseXAndY;
    private float sensitivityX = 15F;
    private float sensitivityY = 15F;
    private float minimumY = -90F;
    private float maximumY = 90F;
    private float rotationY = 0F;
    private bool mouse_locked;
    private bool body_on_ground;//this will be used for put body on ground when player is dead.

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        mouse_locked = true;
        body_on_ground = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mouse_locked = !mouse_locked;
        }
        GameObject player = GameObject.Find("Player");
        if (mouse_locked&&!body_on_ground)
        {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                
                if (axes == RotationAxes.MouseXAndY)
                {
                    float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
                    rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                    rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
                    player.transform.Rotate(0, rotationX, 0);
                    transform.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
                }
                else if (axes == RotationAxes.MouseX)
                {
                    player.transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
                    transform.Rotate(0, 0, 0);
                }
                else
                {
                    rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                    rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
                    player.transform.Rotate(0, transform.localEulerAngles.y, 0);
                    transform.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
                }




        }
        else
        {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
        }
        if (player.GetComponent<healthsystem>().IsDead()&&!body_on_ground)
        {
            player.transform.Rotate(90, 0, 0);
            transform.transform.localEulerAngles = new Vector3(0, 90, 0);
            body_on_ground = true;
        }






        
	}
}
