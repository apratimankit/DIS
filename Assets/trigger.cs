using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trigger : MonoBehaviour
{
    public Text result;
    public gameplay play;
    // Start is called before the first frame update
    void Start()
    {
        result = GameObject.FindGameObjectsWithTag("result")[0].GetComponent<Text>();
        play = GameObject.FindObjectOfType<gameplay>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("goal") && play.result!=2)
        {
            result.text = "Winner";
            play.result = 1;
        }
    }
}
