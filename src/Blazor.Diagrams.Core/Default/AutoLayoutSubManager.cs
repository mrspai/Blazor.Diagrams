using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.Layout;
using Microsoft.Msagl.Core.Geometry;

namespace Blazor.Diagrams.Core.Default
{
    public class AutoLayoutSubManager : DiagramSubManager
    {
        public AutoLayoutSubManager(DiagramManager diagramManager) : base(diagramManager)
        {
            DiagramManager.Changed += DiagramManager_Changed;
        }

        private void DiagramManager_Changed()
        {
            DiagramManager.ApplyLayout(DiagramManager.Options.AutoLayout);
        }

        public override void Dispose()
        {
            DiagramManager.Changed -= DiagramManager_Changed;
        }
    }
}
