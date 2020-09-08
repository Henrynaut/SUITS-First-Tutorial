using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnGumball : MonoBehaviour
{

    public GameObject gumballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            createGumball();
        }
    }

    void createGumball()
    {
        Instantiate(gumballPrefab, new Vector3(0,0,0), Quaternion.identity);
    }
}
