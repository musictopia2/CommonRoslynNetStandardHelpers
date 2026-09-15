global using CommonRoslynNetStandardHelpers.AdvancedGeneralFunctionsAndProcesses.RoslynExtensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
namespace CommonRoslynNetStandardHelpers.AdvancedGeneralFunctionsAndProcesses.RoslynExtensions;
public static class ClassDeclarationExtensions
{
    extension(ClassDeclarationSyntax node)
    {
        public string Name => node.Identifier.Text;
        public int MethodCount => node.Members.OfType<MethodDeclarationSyntax>().Count();
        public int PropertyCount => node.Members.OfType<PropertyDeclarationSyntax>().Count();
        //well see what other things about this i will need in future.
    }
}