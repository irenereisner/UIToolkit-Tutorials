using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public class PlayerData
{
    public string Name;
    public Texture2D Portrait;
    public int Points;

    [NonSerialized, CreateProperty]
    public int Position;
}


public class Leaderboard : MonoBehaviour
{
    [SerializeField]
    List<PlayerData> m_players;


    void OnEnable()
    {
        m_players = m_players.OrderByDescending(x => x.Points).ToList();
        for (int i = 0; i < m_players.Count; i++)
        {
            m_players[i].Position = i + 1;
        }

        FillListView();
    }


    void FillListView()
    {
        var uiDocument = GetComponent<UIDocument>();
        var listView = uiDocument.rootVisualElement.Q<ListView>("leaderboard");


        listView.bindItem = (item, index) =>
        {
            item.dataSource = m_players[index];
        };
        listView.itemsSource = m_players;
    }
}
