using UnityEngine;
using System.Collections;

public class AboutMenuController : MonoBehaviour {
    GameObject about;
    // Use this for initialization
    void Start () {
        about = GameObject.Find("about");
        about.SetActive(false);
	}
    public void Enter_Main_Menu()
    {
        about.SetActive(false);
    }
    public void Enter_Credit()
    {
        about.SetActive(false);
    }
    public void Enter_About()
    {
        about.SetActive(true);
    }
    // Update is called once per frame
    void Update () {
	
	}
}
