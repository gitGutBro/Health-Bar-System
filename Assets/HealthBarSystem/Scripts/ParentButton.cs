using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class ParentButton : MonoBehaviour
{
    protected Button Button { get; private set; }

    private void Awake() =>
        Init();

    private void OnEnable() =>
        Button.onClick.AddListener(OnClick);

    private void OnDisable() =>
        Button.onClick.RemoveListener(OnClick);

    protected virtual void OnClick() { }

    private void Init() =>
        Button = GetComponent<Button>();
}
