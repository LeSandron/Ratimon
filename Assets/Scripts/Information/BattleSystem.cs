using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    private RatDatabase ratDatabase;
    public BattleState state;

    
    // Start is called before the first frame update
    void Start()
    {
        ratDatabase = new RatDatabase();
        state = BattleState.START;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
