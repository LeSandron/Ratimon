using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatInformation
{

    public string ratName { get; set; }
    public int ratHp { get; set; }
    public int ratMaxHp { get; set; }
    public int ratAttack { get; set; }
    public int ratDefense { get; set; }
    public int ratSpeed { get; set; }
    public Sprite Sprite { get; set; }


    public bool hasDied()
    {
        return ratMaxHp <= 0;
    }

    public void DealDamage(int damage)
    {
        if(damage <= 0)
        {
            damage = 1;
        }
        ratMaxHp -= damage * 1/2 + 5;
        if (ratMaxHp <= 0)
        {
            ratMaxHp = 0;
        
        }

    }
    public void HealRat()
    {
        ratMaxHp = ratHp * 2;
    }

    public int CalculateDamage(RatInformation attacker, RatInformation defender)
    {

        return ((attacker.ratAttack - defender.ratDefense/2));
    }
}


