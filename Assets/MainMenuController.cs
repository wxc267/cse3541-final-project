using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {
    GameObject mainMenu;
    // Use this for initialization
    void Start()
    {
        mainMenu = GameObject.Find("mainmenu");
        mainMenu.SetActive(true);
    }
    public void Enter_Main_Menu()
    {
        mainMenu.SetActive(true);
    }
    public void Enter_Credit()
    {
        mainMenu.SetActive(false);
    }
    public void Enter_About()
    {
        mainMenu.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
	
	}
}
