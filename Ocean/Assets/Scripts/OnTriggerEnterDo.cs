using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheOcean
{
public class OnTriggerEnterDo : MonoBehaviour
{
    [SerializeField] public Command ToExecuteWhenTriggerEntered = null;

    private void OnTriggerEnter(Collider other)
    {
        ToExecuteWhenTriggerEntered?.Execute(other);
    }
}
}