using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //exercice Coroutine

    public float timer;
    void Start()
    {
        //StartCoroutine(WaitToDoSomething());
    }
    
    void DoSomething()
    {
        Debug.Log("Something");
    }

    IEnumerator WaitToDoSomething()
    {
        yield return new WaitForSeconds(timer);
        DoSomething();
    }
    
    
}
