using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour {
    public GameObject other;
    void Example() {
        other.transform.Translate(1, 1, 1);
    }
}
