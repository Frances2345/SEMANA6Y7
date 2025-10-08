using UnityEngine;

public class Ebony : Enemy
{
    private float healthRegenerationAmount = 20f;
    private float regenerationInterval = 5f;

    private float regenerationTimer = 0f;

    public float HealthRegenerationAmount
    {
        get { return healthRegenerationAmount; }
        private set { healthRegenerationAmount = value; }
    }

    protected override void Start()
    {
        base.Start();
        Debug.Log("Ebony se puede regenerar cada 5 seguntos, estate atento");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.TakeDamage(BaseDamage);
            Debug.Log(gameObject.name + " se ha golpeado a sí mismo por " + BaseDamage + " de daño.");
        }

        regenerationTimer += Time.deltaTime;

        if (regenerationTimer >= regenerationInterval)
        {
            Regenerate();
            regenerationTimer -= regenerationInterval;
        }
    }

    private void Regenerate()
    {
        if (CurrentHealth > 0 && CurrentHealth < MaxHealth)
        {
            CurrentHealth += HealthRegenerationAmount;

            if (CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
            Debug.Log("Ebony se curó " + HealthRegenerationAmount + " de vida. " + CurrentHealth);
        }
    }

    protected override void Morir()
    {
        Debug.Log("¡Ebony ha muerto y dropeó un ítem!");
        base.Morir();
    }

    public void Initialize(float initialDamageMultiplier, float regeneration, float interval)
    {
        HealthRegenerationAmount = regeneration;
        regenerationInterval = interval;
    }

    public override void ApplyBuff(Entity target)
    {
        Debug.Log("Ebony recibió un buff (no implementado).");
    }
}