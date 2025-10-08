using UnityEngine;

public abstract class Enemy : Entity, IAttackable, IDroppable
{

    [SerializeField] private float damageMultiplier = 1f;

    public float DamageAmount
    {
        get { return BaseDamage * damageMultiplier; }
        set { BaseDamage = value; }
    }

    protected Enemy()
    {

    }

    public void Initialize(float initialDamageMultiplier)
    {
        damageMultiplier = initialDamageMultiplier;
        Debug.Log("aja");
    }

    public virtual void AttackTarget(IDamageable target)
    {
        Debug.Log("as");
        target.TakeDamage(DamageAmount);
    }

    public virtual void DropItem()
    {
        Debug.Log("aads");
    }

    public override void TakeDamage(float amount)
    {

        base.TakeDamage(amount);

    }
}