using HoloToolkit.Unity;
using UnityEngine;

/// <summary>
/// GestureAction performs custom actions based on
/// which gesture is being performed.
/// </summary>
public class GestureAction : MonoBehaviour
{
    [Tooltip("Rotation max speed controls amount of rotation.")]
    public float RotationSensitivity = 10.0f;

    private Vector3 manipulationPreviousPosition;

    private float rotationFactorX;
    private float rotationFactorY;
    private bool isChild;
    void Update()
    {
        
        PerformRotation();
    }

    private void PerformRotation()
    {
        isChild = (HandsManager.Instance.FocusedGameObject.tag == gameObject.tag);
        
        if (GestureManager.Instance.IsNavigating &&isChild)
        {
           
            rotationFactorX = GestureManager.Instance.NavigationPosition.x * RotationSensitivity;
            rotationFactorY = GestureManager.Instance.NavigationPosition.y * RotationSensitivity;
            
            transform.Rotate(new Vector3( rotationFactorY, 0, -1 * rotationFactorX));
        }
    }

    void PerformManipulationStart(Vector3 position)
    {
        manipulationPreviousPosition = position;
    }

    void PerformManipulationUpdate(Vector3 position)
    {
        if (GestureManager.Instance.IsManipulating)
        {
            

            Vector3 moveVector = Vector3.zero;

            // Calculate the moveVector as position - manipulationPreviousPosition.
            moveVector = position - manipulationPreviousPosition;
            //Update the manipulationPreviousPosition with the current position.
            manipulationPreviousPosition = position;
            //Increment this transform's position by the moveVector.
            transform.position += moveVector;
        }
    }
}