using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    [SerializeField] float waitToChange= 2f;
    [SerializeField] int sceneToChangeTo = 0;
    // Use this for initialization
    void Start()
    {
        Invoke("LoadScene", waitToChange);
    }

    // Update is called once per frame
    void LoadScene()
    {
        SceneManager.LoadScene(sceneToChangeTo);
    }
}
