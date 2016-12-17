using UnityEngine;
using System.Collections;

public class KnapsackRoleEquip : MonoBehaviour {

    private UISprite _sprite;
    private InventoryItem it;


    //在需要 修改sprite再获取component
    private UISprite Sprite
    {
        get
        {
            if (_sprite == null)
            {
                _sprite = this.GetComponent<UISprite>();
            }
            return _sprite;
        }
    }

    public void SetId(int id)
    {

        Inventory inventory = null;
        bool isExist = InventoryManager._instance.inventoryDict.TryGetValue(id, out inventory);
        
        if (isExist)
        {
            Sprite.spriteName = inventory.ICON;
        }
    }

}
