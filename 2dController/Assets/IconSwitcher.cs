using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconSwitcher : MonoBehaviour
{
    [SerializeField] private List<SwitchableItem> switchableItems;

    private void Awake()
    {
        switchableItems[0].switchButton.onClick.AddListener(() => SwitchIcon(0));
        switchableItems[1].switchButton.onClick.AddListener(() => SwitchIcon(1));
        switchableItems[2].switchButton.onClick.AddListener(() => SwitchIcon(2));

        // Initially hide all icons
        foreach (var item in switchableItems)
        {
            item.Icon.SetActive(false);
        }
    }

    private void SwitchIcon(int switchId)
    {
        for (int i = 0; i < switchableItems.Count; i++)
        {
            switchableItems[i].Icon.SetActive(i == switchId);
        }
    }
}

[Serializable]
public class SwitchableItem
{
    [field: SerializeField] public Button switchButton { get; private set; }
    [field: SerializeField] public GameObject Icon { get; private set; }
}