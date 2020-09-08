using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnGumball : MonoBehaviour
{

    public GameObject gumballPrefab;
    public GameObject thisGumball;

    [SerializeField]
    private Material[] _materials;
    [SerializeField]
    private Renderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //When E is pressed, spawn 10 gumballs
        if(Input.GetKeyDown(KeyCode.E))
        {
            for(int i = 0; i < 10; i++)
            {
                createGumball();
            }
        }
    }

    void createGumball()
    {
        //Spawn a gumball at 0,0,0 with a default "identity quaternion" rotation
        thisGumball = Instantiate(gumballPrefab, new Vector3(0,0,0), Quaternion.identity);
        _renderer = thisGumball.GetComponent<Renderer>();
        ChangeMaterial();
    }

    public void ChangeMaterial () {
        _renderer.material = SelectRandomMaterial();
    }

    private Material SelectRandomMaterial () {
        return _materials[Random.Range(0, _materials.Length)];
    }
}
