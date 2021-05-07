using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class PersonalHolder : MonoBehaviour, IMechComponent
{
    [SerializeField] private List<Arsenal> items;

    private Mech mech;
    private Dictionary<string, AssetReference> holder;

    private Dictionary<string, GameObject> activeItems = new Dictionary<string, GameObject>();


    public void ConnectWithMech(Mech mech)
    {
        this.mech = mech;
        mech.holder = this;
    }

    public void Setup()
    {
        FillHolder();
    }

    public void GetItem(string item)
    {
        StartCoroutine(c_getItem(item));
    }

    private IEnumerator c_getItem(string item)
    {
        Activate(item);
        var isExist = activeItems.ContainsKey(item);
        if (!isExist)
        {
            StopCoroutine(c_getItem(item));
        }
        else
        {
            yield return new WaitUntil(() => activeItems.ContainsKey(item));
            Debug.Log("I got item " + item);

            yield return new WaitUntil(() => !activeItems.ContainsKey(item));
            Debug.Log("Now it's time to deactivate " + item);
            StopCoroutine(c_getItem(item));
        }
    }

    public void Activate(string item)
    {
        if (holder.ContainsKey(item) && !activeItems.ContainsKey(item))
        {
            StartCoroutine(c_itemWork(item));
        }
    }

    public void Deactivate(string item)
    {
        if(activeItems.ContainsKey(item))
        {
            Addressables.Release<GameObject>(activeItems[item]);
            activeItems.Remove(item);
        }
    }

    private void FillHolder()
    {
        holder = new Dictionary<string, AssetReference>();

        int count = items.Count;
        for (int i = 0; i < count; i++)
        {
            string name = items[i].Item;
            if(!holder.ContainsKey(name))
            {
                holder.Add(name, items[i].Reference);
            }
        }
    }


    private IEnumerator c_itemWork(string item)
    {
        activeItems.Add(item, null);

        AsyncOperationHandle<GameObject> waiter;
        waiter = holder[item].InstantiateAsync(transform);
        yield return new WaitUntil (()=> waiter.Result);
        activeItems[item] = waiter.Result;
    }
    

    [System.Serializable]
    public class Arsenal
    {
        public string Item;
        public AssetReference Reference;
    }
}
