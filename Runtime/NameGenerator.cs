using Random = System.Random;

namespace Pixygon.Dialogue {
    public class NameGenerator {
        private Random random = new Random();

        public string GenerateRandomName(NameGeneratorData data) {
            var firstName = data._firstNames[random.Next(data._firstNames.Count)];
            var lastName = data._lastNames[random.Next(data._lastNames.Count)];

            var middleName = "";
            var title = "";
            var nickname = "";

            if (random.NextDouble() < 0.5 && data._useMiddleName)
                middleName = data._middleNames[random.Next(data._middleNames.Count)];

            if (random.NextDouble() < 0.2 && data._useTitle)
                title = data._titles[random.Next(data._titles.Count)];

            if (random.NextDouble() < 0.3 && data._useNickname)
                nickname = $"\"{data._nicknames[random.Next(data._nicknames.Count)]}\"";

            return $"{title} {firstName} {middleName} {lastName} {nickname}".Replace("  ", " ").Trim();
        }
    }
}