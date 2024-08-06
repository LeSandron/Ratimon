using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    private RatDatabase ratDatabase;
    public BattleState state;

    public Image allySprite, enemySprite;
    public TextMeshProUGUI allyName, enemyName, allyLevel, enemyLevel;

    
    // Start is called before the first frame update
    void Start()
    {
        ratDatabase = new RatDatabase();
        state = BattleState.START;

        DebugStats("Ratsoak");
        DebugStats("Ratomatcho");
        SetUpBattle();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DebugStats(string ratName)
    {
        RatInformation rat = ratDatabase.GetRatByName(ratName);

        if( rat != null)
        {
            print($"Name:{rat.ratName}, Hp { rat.ratHp}, Attack {rat.ratAttack}, Defense {rat.ratDefense}, Speed {rat.ratSpeed}, Sprite {rat.ratSprite.name}");
        }
    }

    public void SetUpBattle()
    {
        RatInformation allyRat = ratDatabase.GetRatByName("Ratsoak");
        RatInformation enemyRat = ratDatabase.GetRatByName("Ratomatcho");

        allyName.text = allyRat.ratName;
        allyLevel.text = "LV. 5";
        allySprite.sprite = allyRat.ratSprite;

        enemyName.text = enemyRat.ratName;
        enemyLevel.text = "LV. 5";
        enemySprite.sprite = enemyRat.ratSprite;


    }
}
