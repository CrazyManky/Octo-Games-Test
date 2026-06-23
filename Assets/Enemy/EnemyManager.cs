using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Enemy
{/*TODO: из за вечной дилемы кто кем должен управлять и как прокидывать решил выбрать самый простой но рабочий вариант, одна колекция хранит все сушности кторые можно удалить при их активации они будут добавлены в List 
при изменении их состояния они буду убраны из активных игровых объектов*/
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private List<IEntity> _entities = new List<IEntity>();

        private List<IEntity> _enemiesActive = new List<IEntity>();

        private void OnEnable()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            foreach (var enemy in _entities)
            {
                enemy.EntityActive += EnemyActive;
                enemy.EntityDisabled += EnemyDisable;
                enemy.EntityDestroyed += EnemyDestroy;
            }
        }

        private void EnemyActive(IEntity entity)
        {
            _enemiesActive.Add(entity);
        }

        private void EnemyDisable(IEntity entity)
        {
            _enemiesActive.Remove(entity);
        }

        private void EnemyDestroy(IEntity entity)
        {
            _enemiesActive.Remove(entity);
        }
    }

    public interface IEntity
    {
        public event Action<IEntity> EntityDestroyed;
        public event Action<IEntity> EntityActive;
        public event Action<IEntity> EntityDisabled;
    }

    public class Enemy : MonoBehaviour, IEntity
    {
        public event Action<IEntity> EntityDestroyed;
        public event Action<IEntity> EntityActive;
        public event Action<IEntity> EntityDisabled;

        private void OnEnable()
        {
            EntityActive?.Invoke(this);
        }

        public void OnDestroy()
        {
            EntityDestroyed?.Invoke(this);
        }

        private void OnDisable()
        {
            EntityDisabled?.Invoke(this);
        }
    }
}