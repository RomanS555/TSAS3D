using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ManagerTrn : MonoBehaviour
{
    
    public void TranslateToScene(string scn){
        SceneManager.LoadScene(scn);
    }
}
