using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatDatabase
{
    public List<RatInformation> Rats { get; private set; }

    public RatDatabase()
    {
        Rats = new List<RatInformation>();
        InitializeDatabase();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeDatabase()
    {
        Rats.Add(new RatInformation { ratName = "Ratomatcho", ratHp = 25,ratMaxHp = 25*2, ratAttack = 25, ratDefense = 25, ratSpeed = 25, Sprite = Resources.Load<Sprite>("Sprites/Ratomatcho") });
        Rats.Add(new RatInformation { ratName = "Ratsoak", ratHp = 35,ratMaxHp=35*2, ratAttack = 40, ratDefense = 55, ratSpeed = 15, Sprite = Resources.Load<Sprite>("Sprites/Ratsoak") });

        Rats.Add(new RatInformation { ratName = "Rattack", ratHp = 35,ratMaxHp=35*2, ratAttack = 60, ratDefense = 20, ratSpeed = 25, Sprite = Resources.Load<Sprite>("Sprites/Rattack") });
        Rats.Add(new RatInformation { ratName = "Ratbat", ratHp = 45,ratMaxHp=45*2, ratAttack = 20, ratDefense = 75, ratSpeed = 10, Sprite = Resources.Load<Sprite>("Sprites/Ratbat") });
    }

    public RatInformation GetRatByName(string name)
    {
        return Rats.Find(p => p.ratName == name);
    }
}
