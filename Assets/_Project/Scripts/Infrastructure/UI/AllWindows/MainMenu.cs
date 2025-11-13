using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

namespace CodeBase.Infrastructure.UI
{
    public class MainMenu : WindowBase
    {
        [SerializeField] private Button _startGameButton;
        public IObservable<Unit> OnStartGameButton => _startGameButton.OnClickAsObservable();


    }
}
