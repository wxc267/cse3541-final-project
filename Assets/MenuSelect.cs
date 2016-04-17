using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuSelect : MonoBehaviour {
    GameObject mainMenu;
    GameObject about;
    GameObject credit;
	// Use this for initialization
	void Start () {
        mainMenu = GameObject.Find("mainmenu");
        about = GameObject.Find("about");
        credit = GameObject.Find("credit");
        mainMenu.SetActive(true);
        about.SetActive(false);
        credit.SetActive(false);
	}
	public void Turn_Red()
    {
        GetComponent<Text>().color = Color.red;

    }
    public void Turn_White()
    {
        GetComponent<Text>().color = Color.white;
    }
    public void Enter_Game()
    {
        SceneManager.LoadScene("test");
    }
	// Update is called once per frame
    public void Enter_Main_Menu()
    {
        mainMenu.SetActive(true);
        about.SetActive(false);
        credit.SetActive(false);
    }
    public void Enter_Credit()
    {
        credit.SetActive(true);
        mainMenu.SetActive(false);
        about.SetActive(false);
    }
    public void Enter_About()
    {

    }
	void Update () {
	
	}
}
