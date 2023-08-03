using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    public abstract void Start();
    public abstract void Update();
    public abstract void OnDeath();

    public abstract void OnTakeDamage();
}
