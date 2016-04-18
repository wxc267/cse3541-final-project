using UnityEngine;
using System.Collections;

public class CreditMenuController : MonoBehaviour {
    GameObject credit;
    // Use this for initialization
    void Start()
    {
        credit = GameObject.Find("credit");
        credit.SetActive(false);
    }
    public void Enter_Main_Menu()
    {
        credit.SetActive(false);
    }
    public void Enter_Credit()
    {
        credit.SetActive(true);
    }
    public void Enter_About()
    {
        credit.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
	
	}
}
