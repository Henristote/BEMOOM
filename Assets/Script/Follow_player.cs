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
            Debug.LogWarning("Aucun target assigné à la caméra !");
            return;
        }

        // Calcul de la position désirée de la caméra
        Vector3 desiredPosition = player.position + player.rotation * offset;

        // Déplacement progressif de la caméra pour lisser le mouvement
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smooth);

        // Orientation de la caméra vers la cible
        transform.LookAt(player.position + Vector3.up * 1.5f); // Ajuste le regard légèrement au-dessus du pivot de la cible
    }
}
