using UnityEngine;

[System.Serializable]
public class TabItem
{
    [SerializeField] private TabButton tabButton;
    [SerializeField] private BaseTabView pageView;

    public TabButton TabButton => tabButton;
    public BaseTabView PageView => pageView;
}
