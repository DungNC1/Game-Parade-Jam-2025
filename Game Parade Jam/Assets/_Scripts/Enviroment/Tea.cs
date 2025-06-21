using UnityEngine;
using UnityEngine.UI;

public class Tea : MonoBehaviour
{
    public RectTransform movingBar;
    public RectTransform perfectZone;
    public float speed = 500f;
    public bool movingRight = true;

    private bool isBrewing = false;

    public GameObject brewingUI;

    void Update()
    {
        if (!isBrewing) return;

        MoveBar();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckBrewResult();
        }
    }

    public void StartBrewing()
    {
        isBrewing = true;
        brewingUI.SetActive(true);
    }

    void MoveBar()
    {
        float step = speed * Time.deltaTime;
        if (movingRight)
        {
            movingBar.anchoredPosition += Vector2.right * step;
            if (movingBar.anchoredPosition.x >= 300f) movingRight = false;
        }
        else
        {
            movingBar.anchoredPosition -= Vector2.right * step;
            if (movingBar.anchoredPosition.x <= -300f) movingRight = true;
        }
    }

    void CheckBrewResult()
    {
        isBrewing = false;
        brewingUI.SetActive(false);

        float barLeft = movingBar.position.x;
        float zoneLeft = perfectZone.position.x;
        float zoneRight = zoneLeft + perfectZone.rect.width;

        if (barLeft >= zoneLeft && barLeft <= zoneRight)
        {
            GetComponent<Pickup>().PickUp();
            DialogueController.instance.NewDialogueInstance("Tea Brewed!");
        }
        else
        {
            DialogueController.instance.NewDialogueInstance("You spilled the tea!");
        }
    }
}