using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DogBreedCardView : MonoBehaviour, IPointerClickHandler
{
    public event Action Click;

    [SerializeField] private Text idText;
    [SerializeField] private Text nameText;
    [SerializeField] private Image loadingImage;

    public void SetData(string id, string name)
    {
        idText.text = id;
        nameText.text = name;
    }

    public void SetLoading(bool isLoading)
    {
        loadingImage.enabled = isLoading;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Click?.Invoke();
    }
}
