using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPattern;

public class Article
{
    public string Content { get; set; }
    private IList<string> previousContents;

    public string Title { get; set; }
    private IList<string> previousTitles;
}
