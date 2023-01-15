using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public GameObject[] tetrisScene;
    public GameObject[] mainScene;
    public GameObject[] pacmanScene;

    public void SetSceneActive(GameObject[] scene, bool active)
    {
        foreach (var object1 in scene)
        {
            object1.SetActive(active);
        }
    }
}