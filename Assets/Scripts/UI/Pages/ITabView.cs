using System;

public interface ITabView
{
    event Action TabOpened;
    event Action TabClosed;

    void Show();
    void Hide();
}
