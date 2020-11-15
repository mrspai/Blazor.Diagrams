using System;
using Microsoft.Msagl.Core.Geometry.Curves;
using Microsoft.Msagl.Core.Layout;
using Microsoft.Msagl.Core.Routing;
using Microsoft.Msagl.Layout.Layered;

namespace Blazor.Diagrams.Core.Layout
{
    public class PhyloTreeLayoutCalculator : ILayoutCalculator
    {
        public LayoutAlgorithmSettings LayoutAlgorithmSettings =>
            new SugiyamaLayoutSettings()
            {
                Transformation = PlaneTransformation.Rotation(Math.PI),
                EdgeRoutingSettings = {
                    EdgeRoutingMode =  EdgeRoutingMode.StraightLine,
                }
            };

        public void CalculateLayout(GeometryGraph phyloTree)
        {
            Microsoft.Msagl.Miscellaneous.LayoutHelpers.CalculateLayout(phyloTree, LayoutAlgorithmSettings, null);
        }
    }
}