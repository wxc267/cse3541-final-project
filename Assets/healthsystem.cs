using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class healthsystem : MonoBehaviour {
   private bool isDead;
    private int hp;
    private int update_time;
	// Use this for initialization
	void Start () {
        isDead = false;
        hp = 100;
        update_time = 0;
	}
    public bool IsDead()
    {
        return isDead;
    }
    public int ReturnHp()
    {
        return hp;
    }
    public void Damage(int damage_point)
    {      
        if (hp < 0)
        {
            hp = 0;
        }
        else
        {
            hp = hp - damage_point;
        }
    }
    public void Heal(int heal_point)
    {        
            hp = hp + heal_point;        
    }
	// Update is called once per frame
	void Update () {
        Text health_point = GameObject.Find("hud/HealthUI/health_point").GetComponent<Text>();
        health_point.text = hp.ToString();
        if (hp==0)
        {
            isDead = true;
        }
        if (hp > 100)
        {
            if(update_time>=100){
                hp--;
                update_time = 0;
            }
            update_time++;
        }
        if (hp < 0)
        {
            hp = 0;
        }
	}
}
