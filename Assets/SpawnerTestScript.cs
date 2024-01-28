using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTestScript : MonoBehaviour
{
    public SSControllerScript ssController; // Asigna el objeto SSControllerScript desde el Inspector
    public GameObject objeto1; // Asigna el objeto padre deseado desde el Inspector
    public GameObject objeto2; // Asigna el objeto padre deseado desde el Inspector

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                // Asegúrate de que el objeto SSControllerScript y el objeto padre estén asignados
                if (ssController != null && objeto1 != null)
                {
                    // Llama a ActivateSSPower con el objeto padre y el número de parámetro
                    ssController.ActivateSSPower(objeto1, 0, 3f, 4f);
                }
                else
                {
                    Debug.LogError("Asegúrate de asignar el objeto SSControllerScript y el objeto padre en el Inspector.");
                }
            }

        if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                // Asegúrate de que el objeto SSControllerScript y el objeto padre estén asignados
                if (ssController != null && objeto2 != null)
                {
                    // Llama a ActivateSSPower con el objeto padre y el número de parámetro
                    ssController.ActivateSSPower(objeto2, 1, 3f, 4f);
                    
                }
                else
                {
                    Debug.LogError("Asegúrate de asignar el objeto SSControllerScript y el objeto padre en el Inspector.");
                }
            }
    }
}
