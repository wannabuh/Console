using UnityEngine;
using UnityEngine.UIElements;

namespace Wannabuh.Console
{
    public class ConsoleBehaviour : MonoBehaviour
    {
        private VisualElement _ui;
        private ListView _historyList;
        private TextField _commandInputField;
        private Console _console;
        private StyleSheet _styleSheet;

        private void Awake()
        {
            _styleSheet = Resources.Load<StyleSheet>("Console");
            _ui = GetComponent<UIDocument>().rootVisualElement;
            _ui.styleSheets.Add(_styleSheet);
            _commandInputField = _ui.Q<TextField>("CommandInputField");
            _historyList = _ui.Q<ListView>("HistoryList");
            _console = new Console(GameContext.Instance);
        }

        private void OnEnable()
        {
            _commandInputField.RegisterCallback<NavigationSubmitEvent>(OnCommandSubmit, TrickleDown.TrickleDown);
            _historyList.itemsSource = _console.InputHistory;
            _historyList.makeItem = () =>
            {
                var label = new Label();
                label.AddToClassList(".history-item");
                return label;
            };
            _historyList.bindItem = (element, i) =>
            {
                ((Label)element).text = _console.InputHistory[i];
            };
        }

        private void OnCommandSubmit(NavigationSubmitEvent evt)
        {
            _console.ProcessCommand(_commandInputField.value);
            _historyList.RefreshItems();
            _commandInputField.value = "";
            _commandInputField.Focus();
        }
    }
}
