using Baruah;
using Baruah.Config;
using Baruah.Service;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

public class NavigationCardSelector : MonoBehaviour
{
    public static NavigationCardSelector Instance;

    [SerializeField] private RectTransform panel;

    private List<string> unusedCards = new List<string>();
    private List<string> discardCards = new List<string>();
    private NavigatinCardConfig navigatinCardConfig;

    private void Start()
    {
        Instance = this;
        navigatinCardConfig = ServiceManager.Get<ConfigService>().Get<NavigatinCardConfig>();

        InitializeCards();
    }

    public void RemoveCards()
    {
        foreach (Transform card in panel)
        {
            Destroy(card.gameObject);
        }
    }

    public void GenerateCards()
    {
        RemoveCards();
        SpawnRandomCard();
        SpawnRandomCard();
    }

    private void SpawnRandomCard()
    {
        var cardData = GetRandomCard();

        if (ServiceManager.Get<ConfigService>().Get<NavigationCardsConfig>().Data.TryGetValue(cardData.navigationDirection, out var cardDirection))
        {
            var card = Instantiate(cardDirection.cards, panel);
            Debug.Log(cardData.ID);
            card.SetCardData(cardData);
        }
    }

    public void InitializeCards()
    {
        var cardInfos = navigatinCardConfig.data;
        foreach (var cardInfo in cardInfos)
        {
            for (int index = 0; index < cardInfo.count; index++)
            {
                unusedCards.Add(cardInfo.ID);
            }
        }
        discardCards.Clear();
        GenerateCards();
    }

    public NavigatinCardConfigData GetRandomCard()
    {
        int index = UnityEngine.Random.Range(0, unusedCards.Count - 1);
        if (navigatinCardConfig.Data.TryGetValue(unusedCards[index], out var card))
        {
            discardCards.Add(unusedCards[index]);
            unusedCards.RemoveAt(index);
            return card;
        }

        return null;
    }
}
