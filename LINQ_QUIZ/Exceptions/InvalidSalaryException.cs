namespace LINQ_QUIZ.Exceptions
{
    [Serializable]
    internal class InvalidSalaryException : Exception
    {
        public InvalidSalaryException() { }

        public InvalidSalaryException(string message) : base(message) { }
    }
}
