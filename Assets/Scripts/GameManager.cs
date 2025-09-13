using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    public Text reportText; // Asignalo en el Inspector

    private int piecesFallen = 0;
    private float shotStartTime;

    // Datos del impacto
    private Vector3 impactPoint;
    private float impactImpulse;

    void Start()
    {
        piecesFallen = 0;
    }

    // Llamar cuando el jugador dispara
    public void StartShotRecording(GameObject projectile, float angle, float force, float mass)
    {
        shotStartTime = Time.time;
        piecesFallen = 0; // reset
    }

    // Llamar desde Projectile cuando hay un impacto
    public void RegisterImpact(Vector3 point, float impulse)
    {
        impactPoint = point;
        impactImpulse = impulse;
    }

    // Llamar cuando una pieza cae
    public void PieceFallen()
    {
        piecesFallen++;
    }

    // Llamar desde Projectile cuando termina el vuelo
    public void EndShotRecording(GameObject projectile, float angle, Vector3 impactPoint, float force, float mass, float impactImpulse)
    {
        float timeOfFlight = Time.time - shotStartTime;

        string report = $"--- Reporte de disparo ---\n" +
                        $"Ángulo: {angle}\n" +
                        $"Fuerza: {force}\n" +
                        $"Masa: {mass}\n" +
                        $"Tiempo de vuelo: {timeOfFlight:F2} s\n" +
                        $"Punto de impacto: {impactPoint}\n" +
                        $"Impulso de colisión: {impactImpulse:F2}\n" +
                        $"Piezas derribadas: {piecesFallen}";

        Debug.Log(report);

        if (reportText != null)
            reportText.text = report;
    }
}
