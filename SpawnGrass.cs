using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrass : MonoBehaviour
{
    [SerializeField] private GameObject _prefabForSpawn;

    [SerializeField] private List<GameObject> _objectWasSpawned;
    
    [SerializeField] private Transform[] _spawnPointForPrefab;

    private float _temp;

    private void Start()
    {
        for(int i = 0; i < (_spawnPointForPrefab.Length - 1); i++)
        {
            _objectWasSpawned.Add(Instantiate(_prefabForSpawn));
        }

        for(int i = 0; i < (_spawnPointForPrefab.Length - 1); i++)
        {
            _objectWasSpawned[i].transform.position = _spawnPointForPrefab[i].transform.position;

            Quaternion rotateSide = Quaternion.Euler(0, Random.Range(0, 360f), 0);
            _objectWasSpawned[i].transform.rotation = rotateSide;
            _temp = Random.Range(1.520817f, 2);
            _objectWasSpawned[i].transform.localScale = new Vector3(_temp, _temp, _temp);
        }
    }

}
