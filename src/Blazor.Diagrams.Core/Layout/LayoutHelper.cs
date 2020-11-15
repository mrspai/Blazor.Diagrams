using System.Linq;
using Blazor.Diagrams.Core.Models;

namespace Blazor.Diagrams.Core.Layout
{
    public static class LayoutHelper
    {
        public static void ApplyLayout(this DiagramManager diagramManager, LayoutType layoutType)
        {
            if (layoutType == LayoutType.None) return;

            var graph = MsaglGeometryGraphHelpers.CreateGeometryGraph(diagramManager);
            graph.UpdateBoundingBox();
            var layout = layoutType.GetLayoutCalculator();
            layout?.CalculateLayout(graph);
            var graphNodes = graph.Nodes.ToList();
            foreach (var graphNode in graphNodes)
            {
                var node = (NodeModel)graphNode.UserData;
                node.SetPosition(graphNode.BoundingBox.Left, graphNode.BoundingBox.Top);
                node.RefreshAll();
            }
        }

        private static ILayoutCalculator? GetLayoutCalculator(this LayoutType layoutType) =>
            layoutType switch
            {
                LayoutType.Sugiyama => new SugiyamaLayoutCalculator(),
                LayoutType.Ranking => new RankingLayoutCalculator(),
                LayoutType.MDS => new MDSLayoutCalculator(),
                LayoutType.DisconnectedGraph => new DisconnectedGraphsLayoutCalculator(),
                _ => null
            };

    }
}