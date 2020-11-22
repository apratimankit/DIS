using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overtrigger : MonoBehaviour
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
        if (other.CompareTag("hero") && play.result!=1)
        {
            result.text = "Game Over";
            play.result = 2;
        }
    }
}
