using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnGumball : MonoBehaviour
{

    public GameObject gumballPrefab;
    public GameObject thisGumball;
    public TextMeshProUGUI gumballText;
    private int numberOfGumballs;
    private int gumballCount;

    [SerializeField]
    private Material[] _materials;
    [SerializeField]
    private Renderer _renderer;


    // Start is called before the first frame update
    void Start()
    {
        numberOfGumballs = 100;
        gumballCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //When E is pressed, spawn 10 gumballs
        if(Input.GetKeyDown(KeyCode.E))
        {
            createGumball(numberOfGumballs);
        }
    }

    void createGumball(int i)
    {
        //Spawn a gumball at 0,0,0 with a default "identity quaternion" rotation
        //after a delay of 10 ms, "numberOfGumballs" times
        for(int j=0; j<i; j++)
        {
            if (runningCoroutine == null)
                {
                    runningCoroutine = ExecuteAfterTime(0.1f);
                    StartCoroutine(runningCoroutine);
                }
                else
                {
                    coroutineQueue.Enqueue(ExecuteAfterTime(0.1f));
                }
        }

    }

    public void ChangeMaterial () {
        _renderer.material = SelectRandomMaterial();
    }

    private Material SelectRandomMaterial () {
        return _materials[Random.Range(0, _materials.Length)];
    }

    IEnumerator runningCoroutine = null;
    private Queue<IEnumerator> coroutineQueue = new Queue<IEnumerator> ();

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        //Spawn gumball and change material
        thisGumball = Instantiate(gumballPrefab, new Vector3(0,0,0), Quaternion.identity);
        _renderer = thisGumball.GetComponent<Renderer>();
        ChangeMaterial();

        //Update gumballCount
        gumballCount++;
        gumballText.text = "Number of Gumballs: " + gumballCount.ToString(); 

        runningCoroutine = null;
        if (coroutineQueue.Count > 0)
        {
            runningCoroutine = coroutineQueue.Dequeue();
            StartCoroutine(runningCoroutine);
        }
    }
}
