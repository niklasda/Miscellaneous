using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using NUnit.Framework;

namespace TypeBuilderTests2
{
    public interface ITypeBuilderTests2
    {
        void DrawBoard2(int[][] pos);
    }

    [TestFixture] public class BuildMatrixTest
    {
        [Test] public void CreateTypeFromIMatrix()
        {
            AppDomain myDomain = Thread.GetDomain();
            AssemblyName asmName = new AssemblyName("DynamicAssemblyName2");
            AssemblyBuilder myAsmBuilder = myDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder myModule = myAsmBuilder.DefineDynamicModule("DynamicModule2", "DynamicAsm2.dll");

            TypeBuilder myTypeBld = myModule.DefineType(
                "DynamicType2", TypeAttributes.Public, typeof(Object), new [] { typeof(ITypeBuilderTests2) });

            MethodBuilder myMthdBld = myTypeBld.DefineMethod(
                "DrawBoard2", MethodAttributes.Public | MethodAttributes.Virtual, typeof(void), new [] { typeof(int[][]) });

            ILGenerator ILout = myMthdBld.GetILGenerator();
            ILout.Emit(OpCodes.Pop);

            Type myType = myTypeBld.CreateType();
        }
    }
}
