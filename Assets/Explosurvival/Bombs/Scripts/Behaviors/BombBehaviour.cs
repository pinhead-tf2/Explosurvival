using System;
using System.Collections;
using UnityEngine;

namespace Explosurvival.Bombs.Behaviors
{
    public class BombBehaviour : MonoBehaviour
    {
        public BombObject bomb;
        protected float Damage;
        protected float Radius;
        protected float FuseTime;
        protected bool CanDestroyTerrain;
        protected AudioClip TickSound; 
        protected AudioClip ExplosionSound; 
        protected GameObject ExplosionEffect;
        protected AudioSource AudioSource;
        private Rigidbody _rigidbody;
        private MeshRenderer _meshRenderer;
        private MeshCollider _meshCollider;
        private const double MagicNumber = 0.84; // dont ask

        private void Awake()
        {
            AudioSource tAudioSource = gameObject.GetComponent<AudioSource>();
            AudioSource = tAudioSource ? tAudioSource : gameObject.AddComponent<AudioSource>(); // If temp set audio source to temp, if not make new one
            Rigidbody tRigidbody = gameObject.GetComponent<Rigidbody>();
            _rigidbody = tRigidbody ? tRigidbody : gameObject.AddComponent<Rigidbody>();
            MeshCollider tMeshCollider = gameObject.GetComponent<MeshCollider>();
            _meshCollider = tMeshCollider ? tMeshCollider : gameObject.AddComponent<MeshCollider>();
            MeshRenderer tMeshRenderer = gameObject.GetComponent<MeshRenderer>();
            _meshRenderer = tMeshRenderer ? tMeshRenderer : GetComponent<MeshRenderer>();
        }

        private void Start()
        {
            Damage = bomb.m_Damage;
            Radius = bomb.m_Radius;
            FuseTime = bomb.m_FuseTime;
            CanDestroyTerrain = bomb.m_DestroyTerrain;
            TickSound = bomb.m_TickSound;
            ExplosionSound = bomb.m_ExplosionSound;
            ExplosionEffect = bomb.m_ExplosionEffect;

            StartCoroutine(TickBomb());
        }

        private IEnumerator TickBomb()
        {
            for (var i = FuseTime*MagicNumber; i > 0; i-=1) // alt i > 2
            {
                float part1 = (float) Math.Pow(0.5f * (0.25 * i), 3) + 0.25f;
                // print("Delay: " + part1 + "\nElapsed: " + _timer);
                AudioSource.PlayOneShot(TickSound);
                yield return new WaitForSeconds(part1);
            }
            AudioSource.PlayOneShot(TickSound);
            // print("kablooey\n Elapsed: " + _timer);
            Explode();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void Explode()
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            var bTransform = transform; // bomb transform
            var bTPosition = bTransform.position;
            var explosion = Instantiate(ExplosionEffect, bTPosition, bTransform.rotation);
            explosion.transform.localScale = new Vector3(Radius, Radius, Radius);
            AudioSource.PlayOneShot(ExplosionSound);
            _meshRenderer.enabled = _meshCollider.enabled = false;
            Collider[] hitPlayers = new Collider[16];
            int playerHits = Physics.OverlapSphereNonAlloc(bTPosition, Radius, hitPlayers, 1<< 3); // Players
            Collider[] hitTerrain = new Collider[25];
            int terrainHits = Physics.OverlapSphereNonAlloc(bTPosition, Radius, hitPlayers, 1<< 8); // Terrain
            Collider[] hitBombs = new Collider[10];
            int bombHits = Physics.OverlapSphereNonAlloc(bTPosition, Radius, hitPlayers, 1<< 6); // Bombs
            
            // do all the hits and stuff here
            
            
            Destroy(gameObject); // Removes the bomb for memory's sake, the explosion removes itself
        }
    }
}