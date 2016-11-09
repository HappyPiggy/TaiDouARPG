using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour
{
#region property

    private string _name;
    private string _headPortrait;
    private int _level;
    private int _power;
    private int _exp;
    private int _diamond;
    private int _coin;
    private int _energy;
    private int _toughen;

#endregion

    private float energyTimer = 0;
    private float toughenTimer = 0;

    public static PlayerInfo _instance; 

#region 属性

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string HeadPortrait
    {
        get { return _headPortrait; }
        set { _headPortrait = value; }
    }

    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }

    public int Power
    {
        get { return _power; }
        set { _power = value; }
    }

    public int Exp
    {
        get { return _exp; }
        set { _exp = value; }
    }

    public int Diamond
    {
        get { return _diamond; }
        set { _diamond = value; }
    }

    public int Coin
    {
        get { return _coin; }
        set { _coin = value; }
    }

    public int Energy
    {
        get { return _energy; }
        set { _energy = value; }
    }

    public int Toughen
    {
        get { return _toughen; }
        set { _toughen = value; }
    }
#endregion

    
#region unity event
    void Awake()
    {
        _instance = this;
    }

    void Update()
    {
        
        

        if (this.Energy < 100)
        {
            energyTimer += Time.deltaTime;

            if (energyTimer > 60)
            {
                Energy++;
                energyTimer = 0;
            }
        }
        else
        {
            energyTimer = 0;
        }

        if (this.Toughen < 50)
        {
            toughenTimer += Time.deltaTime;

            if (toughenTimer > 60)
            {
                Toughen++;
                toughenTimer = 0;
            }
        }
        else
        {
            toughenTimer = 0;
        }
    }
#endregion


    void InitProperty()
    {
        this.Name = "HappyPiggy";
        this.Coin = 9999;
        this.Diamond = 9999;
        this.HeadPortrait = "头像底板女性";
        this.Energy = 100;
        this.Power = 9999;
        this.Toughen = 50;
        this.Level = 2;
        this.Exp = 123;
    }
   
}
