using UnityEngine;
using System.Collections;

public class Corvus : Enemy
{
    private float delayBeforeBoost = 7f;
    private float damageMultiplierBoost = 2f;
    private bool abilityActive = false;

    private float DamageMultiplierBoost
    {
        get { return damageMultiplierBoost; }
        set { damageMultiplierBoost = value; }
    }

    protected override void Start()
    {
        base.Start();
        StartCoroutine(ActivateDamageBoostAfterDelay());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.TakeDamage(BaseDamage);
            Debug.Log(gameObject.name + " se ha golpeado a sí mismo por " + BaseDamage + " de daño.");
        }
    }

    private IEnumerator ActivateDamageBoostAfterDelay()
    {
        Debug.Log("Corvus puede doblar su daño, estate atento");

        yield return new WaitForSeconds(delayBeforeBoost);

        if (!abilityActive)
        {
            BaseDamage *= damageMultiplierBoost;
            abilityActive = true;
            Debug.Log("CUIDADO, CORVUS AUMENTO SU DAÑO. Daño Actual: " + DamageAmount);
        }
    }

    protected override void Morir()
    {
        Debug.Log("¡Corvus ha muerto y dropeó su Lanza!");
        base.Morir();
    }


    public void Initialize(float initialDamageMultiplier, float delay)
    {
        delayBeforeBoost = delay;
    }

    public override void ApplyBuff(Entity target)
    {
        Debug.Log("Corvus recibió un buff (no implementado).");
    }
}