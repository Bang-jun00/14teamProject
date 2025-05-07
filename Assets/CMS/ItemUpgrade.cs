using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUpgrade : MonoBehaviour
{
    public ItemData data;
    public int level;
    public Axe axe;

    Image icon;
    Text textLevel1;

    private void Awake()
    {
       
        Image[] images = GetComponentsInChildren<Image>();
        if (images.Length > 1)
        {
            icon = images[1]; // 2번째 Image (Index 1)
            icon.sprite = data.itemIcon;
        }
        else
        {
            Debug.LogWarning($"[ItemUpgrade] Image가 2개 이상 필요합니다. 현재 개수: {images.Length}");
        }

        
        Text[] texts = GetComponentsInChildren<Text>();
        if (texts.Length > 0)
        {
            textLevel1 = texts[0];
        }
        else
        {
            Debug.LogWarning("[ItemUpgrade] Text 컴포넌트가 없습니다.");
        }
    }

    private void LateUpdate()
    {
        if (textLevel1 != null)
        {
            textLevel1.text = "LV." + (level + 1);
        }
        else
        {
            Debug.LogWarning("[ItemUpgrade] textLevel1이 null입니다.");
        }
    }
}
