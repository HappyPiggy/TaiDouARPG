using UnityEngine;
using System.Collections;

public class StartController : MonoBehaviour
{


    public TweenScale startPanel;
    public TweenScale loginPanel;
    public TweenScale registerPanel;
    public TweenScale serverPanel;


    public UIInput UserNameInputLogin;
    public UIInput UserPwdInputLogin;
    public UILabel UserNameLabelStart;
    public UILabel ServerLabelStart;

    public UIGrid serverListGrid;
    public GameObject redServer;
    public GameObject greenServer;
    public GameObject currentServer;

    private  float waitSec =0.4f;

    private static string userName;
    private static string userPwd;
    private static ServerProperty sp;


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
