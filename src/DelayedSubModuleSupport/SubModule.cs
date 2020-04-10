using System.Threading;
using JetBrains.Annotations;
using TaleWorlds.MountAndBlade;

namespace DelayedSubModuleSupport {

  [PublicAPI]
  public partial class SubModule : MBSubModuleBase {

    private bool _ticked = false;

    protected override void OnApplicationTick(float dt) {
      if (_ticked)
        return;

      _ticked = true;
      SynchronizationContext.Current.Post(_ => {
        LoadDelayedSubModules();
      }, null);
      base.OnApplicationTick(dt);
    }

  }

}