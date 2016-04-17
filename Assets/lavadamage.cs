using UnityEngine;
using System.Collections;

public class lavadamage : MonoBehaviour
{

    GameObject player;
    int hit_time;
    public static int LAVA_LAYER = 10;
    public static int LAVA_DAMAGE = 10;

    // Use this for initialization
    void Start()
    {
        hit_time = 0;
        player = GameObject.Find("Player");
    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.layer == LAVA_LAYER && !player.GetComponent<healthsystem>().IsDead())
        {
            if (hit_time > 100)
            {
                player.GetComponent<healthsystem>().Damage(LAVA_DAMAGE);
                hit_time = 0;
            }
            hit_time++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
