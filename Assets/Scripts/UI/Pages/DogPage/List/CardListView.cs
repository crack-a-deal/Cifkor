using System.Collections.Generic;
using UnityEngine;

public class CardListView : MonoBehaviour
{
    [SerializeField] private Transform contentContainer;
    [SerializeField] private DogBreedCardView cardView;

    private List<DogBreedCardView> _items = new List<DogBreedCardView>();


    public DogBreedCardView SpawnItem()
    {
        DogBreedCardView view = Instantiate(cardView, contentContainer);
        _items.Add(view);
        return view;
    }

    public void ClearList()
    {
        foreach (var item in _items)
        {
            Destroy(item.gameObject);
        }

        _items.Clear();
    }
}
