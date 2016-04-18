using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuSelect : MonoBehaviour {
    
    GameObject[] mainMenu;
    GameObject[] about;
    GameObject[] credit;
    // Use this for initialization
    void Start () {
        /*
        mainMenu = GameObject.FindGameObjectsWithTag("GameMenu");
        about = GameObject.FindGameObjectsWithTag("AboutMenu");//root.transform.Find("about");
        credit = GameObject.FindGameObjectsWithTag("CreditMenu");
        mainMenu[0].SetActive(true);
        about[0].SetActive(false);
        credit[0].SetActive(false);
        */
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

    void Update () {
        
	}
}
