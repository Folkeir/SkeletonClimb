using UnityEngine;

public enum PickupType
{
    Coin,
    Health,
    Spell,
    PowerUp
}

public class Pickupable : MonoBehaviour
{
    [SerializeField] private PickupType pickupType;
    [SerializeField] private int value = 1;
    public void Collect(PlayerPickUp player)
    {
        switch (pickupType)
        {
            case PickupType.Coin:
                Debug.Log(player.name + " collected a coin!");
                player.AddCoin(value);
                ParticleManager.Instance.Play(transform.position,ParticleType.Coin);
                break;

            case PickupType.Health:
                Debug.Log(player.name + " collected health!");
                break;

            case PickupType.Spell:
                Debug.Log(player.name + " collected a spell!");
                break;

            case PickupType.PowerUp:
                Debug.Log(player.name + " collected a powerup!");
                break;
        }

        Destroy(gameObject);
    }
}