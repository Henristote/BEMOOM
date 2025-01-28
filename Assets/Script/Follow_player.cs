using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Follow_player : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    public Vector3 offset = new Vector3(0f, 1.5f, 10f);

    [SerializeField]
    private float smooth = 15f;

    private Vector3 velocity = Vector3.zero;
    

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Aucun target assign� � la cam�ra !");
            return;
        }

        // Calcul de la position d�sir�e de la cam�ra
        Vector3 desiredPosition = player.position + player.rotation * offset;

        // D�placement progressif de la cam�ra pour lisser le mouvement
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smooth);

        // Orientation de la cam�ra vers la cible
        transform.LookAt(player.position + Vector3.up * 1.5f); // Ajuste le regard l�g�rement au-dessus du pivot de la cible
    }
}
