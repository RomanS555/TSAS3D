using UnityEngine;
using UnityEngine.SceneManagement;
public class EventParent : MonoBehaviour
{
    public void DestroyObj(Object obj)
    {
        Destroy(obj);
    }
    public void SpawnObject(GameObject prefab)
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
    public void GoToScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}