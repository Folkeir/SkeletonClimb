
using System.Collections.Generic;
using UnityEngine;

public class FoliageManager : MonoBehaviour
{
    [SerializeField] private Material foliageMaterial;

    private List<InputMan> players = new List<InputMan>();

    public void AddPlayerToGrassList(InputMan player)
    {
        if (player == null) return;

        if (!players.Contains(player))
        {
            players.Add(player);
        }
    }

    public void RemovePlayerFromGrassList(InputMan player)
    {
        players.Remove(player);
    }

    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            string propertyName = $"_p{i + 1}Position";

            Vector3 position = Vector3.zero;

            if (i < players.Count && players[i] != null)
            {
                position = players[i].transform.position;
            }

            foliageMaterial.SetVector(propertyName, position);
        }
    }
}