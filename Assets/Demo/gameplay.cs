using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameplay : MonoBehaviour
{
    public int result;
    public int turn;
    public Text turnprint;
    // Start is called before the first frame update
    void Start()
    {
        turn = 1;
        turnprint = GameObject.FindGameObjectsWithTag("turnprint")[0].GetComponent<Text>();
        result = 0;
    }

    // Update is called once per frame
    void Update()
    {
        turnprint.text = turn.ToString();
    }
}
