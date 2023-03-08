using System.Collections;
using UnityEngine;

namespace Explosurvival.Explosions
{
    public class ShrinkExplosion : MonoBehaviour
    {
        private void Start()
        {
            //Call the function giving it a target scale (Vector3) and a duration (float).
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