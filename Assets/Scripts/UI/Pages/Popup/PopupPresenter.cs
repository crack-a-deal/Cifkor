public class PopupPresenter
{
    private readonly PopupView _view;

    public PopupPresenter(PopupView popupView)
    {
        _view = popupView;
    }

    public void ShowPopup(DogBreed breedData)
    {
        _view.SetTitle(breedData.Attributes.Name);
        _view.SetDescription(breedData.Attributes.Description);
        _view.Show();
    }
}
