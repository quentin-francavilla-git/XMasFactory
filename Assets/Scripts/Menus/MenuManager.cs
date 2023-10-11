using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GamepadController))]
public class MenuManager : MonoBehaviour
{
    [Header("Circles")]
    [SerializeField]
    private Transform circleLeftTs;
    [SerializeField]
    private Transform circleRightTs;
    public float offset_circles_y;
    public float offset_circles_x;

    public GameObject[] buttons;

    private GamepadController gamepadController;

    private int selected = 0;
    private int buttonsLen = 0;

    private void Awake()
    {
        gamepadController = GetComponent<GamepadController>();
        buttonsLen = buttons.Length;
        moveCircles();
    }

    void Update()
    {
        moveSelected();
        Select();
    }

    void Select()
    {
        if (Input.GetButtonDown("Submit"))
        {
            buttons[selected].GetComponent<IActionButton>().Action();
        }
    }

    void moveSelected()
    {
        float vertical = gamepadController.GetDirectionPressed("Vertical");

        if (vertical > 0) {
            moveUp();
        } else if (vertical < 0) {
            moveDown();
        }
    }

    void moveDown()
    {
        if (selected + 1 >= buttonsLen) {
            return;
        }

        selected++;
        moveCircles();
    }

    void moveUp()
    {
        if (selected <= 0) {
            return;
        }

        selected--;
        moveCircles();
    }

    void moveCircles()
    {
        RectTransform selected_ts = buttons[selected].GetComponent<RectTransform>();
        Text text = buttons[selected].GetComponent<Text>();

        float textWidth = text.preferredWidth;
        float posXLeft = text.rectTransform.position.x - (textWidth / 2);
        float posXRight = text.rectTransform.position.x + (textWidth / 2);

        circleLeftTs.position = new Vector2(
            posXLeft - offset_circles_x,
            selected_ts.position.y + offset_circles_y
        );
        circleRightTs.position = new Vector2(
            posXRight + offset_circles_x,
            selected_ts.position.y + offset_circles_y
        );
    }

}
