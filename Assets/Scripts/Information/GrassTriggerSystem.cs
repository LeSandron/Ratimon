using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTriggerSystem : MonoBehaviour
{
    public GameObject encounterScript;
    // Start is called before the first frame update
    void Start()
    {
        print("This script is running");
        encounterScript = GameObject.FindGameObjectWithTag("Encounter");

        print("Hello, ive done this now");
        if (encounterScript == null)
        {
            print("Couldnt find it");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //encounterScript = GameObject.FindGameObjectWithTag("Encounter");

    }

    private void OnTriggerEnter(Collider other)
    {
       
        if(other.tag == "Player")
        {
            

            if(UnityEngine.Random.Range(0, 100) > 85)
            {
                encounterScript.GetComponent<RandomEncounters>().changeState();
                encounterScript.GetComponent<RandomEncounters>().triggerEncounter();
            }
        }
    }
}
