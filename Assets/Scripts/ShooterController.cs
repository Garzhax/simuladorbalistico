using UnityEngine;
using UnityEngine.UI;

public class ShooterController : MonoBehaviour
{
    [Header("UI")]
    public Slider angleSlider;            // slider en grados 0-90
    public Slider forceSlider;            // fuerza
    public Dropdown massDropdown;         // masa seleccionable
    public Button fireButton;

    [Header("Disparo")]
    public Transform spawnPoint;          // punto donde aparece el proyectil
    public GameObject projectilePrefab;   // prefab del proyectil
    public GameManager gameManager;       // referencia al GameManager

    void Start()
    {
        fireButton.onClick.AddListener(OnFire);
    }

    void OnFire()
    {
        float angle = angleSlider.value;
        float force = forceSlider.value;
        float mass = GetMassFromDropdown();

        // Crear proyectil
        GameObject projGo = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody rb = projGo.GetComponent<Rigidbody>();
        rb.mass = mass;

        // Calcular dirección desde el ángulo
        Vector3 dir = Quaternion.Euler(-angle, 0f, 0f) * spawnPoint.forward;
        rb.linearVelocity = dir.normalized * force;

        // Avisar al GameManager
        Projectile projScript = projGo.GetComponent<Projectile>();
        if (projScript != null) projScript.Init(gameManager, angle, force, mass);
    }

    float GetMassFromDropdown()
    {
        string s = massDropdown.options[massDropdown.value].text;
        float m = 1f;
        float.TryParse(s, out m);
        return Mathf.Max(0.001f, m);
    }
}
