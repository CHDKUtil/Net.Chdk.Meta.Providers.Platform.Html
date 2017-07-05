using Net.Chdk.Meta.Generators.Platform;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Net.Chdk.Meta.Providers.Platform.Html
{
    sealed class HtmlPlatformProvider : PlatformProvider
    {
        private static readonly Regex regex = new Regex("<tr><td class=r>(0x[0-9a-f]+)</td><td>= (.+)</td>$");

        public HtmlPlatformProvider(IPlatformGenerator platformGenerator)
            : base(platformGenerator)
        {
        }

        protected override IEnumerable<KeyValuePair<string, string>> DoGetPlatforms(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                string line;

                while ((line = reader.ReadLine()) != null && line != "<tr class=h><th>Value</th><th>CameraModelID</th></tr>")
                {
                }

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length > 0)
                    {
                        var match = regex.Match(line);
                        if (match.Success)
                        {
                            var modelId = match.Groups[1].Value;
                            var modelsStr = match.Groups[2].Value;
                            yield return new KeyValuePair<string, string>(modelId, modelsStr);
                        }
                    }
                }
            }
        }
    }
}
