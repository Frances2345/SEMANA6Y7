using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private Player player;

    private int inventoryCount = 0;
    private int maxInventorySize = 3;

    private int buffCycleCount = 0;

    private float healthBoost = 50f;
    private float speedBoost = 5f;
    private float attackBoost = 10f;
    private float buffDuration = 10f;

    private void Start()
    {
        player = GetComponent<Player>();
        if (player == null)
        {
            Debug.LogError("No se encontro el script Player en este Game Object");
        }
        inventoryCount = maxInventorySize;

        Debug.Log(player.playerName + " tiene 3 items");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UseItem();
        }
    }

    private void UseItem()
    {
        if (inventoryCount > 0)
        {
            inventoryCount--;
            buffCycleCount++;

            ApplyBuff();
            Debug.Log(player.playerName + " uso un item. Te quedan " + inventoryCount + " items");

        }
        else
        {
            Debug.Log(player.playerName + " ya no tiene nada");
        }
    }

    public void ApplyBuff()
    {
        if (buffCycleCount == 1)
        {

            player.HealthBuff(healthBoost);
            Debug.Log("Obtuviste un buff de vida, +" + healthBoost + " puntos regenerados");

        }

        else if (buffCycleCount == 2)
        {
            player.SpeedBuff(speedBoost, buffDuration);
            Debug.Log("Obtuviste un buff de velocidad, eres mas rapido por " + buffDuration + " segundos");

        }

        else if (buffCycleCount == 3)
        {
            player.AttackBuff(attackBoost, buffDuration);
            Debug.Log("Obtuviste un buff de ataque, eres mas fuerte por " + buffDuration + " segundos");
            buffCycleCount = 0;
        }
    }
}