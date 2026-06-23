using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

/*TODO: нет необходимости хватать каждый фрейм компоненты это дорого и создаёт не явную зависимость лучше указать необходимые компоненты сразу в редакторе
 Поставил задержку на 30 кадров на разных устройствах чиста обновлений разная
 Я не совсем понимаю что тут считалось по этому и не могу сказать хорошее моё решение или нет.
*/
public class CharactersView : MonoBehaviour
{
    [SerializeField] private Text _title;
    [SerializeField] private Character[] _characters;

    private float _charactersInScene = 0;
    private int _frameCounter = 0;
    private int _frameDelaeMax = 30;

    private void Update()
    {
        _frameCounter++;
        if (_frameCounter >= _frameDelaeMax)
            return;
        _frameCounter = 0;
        UpdateUIValue();
    }

    private void UpdateUIValue()
    {
        foreach (Character character in _characters)
        {
            if (character != null)
                _charactersInScene++;
        }

        _title.text = $"Characters: {_characters.Length} Avg value: {_characters.Length / _charactersInScene}";
    }
}