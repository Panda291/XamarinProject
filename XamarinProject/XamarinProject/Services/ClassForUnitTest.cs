namespace XamarinProject.Services
{
    public class ClassForUnitTest
    {
        public int isBetween5and10(int input)
        {
            if (input < 5) return -1;
            if (input > 10) return 1;
            return 0;
        }
    }
}