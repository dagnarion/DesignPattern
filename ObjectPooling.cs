using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : Singleton<ObjectPooling>
{
    [SerializeField] Dictionary<GameObject, List<GameObject>> list = new Dictionary<GameObject, List<GameObject>>();
    public GameObject Pool(GameObject _game)
    {
        if (!list.ContainsKey(_game))
        {
            list.Add(_game, new List<GameObject>());
        }
        foreach (var it in list[_game])
        {
            if (!it.activeSelf) return it;
        }
        GameObject g = Instantiate(_game, this.transform.position, Quaternion.identity);
        list[_game].Add(g);
        return g;
    }
    public T GetComp<T>(T _game) where T : MonoBehaviour => Pool(_game.gameObject).GetComponent<T>();
}
