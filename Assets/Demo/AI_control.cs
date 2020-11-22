using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AI_control : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent Enemy;
    public gameplay Turn;
    public int Rmove;
    public Text Move;
    public Text result;
    // Start is called before the first frame update
    void Start()
    {
        Turn = FindObjectOfType<gameplay>();
        result = GameObject.FindGameObjectsWithTag("result")[0].GetComponent<Text>();
        Move = GameObject.FindGameObjectsWithTag("dicevalue")[0].GetComponent<Text>();
        Rmove = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        if (dist <= 0.07f && Turn.result!=1)
        {
            result.text = "Game Over";
            Turn.result = 2;
        }
        if (Enemy.velocity.sqrMagnitude > Mathf.Epsilon)
        {
            transform.rotation = Quaternion.LookRotation(Enemy.velocity.normalized);
        }
        if (Turn.turn == 2 && Rmove==0)
        {
            Rmove = Random.Range(1, 3);
            Move.text = Rmove.ToString();
            Rmove *= 50;
            Enemy.speed = 0.5f;
        }
        if (Rmove>0)
        {
            Enemy.SetDestination(player.position);
            Rmove -= 1;
            Move.text = ((int)Mathf.Ceil(Rmove / 50)).ToString();
            if (Rmove == 0)
            {
                Turn.turn = 1;
                Move.text = "0";
                Enemy.speed = 0;
            }
        }
        else
        {
            Enemy.speed = 0;
        }
        
    }
    
}
