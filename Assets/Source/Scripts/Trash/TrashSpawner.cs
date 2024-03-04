using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TrashSpawner : IInitializable
{
    private readonly TrashSpawnerSettings.Settings _settings;
    private readonly Zone _zone;
    private readonly PlayerModel _playerModel;
    private readonly TrashHeap.Factory _heapFactory;
    private readonly CoroutineManager _coroutineManager;

    private bool _needSpawn = true;
    private List<TrashHeap> _trashHeaps = new List<TrashHeap>();

    public TrashSpawner(Zone zone, TrashSpawnerSettings.Settings settings, PlayerModel playerModel, TrashHeap.Factory heapFactory,
        CoroutineManager coroutineManager)
    {
        _playerModel = playerModel;
        _zone = zone;
        _settings = settings;
        _heapFactory = heapFactory;
        _coroutineManager = coroutineManager;
    }

    public void Initialize()
    {
        _zone.SetSize(_settings.Size);
        _coroutineManager.StartCoroutine(Spawning());
    }

    public IEnumerator Spawning()
    {
        while (_needSpawn)
        {
            yield return new WaitForSeconds(_settings.SpawnDelay);

            if (_settings.MaxHeaps > _trashHeaps.Count)
            {
                Vector3 spawnPosition = Vector3.zero;

                do
                {
                    spawnPosition = _zone.Center.position + new Vector3(Random.Range(-_zone.Size.x / 2f, _zone.Size.x / 2f),
                                                                              0,
                                                                              Random.Range(-_zone.Size.z / 2f, _zone.Size.z / 2f));
                    yield return null;
                } while (Vector3.Distance(new Vector3(_playerModel.Transform.position.x, 0, _playerModel.Transform.position.z), spawnPosition) < _settings.MinDistanceBetweenPlayer);

                SpawnObject(spawnPosition);
            }
        }
    }
    public void SpawnObject(Vector3 spawnPoint)
    {
        TrashHeap newObject = _heapFactory.Create();
        _trashHeaps.Add(newObject);

        newObject.transform.position = spawnPoint;
    }
}
