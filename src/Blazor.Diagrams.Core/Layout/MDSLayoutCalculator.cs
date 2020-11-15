using Microsoft.Msagl.Core.Layout;
using Microsoft.Msagl.Core.Routing;
using Microsoft.Msagl.Layout.MDS;
using Microsoft.Msagl.Miscellaneous;

namespace Blazor.Diagrams.Core.Layout
{
    public class MDSLayoutCalculator : ILayoutCalculator
    {
        public LayoutAlgorithmSettings LayoutAlgorithmSettings =>
            new MdsLayoutSettings()
            {
                EdgeRoutingSettings = {
                    EdgeRoutingMode = EdgeRoutingMode.StraightLine
                }
            };

        public void CalculateLayout(GeometryGraph geometryGraph)
        {
            LayoutHelpers.CalculateLayout(geometryGraph, LayoutAlgorithmSettings, null);
        }
    }
}