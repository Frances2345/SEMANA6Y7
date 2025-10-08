using UnityEngine;

public class CullObsidian : Enemy
{
    private float speedBoostAmount = 15f;
    private float delayBeforeBoost = 8f;

    private float speedTimer = 0f;

    private bool abilityActive = false;

    private float SpeedBoostAmount
    {
        get { return speedBoostAmount; }
    }

    public float CurrentSpeed
    {
        get { return Speed; }
    }

    protected override void Start()
    {
        base.Start();
        Debug.Log("Cull Obsidian puede aumentar su velocidad");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.TakeDamage(BaseDamage);
            Debug.Log(gameObject.name + " se ha golpeado a sí mismo por " + BaseDamage + " de daño.");
        }

        if (abilityActive)
        {
            return;
        }

        speedTimer += Time.deltaTime;

        if (speedTimer >= delayBeforeBoost)
        {
            ActivateSpeedBoost();
        }
    }

    private void ActivateSpeedBoost()
    {
        Speed += speedBoostAmount;
        abilityActive = true;
        Debug.Log("Cull Obsidian aumento su velocidad");
    }

    protected override void Morir()
    {
        Debug.Log("¡Cull Obsidian dropeó un Trozo de Armadura Pesada!");
        base.Morir();
    }

    public void Initialize(float initialDamageMultiplier, float boost, float delay)
    {
        speedBoostAmount = boost;
        delayBeforeBoost = delay;
    }

    public override void ApplyBuff(Entity target)
    {
        Debug.Log("Cull Obsidian recibió un buff (no implementado).");
    }

}