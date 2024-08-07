using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST,}

public class BattleSystem : MonoBehaviour
{
    private RatDatabase ratDatabase;
    public PlayerParty playerParty;
    public BattleState state;

    public Image allySprite, enemySprite;
    public TextMeshProUGUI allyName, enemyName, allyLevel, enemyLevel,dialogueTEXT;
    public Button attack, run;
    public GameObject encounter;

    RatInformation allyRat;
    RatInformation enemyRat;
    private int loopCount;
    private bool playerL, enemyL;


    // Start is called before the first frame update
    void Start()
    {
        loopCount = 0;
        ratDatabase = new RatDatabase();
        state = BattleState.START;
        attack.interactable = false;
        run.interactable = false;

        playerParty.AddPartyRat("Rattack");
        playerParty.AddPartyRat("Ratbat");
        playerParty.AddPartyRat("Ratsoak");
        


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
        RatInformation allyRat = playerParty.FindAliveRat();
        RatInformation enemyRat = ratDatabase.GetRatByName(encounter.GetComponent<RandomEncounters>().chosenRat);

        DebugStats(allyRat.ratName);
        DebugStats(enemyRat.ratName);

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
            yield return new WaitForSeconds(2);
            dialogueTEXT.text = "Players turn, Choose an Action";
            state = BattleState.PLAYERTURN;
            playerTurn();

        }
        else if(allyRat.ratSpeed < enemyRat.ratSpeed)
        {
            print("Enemy is faster");
            state = BattleState.ENEMYTURN;
            enemyTurn();


        }
        else if(allyRat.ratSpeed == enemyRat.ratSpeed)
        {
            print("speeds are the same, doing a coin flip");
            if(UnityEngine.Random.Range(0,100) <= 50)
            {
                print("player won the coin flip");
                yield return new WaitForSeconds(2);
                dialogueTEXT.text = "Players turn, Choose an Action";
                state = BattleState.PLAYERTURN;
                playerTurn();
            }
            else
            { 
                print("Enemy won the coin flip");
                state = BattleState.ENEMYTURN;
                enemyTurn();
            }
        }




    }

    public void startBattle()
    {
        StartCoroutine(SetUpBattle());
    }

    public void playerTurn()
    {
        print("players turn");
        dialogueTEXT.text = "Players turn, Choose an Action";
        attack.interactable = true;
        run.interactable = true;
        
    }

    private void enemyTurn()
    {
        print("Enemies turn");
        StartCoroutine(EnemyAttack());
        enemyL = true;
    }

    IEnumerator PlayerAttack()
    {
        if(state == BattleState.PLAYERTURN)
        {
            RatInformation allyRat = playerParty.FindAliveRat();
            RatInformation enemyRat = ratDatabase.GetRatByName(encounter.GetComponent<RandomEncounters>().chosenRat);
            allySprite.sprite = allyRat.Sprite;
            attack.interactable = false;
            run.interactable = false;
            print("Ow, dont press my button!");
            enemyRat.DealDamage(enemyRat.CalculateDamage(allyRat, enemyRat));
            print(enemyRat.CalculateDamage(allyRat, enemyRat));
            yield return new WaitForSeconds(2);
            state = BattleState.ENEMYTURN;
            enemyTurn();
       
        }


    }
    IEnumerator RunAway()
    {
        print("IM RUNNING AWAY NOW!");
        attack.interactable = false;
        run.interactable = false;
        dialogueTEXT.text = "The player has fled!";
        yield return new WaitForSeconds(2);
        encounter.GetComponent<RandomEncounters>().changeState();
    }

    IEnumerator EnemyAttack()
    {
        if(state == BattleState.ENEMYTURN)
        {
            RatInformation allyRat = playerParty.FindAliveRat();
            RatInformation enemyRat = ratDatabase.GetRatByName(encounter.GetComponent<RandomEncounters>().chosenRat);
            allySprite.sprite = allyRat.Sprite;
            attack.interactable = false;
            run.interactable = false;
            yield return new WaitForSeconds(2);
            dialogueTEXT.text = "";
            dialogueTEXT.text = "Enemies Turn!";
            yield return new WaitForSeconds(2);
            dialogueTEXT.text = "";
            dialogueTEXT.text = "The " + enemyRat.ratName + " attacks!";
            int damage = allyRat.CalculateDamage(enemyRat, allyRat);
            print(enemyRat.CalculateDamage(enemyRat, allyRat));
            allyRat.DealDamage(damage);
            yield return new WaitForSeconds(2);
            dialogueTEXT.text = "";
            playerParty.DebugPartyInfo();
            state = BattleState.PLAYERTURN;
            playerTurn();
        }
        


    }
    public void onAttackButton()
    {
        StartCoroutine(PlayerAttack());
        state = BattleState.ENEMYTURN;
        playerL = true;
    }
    public void onRunButton()
    {
        StartCoroutine(RunAway());
    }
    


}
