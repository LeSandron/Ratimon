using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healparty : MonoBehaviour
{
    public GameObject partyScript;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Healer")
        {
            print("healing");
            partyScript.GetComponent<PlayerParty>().healParty();
        }
    }
}
