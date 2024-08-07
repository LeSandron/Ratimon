using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST,}

public class BattleSystem : MonoBehaviour
{
    private RatDatabase ratDatabase;
    public BattleState state;

    public Image allySprite, enemySprite;
    public TextMeshProUGUI allyName, enemyName, allyLevel, enemyLevel,dialogueTEXT;
    public Button attack, run;
    public GameObject encounter;

    
    // Start is called before the first frame update
    void Start()
    {
        ratDatabase = new RatDatabase();
        state = BattleState.START;
        

        DebugStats("Ratsoak");
        DebugStats("Ratomatcho");
     

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
            print($"Name:{rat.ratName}, Hp { rat.ratHp}, Attack {rat.ratAttack}, Defense {rat.ratDefense}, Speed {rat.ratSpeed}, Sprite {rat.Sprite.name}");
        }
    }

    IEnumerator SetUpBattle()
    {
        RatInformation allyRat = ratDatabase.GetRatByName("Ratsoak");
        RatInformation enemyRat = ratDatabase.GetRatByName(encounter.GetComponent<RandomEncounters>().chosenRat);

        dialogueTEXT.text = "A wild " + enemyRat.ratName + " Has appeared!";

        allyName.text = allyRat.ratName;
        allyLevel.text = "LV. 5";
        allySprite.sprite = allyRat.Sprite;

        enemyName.text = enemyRat.ratName;
        enemyLevel.text = "LV. 5";
        enemySprite.sprite = enemyRat.Sprite;

        if(allyRat.ratSpeed > enemyRat.ratSpeed)
        {
            print("Player is faster");
            state = BattleState.PLAYERTURN;

            yield return new WaitForSeconds(2);
            dialogueTEXT.text = "Players turn, Choose an Action";

            playerTurn();
        }
        else if(allyRat.ratSpeed < enemyRat.ratSpeed)
        {
            print("Enemy is faster");
            state = BattleState.ENEMYTURN;

            yield return new WaitForSeconds(2);
            dialogueTEXT.text = "Enemies Turn!";

            enemyTurn();
        }
        else if(allyRat.ratSpeed == enemyRat.ratSpeed)
        {
            print("speeds are the same, doing a coin flip");
            if(UnityEngine.Random.Range(0,100) <= 50)
            {
                state = BattleState.PLAYERTURN;
                print("player won the coin flip");

                yield return new WaitForSeconds(2);
                dialogueTEXT.text = "Players turn, Choose an Action";

                playerTurn();
            }
            else
            {
                state = BattleState.ENEMYTURN;
                print("Enemy won the coin flip");

                yield return new WaitForSeconds(2);
                dialogueTEXT.text = "Enemies Turn!";

                enemyTurn();
            }
        }




    }

    public void startBattle()
    {
        StartCoroutine(SetUpBattle());
    }

    private void playerTurn()
    {

    }
    private void enemyTurn()
    {

    }
}
