
namespace bvm.Instructions
{
    public interface IInstruction
    {
        void Execute(VmState state);
        uint ToBinary();
        IInstruction Copy();
    }
}
