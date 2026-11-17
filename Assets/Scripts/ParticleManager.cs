
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ParticlePoolEntry
{
    public ParticleType type;
    public ParticleSystem prefab;
    public int poolSize = 10;
}

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance;

    [SerializeField] private ParticlePoolEntry[] particleEntries;

    private Dictionary<ParticleType, List<ParticleSystem>> pools =
        new Dictionary<ParticleType, List<ParticleSystem>>();

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
            List<ParticleSystem> pool = new List<ParticleSystem>();

            pools.Add(entry.type, pool);

            for (int i = 0; i < entry.poolSize; i++)
            {
                CreateParticle(entry, pool);
            }
        }
    }

    private ParticleSystem CreateParticle(
        ParticlePoolEntry entry,
        List<ParticleSystem> pool)
    {
        ParticleSystem particle = Instantiate(entry.prefab, transform);

        particle.gameObject.SetActive(false);

        pool.Add(particle);

        return particle;
    }

    public void Play(Vector3 position, ParticleType type)
    {
        if (!pools.ContainsKey(type))
        {
            Debug.LogWarning("No particle pool found for: " + type);
            return;
        }

        ParticleSystem particle = pools[type].Find(
            p => !p.gameObject.activeInHierarchy
        );

        // Expand pool if all particles are currently playing
        if (particle == null)
        {
            ParticlePoolEntry entry = System.Array.Find(
                particleEntries,
                e => e.type == type
            );

            particle = CreateParticle(entry, pools[type]);
        }

        particle.transform.position = position;

        particle.gameObject.SetActive(true);

        particle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        particle.Play(true);

        StartCoroutine(ReturnParticle(particle));
    }

    private IEnumerator ReturnParticle(ParticleSystem particle)
    {
        while (particle.IsAlive(true))
        {
            yield return null;
        }

        particle.gameObject.SetActive(false);
    }
}
