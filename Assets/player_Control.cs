using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_Control : MonoBehaviour
{
    // Start is called before the first frame update

    
    public Joystick joystick;
    public CharacterController controller;
    public Transform cam;
    public float speed = 0.005f;
    public float turnSmoothtime = 0.1f;
    float turnSmoothvelocity;
    public int Rmove;
    public Text Move;
    public Button dice;
    private bool Strt;
    public gameplay Turn;
    void Start()
    {
        joystick = FindObjectOfType<FixedJoystick>();
        Move = GameObject.FindGameObjectsWithTag("dicevalue")[0].GetComponent<Text>();
        dice = GameObject.FindGameObjectsWithTag("Dice")[0].GetComponent<Button>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        Turn = FindObjectOfType<gameplay>();
        Rmove = 0;
        Strt = false;
    }
    // Update is called once per frame
    void Update()
    {
        dice.onClick.AddListener(Throw);
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 1f && Rmove>0)
        {
            float targertangle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targertangle, ref turnSmoothvelocity, turnSmoothtime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targertangle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            Strt = true;
        }
        if (Strt)
        {
            Rmove -= 1;
            Move.text = ((int)Mathf.Ceil(Rmove / 10)).ToString();
            if (Rmove <= 0)
            {
                Strt = false;
                Move.text = "0";
                Turn.turn = 2;
            }
        }
    }
    public void Throw()
    {
        if (Turn.turn == 1)
        {
            Rmove = Random.Range(1, 4);
            Move.text = Rmove.ToString();
            Rmove *= 10;
        }
        
    }
}
