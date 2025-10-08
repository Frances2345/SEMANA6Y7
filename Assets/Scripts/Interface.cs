public interface IDroppable
{
    void DropItem();
}

public interface IConsumable
{
    void Consume(Entity target);
}

public interface IBuffeable
{
    void ApplyBuff(Entity target);
}

public interface IDamageable
{
    void ApplyBuff(Entity target);
    void TakeDamage(float damageAmount);
}

public interface IAttackable
{
    void ApplyBuff(Entity target);
}