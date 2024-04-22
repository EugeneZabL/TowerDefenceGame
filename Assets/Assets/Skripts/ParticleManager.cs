using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] GameObject DieCr;
    [SerializeField] GameObject Freze;
    [SerializeField] GameObject Bonk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AskForDieCr(Transform a)
    {
        GameObject exp = Instantiate(DieCr, a.position, Quaternion.identity);
        Destroy(exp, 0.5f);
    }

    public void AskForFreze(Transform a)
    {
        GameObject exp = Instantiate(Freze, a.position, Quaternion.identity);
        Destroy(exp, 0.5f);
    }

    public void AskForBonk(Transform a)
    {
        GameObject exp = Instantiate(Bonk, a.position, Quaternion.identity);
        Destroy(exp, 0.5f);
    }
}
