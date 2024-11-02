using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.Sqlite;
using System.Threading.Tasks;

namespace APP_CIH_CAHUL_BAC
{
    public class QuizScore
    {
        public int Id { get; set; }
        public string questionText { get; set; }
        public string imageName { get; set; }
        public List<string> Raspunsuri { get; set; }
        public string Corecte { get; set; }

        public QuizScore(int id, string questionText, string imgName, string r1, string r2, string r3, string c1)
        {
            this.Id = id;
            this.questionText = questionText;
            this.imageName = imgName;
            this.Raspunsuri = new List<string> { r1, r2, r3 };
            this.Corecte = c1;
        }
    }
}
