using System;
using Zenject;

public class BaseTabPresenter : IInitializable, IDisposable
{
    private readonly ITabView _tabView;

    public BaseTabPresenter(ITabView tabView)
    {
        _tabView = tabView;
    }

    public void Initialize()
    {
        _tabView.TabOpened += TabView_OnTabOpened;
        _tabView.TabClosed += TabView_OnTabClosed;
    }

    public void Dispose()
    {
        _tabView.TabOpened -= TabView_OnTabOpened;
        _tabView.TabClosed -= TabView_OnTabClosed;
    }

    protected virtual void TabView_OnTabOpened()
    {
    }

    protected virtual void TabView_OnTabClosed()
    {
    }
}
