#if !EXCLUDE_CODEGEN
#pragma warning disable 162
#pragma warning disable 219
#pragma warning disable 414
#pragma warning disable 649
#pragma warning disable 693
#pragma warning disable 1591
#pragma warning disable 1998
[assembly: global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.5.0.0")]
[assembly: global::Orleans.CodeGeneration.OrleansCodeGenerationTargetAttribute("MergeInterface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
namespace MergeInterface
{
    using global::Orleans.Async;
    using global::Orleans;
    using global::System.Reflection;

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.5.0.0"), global::System.SerializableAttribute, global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.GrainReferenceAttribute(typeof (global::MergeInterface.IMergeSort))]
    internal class OrleansCodeGenMergeSortReference : global::Orleans.Runtime.GrainReference, global::MergeInterface.IMergeSort
    {
        protected @OrleansCodeGenMergeSortReference(global::Orleans.Runtime.GrainReference @other): base (@other)
        {
        }

        protected @OrleansCodeGenMergeSortReference(global::System.Runtime.Serialization.SerializationInfo @info, global::System.Runtime.Serialization.StreamingContext @context): base (@info, @context)
        {
        }

        protected override global::System.Int32 InterfaceId
        {
            get
            {
                return 1581957899;
            }
        }

        protected override global::System.UInt16 InterfaceVersion
        {
            get
            {
                return 1;
            }
        }

        public override global::System.String InterfaceName
        {
            get
            {
                return "global::MergeInterface.IMergeSort";
            }
        }

        public override global::System.Boolean @IsCompatible(global::System.Int32 @interfaceId)
        {
            return @interfaceId == 1581957899;
        }

        protected override global::System.String @GetMethodName(global::System.Int32 @interfaceId, global::System.Int32 @methodId)
        {
            switch (@interfaceId)
            {
                case 1581957899:
                    switch (@methodId)
                    {
                        case 599340730:
                            return "PruebaOrleans";
                        case 384894475:
                            return "Merge";
                        default:
                            throw new global::System.NotImplementedException("interfaceId=" + 1581957899 + ",methodId=" + @methodId);
                    }

                default:
                    throw new global::System.NotImplementedException("interfaceId=" + @interfaceId);
            }
        }

        public global::System.Threading.Tasks.Task<global::System.String> @PruebaOrleans()
        {
            return base.@InvokeMethodAsync<global::System.String>(599340730, null);
        }

        public global::System.Threading.Tasks.Task<global::System.Collections.Generic.List<global::System.String>> @Merge(global::System.Collections.Generic.List<global::System.String> @array, global::System.Int32 @p, global::System.Int32 @q, global::System.Int32 @r)
        {
            return base.@InvokeMethodAsync<global::System.Collections.Generic.List<global::System.String>>(384894475, new global::System.Object[]{@array, @p, @q, @r});
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.5.0.0"), global::Orleans.CodeGeneration.MethodInvokerAttribute(typeof (global::MergeInterface.IMergeSort), 1581957899), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
    internal class OrleansCodeGenMergeSortMethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
    {
        public global::System.Threading.Tasks.Task<global::System.Object> @Invoke(global::Orleans.Runtime.IAddressable @grain, global::Orleans.CodeGeneration.InvokeMethodRequest @request)
        {
            global::System.Int32 interfaceId = @request.@InterfaceId;
            global::System.Int32 methodId = @request.@MethodId;
            global::System.Object[] arguments = @request.@Arguments;
            if (@grain == null)
                throw new global::System.ArgumentNullException("grain");
            switch (interfaceId)
            {
                case 1581957899:
                    switch (methodId)
                    {
                        case 599340730:
                            return ((global::MergeInterface.IMergeSort)@grain).@PruebaOrleans().@Box();
                        case 384894475:
                            return ((global::MergeInterface.IMergeSort)@grain).@Merge((global::System.Collections.Generic.List<global::System.String>)arguments[0], (global::System.Int32)arguments[1], (global::System.Int32)arguments[2], (global::System.Int32)arguments[3]).@Box();
                        default:
                            throw new global::System.NotImplementedException("interfaceId=" + 1581957899 + ",methodId=" + methodId);
                    }

                default:
                    throw new global::System.NotImplementedException("interfaceId=" + interfaceId);
            }
        }

        public global::System.Int32 InterfaceId
        {
            get
            {
                return 1581957899;
            }
        }

        public global::System.UInt16 InterfaceVersion
        {
            get
            {
                return 1;
            }
        }
    }
}
#pragma warning restore 162
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 649
#pragma warning restore 693
#pragma warning restore 1591
#pragma warning restore 1998
#endif
