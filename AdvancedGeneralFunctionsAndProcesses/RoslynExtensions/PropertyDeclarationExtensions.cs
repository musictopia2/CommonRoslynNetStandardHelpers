using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AnalyzersPracticeLibrary.Helpers;
public static class PropertyDeclarationExtensions
{
    extension(PropertyDeclarationSyntax node)
    {
        public string Name => node.Identifier.Text;
    }
}