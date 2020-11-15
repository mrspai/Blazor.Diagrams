using Blazor.Diagrams.Core.Models;
using Microsoft.Msagl.Core.Geometry;
using Microsoft.Msagl.Core.Geometry.Curves;
using Microsoft.Msagl.Core.Layout;
using Microsoft.Msagl.Prototype.Phylo;

namespace Blazor.Diagrams.Core.Layout
{
    public static class MsaglGeometryGraphHelpers
    {
        //public static IEnumerable<PositionInfo<NodeModel>> GetGetNodesPositionInfo(GeometryGraph geometryGraph)
        //{
        //    return geometryGraph.Nodes.Select(node => new Poi PositionInfo<NodelModel>((NodeModel)node.UserData, Converter.MsaglPointToPointConvert(node.BoundingBox.LeftTop)));
        //}
        public static PhyloTree CreatePhyloTrees(DiagramManager graph)
        {
            PhyloTree phyloTree = new PhyloTree();
            foreach (var node in graph.Nodes)
            {
                AddNode(phyloTree, node);
            }
            foreach (var edge in graph.AllLinks)
            {
                AddPhyloTreeEdge(phyloTree, edge.SourcePort.Parent, edge.TargetPort.Parent, 1);
            }
            return phyloTree;
        }
        public static GeometryGraph CreateGeometryGraph(DiagramManager graph)
        {
            GeometryGraph geomGraph = new GeometryGraph();
            
            foreach (var node in graph.Nodes)
            {
                AddNode(geomGraph, node);
            }

            var i = 0;
            foreach (var edge in graph.AllLinks)
            {
                AddEdge(geomGraph, edge.SourcePort.Parent, edge.TargetPort.Parent, i);
                i++;
            }
            return geomGraph;
        }
        public static Node AddNode(GeometryGraph geometryGraph, NodeModel item)
        {
            Node msaglNode = geometryGraph.FindNodeByUserData(item);
            if (msaglNode == null)
            {
                msaglNode = new Node(CreateCurve(item), item);
                geometryGraph.Nodes.Add(msaglNode);
            }
            return msaglNode;
        }
        public static void AddEdge(GeometryGraph geometryGraph, NodeModel parentNodeSource, NodeModel childNodeSource, double weight)
        {
            geometryGraph.Edges.Add(new Edge(AddNode(geometryGraph, parentNodeSource), AddNode(geometryGraph, childNodeSource)) { Weight = (int)weight });
        }
        public static void AddPhyloTreeEdge(PhyloTree phyloTree, NodeModel parentNodeSource, NodeModel childNodeSource, double weight = 1)
        {
            phyloTree.Edges.Add(new PhyloEdge(AddNode(phyloTree, parentNodeSource), AddNode(phyloTree, childNodeSource)) { Weight = (int)weight });
        }
        public static ICurve CreateCurve(NodeModel item)
        {
            return CurveFactory.CreateRectangle(item.Size?.Width ?? 100, item.Size?.Height ?? 100, new Point());
        }
    }
}