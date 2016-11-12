using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

    private UISprite headSprite;
    private UILabel levelLabel;
    private UILabel nameLabel;
    private UILabel powerLabel;
    private UISlider expSlider;
    private UILabel expLabel;
    private UILabel diamondLabel;
    private UILabel coinLabel;
    private UILabel energyLabel;
    private UILabel energyRestorePartLabel;
    private UILabel energyRestoreAllLabel;
    private UILabel toughenLabel;
    private UILabel toughenRestorePartLabel;
    private UILabel toughenRestoreAllLabel;

    void Awake() {
        headSprite = transform.Find("HeadSprite").GetComponent<UISprite>();
        levelLabel = transform.Find("LevelLabel").GetComponent<UILabel>();
        nameLabel = transform.Find("NameLabel").GetComponent<UILabel>();
        powerLabel = transform.Find("PowerLabel").GetComponent<UILabel>();
        expSlider = transform.Find("ExpProgressBar").GetComponent<UISlider>();
        expLabel = transform.Find("ExpProgressBar/Label").GetComponent<UILabel>();
        diamondLabel = transform.Find("DiamondLabel/Label").GetComponent<UILabel>();
        coinLabel = transform.Find("CoinLabel/Label").GetComponent<UILabel>();
        energyLabel = transform.Find("EnergyLabel/NumLabel").GetComponent<UILabel>();
        energyRestorePartLabel = transform.Find("EnergyLabel/RestorePartTime").GetComponent<UILabel>();
        energyRestoreAllLabel = transform.Find("EnergyLabel/RestoreAllTime").GetComponent<UILabel>();
        toughenLabel = transform.Find("ToughenLabel/NumLabel").GetComponent<UILabel>();
        toughenRestorePartLabel = transform.Find("ToughenLabel/RestorePartTime").GetComponent<UILabel>();
        toughenRestoreAllLabel = transform.Find("ToughenLabel/RestoreAllTime").GetComponent<UILabel>();

        PlayerInfo._instance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;
    }
    void Update() {
        UpdateEnergyAndToughenShow();//更新体力和历练恢复时间的计时器
    }
    void OnDestroy() {
        PlayerInfo._instance.OnPlayerInfoChanged -= this.OnPlayerInfoChanged;
    }

    void OnPlayerInfoChanged(InfoType type) {
        UpdateShow();
    }

    void UpdateShow() {
        PlayerInfo info = PlayerInfo._instance;
        headSprite.spriteName = info.HeadPortrait;
        levelLabel.text = info.Level.ToString();
        nameLabel.text = info.Name.ToString();
        powerLabel.text = info.Power.ToString();
        int requireExp = GameController.GetRequireExpByLevel(info.Level + 1);
        expSlider.value = (float)info.Exp / requireExp;
        expLabel.text = info.Exp + "/" + requireExp;
        diamondLabel.text = info.Diamond.ToString();
        coinLabel.text = info.Coin.ToString();

        UpdateEnergyAndToughenShow();//更新体力和历练的显示
    }


    void UpdateEnergyAndToughenShow() {
       // print("test");
        PlayerInfo info = PlayerInfo._instance;
        energyLabel.text = info.Energy + "/100";
        if (info.Energy >= 100) {
            energyRestorePartLabel.text = "00:00:00";
            energyRestoreAllLabel.text = "00:00:00";
        } else {
            int remainTime = 60 - (int)info.energyTimer;
            string str = remainTime <= 9 ? "0" + remainTime : remainTime.ToString();
            energyRestorePartLabel.text = "00:00:" + str;

            //首先总的体力为100 其中一个体力是在最后的00表示 
            int minutes = 99 - info.Energy;
            int hours = minutes / 60;
            minutes = minutes % 60;
            string hoursStr = hours <= 9 ? "0" + hours : hours.ToString();
            string minutesStr = minutes <= 9 ? "0" + minutes : minutes.ToString();
            energyRestoreAllLabel.text = hoursStr + ":" + minutesStr + ":" + str;
        }

        toughenLabel.text = info.Toughen + "/50";
        if (info.Toughen >= 50) {
            toughenRestorePartLabel.text = "00:00:00";
            toughenRestoreAllLabel.text = "00:00:00";
        } else {
            int remainTime = 60 - (int)info.toughenTimer;
            string str = remainTime <= 9 ? "0" + remainTime : remainTime.ToString();
            toughenRestorePartLabel.text = "00:00:" + str;

            //首先总的历练为50 最后的两个零使用了一个历练
            int minutes = 49 - info.Toughen;
            int hours = minutes / 60;
            minutes = minutes % 60;
            string hoursStr = hours <= 9 ? "0" + hours : hours.ToString();
            string minutesStr = minutes <= 9 ? "0" + minutes : minutes.ToString();
            toughenRestoreAllLabel.text = hoursStr + ":" + minutesStr + ":" + str;
        }
    }
}
