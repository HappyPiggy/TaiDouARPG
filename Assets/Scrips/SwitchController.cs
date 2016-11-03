using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour
{


    public TweenScale startPanel;
    public TweenScale loginPanel;
    public TweenScale registerPanel;

    public UIInput UserNameInputLogin;
    public UIInput UserPwdInputLogin;
    public UILabel UserNameLabelStart;

    private  float waitSec =0.4f;
    private static string userName;
    private static string userPwd;


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
        
    }


    //延时隐藏
    IEnumerator HiderObj(GameObject go)
    {
        yield return new WaitForSeconds(waitSec);
        go.SetActive(false);
    }
}
