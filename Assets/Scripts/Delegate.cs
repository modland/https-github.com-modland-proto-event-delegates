using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// example code
public class Delegate : MonoBehaviour
{
    // a delegate is just a variable that holds a method.
    // here is how to declare one.
    // note the Method Signature ie. input and returning parameter types
    // in this example we return void and pass in a Color variable.
    public delegate void ChangeColor(Color newColor);
    public ChangeColor onColorChange;

    // this delegate method signature returns void and accepts no parameters.
    public delegate void OnComplete();
    public OnComplete onComplete;

    private void Start()
    {
        // So long as the signatures match, our delegate can have a method "registered" to it.
        onColorChange = UpdateColor;
        // now when we invoke our delegate we are calling to the registered method.
        onColorChange(Color.green);

        // Delegates are capable of Multicasting. Use += to register more methods to the stack.
        onComplete += Task;
        onComplete += Task1;
        onComplete += Task2;
        // know that you can (+=) register and also deregister (-=) methods to the delegate
        // this can be done out of order
        // onComplete -= Task2;
        // onComplete -= Task;
        // Etc.

        // it's a good move to test that some method has been registered to the delegate before invoking
        onComplete?.Invoke();
    }

    public void UpdateColor(Color newColor)
    {
        Debug.Log("Changing color to: " + newColor.ToString());
    }

    public void Task()
    {
        Debug.Log("Task 1 Finished");
    }
    public void Task1()
    {
        Debug.Log("Task 2 Finished");
    }
    public void Task2()
    {
        Debug.Log("Task 3 Finished");
    }
}

