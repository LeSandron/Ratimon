using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParty : MonoBehaviour
{

    public List<RatInformation> Party { get; private set; }
    private RatDatabase ratDatabase;


    // Start is called before the first frame update
    void Start()
    {
        Party = new List<RatInformation>();
        ratDatabase = new RatDatabase();

        //AddPartyRat("Ratbat");
        //AddPartyRat("Ratsoak");
        //AddPartyRat("Rattack");
    }

    public void AddPartyRat(string ratInformation)
    {
        if (Party.Count < 6)
        {
            RatInformation chosenRat = ratDatabase.GetRatByName(ratInformation);
            print($"Name:{chosenRat.ratName}, Hp { chosenRat.ratHp}, Attack {chosenRat.ratAttack}, Defense {chosenRat.ratDefense}, Speed {chosenRat.ratSpeed}, Sprite {chosenRat.Sprite.name}");
            Party.Add(chosenRat);
            print("Party added");
        }

        else
        {
            print("Parties full");
        }

    }

    public RatInformation FindAliveRat()
    {
        foreach (RatInformation ratInformation in Party)
        {
            if (!ratInformation.hasDied())
            {
                return ratInformation;
            }
        }
        print("You lost silly boy");
        return null;
    }

    public void DebugPartyInfo()
    {
        foreach(RatInformation ratInformation in Party)
        {
            print($"Name:{ratInformation.ratName}, Hp { ratInformation.ratMaxHp}, Attack {ratInformation.ratAttack}, Defense {ratInformation.ratDefense}, Speed {ratInformation.ratSpeed}, Sprite {ratInformation.Sprite.name}");
        }
    }

    public void healParty()
    {
        foreach(RatInformation ratInformation in Party)
        {
            ratInformation.ratMaxHp = ratInformation.ratHp * 2;
        }
    }
}
