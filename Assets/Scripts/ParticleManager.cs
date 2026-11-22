
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.VFX;

[System.Serializable]
public class ParticlePoolEntry
{
    public ParticleType type;

    public bool isVFXG = false;

    public ParticleSystem particlePrefab;
    public VisualEffect vfxPrefab;

    public int poolSize = 10;
}

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance;

    [SerializeField] private ParticlePoolEntry[] particleEntries;

    private Dictionary<ParticleType, List<PooledParticle>> pools =
     new Dictionary<ParticleType, List<PooledParticle>>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        InitializePools();
    }

    private void InitializePools()
    {
        foreach (ParticlePoolEntry entry in particleEntries)
        {
            List<PooledParticle> pool = new List<PooledParticle>();

            pools.Add(entry.type, pool);

            for (int i = 0; i < entry.poolSize; i++)
            {
                CreateParticle(entry, pool);
            }
        }
    }

    private PooledParticle CreateParticle(
     ParticlePoolEntry entry,
     List<PooledParticle> pool)
    {
        PooledParticle pooled = new PooledParticle();

        if (entry.isVFXG)
        {
            pooled.vfx = Instantiate(entry.vfxPrefab, transform);
            pooled.gameObject = pooled.vfx.gameObject;
        }
        else
        {
            pooled.particleSystem = Instantiate(entry.particlePrefab, transform);
            pooled.gameObject = pooled.particleSystem.gameObject;
        }

        pooled.gameObject.SetActive(false);

        pool.Add(pooled);

        return pooled;
    }

    public void Play(Vector3 position, ParticleType type)
    {
        if (!pools.ContainsKey(type))
        {
            Debug.LogWarning("No particle pool found for: " + type);
            return;
        }

        PooledParticle particle = pools[type].Find(
            p => !p.gameObject.activeInHierarchy
        );

        if (particle == null)
        {
            ParticlePoolEntry entry = System.Array.Find(
                particleEntries,
                e => e.type == type
            );

            particle = CreateParticle(entry, pools[type]);
        }

        particle.gameObject.transform.position = position;
        particle.gameObject.SetActive(true);

        if (particle.particleSystem != null)
        {
            particle.particleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            particle.particleSystem.Play(true);
        }
        else if (particle.vfx != null)
        {
            particle.vfx.gameObject.SetActive(false);
            particle.vfx.gameObject.SetActive(true);

            particle.vfx.Reinit();
            particle.vfx.Play();
        }

        StartCoroutine(ReturnParticle(particle));
    }

    private IEnumerator ReturnParticle(PooledParticle particle)
    {
        if (particle.particleSystem != null)
        {
            while (particle.particleSystem.IsAlive(true))
            {
                yield return null;
            }
        }
        else if (particle.vfx != null)
        {
            // Vänta tills VFX Graph faktiskt har skapat partiklar
            while (particle.vfx.aliveParticleCount == 0)
            {
                yield return null;
            }

            // Vänta tills alla partiklar har försvunnit
            while (particle.vfx.aliveParticleCount > 0)
            {
                yield return null;
            }
        }

        particle.gameObject.SetActive(false);
    }
}
