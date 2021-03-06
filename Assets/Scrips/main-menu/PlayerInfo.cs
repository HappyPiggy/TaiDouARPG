﻿using UnityEngine;
using System.Collections;

public enum InfoType {
    Name,
    HeadPortrait,
    Level,
    Power,
    Exp,
    Diamond,
    Coin,
    Energy,
    Toughen,
    HP,
    Damage,
    Equip,
    All
}

public class PlayerInfo : MonoBehaviour {

    public static PlayerInfo _instance;


    #region property

    private string _name;
    private string _headPortrait;
    private int _level = 1;
    private int _power = 1;
    private int _exp = 0;
    private int _diamond;
    private int _coin;
    private int _energy;
    private int _toughen;
    private int _hp;
    private int _damage;
    #endregion

    public float energyTimer = 0;
    public float toughenTimer = 0;


    //c#委托与事件
    public delegate void OnPlayerInfoChangedEvent( InfoType type );
    public event OnPlayerInfoChangedEvent   OnPlayerInfoChanged;

    #region get set method
    public string Name {
        get {
            return _name;
        }
        set {
            _name = value;
        }
    }
    public string HeadPortrait {
        get {
            return _headPortrait;
        }
        set {
            _headPortrait = value;
        }
    }
    public int Level {
        get {
            return _level;
        }
        set {
            _level = value;
        }
    }
    public int Power {
        get {
            return _power;
        }
        set {
            _power = value;
        }
    }
    public int Exp {
        get {
            return _exp;
        }
        set {
            _exp = value;
        }
    }
    public int Diamond {
        get {
            return _diamond;
        }
        set {
            _diamond = value;
        }
    }
    public int Coin {
        get {
            return _coin;
        }
        set {
            _coin = value;
        }
    }
    public int Energy {
        get {
            return _energy;
        }
        set {
            _energy = value;
        }
    }
    public int Toughen {
        get {
            return _toughen;
        }
        set {
            _toughen = value;
        }
    }

    public int HP
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
        }
    }
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    #endregion
    #region unity event
    void Awake() {
        _instance = this;
    }

    void Start() {
        Init();
    }

    void Update() {
        //实现体力和历练的自动增长
        if (this.Energy < 100) {
            energyTimer += Time.deltaTime;
            if (energyTimer > 60) {
                Energy += 1;
                energyTimer -= 60;
                OnPlayerInfoChanged(InfoType.Energy);
            }
        } else {
            this.energyTimer = 0;
        }
        if (this.Toughen < 50) {
            toughenTimer += Time.deltaTime;
            if (toughenTimer > 60) {
                Toughen += 1;
                toughenTimer -= 60;
                OnPlayerInfoChanged(InfoType.Toughen);
            }
        } else {
            toughenTimer = 0;
        }

    }
    #endregion

    void Init() {
        this.Coin = 9870;
        this.Diamond = 1234;
        this.Energy = 78;
        this.Exp = 123;
        this.HeadPortrait = "头像底板女性";
        this.Level = 12;
        this.Name="千颂伊";
        this.Toughen = 34;

        InitHPDamagePower();
        OnPlayerInfoChanged( InfoType.All );
    }

    void InitHPDamagePower()
    {
        this.HP = this.Level * 100;
        this.Damage = this.Level * 50;
        this.Power = this.HP + this.Damage;


        //测试 人物穿上equip后的加能力效果
        PutoffEquip(1001);
        PutoffEquip(1002);
    }


    void PutonEquip(int id)
    {
        if (id == 0) return;
        Inventory inventory = null;
        bool isExit = InventoryManager._instance.inventoryDict.TryGetValue(id, out inventory);

        this.HP += inventory.HP;
        this.Damage += inventory.Damage;
        this.Power += inventory.Power;
    }
    void PutoffEquip(int id)
    {
        if (id == 0) return;
        Inventory inventory = null;
        InventoryManager._instance.inventoryDict.TryGetValue(id, out inventory);
        this.HP -= inventory.HP;
        this.Damage -= inventory.Damage;
        this.Power -= inventory.Power;
    }


    public void ChangeName(string newname)
    {
        Name = newname;
        OnPlayerInfoChanged(InfoType.Name);
    }

}
