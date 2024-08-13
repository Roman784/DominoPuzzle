using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DemonstrationCursor : MonoBehaviour
{
    private SpriteRenderer _renderer;

    [SerializeField] private Sprite _default;
    [SerializeField] private Sprite _pressed;

    [Space]

    [SerializeField] private float _moveSpeed;

    private Camera _camera;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        ChangeSprite();
        Move(Time.fixedDeltaTime);
    }

    private void ChangeSprite()
    {
        if (Input.GetKey(KeyCode.Mouse0))
            _renderer.sprite = _pressed;
        else
            _renderer.sprite = _default;
    }

    private void Move(float delta)
    {
        Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.Lerp(transform.position, position, _moveSpeed * delta);
    }
}
