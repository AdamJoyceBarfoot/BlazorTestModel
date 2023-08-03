namespace BlazorTestModel.Shared
{
    public class DirectorsLetterViewModel
    {
        private readonly List<DirectorsLetter> _directorsLetters = new();

        public DirectorsLetterViewModel()
        {
            const int postSampleCount = 3;
            const int emailSampleCount = 7;
            _directorsLetters.AddRange(GenerateSamples(postSampleCount, false));
            _directorsLetters.AddRange(GenerateSamples(emailSampleCount, true));
        }

        public List<DirectorsLetter> EmailLetters => _directorsLetters.Where(s => s.IsEmail).ToList();
        public List<DirectorsLetter> PostalLetters => _directorsLetters.Where(s => !s.IsEmail).ToList();

        private static List<DirectorsLetter> GenerateSamples(int count, bool isEmail)
        {
            var letters = new List<DirectorsLetter>();
            for (int i = 0; i < count; i++)
            {
                letters.Add(new DirectorsLetter
                {
                    Id = i,
                    Name = isEmail ? $"Email {i+1}" : $"Postal {i+1}",
                    IsEmail = isEmail,
                    Email = isEmail ? $"email@{i+1}.com" : string.Empty,
                    PostalAddress = isEmail ? string.Empty : $"{i+1} Nowhere Street"
                });
            }

            return letters;
        }
    }

    public class DirectorsLetter
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsEmail { get; set; }

        public string Email { get; set; }

        public string PostalAddress { get; set; }

        public bool Processed { get; set; }

        public bool HasError { get; set; }

        public string ErrorMessage { get; set; }
    }
}
