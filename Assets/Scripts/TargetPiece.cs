using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TargetPiece : MonoBehaviour
{
    Rigidbody rb;
    public bool isCountedAsFallen = false; // marca si ya la contamos como ca�da
    public float fallenThreshold = 0.5f; // altura o velocidad para contar como ca�da

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // criterio simple para determinar si la pieza qued� "derribada":
        // si su inclinaci�n es grande o su velocidad supera cierto umbral
        if (!isCountedAsFallen)
        {
            if (rb.linearVelocity.magnitude > 0.5f) // empez� a moverse
            {
                // si cae por debajo de cierta altura o se separa demasiado de la posici�n inicial,
                // deber�as guardar la posici�n inicial para comparar � aqu� simplificamos:
                if (Mathf.Abs(transform.up.y) < 0.7f) // se inclin� notablemente
                {
                    isCountedAsFallen = true;
                    GameManager gm = FindFirstObjectByType<GameManager>();

                }
            }
        }
    }
}
