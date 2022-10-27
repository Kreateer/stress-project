using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene("Edin the Second", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene("Edin's Insane Asylum");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene("Edin the Second", LoadSceneMode.Single);
        }
    }
}
