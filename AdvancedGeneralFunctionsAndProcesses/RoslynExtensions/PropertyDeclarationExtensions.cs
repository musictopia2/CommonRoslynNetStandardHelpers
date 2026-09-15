using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CommonRoslynNetStandardHelpers.AdvancedGeneralFunctionsAndProcesses.RoslynExtensions;
public static class PropertyDeclarationExtensions
{
    extension(PropertyDeclarationSyntax node)
    {
        public string Name => node.Identifier.Text;
    }
}