    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [System.Serializable]
    public struct SSParameters
    {
        public Gradient gradient;
        public Color color;
        public Color light;
    }
    public class SSControllerScript : MonoBehaviour
    {
        public GameObject SSParticlesPrefab;

        public SSParameters [] parameters;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        IEnumerator StopEmissionAfterDelay(ParticleSystem particleSystem, float delay)
    {
        yield return new WaitForSeconds(delay);
        particleSystem.Stop();
    }

        public void ActivateSSPower(GameObject padre,  int n_param, float emisionTime, float destroyTime){
            if (n_param < 0 || n_param >= parameters.Length)
            {
                Debug.LogError("Índice de parámetro inválido. Asegúrate de que n_param esté dentro de los límites del array parameters.");
            }

            SSParameters parameter = parameters[n_param];
            if (SSParticlesPrefab != null)
            {
                GameObject instanciaPrefab = Instantiate(SSParticlesPrefab);

                instanciaPrefab.transform.position = padre.transform.position;

                ParticleSystem sistemaParticulas = instanciaPrefab.GetComponent<ParticleSystem>();
                if (sistemaParticulas != null)
                {
                    ParticleSystem.MainModule mainModule = sistemaParticulas.main;

                    mainModule.startColor = new ParticleSystem.MinMaxGradient(parameter.gradient);
                }
                else
                {
                    Debug.LogError("El prefab no tiene un componente ParticleSystem.");
                }
                
                Transform hijoTransform = instanciaPrefab.transform.GetChild(0);
                ParticleSystem sistemaParticulasSecundario = hijoTransform.GetComponent<ParticleSystem>();
                if (sistemaParticulasSecundario != null)
                {
                    ParticleSystem.MainModule mainModuleSecundario = sistemaParticulasSecundario.main;
                    mainModuleSecundario.startColor = parameter.color;
                }
                else
                {
                    Debug.LogWarning("El prefab no tiene un componente de sistema de partículas secundario.");
                }

                Light luzPuntual = instanciaPrefab.GetComponent<Light>();
                if (luzPuntual != null)
                {
                    luzPuntual.color = parameter.light;
                }
                else
                {
                    Debug.LogWarning("El prefab no tiene un componente de luz puntual.");
                }
                StartCoroutine(StopEmissionAfterDelay(instanciaPrefab.GetComponent<ParticleSystem>(), 3f));
                Destroy(instanciaPrefab, 4f);
            }
            else
            {
                Debug.LogError("Prefab no asignado en el Inspector.");
            }
        }
    }
