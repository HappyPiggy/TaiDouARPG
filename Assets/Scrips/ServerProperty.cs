using UnityEngine;
using System.Collections;

public class ServerProperty : MonoBehaviour
{

    public string ip   = "127.0.0.1:8080";

    private string _name;
   // private bool isPress = false;

    public string name
    {
        set
        {
            //value为当前的name值  在别处实例化时候赋值
            transform.FindChild("Label").GetComponent<UILabel>().text = value;
            _name = value;
        }
        get { return _name; }
    }
    public int count   = 100;


    public void OnPress(bool isPress)
    {
        if (!isPress)
        {
            transform.root.SendMessage("OnServerSelected",gameObject);
        }
    }


}
