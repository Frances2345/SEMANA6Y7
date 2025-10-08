using UnityEngine;

public abstract class Entity : MonoBehaviour, IDamageable, IBuffeable
{

    [SerializeField] private float maxHealth = 100f;
    [SerializeField] protected float Speed = 5f;
    [SerializeField] private float baseDamage = 10f;

    private float health;

    public float MaxHealth
    {
        get { return maxHealth; }
        protected set { maxHealth = value; }
    }

    public float CurrentHealth
    {
        get { return health; }
        protected set { health = value; }
    }

    public float BaseDamage
    {
        get { return baseDamage; }
        protected set { baseDamage = value; }
    }

    protected virtual void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public virtual void TakeDamage(float amount)
    {
        if (amount >= 0)
        {
            CurrentHealth -= amount;
            Debug.Log("Recibio " + amount + " de daño");
        }
        else
        {
            return;
        }

        if (CurrentHealth <= 0)
        {
            Morir();
        }
    }

    protected virtual void Morir()
    {
        Debug.Log(gameObject.name + " ha muerto");
        Destroy(gameObject);
    }

    public abstract void ApplyBuff(Entity target);


    public virtual void SpeedBuff(float boost, float duration)
    {
        Debug.Log("Se Aplico un Buff de Velocidad");
    }

    public virtual void AttackBuff(float boost, float duration)
    {
        Debug.Log("Se Aplico ira imparable, Daño Aumentado");
    }

    public virtual void HealthBuff(float boost)
    {
        Debug.Log("Se Aplico una regneración instantanea");
    }
}