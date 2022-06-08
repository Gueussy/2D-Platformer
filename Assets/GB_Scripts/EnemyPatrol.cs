using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;

    public SpriteRenderer spriteRenderer;
    private Transform target;
    private int destinationPoint;
    void Start()
    {
        target = waypoints[0]; //l'ennemi se déplace vers le 1er waypoint de l'array
        spriteRenderer.flipX = true; //fix le bug du moonwalk
    }
    void Update()
    {
        Vector3 direction = target.position - transform.position; //calcul la direction du prochain waypoint
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World); //bouge l'ennemi en fonction de sa direction et de sa vitesse

        if(Vector3.Distance(transform.position, target.position) < 0.3f) //si l'ennemi est quasiment arrivé à sa destination
        {
            destinationPoint = (destinationPoint + 1) % waypoints.Length; //calcule le prochain waypoint. Le modulo permet de boucler sans erreur au dernier waypoint.
            target = waypoints[destinationPoint]; //renvoie l'ennemi dans la direction du prochain waypoint
            spriteRenderer.flipX = !spriteRenderer.flipX; //flip le sprite dans le sens de marche
        } 

    }
}
