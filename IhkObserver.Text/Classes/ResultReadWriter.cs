using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using IhkObserver.Observer.Classes;
using Newtonsoft.Json;

namespace IhkObserver.Text.Classes
{
    public class ResultReadWriter
    {
        public async Task<IEnumerable<SubjectMarks>> ReadAsync()
        {
            string contents = string.Empty;
            using (FileStream fs = new FileStream(Results, FileMode.OpenOrCreate))
            using (StreamReader reader = new StreamReader(fs))
            {
                contents = await reader.ReadToEndAsync();
            }

            if (string.IsNullOrWhiteSpace(contents))
            {
                return new List<SubjectMarks>();
            }
            return JsonConvert.DeserializeObject<List<SubjectMarks>>(contents);
        }

        public void Write(IEnumerable<SubjectMarks> marks)
        {
            File.WriteAllText(Results, JsonConvert.SerializeObject(marks));
        }

        private string Results => $@"{PathGetter.GetBasePath()}\Results.json";
    }
}
