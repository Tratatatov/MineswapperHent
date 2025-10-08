using System;
using UnityEngine;

namespace Test
{
    public class RunProgressController : MonoBehaviour
    {
        [SerializeField] private CharacterStatsView _view;
        private RunProgressModel _model;

        public void Reset()
        {
            _model.Reset();
        }

        public bool TryLoad()
        {
            return _model.TryLoad();
            if (_model.TryLoad())
            {
                UpdateHpText();
                UpdateLevelText();
            }
        }

        public void Save()
        {
            _model.Save();
        }

        public bool TryDecreaseHp(int amount)
        {
            if (_model.TryDecreaseHp(amount: amount)) UpdateHpText();

            return _model.TryDecreaseHp(amount: amount);
        }

        public void SetHp(int count)
        {
            _model.SetHp(count: count);
            UpdateHpText();
        }

        public void IncreaseLevel()
        {
            _model.IncreaseLevel();
            UpdateLevelText();
        }


        public void SetLevel(int count)
        {
            _model.SetLevel(count: count);
            UpdateLevelText();
        }

        private void UpdateHpText()
        {
            _view.SetHpText(count: _model.CurrentHp);
        }

        private void UpdateLevelText()
        {
            _view.SetLevelText(count: _model.CurrentLevel);
        }
    }
}