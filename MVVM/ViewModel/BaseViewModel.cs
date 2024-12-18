using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonLikeCsharp.MVVM.ViewModel
{
    abstract public class BaseViewModel : ObservableObject
    {
        public virtual void OnShowVM() { }
        public virtual void OnHideVM() { }
       

    }
}
