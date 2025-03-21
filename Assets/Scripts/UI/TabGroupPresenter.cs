using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class TabGroupPresenter : IInitializable, IDisposable
{
    private readonly List<TabItem> _tabItems;
    private readonly TabGroupView _tabGroupView;

    private readonly Dictionary<TabButton, BaseTabView> keyValuePairs;
    private BaseTabView _currentTab;

    public TabGroupPresenter(TabGroupView tabGroupView)
    {
        _tabGroupView = tabGroupView;

        _tabItems = tabGroupView.TabItems;
        keyValuePairs = _tabItems.ToDictionary(x => x.TabButton, y => y.PageView);
    }

    public void Initialize()
    {
        _currentTab = _tabItems[0].PageView;
        _currentTab.Show();

        foreach (TabItem item in _tabItems)
        {
            item.TabButton.TabSelected += TabButton_OnTabSelected;
        }
    }

    public void Dispose()
    {
        foreach (TabItem item in _tabItems)
        {
            item.TabButton.TabSelected -= TabButton_OnTabSelected;
        }
    }

    private void TabButton_OnTabSelected(TabButton button)
    {
        if (_currentTab != null)
        {
            _currentTab.Hide();
        }

        _currentTab = keyValuePairs[button];
        _currentTab.Show();
    }
}
