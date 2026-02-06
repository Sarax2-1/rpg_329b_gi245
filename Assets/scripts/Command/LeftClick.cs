using UnityEngine;

public class LeftClick : MonoBehaviour
{
    Camera cam;

    [SerializeField]
    Character curChar;
    public Character CurChar { get { return curChar; } }
    [SerializeField]
    LayerMask layerMask;

    public static LeftClick instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        cam = Camera.main;
        layerMask = LayerMask.GetMask("Ground", "Character", "Building", "Item");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            TrySelect(Input.mousePosition);
        }
    }

    void SelectCharacter(RaycastHit hit)
    {
        curChar = hit.collider.GetComponent<Character>();
        Debug.Log("Selected Char: " + hit.collider.gameObject);
    }
    void TrySelect(Vector2 screenPos)
    {
        Ray ray = cam.ScreenPointToRay(screenPos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            switch (hit.collider.tag)
            {
                case "Player":
                case "Hero":
                    SelectCharacter(hit);
                    break;
            }
        }
    }
}
