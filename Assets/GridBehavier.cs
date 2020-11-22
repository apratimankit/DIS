using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBehavier : MonoBehaviour
{
    public int row = 10;
    public int columns = 10;
    public int scale = 1;
    public GameObject gridPrefab;
    public Vector3 leftbottomlocation = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Awake()
    {
        if (gridPrefab)
        {
            GenerateGrid();
        }
        else
        {
            print("missing gridprefeb");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateGrid()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < row; j++)
            {
                GameObject obj = Instantiate(gridPrefab, new Vector3(leftbottomlocation.x + scale * i, leftbottomlocation.y, leftbottomlocation.z + scale * j), Quaternion.identity);
                obj.transform.SetParent(gameObject.transform);
                obj.GetComponent<Gridstat>().x = i;
                obj.GetComponent<Gridstat>().y = j;
            }
        }
    }
}
