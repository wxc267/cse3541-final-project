using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuSelect : MonoBehaviour {

    // Use this for initialization
    void Start () {
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
        SceneManager.LoadScene("final-main");
    }
    public void Exit_Menu()
    {
        SceneManager.LoadScene("menu");
    }
    public void Quit()
    {
        Application.Quit();
    }
    // Update is called once per frame

    void Update () {
        
	}
}
