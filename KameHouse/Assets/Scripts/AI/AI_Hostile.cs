public class AI_Hostile : AI_Brain, IDamageable
{
    public int currentHealth;

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
