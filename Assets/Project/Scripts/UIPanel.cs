using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIPanel : MonoBehaviour
{
    [SerializeField] private Button restartButton = default;
    void Start()
    {
        restartButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
