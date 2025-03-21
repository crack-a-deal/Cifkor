using UnityEngine;
using UnityEngine.UI;

public class PopupView : MonoBehaviour
{
    [SerializeField] private Text title;
    [SerializeField] private Text description;
    [SerializeField] private Button closeButton;

    private void OnEnable()
    {
        closeButton.onClick.AddListener(Hide);
    }

    private void OnDisable()
    {
        closeButton.onClick.RemoveListener(Hide);
    }

    public void SetTitle(string titleText)
    {
        title.text = titleText;
    }

    public void SetDescription(string descriptionText)
    {
        description.text = descriptionText;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
