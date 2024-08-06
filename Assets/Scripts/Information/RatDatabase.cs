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
        Rats.Add(new RatInformation { ratName = "Ratomatcho", ratHp = 25, ratAttack = 25, ratDefense = 25, ratSpeed = 25, Sprite = Resources.Load<Sprite>("Sprites/Ratomatcho") });
        Rats.Add(new RatInformation { ratName = "Ratsoak", ratHp = 35, ratAttack = 40, ratDefense = 55, ratSpeed = 15, Sprite = Resources.Load<Sprite>("Sprites/Ratsoak") });
    }

    public RatInformation GetRatByName(string name)
    {
        return Rats.Find(p => p.ratName == name);
    }
}
