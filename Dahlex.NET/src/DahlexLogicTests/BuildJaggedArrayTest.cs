using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using NUnit.Framework;

namespace TypeBuilderTests1
{
    public interface ITypeBuilderTests1
    {
        void DrawBoard1(int[][] positions);
    }

    [TestFixture] public class BuildJaggedArrayTest
    {
        [Test] public void CreateTypeFromIJaggedArray()
        {
            AppDomain myDomain = Thread.GetDomain();
            AssemblyName asmName = new AssemblyName("DynamicAssemblyName1");
            AssemblyBuilder myAsmBuilder = myDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder myModule = myAsmBuilder.DefineDynamicModule("DynamicModule1", "DynamicAsm1.dll");

            TypeBuilder myTypeBld = myModule.DefineType(
                "DynamicType1", TypeAttributes.Public, typeof(Object), new [] { typeof(ITypeBuilderTests1) });

            MethodBuilder myMthdBld = myTypeBld.DefineMethod(
                "DrawBoard1", MethodAttributes.Public | MethodAttributes.Virtual, typeof(void), new [] { typeof(int[][]) });

            ILGenerator ILout = myMthdBld.GetILGenerator();
            ILout.Emit(OpCodes.Pop);

            Type myType = myTypeBld.CreateType();
        }
    }
}
