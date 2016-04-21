using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class getitem : MonoBehaviour {
    public static int POTION_HEAL = 10;
    public static int POTION_LAYER = 11;
    public static int BAG_LAYER = 14;
    GameObject player; 
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == POTION_LAYER)
        {
            player.GetComponent<healthsystem>().Heal(POTION_HEAL);
            Destroy(col.gameObject);
        }
        if (col.gameObject.layer == 14)
        {
            player.GetComponent<shootarrows>().Get_Arrow(5);
            Destroy(col.gameObject);
        }
        if (col.gameObject.layer == 15)
        {
            SceneManager.LoadScene("win");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
