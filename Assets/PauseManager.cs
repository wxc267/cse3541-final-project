using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {
    private bool pause;
    public GameObject pausedMenu;
	// Use this for initialization
	void Start () {
        pause = false;
        pausedMenu = GameObject.Find("ingamemenu");
        
	}
    public bool IsPause()
    {
        return pause;
    }

	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }
        pausedMenu.SetActive(pause);
    }
}
