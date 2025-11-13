using VContainer;
using UnityEngine;
using CodeBase.Infrastructure.Services;
using UnityEngine.UI;
using UniRx;
using System;

namespace CodeBase.Infrastructure.UI
{
    public class GameLoopWindow : WindowBase
    {
        [SerializeField] private Button _goToMenuButton;
        [SerializeField] private Button _winButton;
        [SerializeField] private Button _loseButton;
        
        [Inject] private readonly IAppStateService _appStateService;
        
        public IObservable<Unit> OnGoToMenuButton => _goToMenuButton.OnClickAsObservable();

        public override void Initialize()
        {
        
        }
    }
}
