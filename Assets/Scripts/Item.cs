using UnityEngine;

public abstract class Item : MonoBehaviour, IConsumable
{
    public abstract void Consume(Entity entity);

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            Consume(player);
            Destroy(gameObject);
        }
    }
}