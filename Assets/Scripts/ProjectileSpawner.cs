using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public List<ProjectileDirections> projectileDirections;
    public int projectileDirectionPatternIndex;
    public GameObject projectile;
    public GameObject effect;


    private void Awake()
    {

        //effect      
    }
    public void FireProjectile()
    {
        if (projectileDirections[projectileDirectionPatternIndex] != null)
        {
            foreach (var direction in projectileDirections[projectileDirectionPatternIndex].directions)
            {
                Projectile var = Instantiate(projectile,gameObject.transform).GetComponent<Projectile>();
                var.gameObject.transform.localPosition = direction;
                var.gameObject.transform.parent = null;
                var.MoveToDirection(direction);
            }
            //pool if you have time
            Destroy(gameObject);
        }
    }
}
[System.Serializable]
public class ProjectileDirections
{
    public List<Vector3> directions;
}