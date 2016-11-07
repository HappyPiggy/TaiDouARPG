using UnityEngine;
using System.Collections;

public class StartController : MonoBehaviour
{


    public TweenScale startPanel;
    public TweenScale loginPanel;
    public TweenScale registerPanel;
    public TweenScale serverPanel;
    public TweenPosition  characterDisPlayPanel;
    public TweenPosition characterSelectPanel;


    public UIInput UserNameInputLogin;
    public UIInput UserPwdInputLogin;
    public UILabel UserNameLabelStart;
    public UILabel ServerLabelStart;
    public UILabel CharacterNameLabelCP;
    public UILabel CharacterLvLabelCP;
    public UIInput inputNameCSP;

    public UIGrid serverListGrid;
    public GameObject redServer;
    public GameObject greenServer;
    public GameObject currentServer;

    public GameObject[] characterArray;
    public GameObject[] characterDisplayArray;

    public Transform ModelPos;


    private  float waitSec =0.4f;

    private static string userName;
    private static string userPwd;
    private static ServerProperty sp;
    private GameObject currentCharacter;

    public static StartController _instance;

   

    void Awake()
    {
        _instance = this;
    }


    void Start()
    {
        InitServerList();
    }


    void InitServerList()
    {
        //TODO
        //读取游戏服务器个数 动态加载服务器列表


        //模拟  假设有20个服务器
        for (int i = 0; i < 20; i++)
        {
            //模拟随机生成每个区信息
            string ip = "127.0.0.1:8080";
            string name = i + 1 + "区 南三食堂";
            int count = Random.Range(0, 100);


            //每个go都是代表一个服务器
            GameObject go = null;

            if (count > 50)
            {
                //火爆
                go = NGUITools.AddChild(serverListGrid.gameObject, redServer);
            }
            else
            {
                //流畅
                go = NGUITools.AddChild(serverListGrid.gameObject, greenServer);
            }

            ServerProperty sp = go.GetComponent<ServerProperty>();
            sp.ip = ip;
            sp.name = name;
            sp.count = count;

            serverListGrid.AddChild(go.transform);
        }


        
    }

    public void OnChangeCharacterBtnClick()
    {
        characterDisPlayPanel.PlayReverse();
        StartCoroutine(HiderObj(characterDisPlayPanel.gameObject));

        characterSelectPanel.gameObject.SetActive(true);
        characterSelectPanel.PlayForward();
    }

    public void OnReturnBtnCharacterClick()
    {


        characterSelectPanel.PlayReverse();
        StartCoroutine(HiderObj(characterSelectPanel.gameObject));

        characterDisPlayPanel.gameObject.SetActive(true);
        characterDisPlayPanel.PlayForward();
    }

    public void OnSureBtnCharacterClick()
    {
        //TODO
        //服务器验证姓名
        //验证是否选择了角色


        //记录姓名 等级 人物模型
        CharacterNameLabelCP.text = inputNameCSP.value;
        CharacterLvLabelCP.text = "lv.1";

       for (int i = 0; i < characterArray.Length; i++)
        {
          
           // print(currentCharacter);
           // print(characterArray[1]);
          if (currentCharacter == characterArray[i])
            {
               // print("123");
                //删除人物界面原有人物模型
                Destroy(ModelPos.GetComponentInChildren<Animation>().gameObject);
                //实例化人物模型到 人物显示界面
                GameObject go = Instantiate(characterDisplayArray[i], Vector3.zero, Quaternion.identity) as GameObject;
                go.transform.SetParent(ModelPos);
                go.transform.localPosition=Vector3.zero;
                go.transform.localRotation=Quaternion.identity;
                go.transform.localScale=Vector3.one;

               break;

           }

      }



        //切换到人物显示界面
        OnReturnBtnCharacterClick();
    }


    public void OnCharacterSelected(GameObject go)
    {
        if(go==currentCharacter)
            return;
    
        iTween.ScaleTo(go, new Vector3(1.2f,1.2f,1.2f), 0.5f);
        if (currentCharacter != null)
        {

            iTween.ScaleTo(currentCharacter, new Vector3(1f, 1f, 1f), 0.5f);
        }
        currentCharacter = go;
    }

    public void OnEnterGameBtnClick()
    {
        //TODO
        //连接服务器

        //切换到角色选择界面
        startPanel.PlayForward();
        StartCoroutine(HiderObj(startPanel.gameObject));

        characterDisPlayPanel.gameObject.SetActive(true);
        characterDisPlayPanel.PlayForward();
        
    }

    public void OnServerSelected(GameObject go)
    {
        sp = go.GetComponent<ServerProperty>();

        //修改当前服务器的 sprite 和name为 选中服务器
        currentServer.GetComponent<UISprite>().spriteName = go.GetComponent<UISprite>().spriteName;
        currentServer.transform.FindChild("Label").GetComponent<UILabel>().text = sp.name;
    }

    public void OnCurrentServerBtnClick()
    {
        //切换为start界面
        serverPanel.PlayReverse();
        StartCoroutine(HiderObj(serverPanel.gameObject));

        startPanel.gameObject.SetActive(true);
        startPanel.PlayReverse();


        //服务器label更新
        ServerLabelStart.text = sp.name;
    }

    public void OnLoginBtnClick()
    {

        //记录账号密码 
        userName = UserNameInputLogin.value;
        userPwd = UserPwdInputLogin.value;


        //TODO
        //登录验证


        //跳转到开始界面
        UserNameLabelStart.text = userName;

        loginPanel.PlayReverse();
        StartCoroutine(HiderObj(loginPanel.gameObject));

        startPanel.gameObject.SetActive(true);
        startPanel.PlayReverse();
    }

    public void OnLoginRegisterBtnClick()
    {
        loginPanel.PlayReverse();
        StartCoroutine(HiderObj(loginPanel.gameObject));

        registerPanel.gameObject.SetActive(true);
        registerPanel.PlayForward();
    }

    public void OnLoginCloseBtnClick()
    {
        loginPanel.PlayReverse();
        StartCoroutine(HiderObj(loginPanel.gameObject));

        startPanel.gameObject.SetActive(true);
        startPanel.PlayReverse();
    }

    public void OnUserNameClick()
    {
        startPanel.PlayForward();
        StartCoroutine(HiderObj(startPanel.gameObject));

        loginPanel.gameObject.SetActive(true);
        loginPanel.PlayForward();
    }


    public void OnRegisterCloseBtnClick()
    {
        registerPanel.PlayReverse();
        StartCoroutine(HiderObj(registerPanel.gameObject));

        startPanel.gameObject.SetActive(true);
        startPanel.PlayReverse();
    }

    public void OnRegisterCancleBtnClick()
    {
        registerPanel.PlayReverse();
        StartCoroutine(HiderObj(registerPanel.gameObject));

        loginPanel.gameObject.SetActive(true);
        loginPanel.PlayForward();
    }


    public void OnRegisterAndLoginBtnClick()
    {
        //TODO
        //本地验证密码是否相同
        //加入数据库

        //进入登录界面
        registerPanel.PlayReverse();
        StartCoroutine(HiderObj(registerPanel.gameObject));
        loginPanel.gameObject.SetActive(true);
        loginPanel.PlayForward();
    }

    public void OnServceNameClick()
    {
        startPanel.PlayForward();
        StartCoroutine(HiderObj(startPanel.gameObject));

        serverPanel.gameObject.SetActive(true);
        serverPanel.PlayForward();
    }


    //延时隐藏
    IEnumerator HiderObj(GameObject go)
    {
        yield return new WaitForSeconds(waitSec);
        go.SetActive(false);
    }
}
