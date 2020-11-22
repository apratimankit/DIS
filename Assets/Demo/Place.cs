using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objecttoSpawn;
    private PlacementIndicator placementIndicator;
    private bool check;
    void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
        check = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && check==true)
        {
            GameObject obj = Instantiate(objecttoSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
            //obj.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            check = false;
            placementIndicator.Indicatoroff();
        }
    }
}
