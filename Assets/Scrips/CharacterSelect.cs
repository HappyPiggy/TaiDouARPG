using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour {


    //NGUI 提供   按下ispress为真  放开为假 
    void OnPress(bool isPress)
    {
        if (!isPress)
        {
            StartController._instance.OnCharacterSelected(gameObject);
        }
    }
}
