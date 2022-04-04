using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// 씬 전환을 위해 만든 스크립트
public class BackSampleScene : MonoBehaviour
{
public void BacktoScene()
    {
        SceneManager.LoadScene(1);
    }
}
