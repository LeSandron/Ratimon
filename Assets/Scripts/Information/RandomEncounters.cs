using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Playerstate { INBATTLE,OUTBATTLE}
public class RandomEncounters : MonoBehaviour
{
    private RatDatabase ratDatabase;
    public Playerstate state;
    public GameObject battleSystem;
    public GameObject battleUI;
    public GameObject Player;
    public string chosenRat;
    private int randNumb;
    // Start is called before the first frame update
    void Start()
    {
        randNumb = 0;
        ratDatabase = new RatDatabase();
        state = Playerstate.OUTBATTLE;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == Playerstate.OUTBATTLE)
        {
            Cursor.lockState = CursorLockMode.Locked;
            battleSystem.SetActive(false);
            battleUI.SetActive(false);
            Player.GetComponent<playerMovement>().enabled = true;
        }
    }


    public void changeState()
    {
        if(state == Playerstate.INBATTLE)
        {
            state = Playerstate.OUTBATTLE;
        }
        else if (state == Playerstate.OUTBATTLE)
        {
            state = Playerstate.INBATTLE;
        }
    }

    public void triggerEncounter()
    {
        randNumb = UnityEngine.Random.Range(0, 100);
        Cursor.lockState = CursorLockMode.None;
        battleSystem.SetActive(true);
        battleUI.SetActive(true);
        Player.GetComponent<playerMovement>().enabled = false;
        if (randNumb < 25)
        {
             chosenRat = "Ratomatcho";
        }
        else if (randNumb > 25 && randNumb < 50)
        {
             chosenRat = "Ratsoak";
        }
        else if (randNumb > 50 && randNumb < 75)
        {
             chosenRat = "Rattack";
        }
        else if (randNumb > 75 && randNumb <= 100)
        {
             chosenRat = "Ratbat";
        }
        battleSystem.GetComponent<BattleSystem>().SetUpBattle();
        
    }    
}
