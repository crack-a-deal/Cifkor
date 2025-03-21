using System.Collections.Generic;
using UnityEngine;

public class TabGroupView : MonoBehaviour
{
    [SerializeField] private List<TabItem> tabItems;

    public List<TabItem> TabItems => tabItems;
}
