using System.Collections;
using UnityEngine;

namespace Explosurvival.Explosions
{
    public class ShrinkExplosion : MonoBehaviour
    {
        public void Explode(float radius)
        {
            var position = transform.position;
            
            Collider[] hitPlayers = new Collider[16];
            int playerHits = Physics.OverlapSphereNonAlloc(position, radius, hitPlayers, 1 << 3); // Players
            Collider[] hitTerrain = new Collider[25];
            int terrainHits = Physics.OverlapSphereNonAlloc(position, radius, hitPlayers, 1 << 8); // Terrain
            Collider[] hitBombs = new Collider[10];
            int bombHits = Physics.OverlapSphereNonAlloc(position, radius, hitPlayers, 1 << 6); // Bombs
            StartCoroutine(ScaleToTargetCoroutine(new Vector3(0, 0, 0), 0.5f));
            
            if (terrainHits > 0)
            {
                print("Length: " + terrainHits);
                for (int i = 0; i < terrainHits; i++)
                {
                    print(hitTerrain[i].transform.position.x);
                    // Destroy(hitTerrain[i].gameObject);
                }
            }
        }

        public void ExplodePlayerOnly(float radius)
        {
            var position = transform.position;
            
            Collider[] hitPlayers = new Collider[16];
            int playerHits = Physics.OverlapSphereNonAlloc(position, radius, hitPlayers, 1 << 3); // Players
            Collider[] hitBombs = new Collider[10];
            int bombHits = Physics.OverlapSphereNonAlloc(position, radius, hitPlayers, 1 << 6); // Bombs
            StartCoroutine(ScaleToTargetCoroutine(new Vector3(0, 0, 0), 0.5f));
        }

        private IEnumerator ScaleToTargetCoroutine(Vector3 targetScale, float duration)
        {
            Vector3 startScale = transform.localScale;
            float timer = 0.0f;
 
            while(timer < duration)
            {
                timer += Time.deltaTime;
                float t = timer / duration;
                //smoother step algorithm
                t = t * t * t * (t * (6f * t - 15f) + 10f);
                transform.localScale = Vector3.Lerp(startScale, targetScale, t);
                yield return null;
            }
 
            Destroy(gameObject);
            yield return null;
        }
    }
}