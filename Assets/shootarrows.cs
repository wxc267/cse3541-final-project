using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class shootarrows : MonoBehaviour {
    public GameObject flyingarrow;
    public GameObject emptybow;
    public GameObject reloadedbow;
    GameObject currentbow;
    public static int ARROW_SPEED = 5;
    private int reload_time=0;
    private bool can_shoot;
    int arrow_ammo;
	// Use this for initialization
	void Start () {
        flyingarrow = Resources.Load("Arrow") as GameObject;
        emptybow = Resources.Load("emptycrossbow") as GameObject;
        reloadedbow = Resources.Load("loadedcrossbow") as GameObject;
        currentbow = GameObject.Find("loadedcrossbow(Clone)");
        can_shoot = true;
        arrow_ammo = 5;
    }
    public void Get_Arrow(int ammo)
    {
        arrow_ammo += ammo;
    }
	void shoot_arrow()
    {
        Vector3 original = Camera.main.transform.rotation.eulerAngles;      
        Instantiate(flyingarrow, Camera.main.transform.position,Quaternion.Euler(original));
        
        GameObject emptyBowClone = Instantiate(emptybow,currentbow.transform.position,currentbow.transform.rotation)as GameObject;
        Destroy(currentbow);
        emptyBowClone.transform.parent = GameObject.Find("Main Camera").transform;
        currentbow = GameObject.Find("emptycrossbow(Clone)");
    }
	// Update is called once per frame
	void Update () {
        Text arrows = GameObject.Find("hud/ArrowUI/Arrow").GetComponent<Text>();
        arrows.text = arrow_ammo.ToString();
        if (!GetComponent<PauseManager>().IsPause())
        {
            if (!GetComponent<healthsystem>().IsDead())
            {
                if (Input.GetMouseButtonDown(0) && reload_time == 0 && can_shoot)
                {
                    shoot_arrow();
                    reload_time = 150;
                    can_shoot = false;
                    arrow_ammo--;
                }
                if (reload_time > 0)
                {
                    reload_time--;
                }
                else if (reload_time < 10 && !can_shoot && arrow_ammo > 0)
                {
                    GameObject reloadedBowClone = Instantiate(reloadedbow, currentbow.transform.position, currentbow.transform.rotation) as GameObject;
                    Destroy(currentbow);
                    reloadedBowClone.transform.parent = GameObject.Find("Main Camera").transform;
                    currentbow = GameObject.Find("loadedcrossbow(Clone)");
                    can_shoot = true;
                }
            }
            else
            {
                Destroy(currentbow);
            }
        }
        
    }
}
