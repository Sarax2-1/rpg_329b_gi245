using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform selectionBox;
    public RectTransform SelectionBox { get { return selectionBox; } }

    public static UIManager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
