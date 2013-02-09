
namespace bvm
{
    public static class Extensions
    {
        public static T As<T>(this object obj)
        {
            return (T) obj;
        }
    }
}
