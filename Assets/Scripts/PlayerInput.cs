using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] public Vector2 leftInput = Vector2.zero, rightInput = Vector2.zero;

    private void Update()
    {
        leftInput = LeftInput();
        rightInput = RightInput();

        if (FindObjectOfType<CubeMenager>() == null) return;
        if (FindObjectOfType<CubeMenager>().path == "Left") FindObjectOfType<CubeMenager>().playerInput = leftInput;
        if (FindObjectOfType<CubeMenager>().path == "Right") FindObjectOfType<CubeMenager>().playerInput = rightInput;
    }

    Vector2 RightInput()
    {
        int rightVertical, rightHorizontal;

        if (Input.GetKey(KeyCode.I)) rightVertical = 1;
        else if (Input.GetKey(KeyCode.K)) rightVertical = -1;
        else rightVertical = 0;

        if (Input.GetKey(KeyCode.L)) rightHorizontal = 1; 
        else if (Input.GetKey(KeyCode.W)) rightHorizontal = -1;
        else rightHorizontal = 0;

        return new Vector2(rightHorizontal, rightVertical);
    }

    Vector2 LeftInput()
    {
        int leftVertical, leftHorizontal;

        if (Input.GetKey(KeyCode.W)) leftVertical = 1;
        else if (Input.GetKey(KeyCode.S)) leftVertical = -1;
        else leftVertical = 0;

        if (Input.GetKey(KeyCode.A)) leftHorizontal = -1;
        else if (Input.GetKey(KeyCode.D)) leftHorizontal = 1;
        else leftHorizontal = 0;

        return new Vector2(leftHorizontal, leftVertical);
    }
}
