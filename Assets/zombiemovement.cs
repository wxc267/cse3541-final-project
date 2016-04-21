using UnityEngine;
using System.Collections;

public class zombiemovement : MonoBehaviour {
    Animator animator;
    GameObject player;
    float fov=120.0f;
    float zombie_speed = 0.3f;
    GameObject[] cubes;
    RaycastHit hit;
    Vector3 playerLostPosition;
    bool playerIsLost;
    int hp;
    // Use this for initialization
    void Start () {
	    animator = GetComponent<Animator>();
        hp = animator.GetInteger("hp");
        player = GameObject.Find("Player");
        cubes = GameObject.FindGameObjectsWithTag("cube");
    }
    public void GetDamaged(int damage_point)
    {
        if (hp > 0)
        {
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

            hp -= damage_point;
            animator.SetInteger("hp", hp);
        }
    }

	void OnCollisionEnter(Collision col)
    {
        
    }
    bool OnSight(Transform target)
    {
        //if player was in the angle of the line of sight of zombie and zombie dose not see the wall
        if (Vector3.Angle(target.position - transform.position, transform.forward) <= fov &&
       Physics.Linecast(transform.position, target.position, out hit) && hit.transform == target)
        {
            return true;
        }
        return false;
    }

    bool ArrivePlayerLostPlace()
    {
        float zombie_x = transform.position.x;
        float player_x = playerLostPosition.x;
        float zombie_z = transform.position.z;
        float player_z = playerLostPosition.z;
        float distance = Mathf.Pow(Mathf.Pow(zombie_x - player_x, 2f) + Mathf.Pow(zombie_z - player_z, 2f), 0.5f);
        return distance < 1f;
    }
    void Collision_Handler()
    {
        foreach (GameObject cube in cubes)
        {
            
            Vector3 cubeLocation = cube.transform.position;
            if (cubeLocation.y > 0.5)
                //make sure that only the hight of cubes whose height are greater than ground will have collision with the zombie.
            {
                float length = cube.transform.localScale.x+1f;
                float playerX = transform.position.x;
                float playerZ = transform.position.z;
                float cubeX = cubeLocation.x;
                float cubeZ = cubeLocation.z;
                float halfLength = length / 2;
                if (playerX >= (cubeX - halfLength) && playerX <= (cubeX + halfLength) && playerZ >= (cubeZ - halfLength) && playerZ <= (cubeZ + halfLength))
                {
                    //collision happens
                    float newPositionX = playerX;
                    float newPositionZ = playerZ;
                    float dToDown = Mathf.Abs(playerZ - (cubeZ - halfLength));
                    float dToUp = Mathf.Abs(playerZ - (cubeZ + halfLength));
                    float dToLeft = Mathf.Abs(playerX - (cubeX - halfLength));
                    float dToRight = Mathf.Abs(playerX - (cubeX + halfLength));
                    float[] distances = { dToDown, dToUp, dToLeft, dToRight };
                    float min = distances[0];
                    int minIndex = 0;
                    for (int i = 1; i < distances.Length; i++)
                    {
                        if (distances[i] <= min)
                        {
                            min = distances[i];
                            minIndex = i;
                        }
                    }
                    switch (minIndex)
                    {
                        case 0:
                            newPositionZ = cubeZ - halfLength;
                            break;
                        case 1:
                            newPositionZ = cubeZ + halfLength;
                            break;
                        case 2:
                            newPositionX = cubeX - halfLength;
                            break;
                        case 3:
                            newPositionX = cubeX + halfLength;
                            break;
                    }
                    Vector3 newPosition = new Vector3(newPositionX, transform.position.y, newPositionZ);
                    transform.position = newPosition;
                }
            }
        }
    }
    void Attack()
    {


    }
	// Update is called once per frame
	void Update () {
        Collision_Handler();

        //the animator will be enabled once zombie see the player. It could make the game have better performance.
        //the zombie will chase the player for a while until when it gose to the player's lost location and it could not see the player.
       if(player.GetComponent<PauseManager>().IsPause())
        {
            animator.enabled = false;
        }
        if (!player.GetComponent<healthsystem>().IsDead()&&hp>0&& !player.GetComponent<PauseManager>().IsPause())
        {
            if (OnSight(player.transform))
            {
                playerIsLost = false;
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
                {
                    transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
                    transform.Translate(Vector3.forward * zombie_speed * Time.deltaTime);
                }
                animator.enabled = true;
            }
            else
            {
                if (!playerIsLost)
                {
                    playerIsLost = true;
                    playerLostPosition = player.transform.position;
                }
                if (!ArrivePlayerLostPlace())
                {
                    transform.LookAt(new Vector3(playerLostPosition.x, transform.position.y, playerLostPosition.z));
                    transform.Translate(Vector3.forward * zombie_speed * Time.deltaTime);
                }
                else
                {

                    animator.enabled = false;
                }
            }
            if (Vector3.Distance(player.transform.position, transform.position) < 2f)
            {

                animator.SetBool("attack", true);
            }
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack") && Vector3.Distance(player.transform.position, transform.position) < 2f)
            {
                player.GetComponent<healthsystem>().Damage(1);
            }
        }
    }
}
