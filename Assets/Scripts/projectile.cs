using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameManager gameManager;
    private float angle;
    private float force;
    private float mass;

    private bool hasImpacted = false;
    private float impactImpulseValue = 0f;
    private Vector3 impactPoint = Vector3.zero;

    public void Init(GameManager gm, float angle, float force, float mass)
    {
        this.gameManager = gm;
        this.angle = angle;
        this.force = force;
        this.mass = mass;

        gm.StartShotRecording(gameObject, angle, force, mass);
    }

    void OnCollisionEnter(Collision col)
    {
        if (!hasImpacted)
        {
            hasImpacted = true;
            impactPoint = col.contacts[0].point;
            impactImpulseValue = col.impulse.magnitude;

            gameManager.RegisterImpact(impactPoint, impactImpulseValue);

            // Terminar registro del disparo
            gameManager.EndShotRecording(gameObject, angle, impactPoint, force, mass, impactImpulseValue);
        }
    }
}
