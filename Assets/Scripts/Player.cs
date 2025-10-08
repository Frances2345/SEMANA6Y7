using UnityEngine;

public class Player : Entity, IAttackable
{
    public string playerName = "Scott";

    [SerializeField] private float currentDamage = 10f;

    public float DamageAmount
    {
        get { return currentDamage; }
        set { currentDamage = value; }
    }

    protected override void Start()
    {
        base.Start();
        Debug.Log(playerName + " entro al campo. " + CurrentHealth + " de vida y " + DamageAmount + " de daño");
    }

    private void Update()
    {
        Movement();
        Attack();
    }

    private void Movement()
    {
        Vector3 movement = Vector3.zero;
        float movedistance = Speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W)) movement += Vector3.up;
        if (Input.GetKey(KeyCode.S)) movement += Vector3.down;
        if (Input.GetKey(KeyCode.D)) movement += Vector3.right;
        if (Input.GetKey(KeyCode.A)) movement += Vector3.left;

        if (movement.magnitude > 0)
        {
            transform.Translate(movement.normalized * movedistance, Space.World);
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.TakeDamage(currentDamage);

            Debug.Log(playerName + " Ha logrado hacerle daño a algo (el mismo)");
        }
    }

    public void AttackTarget(IDamageable target)
    {
        target.TakeDamage(DamageAmount);
    }

    public override void ApplyBuff(Entity target)
    {
        Debug.Log(playerName + " ha recibido un buff (no implementado aquí).");
    }

    public override void SpeedBuff(float boost, float duration)
    {
        Speed += boost;
        Debug.Log(playerName + " aumento su velocidad por " + duration + " segundos (Bueno en realidad el efecto es permanente)");
    }

    public override void AttackBuff(float boost, float duration)
    {
        currentDamage += boost;
        Debug.Log(playerName + " aumento su ataque por " + duration + " segundos(Bueno en realidad el efecto es permanente)");
    }

    public override void HealthBuff(float boost)
    {
        CurrentHealth += boost;
        Debug.Log(playerName + " se ha curado " + boost + " de vida (Permanente)");
    }
}