using UnityEngine;

namespace SaveAndLoads_Utility
{
    public class SaveLoadingSystem : MonoBehaviour
    {
        private LoadingHandler _loadingHandler;
        private SaveHandler _saveHandler;

        private void Awake()
        {
            _loadingHandler = new LoadingHandler();
            _saveHandler = new SaveHandler();
        }
        
        private void Start()
        {
            _saveHandler.Save(new SaveData());
          var loadingResult =  _loadingHandler.LoadingData<SaveData>();
          Debug.Log($"Загрузили:{loadingResult}");
        }
    }
}